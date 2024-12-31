using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

				//if (noShowMessage)
				//	noShowMessage = DoConsoleCommand();

				if (!noShowMessage)
					Console.WriteLine($"Действие невозможно, попробуйте еще раз.");
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
