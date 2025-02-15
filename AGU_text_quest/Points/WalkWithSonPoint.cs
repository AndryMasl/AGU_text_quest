using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	public class WalkWithSonPoint : PointBase
	{
		public override string Content => $"В субботу {Player.Name} и Мем беззаботно гуляли в парке. Они нашли замечательную площадку всего в 100 м от турника. Пока Мем игрался на площадке {Player.Name} мог покачаться. \n{Player.Name}: \"Мем, пойдешь со мной в лесенку?\"\nМем: \"Не, Па, я пойду кадрить девочек у песочницы\"";

        public WalkWithSonPoint()
        {
			Actions = new()
			{
				new FirstActionWalkWithSonPoint(),
				new SecondActionWalkWithSonPoint(),
				new ThirdActionWalkWithSonPoint(),
			};

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal()
		{
			Console.WriteLine($"{Player.Name} подходит к турнику. Ему предстоит легкая тренировочка. Всего 5 по 5 подтягивания, 5 по 5 брусья, 5 по 5 отжимания, 3 по по 10 пресс. Ничего нового.");
		}
	}

	internal class ThirdActionWalkWithSonPoint : ThirdAction
	{
		public override string ActionDescription => "Красава сын.";
        public ThirdActionWalkWithSonPoint()
        {
			IsAvailable = true;
			NextPointID = 4;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} ухмыльнулся. По его ухмылке стало сразу ясно, что и он в детстве так делал.");
		}
	}

	internal class SecondActionWalkWithSonPoint : SecondAction
	{
		public override string ActionDescription => "Ну и дурачек.";

        public SecondActionWalkWithSonPoint()
        {
			IsAvailable = true;
			NextPointID = 4;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} покачал головой. \"Эх, бездарь растет. Нет бы на турнике качаться, а ему все за юбками бегать.\"");
		}
	}

	internal class FirstActionWalkWithSonPoint : FirstAction
	{
		public override string ActionDescription => "Уйти молча.";

        public FirstActionWalkWithSonPoint()
        {
			IsAvailable = true;
			NextPointID = 4;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} молча уходит. Ему явно безразлично мнение мелкого. Он в предвкушении знатной тренировки.");
		}
	}
}
