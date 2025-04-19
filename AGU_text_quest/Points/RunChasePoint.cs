using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class RunChasePoint : PointBase
	{
		public override string Content => $"До странного мужика рукой подать, кажется вот вот и можно будет дотянуться. Вокруг мелькают здания, улицы. Кажется все потеряло смысл.";

        public RunChasePoint()
        {
			Actions = new()
			{
				new FirstActionRunChasePoint(),
				new SecondActionRunChasePoint(),
				new ThirdActionRunChasePoint(),
				new FourthActionRunChasePoint(),
			};
		}
    }

	internal class FourthActionRunChasePoint : FourthAction
	{
		public override string ActionDescription => "Долбануть фронт киком.";

        public FourthActionRunChasePoint()
        {
			IsAvailable = true;
			NextPointID = 6;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} бьет фронт-кик. Мужик улетает в стратосферу. Мем кубарем катится в сторону. Переборщил, Мем слишком далеко укатился.");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			if (player.pullUpHorizontalBarPoint)
				IsVisible = true;
		}
	}

	internal class ThirdActionRunChasePoint : ThirdAction
	{
		public override string ActionDescription => "Схватить за ручку рюкзака.";

        public ThirdActionRunChasePoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} хватается за ручку рюкзака и со всей дури дергает на себя, в надежде опрокинуть мужика. Но лямки рвутся и ошарашенный {Player.Instance.Name} смотрит на тикающий в руке рюкзак. Вот блин, там бомба. {Player.Instance.Name} швыряет рюкзак в сторону, раздается оглушительных хлопок, крики людей. Не важно, нужно догнать мужика.";
        }

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class SecondActionRunChasePoint : SecondAction
	{
		public override string ActionDescription => "Напрыгнуть на странного мужика.";

		public SecondActionRunChasePoint()
		{
			IsAvailable = true;
			NextPointID = 6;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} напрыгивает на странного мужика. Мужик из последних сил откидывает Мема вперед. Под тяжестью {player.Name}а мужик распластался на асфальте. Мем слишком далеко, не дотянуться.");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class FirstActionRunChasePoint : FirstAction
	{
		public override string ActionDescription => "Схватить за капюшон.";

        public FirstActionRunChasePoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Капюшон с треском рвется, какая неудача...";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == SecondAction.ACTION_NUMBER || x.Number == ThirdAction.ACTION_NUMBER);

			if (actions is null) return;

			foreach (var action in actions)
				action.IsVisible = true;
		}
	}
}
