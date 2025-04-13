using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class AfterlifePoint : PointBase
	{
		public override string Content => $"Приехав на место назначение, {Player.Instance.Name} спустился в какой-то подвал. Дорогу ему преградил амбал, однако увидев визитку отступил, освобождая дорогу, и указал путь. Проходя мимо барной стойки {Player.Instance.Name} обратил внимание на избыток наемников разных мастей. Ну и лохи, подумал {Player.Instance.Name}, каждого могу поломать одной левой.\n Местом встречи была звукоизолированная коробка посреди просторной комнаты, внутри на диване расплылся Мега Жирный Трил Дектор-Пил. {Player.Instance.Name} присел напротив.";

		public AfterlifePoint()
		{
			Actions = new()
			{
				new FirstActionAfterlifePoint(),
				new SecondActionAfterlifePoint(),
				new ThirdActionAfterlifePoint(),
				new FourthActionAfterlifePoint(),
				new FifthActionAfterlifePoint(),
				new SixthActionAfterlifePoint(),
				new SeventhActionAfterlifePoint(),
			};

		}
	}

	internal class SeventhActionAfterlifePoint : SeventhAction
	{
		public override string ActionDescription => "Мне этого достаточно, выдвигаемся.";

		public SeventhActionAfterlifePoint()
		{
			IsAvailable = true;
			NextPointID = 21;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} и Цой встают и эпично уходят на Мега вылазку века.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SixthActionAfterlifePoint : SixthAction
	{
		public override string ActionDescription => "Йоу, Цой, докажи этот чел пипец жирный.";

        public SixthActionAfterlifePoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"Цой: Да ваще пипец, свинота.\n" +
				$"Трил Декстор-Пил краснеет от злобы и непроизвольно похрюкивает, но пытается сделать вид, будто ничего не услышал.\n";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.fatTril++;
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class FifthActionAfterlifePoint : FifthAction
	{
		public override string ActionDescription => "Посмотреть на стол.";

        public FifthActionAfterlifePoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"На стеклянном столике {Player.Instance.Name} замечает просроченные тако.\n" +
				$"{Player.Instance.Name}: Это что за фигня? От них воняет...\n" +
				$"Трил Декстор-Пил: Это отвлекающий маневр, придет время, поймешь.\n";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.tacos++;
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class FourthActionAfterlifePoint : FourthAction
	{
		public override string ActionDescription => "Ты хочешь, чтобы я провернул это в одиночку?";

		public FourthActionAfterlifePoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Трил Декстор-Пил мнет губами жирную сигару напоминающую по форме хуй.\n" +
				$"Трил Декстор-Пил: Нет, позволь представить тебе...\n" +
				$"В комнату заходит Александр Цой и садится на диван рядом с {Player.Instance.Name}ом, Цой улыбается: Давно не виделись, {Player.Instance.Name}.\n" +
				$"{Player.Instance.Name}: Цой, братан, сколько лет, сколько зим, как же я рад тебя видеть.\n" +
				$"Цой: Хехе, Братка, и я тебя... Ну что, готов ворваться в Высшую лигу?\n" +
				$"{Player.Instance.Name}: С тобой хоть на край света!!!\n";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { SixthAction.ACTION_NUMBER, SeventhAction.ACTION_NUMBER });
		}
	}

	internal class ThirdActionAfterlifePoint : ThirdAction
	{
		public override string ActionDescription => "Мне нужны детали!!";

		public ThirdActionAfterlifePoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"До места и обратно тебя доставит лимузин ДелиМерс. В отель пройдешь без проблем по фальшивым документам. Все системы слежения Ёринобу отключил лично. Остается просто забрать контейнер с чипом и смыться. Если все пройдет гладко, а иначе и быть не может, то встретимся здесь. В противном случае ДелиМерс отвезет тебя в мотель, где буду ждать я.\n" +
				$"{Player.Instance.Name}: Как-то все слишком просто, не замечаешь?\n" +
				$"Трил Декстор-Пил: Конечно все просто, я же гений стратег.\n";
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionAfterlifePoint : SecondAction
	{
		public override string ActionDescription => "В чем суть дела?";

		public SecondActionAfterlifePoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Твоя задача проще некуда: нужно пробраться в Компэки плаза, подняться в люкс Ёринобу Арасака и выкрасть био-чип. Проще некуда.\n";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER, FifthAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionAfterlifePoint : FirstAction
	{
		public override string ActionDescription => "Ебать ты жирный!";

        public FirstActionAfterlifePoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Трил Декстор-Пил сделал вид, будто ничего не слышал.\n";
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.fatTril++;
		}
	}
}
