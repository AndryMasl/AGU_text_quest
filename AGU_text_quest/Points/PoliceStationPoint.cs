using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class PoliceStationPoint : PointBase
	{
		public override string Content => $"{Player.Name} заходит в ментовский участок. Все вокруг выглядит так, будто последний ремонт проводили еще во  времена СССР. За столом преграждающем путь сидит хмурая тетка в форме. Она не обращает внимание на подошедшего {Player.Name}а.";

        public PoliceStationPoint()
        {
			Actions = new()
			{
				new FirstActionPoliceStationPoint(),
				new SecondActionPoliceStationPoint(),
				new ThirdActionPoliceStationPoint(),
				new FourthActionPoliceStationPoint(),
				new FifthActionPoliceStationPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"На стол запрыгивает СильверГрэг и садится на кортаны перед дамой: \"Вот он, пример человека, сломанного системой: ей ничего не нужно от жизни, лишь бы поскорее закончить смену, сидит и раскладывает пасьянс, убивая свое время. А нафига мы сюда пришли?\"\n" +
				$"{Player.Name}: \"Они могут помочь.\"\n" +
				$"СильверГрэг: \"Кто? Эти пргнувшиеся под корпаратами шавки? Помяни мое слово, к добру это не приведет. Пошли лучше Покашевари посмотрим.\"\n" +
				$"{Player.Name}: \"Я остаюсь.\"\n" +
				$"После этих слов СильверГрэг исчез.");
			Console.WriteLine();
		}
	}

	internal class FifthActionPoliceStationPoint : FifthAction
	{
		public override string ActionDescription => "Пойду ка я лучше домой.";

		public FifthActionPoliceStationPoint()
		{
			IsAvailable = true;
			NextPointID = 10;
			DoAfterAction = DoAfterActionLocal;
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} понимает, что здесь что-то не так и разворачивается, чтобы уйти. Но за его спиной пристроились два здоровых амбала в ментовской форе.");

			if (player.SilverGreg)
				Console.WriteLine($"За спинами амбалов материализуется СильверГрэг: \"Ну вот ты и попал, обязательно было быть таким упертым? А теперь ты овечка ведомая гончей. Эх...\"");

			Console.WriteLine($"{player.Name} решил приберечь силы на будущее и не стал сопротивляться, просто последовал за амбалами, они завели его в кабинет номер 9 и удалились.");
		}
	}

	internal class FourthActionPoliceStationPoint : FourthAction
	{
		public override string ActionDescription => "Отправиться в кабинет 9.";

        public FourthActionPoliceStationPoint()
        {
			IsAvailable = true;
			NextPointID = 10;
			DoAfterAction = DoAfterActionLocal;
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{player.Name} отправляется на поиски кабинета. Задача оказывается не сложной. Огромную металлическую дверь с нарисованной мелом 9ой сложно не заметить. {player.Name} решительно заходит внутрь.");
		}
	}

	internal class ThirdActionPoliceStationPoint : ThirdAction
	{
		public override string ActionDescription => $"Меня зовут: {Player.Instance.Name}";

		public ThirdActionPoliceStationPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Дама со словами: \"9 кабинет\", возвращается к прежнему занятию - раскладыванию пасьянса на доисторическом ПК.";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { FourthAction.ACTION_NUMBER, FifthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int>() { FirstAction.ACTION_NUMBER, SecondAction.ACTION_NUMBER });
		}
	}

	internal class SecondActionPoliceStationPoint : SecondAction
	{
		public override string ActionDescription => "Моего сына похитили, я запомнил номер автомобиля.";

		public SecondActionPoliceStationPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Дама вздыхает и мерзким, словно скрип доски, голосом произносит: \"Имя.\"";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { ThirdAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionPoliceStationPoint : FirstAction
	{
		public override string ActionDescription => "Добрый день, хочу сообщить о преступлении.";

        public FirstActionPoliceStationPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Дама нехотя и с пренебрежением переводит взгляд на {Player.Instance.Name} и выдавливает из себя: \"Назови имя.\"";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { ThirdAction.ACTION_NUMBER });
		}
	}
}
