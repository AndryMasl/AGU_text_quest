using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint : PointBase
	{
		public override string Content => $"Дверь за спиной захлопнулась и закрылась на 10 замков. В комнате нет мебели, кроме стола и стула посередине. Это явно комната для допроса. Помимо {Player.Name} в комнате были еще двоя, Майор Либовски и Капитан Никитин. Кто из них хороший, а кто плохой полицейский еще предстояло узнать. Либовски жестом пригласил {Player.Name} присесть за стол.";

		public InterrogationPoint()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint(),
				//new SecondActionInterrogationPoint(),
				//new ThirdActionInterrogationPoint(),
				//new FourthActionInterrogationPoint(),
				//new FifthActionInterrogationPoint(),
			};
		}
	}

	internal class FirstActionInterrogationPoint : FirstAction
	{
		public override string ActionDescription => "Сесть за стол.";
	}
}
