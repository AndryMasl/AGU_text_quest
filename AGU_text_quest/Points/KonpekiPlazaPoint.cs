using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class KonpekiPlazaPoint : PointBase
	{
		public override string Content => $"ДелиМерс подвез прямо к главным дверям Компэки плаза. Охрана взглянула на фальшивые документы.\n" +
			$"Охранник: Документы фальшивые?\n" +
			$"{Player.Instance.Name}: Да.\n" +
			$"Охранник 2: Документы фальшивые.\n" +
			$"Охранник: Угу, проходите, хорошего дня.\n" +
			$"Цой и {Player.Instance.Name} подошли к ресепшену. Девушка за стойкой показалась Цою очень красивой и у него встал, да так сильно, что его начало корчить от боли. Все начали озираться, но {Player.Instance.Name} разрядил обстановку анекдотом про Пушкина и Лермонтова на балу.\n" +
			$"Цой: Красиво ты там все разрулил. Я пойду в номер, надо привести себя в порядок, а ты можешь погулять здесь если хочешь.";

		public KonpekiPlazaPoint()
		{
			Actions = new()
			{
				new FirstActionKonpekiPlazaPoint(),
				new SecondActionKonpekiPlazaPoint(),
			};
		}
	}

	internal class SecondActionKonpekiPlazaPoint : SecondAction
	{
		public override string ActionDescription => "Пойду прогуляюсь.";

		public SecondActionKonpekiPlazaPoint()
		{
			IsAvailable = true;
			NextPointID = 23;
		}
	}

	internal class FirstActionKonpekiPlazaPoint : FirstAction
	{
		public override string ActionDescription => "Я с тобой.";

        public FirstActionKonpekiPlazaPoint()
        {
            IsAvailable = true;
			NextPointID = 22;
			DoAfterAction = DoAfterActionLocal;

		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} и Цой вошли в лифт. Ехали долго и молча. Войдя в номер, Цой побежал менять штаны. {Player.Instance.Name} решил немного почиллить на диване.\n");
		}
	}
}
