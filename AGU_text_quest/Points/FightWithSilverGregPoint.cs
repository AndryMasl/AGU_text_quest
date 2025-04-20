using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class FightWithSilverGregPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} еще долго прогуливался по городу обдумывая произошедшее. До дома он решил доехать на автобусе.\n{Player.Instance.Name} сидел в автобусе и никого не трогал, как вдруг био-чип начал работать и рядом с {Player.Instance.Name}ом появился злобный СильверГрэг.\nСильверГрэг: Ты убил Триллыча...\n{Player.Instance.Name}: Он сам виноват, мои руки чисты.\nСильверГрэг не хочет слышать голос разума, он берет под контроль левую половину тела {Player.Instance.Name}а и начинается бой, словно в бойцовском клубе.";

		public FightWithSilverGregPoint()
		{
			Actions = new()
			{
				new FirstActionFightWithSilverGregPoint(),
				new SecondActionFightWithSilverGregPoint(),
				new ThirdActionFightWithSilverGregPoint(),
				new FourthActionFightWithSilverGregPoint(),
			};
		}
	}

	internal class FourthActionFightWithSilverGregPoint : FourthAction
	{
		public override string ActionDescription => "Остановить автобус.";

        public FourthActionFightWithSilverGregPoint()
        {
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"СильверГрэг ослаб. {Player.Instance.Name} вернул себе контроль и кинулся к водительскому сидению. Слишком поздно. Автобус на полном ходу влетает во встречную фуру.\nСпустя какое-то время {Player.Instance.Name} приходит в себя на груде металлолома, по видимому остатки автобуса. Рядом сидит курит СильверГрэг.\nСильверГрэг: Проснулся, самурай?\n{Player.Instance.Name}: Ты больше не хочешь меня убить?\nСильверГрэг: Я тут посидел, обдумал все, и пожалуй я погорячился. Наше сотрудничество может быть полезным нам обоим.\n{Player.Instance.Name}: СильверГрэг?\nСильверГрэг: Я-блоко.\n{Player.Instance.Name}: понял.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class ThirdActionFightWithSilverGregPoint : ThirdAction
	{
		public override string ActionDescription => "Съесть кусочек свинины (сейчас пост).";

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			player.fightWithSilverGregAction.Add(Number);

			if (player.fightWithSilverGregAction.Count < 3)
				return;

			SetOtherActionVisible(point, new List<int> { FourthAction.ACTION_NUMBER });
		}

        public ThirdActionFightWithSilverGregPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} съедает кусочек свинины, СильверГрэгу становится так плохо, что он теряет хватку. {Player.Instance.Name} хватает левое запястье чтобы не дать противнику наносить урон, но у противника еще есть левая нога.\nТем временем автобус все разгоняется и разгоняется, незаметно автобус выруливает на встречку.\n";
        }
	}

	internal class SecondActionFightWithSilverGregPoint : SecondAction
	{
		public override string ActionDescription => "Тупой Покашевари не шарит в еде.";

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			player.fightWithSilverGregAction.Add(Number);

			if (player.fightWithSilverGregAction.Count < 3)
				return;

			SetOtherActionVisible(point, new List<int> { FourthAction.ACTION_NUMBER });
		}

        public SecondActionFightWithSilverGregPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"СильверГрэг: Нет, он гений кулинарии.\nВ процессе борьбы {Player.Instance.Name}а кидает по всему салону автобуса. Пассажирские сидения не выдерживают и ломаются одно за другим. Офигевший водитель выпрыгивает из автобуса.\n";
        }
	}

	internal class FirstActionFightWithSilverGregPoint : FirstAction
	{
		public override string ActionDescription => "Трил был ультра жирный.";

        public FirstActionFightWithSilverGregPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"СильверГрэг: Нет у него была идеальная форма.\nГлаза СильверГрэга начинают слезится и он не замечает несколько быстрых ударов {Player.Instance.Name}а. Ауч, больно от этих ударов обоим.\nОфигевшие от происходящего пассажиры начинают на ходу выпрыгивать из автобуса. В основном они это делают через люк на крыше и форточки.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			player.fightWithSilverGregAction.Add(Number);

			if (player.fightWithSilverGregAction.Count < 3)
				return;

			SetOtherActionVisible(point, new List<int> { FourthAction.ACTION_NUMBER });
		}
	}
}
