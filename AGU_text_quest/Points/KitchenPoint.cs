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
		public override string Content => $"{_player.Name} заходит на кухню. Все выглядит точно так же как и в последний раз, когда он здесь был.";

        public KitchenPoint() : base()
        {
			DoAfterPoint = KitchenPointAction;
			Actions = new()
			{
				new FirstActionForKitchenPoint(),
				new SecondActionForKitchenPoint(),
			};
		}

		protected void KitchenPointAction()
		{
			_player.endGame = true;
			Console.WriteLine($"В холодильнике осталась только недопитая газировка. Но {_player.Name} Точно помнит, что холодильник был забит до отказа!! Здесь явно был Dre и все съел!! {_player.Name} кричит: Нееет! И дает слово мстить Dre до конца своих дней. \nКОНЕЦ!!!");
		}

	}

	public class FirstActionForKitchenPoint : ActionBase
	{
		private const int ACTION_NUMBER = 1;
		public override int Number => ACTION_NUMBER;
		public override string ActionDescription => "Посмотреть в окно";

		public FirstActionForKitchenPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"За окном ночь, мало что можно разобрать во тьме";
		}
	}

	public class SecondActionForKitchenPoint : ActionBase
	{
		private const int ACTION_NUMBER = 2;
		public override int Number => ACTION_NUMBER;
		public override string ActionDescription => "Надо подкрепится";

		public SecondActionForKitchenPoint()
		{
			IsAvailable = true;
			MassageAfterAction = $"За окном ночь, мало что можно разобрать во тьме";
		}
	}
}
