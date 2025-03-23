using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class CorridorSectionPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} оказывается в коридоре. В левой части коридора стоит Коп с Топором, в правой части толпа из 10 ментов.";

		public CorridorSectionPoint()
		{
			Actions = new()
			{
				new FirstActionCorridorSectionPoint(),
				new SecondActionCorridorSectionPoint(),
				new ThirdActionCorridorSectionPoint(),
			};
		}
	}

	internal class ThirdActionCorridorSectionPoint : ThirdAction
	{
		public override string ActionDescription => "Коп с топором, помоги.";

        public ThirdActionCorridorSectionPoint()
        {
			IsAvailable = true;
			NextPointID = 19;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"Коп с топором разбегается, проносится мимо {Player.Instance.Name}а, затем закручивается как юла выставив топор и раскидывает дюжину ментов освобождая путь. После такого приема у Копа закружилась голова и он прилег вздремнуть. {Player.Instance.Name} проходит по коридору мимо раскиданных тел ментов.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionCorridorSectionPoint : SecondAction
	{
		public override string ActionDescription => "Побежать на Копа с топором.";

        public SecondActionCorridorSectionPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} бежит на Копа с топором с криком: Аааааааа...\n" +
				$"Коп с топором выставляет ладонь, прося остановится. {Player.Instance.Name} останавливается.\n" +
				$"Коп с топором: Господин, выход в другой стороне.\n" +
				$"{Player.Instance.Name}: Ох я совсем запутался, благодарю.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int>() { ThirdAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionCorridorSectionPoint : FirstAction
	{
		public override string ActionDescription => "Побежать на толпу ментов.";

		public FirstActionCorridorSectionPoint()
		{
			IsAvailable = true;
			NextPointID = 19;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus -= 2;

			Console.WriteLine($"{Player.Instance.Name} бежит на толпу ментов с криком: АААааааааа. Менты достают пистолеты и открывают огонь, но уже слишком поздно, {Player.Instance.Name} слишком близко. Словно бульдозер, {Player.Instance.Name} сносит толпу ментов, бездыханные тела отбрасывает на стены. {Player.Instance.Name} продолжает бежать вперед.\n");

			if (!player.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Я смотрю, ты даже не стараешься свести жертвы к минимуму.\n" +
				$"{Player.Instance.Name}: Кто бы говорил, ты же взорвал Арасака-Тауер.\n" +
				$"СильверГрэг: На то были веские причины...\n");
		}
	}
}
