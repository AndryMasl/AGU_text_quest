using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static MainLogic.ModuleDim;

namespace MainLogic
{
	public class MainLogicClass
	{
		public void MainCycle()
		{
			var player = Player.Instance;
			
			while (!player.endGame)
			{
				var point = PointDictionary[player.pointID];
				ShowContent(point);

				GetAnswer(point, player);
				// point.DoAfterPoint?.Invoke(); // В этом действии нет смысла
			}
		}

		private void GetAnswer(PointBase point, Player player)
		{
			bool isAnswerGot = false;

			while (!isAnswerGot)
			{
				if (CheckPoint(point, player))
					return;

				var str = Console.ReadLine();

				var commandType = GetCommandType(str);

				var DoNotShowWarning = true;

				switch (commandType)
				{
					case CommandType.Action:
						{
							DoNotShowWarning = DoAction(str, point, player, ref isAnswerGot);
							break;
						}
					case CommandType.ConsoleCommandWithoutValue:
						{
							DoNotShowWarning = DoConsoleCommand(str, point, player, ref isAnswerGot);
							break;
						}
					case CommandType.ConsoleCommandWithValue:
						{
							DoNotShowWarning = DoConsoleCommandWithValue(str, point, player, ref isAnswerGot);
							break;
						}
					default:
						{
							DoNotShowWarning = false;
							break;
						}
				}

				if (!DoNotShowWarning)
					Console.WriteLine($"Действие невозможно, попробуйте еще раз.");
			}
		}

		private CommandType GetCommandType(string? str)
		{
			if (str is null)
				return CommandType.None;

			if (int.TryParse(str, out var actionNumber))
				return CommandType.Action;

			Regex regex = new Regex(@"\w+\s\d+");
			if (regex.IsMatch(str))
				return CommandType.ConsoleCommandWithValue;

			regex = new Regex(@"\w+");
			if (regex.IsMatch(str))
				return CommandType.ConsoleCommandWithoutValue;

			return CommandType.None;
		}

		enum CommandType
		{
			None = 0,
			Action = 1,
			ConsoleCommandWithoutValue = 2,
			ConsoleCommandWithValue = 3,
		}

		private bool DoConsoleCommandWithValue(string? str, PointBase point, Player player, ref bool isAnswerGot)
		{
			if (str is null)
				return false;

			Regex regex = new Regex(@"\w+\s\d+");

			if (!regex.IsMatch(str))
				return false;
			
			var strs = str.Split(' ');

			if (!int.TryParse(strs[1], out var number))
				return false;

			return DoConsoleCommand(strs[0], point, player, ref isAnswerGot, number);
		}

		private bool DoConsoleCommand(string? str, PointBase point, Player player, ref bool isAnswerGot, int value = 0)
		{
			if (str is null)
				return false;

			if (!ConsoleCommandDic.TryGetValue(str, out var consoleCommand))
				return false;

			consoleCommand.Invoke(point, player, value);
			isAnswerGot = true;
			return true;
		}

		private bool DoAction(string? str, PointBase point, Player player, ref bool isAnswerGot)
		{
			if (!int.TryParse(str, out var actionNumber))
				return false;
			
			var action = point?.Actions?
				.FirstOrDefault(x => x.Number == actionNumber && x.IsVisible == true);

			if (action is null)
				return false;

			isAnswerGot = action.IsAvailable;
			action.SetVisibleAfterAction(player);

			if (!isAnswerGot)
			{
				Console.WriteLine(action.MassageAfterAction);
				point?.ShowActions();
			}
			else
				player.pointID = action.NextPointID;

			action?.DoAfterAction?.Invoke(player);

			return true;
		}

		private bool CheckPoint(PointBase point, Player player)
		{
			if (point?.Actions?.Where(x => x.IsVisible == true).Count() == 0)
			{
				player.endGame = true;
				Console.WriteLine("Нет доступных действий.\nАварийное завершение.");
				return true;
			}

			return false;
		}

		private void ShowContent(PointBase point)
		{
			Console.WriteLine(point.Content + "\n");

			point.SetActions();
			point.ShowActions();
		}
	}
}
