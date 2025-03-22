using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint5 : PointBase
	{
		public override string Content => "Либовски: Пожалуй один из важнейших вопросов. Ваша бабушка приглашает вас на чай. К вашему удивлению, она даёт вам пистолет и приказывает убить другого жителя Убежища. Ваши действия?";

		public InterrogationPoint5()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint5(),
				new SecondActionInterrogationPoint5(),
				new ThirdActionInterrogationPoint5(),
				new FourthActionInterrogationPoint2(),
				new FifthActionInterrogationPoint5(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Fallout 3 фигня, надо играть в Атомик, пфффффф (пускает дым)\n");
		}
	}

	internal class FifthActionInterrogationPoint5 : FifthAction
	{
		public override string ActionDescription => "Да я и что?";

		public FifthActionInterrogationPoint5()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus++;

			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Бедная бабушка, скажу Вокако, чтоб с тобой не работала.\n");
		}
	}

	internal class ThirdActionInterrogationPoint5 : ThirdAction
	{
		public override string ActionDescription => "Выплеснуть чай бабушке в лицо.";

		public ThirdActionInterrogationPoint5()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Бедная бабушка, скажу Вокако, чтоб с тобой не работала.\n");
		}
	}

	internal class SecondActionInterrogationPoint5 : SecondAction
	{
		public override string ActionDescription => "Попросить у бабушки миниган. А то ещё промажете ненароком.";

		public SecondActionInterrogationPoint5()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;

			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Правильно корпы в одиночку не ходят.\n" +
				$"{Player.Instance.Name}: С чего ты взял, что речь про корпа?\n" +
				$"СильверГрэг: А зачем бабушке убивать не корпа?\n");
		}
	}

	internal class FirstActionInterrogationPoint5 : FirstAction
	{
		public override string ActionDescription => "Убить этого жителя из пистолета — старших надо слушаться.";

		public FirstActionInterrogationPoint5()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;

			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Если бабушка хочет убить корпа, я бы тоже так поступил.\n" +
				$"{Player.Instance.Name}: Корпа ты бы и без просьбы бабушки завалил.\n" +
				$"СильверГрэг: Твоя правдв.\n");
		}
	}
}
