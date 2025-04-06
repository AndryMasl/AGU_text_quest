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
				new FifthActionHousePoint(),
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
			if (Player.Instance.houseAction.Contains(FirstAction.ACTION_NUMBER)
				&& Player.Instance.houseAction.Contains(SecondAction.ACTION_NUMBER)
				&& Player.Instance.houseAction.Contains(ThirdAction.ACTION_NUMBER))
			{
				Actions.First(x => x.Number == FifthAction.ACTION_NUMBER).IsVisible = true;
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

	internal class FifthActionHousePoint : FifthAction
	{
		public override string ActionDescription => "Попробовать отгадать слово.";

        public FifthActionHousePoint()
        {
            IsAvailable = true;
			NextPointID = 30;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			bool flag = false;
			int counter = 0;

			player.letters.Sort();
			Console.WriteLine($"{Player.Instance.Name} вывалил собранные крышки на стол. На собранных крышках присутствуют буквы: {string.Join(", ", player.letters).ToLower()}. Какое же слово образуют эти буквы?");

			while (counter < 3 && !flag)
			{
				var word = Console.ReadLine();
				counter++;

				if (word.ToLower() == "aboba")
				{
					flag = true;
				}
				else
				{
					Console.WriteLine("Это не то слово, нужно думать дальше.");
				}
			}

			if(flag)
			{
				Console.WriteLine($"{player.Name}: Aboba...\nПосле этих слов воздух стал холодным, при дыхании из рта шел пар. Мгла заволокла дом, стало тяжело ориентироваться в пространстве, дальше вытянутой руки ничего не видно. {player.Name} побрел к входной двери. Огромная металлическая дверь, такие обычно ставили в бункеры, именно такой была входная дверь у {player.Name}а. Раздались оглушительные удары, в двери появились вмятины. Через 10 секунд дверь с визгом обрушилась, в дверном проеме стоял Ам.\n{player.Name}: Чтоб тебя, Ам, мог просто позвонить в звонок.\nАм: Aboba... Поехали.\nОба сели в тюнингованный SAAB Ама, через несколько минут были на месте.\nАм: Я обнаружил подозрительную активность в этом месте, думаю твой сын там.\n{player.Name}: Спасибо, Ам.\n{player.Name} Вышел из тачки и побрел к зловещему зданию.\n");

				Player.Instance.Am = true;
			}
			else
			{
				Console.WriteLine($"{player.Name}: Это невозможно!!!\n{player.Name} смахивает крышки со стола и они разлетаются по комнате. {player.Name} берется за голову и думает, что же делать дальше. Звонит телефон, неизвестный номер.\n{player.Name}: Ало.\nЛиза: Ало, привет {player.Name}, я провела свое независимое расследование, твой сын находится по адресу: ул. Немчинова, 8, Москва.\n{player.Name}: Спасибо, век помнить буду, ты лучшая!!!\n{player.Name} пулей вылетает из дома и мчится по указанному адресу.\n");
			}
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
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
			NextPointID = 20;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name}, осторожно и недоверчиво открыл зеленую коробку. Она пуста. \"Не может быть!\" - подумал {player.Name}. И правда, на дне оказалась маленькая лакированная визитка: Трил Декстор-Пил, место встречи: Посмертие. Что ж, посмотрим на это ваше Посмертие, подумал {player.Name} и сунул визитку в карман.\n");

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
