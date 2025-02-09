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
				// new SecondActionForHouseWithSonPoint(),
				new ThirdActionForHouseWithSonPoint(),
				new FourthActionForHouseWithSonPoint(),
			};
        }
    }

	

	internal class FirstActionForHouseWithSonPoint : FirstAction
	{
		public override string ActionDescription => "Посмотреть телик вместе с сыном";

		public FirstActionForHouseWithSonPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"По телевизору идет прямая трансляция соревнований по тяжелой атлетике. Эди Холл выполняет становую с весом 502 кг. В процессе выполнения у него из носа льются струи крови.";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var actions = point?.Actions?.Where(x => x.Number == 3 || x.Number == 4);

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
			var action = point?.Actions?.FirstOrDefault(x => x.Number == 4);

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
			MassageAfterAction = $"{Player.Instance.Name} с улыбкой на лице смотрит на триумф Эди. Эди с грохотом опускает штангу и падает на колени. К нему сбегаются медики, тренера. Один их медиков машет рукой, Эди жив. {Player.Instance.Name} представляет, что и его сын однажды станет гиго качком.";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			base.IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var action = point?.Actions?.FirstOrDefault(x => x.Number == 3);

			if (action is null) return;

			action.IsVisible = false;
		}
	}
}
