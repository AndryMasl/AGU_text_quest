using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint2 : PointBase
	{
		public override string Content => $"{Player.Name} садится за стол, менты присаживаются с противоположной стороны стола.\n" +
			$"Либовски: В каких отношениях Вы со своим сыном? Часта ли случаются ссоры и разногласия?";

		public InterrogationPoint2()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint2(),
				new SecondActionInterrogationPoint2(),
				new ThirdActionInterrogationPoint2(),
				new FourthActionInterrogationPoint2(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг ложится на стол между {Player.Name}ом и ментами, ногу закинул на ногу, смотрит в потолок и пускает столбы сигаретного дыма.\n" +
				$"СильверГрэг: Напоминает дни моей бунтарской молодости.\n");
		}
	}

	internal class FourthActionInterrogationPoint2 : FourthAction
	{
		public override string ActionDescription => "Мне это надоело, пора бить морды.";

        public FourthActionInterrogationPoint2()
        {
			IsAvailable = true;
			NextPointID = 13;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus -= 2;
		}
	}

	internal class ThirdActionInterrogationPoint2 : ThirdAction
	{
		public override string ActionDescription => "Вы о чем? Все общение сводится к: Пойди принеси пива, мелкий...";

        public ThirdActionInterrogationPoint2()
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

			Console.WriteLine($"СильверГрэг: Хехехех, для этого и нужны дети.\n");
		}
	}

	internal class SecondActionInterrogationPoint2 : SecondAction
	{
		public override string ActionDescription => $"Я усыновил Мема 8 лет назад, он уже был достаточно взрослым ребенком, поэтому по началу было сложно, он не хотел признавать чужой авторитет. Но со временем он понял, что я желаю ему только добра.";

        public SecondActionInterrogationPoint2()
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

	internal class FirstActionInterrogationPoint2 : FirstAction
	{
		public override string ActionDescription => "Как и в любой другой нормальной семье.";

        public FirstActionInterrogationPoint2()
        {
			IsAvailable = true;
			NextPointID = 12;
		}
    }
}
