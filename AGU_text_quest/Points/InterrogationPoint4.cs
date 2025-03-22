using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint4 : PointBase
	{
		public override string Content => "Либовски: Часто вам снятся странные сны? Случаются ли провалы в памяти? Регулярные головокружения?";

		public InterrogationPoint4()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint4(),
				new SecondActionInterrogationPoint4(),
				new ThirdActionInterrogationPoint4(),
				new FourthActionInterrogationPoint2(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Во мне много препаратов, мама я не знаю где я... пфффффф\n");
		}
	}

	internal class ThirdActionInterrogationPoint4 : ThirdAction
	{
		public override string ActionDescription => "Да я и что?";

		public ThirdActionInterrogationPoint4()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus += 2;

			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Ебать ты крутой, чумба.\n");
		}
	}

	internal class SecondActionInterrogationPoint4 : SecondAction
	{
		public override string ActionDescription => "Я что по вашему похож на психа?";

		public SecondActionInterrogationPoint4()
		{
			IsAvailable = true;
			NextPointID = 12;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;
		}
	}

	internal class FirstActionInterrogationPoint4 : FirstAction
	{
		public override string ActionDescription => "Ни припомню ничего подобного";

		public FirstActionInterrogationPoint4()
		{
			IsAvailable = true;
			NextPointID = 12;
		}
	}


}
