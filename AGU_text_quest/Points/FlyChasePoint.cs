using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class FlyChasePoint : PointBase
	{
		public override string Content => $"{Player.Name} бежит к Мему и в последнюю минуту Мема подхватывает птеродактиль. Динозавр взмывает в небо и несется над зданиями. {Player.Name} выкладывается на полную и старается оббегая здания не упустить птеродактиля.";

        public FlyChasePoint()
        {
			Actions = new()
			{
				new FirstActionFlyChasePoint(),
				new SecondActionFlyChasePoint(),
				new ThirdActionFlyChasePoint(),
				new FourthActionFlyChasePoint(),
			};
		}
    }

	internal class FourthActionFlyChasePoint : FourthAction
	{
		public override string ActionDescription => "Долбануть Апперкотом.";

        public FourthActionFlyChasePoint()
        {
            IsAvailable = true;
			NextPointID = 7;
			DoAfterAction = DoAfterActionLocal;
		}

        public override void SetVisibleBeforeAction(Player player)
		{
			if (player.PullUpHorizontalBarPoint)
				IsVisible = true;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} останавливается, принимает боксерскую стойку, прикидывает траекторию полета динозавра. Все вокруг перестает существовать, только {player.Name}, птеродактиль и Мем. Толок носками, удар должен идти от ног. Икры настолько сильны, что {player.Name} взмывает в в воздух. В полете он отводит кулак вниз и напрягает спину. В удар нужно вложить всю массу тела. И вот он, удар в челюсть. Голова птеродактиля взмывает к звездам, Мем падает вниз, {player.Name} пытается дотянуться но траектории падения расходятся, {player.Name} рухнет в 20 метрах от Mема.");
		}
	}

	internal class ThirdActionFlyChasePoint : ThirdAction
	{
		public override string ActionDescription => "Выстрелить из ПЗРК.";

        public ThirdActionFlyChasePoint()
        {
            IsAvailable = true;
			NextPointID = 7;
			DoAfterAction = DoAfterActionLocal;

		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"\"Ух, хорошо, что я прихватил с собой ПЗРК.\" - подумал {player.Name} и навел прицел комплекса на птеродактиля. Характерный звуковой сигнал, цель захвачена. \"Лишь бы Мем сгруппировался.\" - с этими словами {player.Name} нажал на спусковой крючок. Ракета с хлопком и шипением вылетела из ствола. Ракета медленно поднялась вверх, вышла на ударную траекторию и выпустила языки пламени из сопла. Через мгновение ошметки птеродактиля разбросало нп стены зданий. Мем камнем падает вниз.");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class SecondActionFlyChasePoint : SecondAction
	{
		public override string ActionDescription => "Прыгнуть еще раз.";

		public SecondActionFlyChasePoint()
		{
			IsAvailable = false;
			MassageAfterAction = "Прыжок вышел точно таким же, эх, не повезло. Может в другой раз?";
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class FirstActionFlyChasePoint : FirstAction
	{
		public override string ActionDescription => "Прыгнуть вверх.";

        public FirstActionFlyChasePoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} прыгает вверх.";
			DoAfterAction = DoAfterActionLocal;

		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == SecondAction.ACTION_NUMBER || x.Number == ThirdAction.ACTION_NUMBER);

			if (actions is null) return;

			foreach (var action in actions)
				action.IsVisible = true;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (player.PullUpHorizontalBarPoint)
			{
				Console.WriteLine($"{player.Name} перелетает через птеродактиля и еще несколько минут летит в воздухе. Затем {player.Name} совершает супергеройское приземление. Асфальт трескается под его ногами. \"Уф, слишком хорошо разогрелся.\"");
			}
			else
			{
				Console.WriteLine($"И вот блин, {player.Name} подпрыгнул всего на 1 метр, а птеродактиль на высоте в 100 метров. Эх блин, а ведб такая хорошая затея была.");
			}
		}
	}
}
