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
				new FifthActionSmellyPantsPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal()
		{
			Console.WriteLine($"Такой ответ сильно озадачил Никитина, он сел, опустил голову и ушел в себя. В его голове явно проносятся потоки мыслей, он пытается все обдумать.\n");
		}

		private void DoBeforeActionLocal()
		{
			SetVisibleByList(Player.Instance.smellyPantsAnswer);

			if (Player.Instance.smellyPantsAnswer.Count == 0)
			{
				Actions?.ForEach(x => x.NextPointID = 14);
			}
			if (Player.Instance.smellyPantsAnswer.Count == 1)
			{
				Actions?.ForEach(x => x.NextPointID = 15);
			}
			if (Player.Instance.smellyPantsAnswer.Count == 2)
			{
				Actions?.ForEach(x => x.NextPointID = 16);
			}
			if (Player.Instance.smellyPantsAnswer.Count == 3)
			{
				Actions?.ForEach(x => x.NextPointID = 17);
			}

			if (!Player.Instance.SilverGreg)
				return;

			if (Player.Instance.smellyPantsAnswer.Count == 0)
			{
				Console.WriteLine($"СильверГрэг от удивления приподнялся и приспустил очки.\n" +
					$"СильверГрэг: В чем проблема этого парня?\n");
			}

			if (Player.Instance.smellyPantsAnswer.Count == 1)
			{
				Console.WriteLine($"СильверГрэг: У этого парня серьезные проблемы.\n");
			}

			if (Player.Instance.smellyPantsAnswer.Count == 2)
			{
				Console.WriteLine($"СильверГрэг: Я это уже слышал, он начинает мне надоедать.\n");
			}

			if (Player.Instance.smellyPantsAnswer.Count == 3)
			{
				Console.WriteLine($"СильверГрэг: Да выкинь ты уже эти трусы, задрал...\n");
			}
		}
	}

	internal class FifthActionSmellyPantsPoint : FifthAction
	{
		public override string ActionDescription => $"Леха, ты чего? Это же я {Player.Instance.Name}! Да, сильно ты изменился после свадьбы...";

        public FifthActionSmellyPantsPoint()
		{
			IsAvailable = true;
			NextPointID = 0;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name}, {Player.Instance.Name}... Хм...\n");
			player.smellyPantsAnswer.Add(Number);
		}
	}

	internal class FourthActionSmellyPantsPoint : FourthAction
	{
		public override string ActionDescription => "Есть человек, зовут Свят. Вот его визитка, позвони и скажи, что от Магера. Он поможет.";

        public FourthActionSmellyPantsPoint()
		{
			IsAvailable = true;
			NextPointID = 0;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine("Никитин берет визитку и крепко сжимает в руках.\n");
			player.smellyPantsAnswer.Add(Number);
		}
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
		public override string ActionDescription => "А ты их снимать пробовал? Не обязательно дрочить в трусы.";

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
		public override string ActionDescription => "Потому что так поётся в легендарной песне!";

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
