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
		public override string Content => $"{Player.Name} возвращается домой.";

        public HousePoint()
        {
			Actions = new()
			{
				new FirstActionHousePoint(),
				new SecondActionHousePoint(),
				new ThirdActionHousePoint(),
				new FourthActionHousePoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			SetVisibleLocal();

			if (Player.Instance.houseAction.Count == 0)
			{
				Console.WriteLine($"{Player.Name} не в себе от горя. Он метается по дому, словно нет ему места где он сможет найти покой. Проходя в третий раз мимо стола в гостиной {Player.Name} замечает несколько коробок на столе. Отправитель: Мастер Оригами.\n");
			}
		}

		private void SetVisibleLocal()
		{
			foreach (var action in Actions)
			{
				if (Player.Instance.houseAction.Contains(action.Number))
				{
					action.IsVisible = false;
				}
			}
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
			Console.WriteLine($"{player.Name} запомнил номер ментовской тачки: Х228УЙ. Странно, номер не похож на ментовский. Однако ментам виднее. {player.Name} накидывает куртку и отправляется в ментовский участок.\n");

			player.houseAction.Add(Number);
		}
	}

	internal class ThirdActionHousePoint : ThirdAction
	{
		public override string ActionDescription => "Посмотреть содержимое Зеленой коробки.";

        public ThirdActionHousePoint()
        {
			IsAvailable = true;
			NextPointID = 25;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.houseAction.Add(Number);
		}
	}

	internal class SecondActionHousePoint : SecondAction
	{
		public override string ActionDescription => "Посмотреть содержимое Оранжевой коробки.";

		public SecondActionHousePoint()
		{
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.houseAction.Add(Number);
		}
	}

	internal class FirstActionHousePoint : FirstAction
	{
		public override string ActionDescription => "Посмотреть содержимое Красной коробки.";

        public FirstActionHousePoint()
        {
			DoAfterAction = DoAfterActionLocal;
		}

        private void DoAfterActionLocal(Player player)
		{
			player.houseAction.Add(Number);
		}
	}
}
