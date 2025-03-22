using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class SmellyPantsPoint : PointBase
	{
		public override string Content => $"Никитин резко вскакивает со своего стула и бьет кулаками по столу. Стол вздрагивает.\n" +
			$"Никитин: Ах ты ублюдок!!! Ответь мне лучше вот на что: Почему мои трусы воняют после дрочки???\n" +
			$"Никитен злыми не моргающими глазами сверлит {Player.Instance.Name}а.";

		public SmellyPantsPoint()
		{
			Actions = new()
			{
				new FirstActionSmellyPantsPoint(),
				new SecondActionSmellyPantsPoint(),
				new ThirdActionSmellyPantsPoint(),
				new FourthActionSmellyPantsPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal()
		{
			Console.WriteLine($"Такой ответ сильно озадачил Никитина, он сел, опустил голову и ушел в себя. В его голове явно проносятся потоки мыслей, он пытается все обдумать.");
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			SetVisibleLocal();

			if (Player.Instance.smellyPantsAnswer.Count == 0)
			{
				Console.WriteLine($"СильверГрэг от удивления приподнялся и приспустил очки.\n" +
					$"СильверГрэг: В чем проблема этого парня?\n");

				Actions?.ForEach(x => x.NextPointID = 14);
			}

			if (Player.Instance.smellyPantsAnswer.Count == 1)
			{
				Console.WriteLine($"СильверГрэг: У этого парня серьезные проблемы.\n");
				Actions?.ForEach(x => x.NextPointID = 15);
			}

			if (Player.Instance.smellyPantsAnswer.Count == 2)
			{
				Console.WriteLine($"СильверГрэг: Я это уже слышал, он начинает мне надоедать.\n");
				Actions?.ForEach(x => x.NextPointID = 16);
			}

			if (Player.Instance.smellyPantsAnswer.Count == 3)
			{
				Console.WriteLine($"СильверГрэг: Да выкинь ты уже эти трусы, задрал...\n");
				Actions?.ForEach(x => x.NextPointID = 17);
			}
		}

		private void SetVisibleLocal()
		{
			foreach (var action in Actions)
			{
				if (Player.Instance.smellyPantsAnswer.Contains(action.Number))
				{
					action.IsVisible = false;
				}
			}
		}
	}

	internal class FourthActionSmellyPantsPoint : FourthAction
	{
		public override string ActionDescription => "Есть человек, зовут Свят. Вот его визитка, позвони и скажи, что от Магепа";
	}

	internal class ThirdActionSmellyPantsPoint : ThirdAction
	{
		public override string ActionDescription => "Есть такая штука, называется стиральная машина.";
		public ThirdActionSmellyPantsPoint()
		{
			IsAvailable = true;
			NextPointID = 0;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.smellyPantsAnswer.Add(Number);
		}
	}

	internal class SecondActionSmellyPantsPoint : SecondAction
	{
		public override string ActionDescription => "А ты их снимать пробовал?";

		public SecondActionSmellyPantsPoint()
		{
			IsAvailable = true;
			NextPointID = 0;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.smellyPantsAnswer.Add(Number);
		}
	}

	internal class FirstActionSmellyPantsPoint : FirstAction
	{
		public override string ActionDescription => "Потому что так поется в легендарной песне!";

        public FirstActionSmellyPantsPoint()
		{
			IsAvailable = true;
			NextPointID = 0;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.smellyPantsAnswer.Add(Number);
		}
	}
}
