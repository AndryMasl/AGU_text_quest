using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class WomanWithExplosivesPoint : PointBase
	{
		public override string Content => $"Дорогу {Player.Instance.Name}у преграждает та самая тетка, которая отправила его в кабинет 9, в обоих руках у нее по противопехотной гранате. Она выдергивает каждую чеку и с воплем бежит на {Player.Instance.Name}а. {Player.Instance.Name} опешил и остановился, он в замешательстве.";

		public WomanWithExplosivesPoint()
		{
			Actions = new()
			{
				new FirstActionWomanWithExplosivesPoint(),
				new SecondActionWomanWithExplosivesPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг продолжает бежать навстречу женщине.\n" +
				$"СильверГрэг: Чего встал? Бежим!!\n");
		}
	}

	internal class SecondActionWomanWithExplosivesPoint : SecondAction
	{
		public override string ActionDescription => "Убегать от Тетки.";

		public SecondActionWomanWithExplosivesPoint()
		{
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus -= 2;

			Console.WriteLine($"{Player.Instance.Name} разворачивается и бежит прочь от Тетки. {Player.Instance.Name} слишком быстр, тетке не удается его догнать и она взрывается за его спиной. Коридор обваливается, выход закрыт. {Player.Instance.Name}у приходится пробиваться на крышу, прокладывая себе путь сквозь все новых и новых ментов, которые лезут со всех щелей. В конечном итоге {Player.Instance.Name}у приходится прыгнуть с крыши. Он приземляется на такси, которая уносит его в горизонт.\n");
		}
	}

	internal class FirstActionWomanWithExplosivesPoint : FirstAction
	{
		public override string ActionDescription => "Бежать на встречу женщине.";

		public FirstActionWomanWithExplosivesPoint()
		{
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"Кажется, что {Player.Instance.Name} бежит к собственной гибели. Он все ближе и ближе к взрывоопасной тетке. В последний момент {Player.Instance.Name} делает подкат и сносит тетку с ног. Тетка летит назад, а {Player.Instance.Name} продолжает скользить вперед, за спиной раздается хлопок взрыва, но {Player.Instance.Name} уже вылетел через двери участка. Поднявшись на ноги {Player.Instance.Name} убегает прочь.\n");
		}
	}
}
