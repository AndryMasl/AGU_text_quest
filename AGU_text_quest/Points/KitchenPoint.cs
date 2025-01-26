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
			DoAfterPoint = KitchenPointAction;
			Actions = new()
			{
				new FirstActionForKitchenPoint(),
				new SecondActionForKitchenPoint(),
			};
		}

		protected void KitchenPointAction() // TODO_MAV: это не должно быть здесь. Тупиковый Point получается.
		{
			Player.endGame = true;
			Console.WriteLine($"В холодильнике осталась только недопитая газировка. Но {Player.Name} Точно помнит, что холодильник был забит до отказа!! Здесь явно был Dre и все съел!! {Player.Name} кричит: Нееет! И дает слово мстить Dre до конца своих дней. \nКОНЕЦ!!!");
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
			IsAvailable = true;
		}
	}
}
