using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class HomelessDrePoint : PointBase
	{
		public override string Content => $"Как же ты низко пал, - подумал {Player.Instance.Name}, - замызганная, вытертая до блеска куртка, неопрятная борода, рваные берцы...\nДре побренчал мелочью в стакане, который держал в руках. Дрэ протянул стакан {Player.Instance.Name}у со словами: Мелочи на galant 8 не найдется?";

        public HomelessDrePoint()
        {
			Actions = new()
			{
				new FirstActionHomelessDrePoint(),
				new SecondActionHomelessDrePoint(),
				new ThirdActionHomelessDrePoint(),
				new FourthActionHomelessDrePoint(),
				new FifthActionHomelessDrePoint(),
			};
		}
    }

	internal class FifthActionHomelessDrePoint : FifthAction
	{
		public override string ActionDescription => "Пнуть бомжа.";

        public FifthActionHomelessDrePoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} пинает Дре. Дре вскакивает и хлопает глазами, не понимая, что произошло.\nДре: Нихуя себе, ты меня уебал?\nУ Дре ступор, с ним больше нет смысла общаться.\n");
		}
	}

	internal class FourthActionHomelessDrePoint : FourthAction
	{
		public override string ActionDescription => "Не дам.";
        public FourthActionHomelessDrePoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} со словами: Дружба и деньги не имеют ничего общего, - разворачивается и уходит.\n");
		}
	}

	internal class ThirdActionHomelessDrePoint : ThirdAction
	{
		public override string ActionDescription => $"Держи монетку.";

        public ThirdActionHomelessDrePoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.dresMoney++;
			Console.WriteLine($"{Player.Instance.Name} кидает монетку в стакан. Дре весело трясет стаканом и слушает как бренчат монетки.\nДер: Да хранит тебя всевышний, братишка...\n");
		}
	}

	internal class SecondActionHomelessDrePoint : SecondAction
	{
		public override string ActionDescription => "Работа, работа, работа...";

        public SecondActionHomelessDrePoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} многократно повторяет слово: работа. Дре начинает ворчать, затем быстро отжимается, вскакивает и куда-то убегает.\n");
		}
	}

	internal class FirstActionHomelessDrePoint : FirstAction
	{
		public override string ActionDescription => "Найди нормальную работу.";

        public FirstActionHomelessDrePoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name}: Заебал, откликайся на вакансии и найди уже норм работу, чтоб получать 250к+, и не придется бомжевать. А еще телку найди, чтоб тебя стимулировала...\nДер что-то проворчал себе под нос и повернулся к {Player.Instance.Name}у спиной. По видимому разговор окончен.\n");
		}
	}
}
