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
			bool IsAnswerGot = false;

			while (!IsAnswerGot)
			{
				IsAnswerGot = CheckPoint(point, player);

				var str = Console.ReadLine();

				if (int.TryParse(str, out var actionNumber))
				{
					var action = point.Actions.FirstOrDefault(x => x.Number == actionNumber);

					if (action is null)
					{
						Console.WriteLine($"Действие невозможно, попробуйте еще раз.");
						continue;
					}
						

					IsAnswerGot = action.IsAvailable;
					action.SetVisibleAfterAction(player);

					if (!IsAnswerGot)
					{
						Console.WriteLine(action.MassageAfterAction);
						point.ShowActions();
					}
					else
						player.pointID = action.NextPointID;
					
					continue;
				}
				
				Console.WriteLine($"Действие невозможно, попробуйте еще раз.");
			}
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
