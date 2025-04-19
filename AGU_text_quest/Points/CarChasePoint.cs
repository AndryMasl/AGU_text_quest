using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class CarChasePoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} побежал к Мему, но его опередила ментовская тачка. Дверь открылась и чья-то рука схватила Мема за шиворот и швырнула на заднее сидение. Когда {Player.Instance.Name} подбежал к багажнику, водитель вжал педаль в пол.";

		public CarChasePoint()
		{
			Actions = new()
			{
				new FirstActionCarChasePoint(),
				new SecondActionCarChasePoint(),
				new ThirdActionCarChasePoint(),
				new FourthActionCarChasePoint(),
				new FifthActionCarChasePoint(),
			};
		}


	}

	internal class FifthActionCarChasePoint : FifthAction
	{
		public override string ActionDescription => "Долбануть лоу-кик.";

        public FifthActionCarChasePoint()
        {
			IsAvailable = true;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.endGame = true;
			Console.WriteLine($"{player.Name} принимает стойку муай-тай и бьет лоу-кик. Машину разрывает на две половины. Скрежет и звон падающих останков кузова витает в воздухе. {player.Name} смотрит на Мема. Тот сидит на заднем сидении выпавшем из перекореженного автомобиля. Мем кивает: \"Я в порядке, Па.\" {player.Name} кивает в ответ и подходит к водителю. Томми Крахмальный-Шелби тяжело дыша: \"И что теперь?\". {player.Name} со словами: \"Передавай привет Джону Шеппарду\" - прописывает ему хук правой.\nМем и {player.Name} идут в горизонт. Мем: \"Па, почему ты такой крутой?\" {player.Name}: \"Потому что, сынок, потому что...\"\nКОНЕЦ!!!");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			if (player.pullUpHorizontalBarPoint)
				IsVisible = true;
		}
	}

	internal class FourthActionCarChasePoint : FourthAction
	{
		public override string ActionDescription => "Выстрелить из ПЗРК.";

		public FourthActionCarChasePoint()
		{
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} вытаскивает верный ПЗРК, наводит на автомобиль и нажимает на спусковой крючок. Щелчок и тишина. Нажимает еще раз. Щелчок... Патроны закончились. {Player.Instance.Name} оглядывается. Рядом нет ни одного: Friendly Fire, патрон купить негде. {Player.Instance.Name}: \"Фак.. ФАК... Ляяяяяяяя!!!\"");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class ThirdActionCarChasePoint : ThirdAction
	{
		public override string ActionDescription => $"Бежать за автомобилем.";

        public ThirdActionCarChasePoint()
        {
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} бежал за автомобилем несколько кварталов и в конце концов силы покинули его. Появилась отдышка, шаги замедлились, машина начала медленно скрываться из вида. {Player.Instance.Name} закричал: \"Нееееет!!!\", а про себя подумал: \"Надо было бегать по утрам\"");
		}

		public override void SetVisibleBeforeAction(Player player) => IsVisible = false;
	}

	internal class SecondActionCarChasePoint : SecondAction
	{
		public override string ActionDescription => "Запрыгнуть на машину.";

		public SecondActionCarChasePoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} запрыгивает в тот момент, когда машина стартует. Водитель это замечает и начинает сильно вилять. Машину кидает из стороны в сторону. {Player.Instance.Name} борется, стараясь не потерять равновесие, но его хватает только на 5 минут, после чего он падает на асфальт.";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var visibleActions = point?.Actions?.Where(x => x.Number == ThirdAction.ACTION_NUMBER || x.Number == FourthAction.ACTION_NUMBER);
			var nonVisibleActions = point?.Actions?.Where(x => x.Number == FirstAction.ACTION_NUMBER || x.Number == FifthAction.ACTION_NUMBER);

			if (visibleActions is null)
				return;

			foreach (var action in visibleActions)
				action.IsVisible = true;

			if (nonVisibleActions is null)
				return;

			foreach (var action in nonVisibleActions)
				action.IsVisible = false;
		}
	}

	internal class FirstActionCarChasePoint : FirstAction
	{
		public override string ActionDescription => "Схватить тачку за задний бампер.";

        public FirstActionCarChasePoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} тянет за бампер вверх и поднимает заднюю ось автомобиля. Задние колеса крутятся в холостую и машина не может сдвинуться с места. Растерянный водитель смотрит в стекло заднего вида, и ему кажется, будто тачку держит не {Player.Instance.Name}, а огромный Вер-Вульф. В панике водитель начинает судорожно бить по педали газа. В этот момент бампер не выдерживает и отрывается. Тачка с визгом и дымом стартует с места.";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			var visibleActions = point?.Actions?.Where(x => x.Number == ThirdAction.ACTION_NUMBER || x.Number == FourthAction.ACTION_NUMBER);
			var nonVisibleActions = point?.Actions?.Where(x => x.Number == SecondAction.ACTION_NUMBER || x.Number == FifthAction.ACTION_NUMBER);

			if (visibleActions is null)
				return;

			foreach (var action in visibleActions)
				action.IsVisible = true;

			if (nonVisibleActions is null)
				return;

			foreach (var action in nonVisibleActions)
				action.IsVisible = false;
		}
	}
}
