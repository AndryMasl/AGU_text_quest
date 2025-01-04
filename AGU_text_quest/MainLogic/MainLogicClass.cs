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
				point.DoAfterPoint?.Invoke();
			}
		}

		private void GetAnswer(PointBase point, Player player)
		{
			bool isAnswerGot = false;

			while (!isAnswerGot)
			{
				isAnswerGot = CheckPoint(point, player);

				var str = Console.ReadLine();

				var noShowMessage = DoAction(str, point, player, ref isAnswerGot);

				if (!noShowMessage)
					noShowMessage = DoConsoleCommand(str, point, player, ref isAnswerGot);

				if (!noShowMessage)
					Console.WriteLine($"Действие невозможно, попробуйте еще раз.");
			}
		}

		private bool DoConsoleCommand(string? str, PointBase point, Player player, ref bool isAnswerGot)
		{
			if (str is null)
				return false;

			Regex regex = new Regex(@"\w+\s\d+");

			if (regex.IsMatch(str))
			{
				var strs = str.Split(' ');

				if (!int.TryParse(strs[1], out var number))
					return false;

				if (!ConsoleCommandDic.TryGetValue(strs[0], out var consoleCommand))
					return false;

				consoleCommand.Invoke(point, player, number);
				isAnswerGot = true;
				return true;
			}
			else
			{
				if (!ConsoleCommandDic.TryGetValue(str, out var consoleCommand))
					return false;

				consoleCommand.Invoke(point, player, 0);
				isAnswerGot = true;
				return true;
			}
		}

		private bool DoAction(string? str, PointBase point, Player player, ref bool isAnswerGot)
		{
			if (int.TryParse(str, out var actionNumber))
			{
				var action = point.Actions.FirstOrDefault(x => x.Number == actionNumber);

				if (action is null)
					return false;

				isAnswerGot = action.IsAvailable;
				action.SetVisibleAfterAction(player);

				if (!isAnswerGot)
				{
					Console.WriteLine(action.MassageAfterAction);
					point.ShowActions();
				}
				else
					player.pointID = action.NextPointID;

				return true;
			}

			return false;
		}

		private bool CheckPoint(PointBase point, Player player)
		{
			if (point.Actions.Where(x => x.IsVisible == true).Count() == 0)
			{
				player.endGame = true;
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
