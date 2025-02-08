using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	public class KitchenPoint : PointBase
	{
		public override string Content => $"{Player.Name} заходит на кухню. Все выглядит точно так же как и в последний раз, когда он здесь был.";

        public KitchenPoint()
        {
			Actions = new()
			{
				new FirstActionForKitchenPoint(),
				new SecondActionForKitchenPoint(),
			};
		}
	}

	public class FirstActionForKitchenPoint : FirstAction
	{
		public override string ActionDescription => "Посмотреть в окно";

		public FirstActionForKitchenPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"За окном ночь, мало что можно разобрать во тьме";
		}
	}

	public class SecondActionForKitchenPoint : SecondAction
	{
		public override string ActionDescription => "Надо подкрепится";

		public SecondActionForKitchenPoint()
		{
			DoAfterAction = DoAfterActionLocal;
			IsAvailable = true;
		}

		protected void DoAfterActionLocal(Player player)
		{
			player.endGame = true;
			Console.WriteLine($"В холодильнике осталась только недопитая газировка. Но {player.Name} Точно помнит, что холодильник был забит до отказа!! Здесь явно был Dre и все съел!! {player.Name} кричит: Нееет! И дает слово мстить Dre до конца своих дней. \nКОНЕЦ!!!");
		}
	}
}
