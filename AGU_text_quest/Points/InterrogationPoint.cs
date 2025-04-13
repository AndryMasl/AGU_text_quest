using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationPoint : PointBase
	{
		public override string Content => $"Дверь за спиной захлопнулась и закрылась на 10 замков. В комнате нет мебели, кроме стола и стульев посередине. Помимо {Player.Name}а в комнате были еще двое, слева от стола - Майор Либовски, справа - Капитан Никитин. Кто из них хороший, а кто плохой полицейский еще предстояло узнать. Либовски жестом пригласил {Player.Name}а присесть за стол.";

		public InterrogationPoint()
		{
			Actions = new()
			{
				new FirstActionInterrogationPoint(),
				new SecondActionInterrogationPoint(),
				new ThirdActionInterrogationPoint(),
				new FourthActionInterrogationPoint(),
				new FifthActionInterrogationPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.SilverGreg)
				return;

			Console.WriteLine("Сквозь закрытую дверь, словно призрак, входит СильверГрэг. \"Так, так, ебаная комната для допросов. Ну ты попал, чумба. Глянь на того справа, выкрасил волосы в белый, и проколол себе всю морду, явно тащится от РаймШтайн. Ну и долбан, на него можешь не обращать внимание, важен тут левый, постарайся с ним поспокойнее.\"\n");
		}
	}

	internal class FifthActionInterrogationPoint : FifthAction
	{
		public override string ActionDescription => "УК РФ от 13.06.1996 N 63-ФЗ (ред. от 28.02.2025) Статья 128.1: Клевета, то есть распространение заведомо ложных сведений, порочащих честь и достоинство другого лица...";

        public FifthActionInterrogationPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Никитен: Ах ты урод, да я тебя прям ща в камеру упрячу до выяснения всех обстоятельств.\n" +
				$"Либовски: Алексей, успокойтесь, я уверен, пара вопросов и все встанет на свои места. {Player.Instance.Name}, присядьте, пожалуйста.";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus--;
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsAvailable = false;
		}
	}

	internal class FourthActionInterrogationPoint : FourthAction
	{
		public override string ActionDescription => "Кто на меня донес?";

        public FourthActionInterrogationPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Либовски: Ваша жена, госпожа Лэйла Саламова, она утверждает, что Вы похитили вашего общего ребенка мема.\n" +
				$"{Player.Instance.Name}: Ебануться, она мне не жена, я в принципе всю жизнь старался избегать эту шизанутую. И вообще, у меня нет жены, я холост, а сына я усыновил.\n" +
				$"Либовски: Что ж я проверю эти данные.\n" +
				$"Либовски что-то вбивает в свой планшет.\n" +
				$"Либовски: И правда, эта дама не имеет к вам никакого отношения, странно, кто пропустил это обвинение? В любом случае, я бы задал Вам пару вопросов, присаживайтесь.";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.interrogationStatus++;

			if (!player.SilverGreg)
				return;

			Console.WriteLine($"СлильверГрэг подходит в упор к Либовски и смотрит ему прямо в глаза, припустив свои черные очки. СлильверГрэг: А вот тут не горячись, дружок, дальше их гнобить, смысла нет, копы этого не любят. Давай сядем и послушаем.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsAvailable = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { FifthAction.ACTION_NUMBER });
		}
	}

	internal class ThirdActionInterrogationPoint : ThirdAction
	{
		public override string ActionDescription => "На каком основании?";

        public ThirdActionInterrogationPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Либовски: Подозрение в причастности к серийному похищению детей в возрасте от 5 да 15 лет.\n" +
				$"{Player.Instance.Name}: Очень громкое обвинение, у Вас должны быть веские основания.\n" +
				$"Никитин: Заткнись, это мы здесь задаем вопросы, сядь!";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsAvailable = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { FourthAction.ACTION_NUMBER });
		}
	}

	internal class SecondActionInterrogationPoint : SecondAction
	{
		public override string ActionDescription => "Вы меня допросить решили?";

        public SecondActionInterrogationPoint()
        {
			IsAvailable = false;
			MassageAfterAction = "Либовски: Всего несколько вопросов, будьте так любезны, присядьте.";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionInterrogationPoint : FirstAction
	{
		public override string ActionDescription => "Сесть за стол.";

        public FirstActionInterrogationPoint()
        {
            IsAvailable = true;
			NextPointID = 11;
        }
    }
}
