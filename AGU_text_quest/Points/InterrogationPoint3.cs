using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint3 : PointBase
	{
		public override string Content => $"Либовски: Когда Вы в последний раз виделись со своим сыном?";

		public InterrogationPoint3()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint3(),
				new SecondActionInterrogationPoint3(),
				new ThirdActionInterrogationPoint3(),
				new FourthActionInterrogationPoint2(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Как бы меня это не бесило, но лучше им отвечать точно и без провокаций, а то ведь не отвяжутся.\n" +
				$"После этих слов СильверГрэг продолжает пускать фонтаны дыма и тихо напивает себе под нос: Как достать соседа, как достать соседа...\n");
		}
	}

	internal class ThirdActionInterrogationPoint3 : ThirdAction
	{
		public override string ActionDescription => "Сегодня утром, я отправил его покататься с незнакомцем в машине с номером Х228УЙ.";

		public ThirdActionInterrogationPoint3()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;

			if (!player.SilverGreg)
				return;

			Console.WriteLine("СильверГрэг усмехнулся.\n");
		}
	}

	internal class SecondActionInterrogationPoint3 : SecondAction
	{
		public override string ActionDescription => "Его похитили, и поэтому я здесь.";

		public SecondActionInterrogationPoint3()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;

			if (!player.SilverGreg)
				return;

			Console.WriteLine("СильверГрэг: Зря ты так, менты не любят работать.\n");
		}
	}

	internal class FirstActionInterrogationPoint3 : FirstAction
	{
		public override string ActionDescription => "4 часа назад, на площадке, мы гуляли...";

		public FirstActionInterrogationPoint3()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus++;
		}
	}
}
