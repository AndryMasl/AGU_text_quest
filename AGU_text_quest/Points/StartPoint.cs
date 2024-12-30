using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	public class StartPoint : PointBase
	{
		public override string Content => $"{_player.Name} проснулся посреди ночи и приподнялся на постели. Оглянувшись он понял, что в квартире больше никого нет.";


		public StartPoint() : base()
		{
			Actions = new()
			{
				new FirstActionForStartPoint(),
				new SecondActionForStartPoint(),
				new ThirdActionForStartPoint(),
			};
		}
	}

	public class FirstActionForStartPoint : FirstAction
	{
		public override string ActionDescription => "Еще немного поспать";

		public FirstActionForStartPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} понял что не может уснуть";
		}
	}

	public class SecondActionForStartPoint : SecondAction
	{
		public override string ActionDescription => "Позвать Лизу";

		public SecondActionForStartPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Никто не ответил";
		}
	}

	public class ThirdActionForStartPoint : ThirdAction
	{
		public override string ActionDescription => "Пойти на кухню";

		public ThirdActionForStartPoint()
		{
			IsAvailable = true;
			NextPointID = 1;
		}
	}
}
