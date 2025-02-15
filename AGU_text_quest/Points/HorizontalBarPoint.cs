using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class HorizontalBarPoint : PointBase
	{
		public override string Content => $"Тренировка шла как надо. {Player.Name} так увлекся, что потерял счет времени. Надо бы проверить как там Мем, подумал {Player.Name}. Внезапно драма, Мема нет на площадке. {Player.Name} стремительно обводит окрестность глазами. И вот оно, странный мужчина в черной толстовке. Под мышкой у него Мем размахивает ногами. Мужчина убегает к выходу их парка.";

        public HorizontalBarPoint()
        {
			Actions = new()
			{
				new FirstActionHorizontalBarPoint(),
				new SecondActionHorizontalBarPoint(),
				new ThirdActionHorizontalBarPoint(),
			};
		}
    }

	internal class ThirdActionHorizontalBarPoint : ThirdAction
	{
		public override string ActionDescription => "И еще подходик.";

        public ThirdActionHorizontalBarPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Еще 100 подтягиваний. Ух хорошо идет.";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.CounterPullUpHorizontalBarPoint++;

			if (player.CounterPullUpHorizontalBarPoint > 2)
			{
				player.PullUpHorizontalBarPoint = true;
				Console.WriteLine("Ух хорошо разогрелся прям...");
			}
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			if (player.CounterPullUpHorizontalBarPoint > 3)
				IsVisible = false;
		}
	}

	internal class SecondActionHorizontalBarPoint : SecondAction
	{
		public override string ActionDescription => "Сначала надо сделать подходик на турничке.";

        public SecondActionHorizontalBarPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} подтягивается 100 раз. Ух хорошо идет.";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.CounterPullUpHorizontalBarPoint++;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == ThirdAction.ACTION_NUMBER);

			if (actions is null)
				return;

			foreach (var action in actions)
				action.IsVisible = true;
		}
	}

	internal class FirstActionHorizontalBarPoint : FirstAction
	{
		public override string ActionDescription => "Бежать за мужиком";

        public FirstActionHorizontalBarPoint()
        {
			IsAvailable = true;
			NextPointID = 5;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (player.PullUpHorizontalBarPoint)
			{
				Console.WriteLine($"{player.Name} совершает стримительный рывок и уже через секунду настигает странного мужика.");
			}
			else
			{
				Console.WriteLine($"Погоня длиться долгие минуты. {player.Name} почти выдохся, но все же ему удается догнать странного мужика");
			}
		}
	}
}
