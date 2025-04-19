using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class HotelRoomPoint : PointBase
	{
		public override string Content => $"Цой подошел к {Player.Name}у, они посмотрели друг на друга и поняли, что пора начинать. Быстро поднялись на верхний этаж, без проблем вошли в номер Ёринобу. Стоял жёстки смрад, пахло говном, слышны звуки пердежа.";

        public HotelRoomPoint()
        {
			Actions = new()
			{
				new FirstActionHotelRoomPoint(),
				new SecondActionHotelRoomPoint(),
				new ThirdActionHotelRoomPoint(),
				new FourthActionHotelRoomPoint(),
			};
		}
    }

	internal class FourthActionHotelRoomPoint : FourthAction
	{
		public override string ActionDescription => "Залезть в серверную.";

        public FourthActionHotelRoomPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} залез в серверную, здесь пахло получше, можно перевести дыхание.\nЦой: Хватит придуриваться, вылась, надо стырить чип.\n{Player.Instance.Name} вылез из серверной.\n";
        }
    }

	internal class ThirdActionHotelRoomPoint : ThirdAction
	{
		public override string ActionDescription => "Забрать био-чип.";

        public ThirdActionHotelRoomPoint()
        {
            IsAvailable = true;
			NextPointID = 26;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"Био-чип нашли быстро, огромный чемодан с лампочками было сложно не заметить. {Player.Instance.Name} вытащил био-чип и сунул в карман. Вдруг, после резкого всхлипывания, пердеж прекратился, завыла серена. Цой с ноги выбил дверь туалета.\nЦой: Ёринобу сдох от несварения!!\n");
		}
	}

	internal class SecondActionHotelRoomPoint : SecondAction
	{
		public override string ActionDescription => "Взглянуть на стол.";

        public SecondActionHotelRoomPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"На столе лежат просроченные тако. Вот откуда отвратительный смрад, помимо запаха говна.\n";
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			if (player.tacos > 0)
			{
				Console.WriteLine($"Такое же тако было на столе в Посмертье, вот уж Трил Декстор-Пил, то же мне стратег, отравил Ёринобу.\n");
			}

			player.tacos++;
		}
	}

	internal class FirstActionHotelRoomPoint : FirstAction
	{
		public override string ActionDescription => "Заглянуть в туалет.";

        public FirstActionHotelRoomPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} дернул ручку туалета, заперто. Изнутри донесся голос Ёренобу, периодически прерываемый пердежом: Смешер, это ты? Позови уборщиков, я тут все обосрал...\n";
        }
    }
}
