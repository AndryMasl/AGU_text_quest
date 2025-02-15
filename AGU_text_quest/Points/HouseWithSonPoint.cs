using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	public class HouseWithSonPoint : PointBase
	{
		public override string Content => $"Кажется {Player.Name} задремал в конце рабочего дня. Оглянувшись {Player.Name} понял, что все как обычно. Сын: Мем младший, уже вернулся домой после школы и сидел залипал в телик. {Player.Name} подошел и сел рядом.";

        public HouseWithSonPoint()
        {
            Actions = new()
            {
				new FirstActionForHouseWithSonPoint(),
				new SecondActionForHouseWithSonPoint(),
				new ThirdActionForHouseWithSonPoint(),
				new FourthActionForHouseWithSonPoint(),
				new FifthActionForHouseWithSonPoint(),
				new SixthActionForHouseWithSonPoint(),
			};
        }
    }

	internal class FirstActionForHouseWithSonPoint : FirstAction
	{
		public override string ActionDescription => "Посмотреть телик вместе с сыном";

		public FirstActionForHouseWithSonPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"По телевизору идет прямая трансляция соревнований по тяжелой атлетике. Эдди Холл выполняет становую с весом 502 кг. В процессе выполнения у него из носа льются струи крови.";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == ThirdAction.ACTION_NUMBER || x.Number == FourthAction.ACTION_NUMBER);

			if (actions is null)
				return;

			foreach (var action in actions)
				action.IsVisible = true;
		}
	}

	internal class SecondActionForHouseWithSonPoint : SecondAction
	{
		public override string ActionDescription => "Спросить про домашку";

		public SecondActionForHouseWithSonPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: \"Вот ты смотришь телик, а домашку ты сделал?\" \nМем: \"Па, я потом сделаю, можно?\"";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == FifthAction.ACTION_NUMBER || x.Number == SixthAction.ACTION_NUMBER);

			if (actions is null)
				return;

			foreach (var action in actions)
				action.IsVisible = true;
		}
	}

	internal class ThirdActionForHouseWithSonPoint : ThirdAction
	{
		public override string ActionDescription => "Что за фигню ты смотришь...";

        public ThirdActionForHouseWithSonPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} забирает пульт и включает \"Папины Дочки\". Вот теперь нормально.";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			base.IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var action = point?.Actions?.FirstOrDefault(x => x.Number == FourthAction.ACTION_NUMBER);

			if (action is null) return;

			action.IsVisible = false;
		}
	}

	internal class FourthActionForHouseWithSonPoint : FourthAction
	{
		public override string ActionDescription => "Мой пиздюк";

		public FourthActionForHouseWithSonPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} с улыбкой на лице смотрит на триумф Эдди. Эдди с грохотом опускает штангу и падает на колени. К нему сбегаются медики, тренера. Один из медиков машет рукой, Эди жив. {Player.Instance.Name} представляет, что и его сын однажды станет гиго качком.";
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var action = point?.Actions?.FirstOrDefault(x => x.Number == ThirdAction.ACTION_NUMBER);

			if (action is null) return;

			action.IsVisible = false;
		}
	}

	internal class FifthActionForHouseWithSonPoint : FifthAction
	{
		public override string ActionDescription => "В пень домашку, можешь не делать.";

		public FifthActionForHouseWithSonPoint()
		{
			IsAvailable = true;
			NextPointID = 3;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name}: \"Посмотри на меня, я мего успешный миллионер. И знаешь что? Я никогда не делал домашку!! Просто забей и живи полной жизнью.\"\nМем: \"Па, ты лучший!! Ты же помнишь, что мы собирались погулять вместе в эту Сб?\"\n{Player.Instance.Name}: \"Конечно помню!!\"");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class SixthActionForHouseWithSonPoint : SixthAction
	{
		public override string ActionDescription => "Иди делай домашку!!";

		public SixthActionForHouseWithSonPoint()
		{
			IsAvailable = true;
			NextPointID = 3;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name}: \"И когда наступит это твое потом? Опять ночью спать не будешь? А потом вырубишься прям на уроке? Нет так не пойдет, марш делать домашку!!\"Мем: \"Ладно, ладно, я уже иду. Но ты же помнишь, что обещал погулять со мной в эту Сб?\"\n{Player.Instance.Name}: \"Конечно помню!!\"");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}
}
