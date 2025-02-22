using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class HousePoint : PointBase
	{
		public override string Content => $"{Player.Name} не в себе от горя. Он возвращается домой и метается по дому, словно нет ему места где он сможет найти покой. Проходя в третий раз мимо стола в гостиной {Player.Name} замечает несколько коробок на столе. Отправитель: Мастер Оригами.";

        public HousePoint()
        {
			Actions = new()
			{
				new FirstActionHousePoint(),
				new SecondActionHousePoint(),
				new ThirdActionHousePoint(),
				new FourthActionHousePoint(),
			};
		}
    }

	internal class FourthActionHousePoint : FourthAction
	{
		public override string ActionDescription => "Пойти к ментам.";

        public FourthActionHousePoint()
        {
			IsAvailable = true;
			NextPointID = 9;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} запомнил номер ментовской тачки: Х228УЙ. Странно, номер не похож на ментовский. Однако ментам виднее. {player.Name} накидывает куртку и отправляется в ментовский участок.");
		}
	}

	internal class ThirdActionHousePoint : ThirdAction
	{
		public override string ActionDescription => "Посмотреть содержимое Зеленой коробки.";
	}

	internal class SecondActionHousePoint : SecondAction
	{
		public override string ActionDescription => "Посмотреть содержимое Оранжевой коробки.";
	}

	internal class FirstActionHousePoint : FirstAction
	{
		public override string ActionDescription => "Посмотреть содержимое Красной коробки.";
	}
}
