using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class FightWithPolicePoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} опрокидывает стол вперед. Как только столешница превращается в стену между {Player.Instance.Name}ом и ментами, {Player.Instance.Name} бьет фронт-кик. Стол со свистом улетает вперед, впечатывая в стену Либовски. Никитин умудрился увернуться. На капитана обрушивается град ударов: Ора-Ора Ора-Ора Ора-Ора Ора-Ора Ора-Ора. У Никитина нет шансов, он падает без сознания. Не зря {Player.Instance.Name} приберег силы на потом. Однако дверь все ещё заперта, чо же делать?";

		public FightWithPolicePoint()
		{
			Actions = new()
			{
				new FirstActionFightWithPolicePoint(),
				new SecondActionFightWithPolicePoint(),
				new ThirdActionFightWithPolicePoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг, спрыгнувший со стала в самом начале разборок: Не будь я голограммой в твоей голове, я бы обиделся. Опрокидывать стол с лежащим на нем чумбой не хорошо.\n" +
				$"СильверГрэг подходит к окну: Глянь, эта решётка на соплях держится, может получится выбраться?\n");
		}
	}

	internal class ThirdActionFightWithPolicePoint : ThirdAction
	{
		public override string ActionDescription => "Пробить стену.";

		public ThirdActionFightWithPolicePoint()
		{
			IsAvailable = true;
			NextPointID = 18;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} постукивает по стене, она полая, это даже не стена, а покрашенная под стену фанера. Мдээ, подумал {Player.Instance.Name}, похоже весь бюджет ушел на дверь. {Player.Instance.Name} с легкостью проламывает стену и проходит сквозь нее.\n");
		}
	}

	internal class SecondActionFightWithPolicePoint : SecondAction
	{
		public override string ActionDescription => "Выбить дверь.";

        public SecondActionFightWithPolicePoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"На металлическую дверь обрушивается град ударов. Образуются огромные вмятины, но дверь слишком прочна, продолжить в таком духе, значит рискнуть повредить суставы рук. {Player.Instance.Name} оставляет эту затею.\n";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Хорошо бьешь, если я буду восстанавливать свою группу, позову тебя барабанщиком.\n" +
				$"{Player.Instance.Name}: Ага, а Покашевари будет на бас гитаре.\n" +
				$"СильверГрэг: Пау-Пау мани, так и сделаем...\n");
		}
	}

	internal class FirstActionFightWithPolicePoint : FirstAction
	{
		public override string ActionDescription => "Выбить оконную решётку.";

		public FirstActionFightWithPolicePoint()
		{
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} открывает окно и пробует тряхнуть решётку. Решётка держится довольно слабо. То что надо, подумал {Player.Instance.Name}. С разбега он выбивает решётку и вылетает на улицу. Грохот падения привлекает внимание, но {Player.Instance.Name} быстро вскакивает на ноги и скрывается в узких проулках.\n");
		}
	}
}
