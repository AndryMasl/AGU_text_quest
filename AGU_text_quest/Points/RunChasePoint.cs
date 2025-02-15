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
		public override string Content => $"До странного мужика рукой подать, кажется вот вот и можно будет дотянуться. Вокруг мелькают здания, улицы. кажется все потеряло смысл.";

        public RunChasePoint()
        {
			Actions = new()
			{
				new FirstActionRunChasePoint(),
				new SecondActionRunChasePoint(),
				new ThirdActionRunChasePoint(),
			};
		}
    }

	internal class ThirdActionRunChasePoint : ThirdAction
	{
		public override string ActionDescription => "Долбонуть фронт киком.";

        public ThirdActionRunChasePoint()
        {
			IsAvailable = true;
			NextPointID = 5;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			throw new NotImplementedException();
		}
	}

	internal class SecondActionRunChasePoint : SecondAction
	{
		public override string ActionDescription => "Напрыгнуть на странного мужика.";
	}

	internal class FirstActionRunChasePoint : FirstAction
	{
		public override string ActionDescription => "Схватить за капюшон.";

        public FirstActionRunChasePoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Капюшон с треском рвется, какая неудача...";
		}
    }
}
