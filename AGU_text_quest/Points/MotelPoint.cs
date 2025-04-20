using MainLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class MotelPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} зашел в номер мотеля. Трил Декстор-Пил ходил по номеру из угла в угол, он явно нервничал.\nТрил Декстор-Пил: Как можно было так облажаться? О вашем проёбе говорят все новостные каналы...\n{Player.Instance.Name}: Эм, позволь уточнить, и где же я по твоему проебался?\nТрил Декстор-Пил: Нафиг было убивать Ёринобу?";

		public MotelPoint()
		{
			Actions = new()
			{
				new FirstActionMotelPoint(),
				new SecondActionMotelPoint(),
				new ThirdActionMotelPoint(),
				new FourthActionMotelPoint(),
				new FifthActionMotelPoint(),
				new SixthActionMotelPoint(),
				new SeventhActionMotelPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.tacos > 1)
			{
				SetVisibleByList(new List<int> { SecondAction.ACTION_NUMBER }, true);
			}
		}
	}

	internal class SeventhActionMotelPoint : SeventhAction
	{
		public override string ActionDescription => "Выкинуть чип.";

        public SeventhActionMotelPoint()
        {
            IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"Неизвестно, что за технология на этом чипе, безопаснее всего будет от него избавится. {Player.Instance.Name} кидает чип прочь.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SixthActionMotelPoint : SixthAction
	{
		public override string ActionDescription => "Вставить чип себе в голову.";

        public SixthActionMotelPoint()
        {
            IsAvailable = true;
			NextPointID = 28;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.SilverGreg = true;
			Console.WriteLine($"{Player.Instance.Name} не думая о последствиях вставляет неизвестный чип себе в нейро-порт. И ничего не происходит, однако чип засел намертво, без помощи рипера фиг вытащишь. Ну и хрен с ним, - подумал {Player.Instance.Name}\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class FifthActionMotelPoint : FifthAction
	{
		public override string ActionDescription => "Для начала похудей, жирная свинья.";

        public FifthActionMotelPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Трил Декстор-Пил тяжело дышит и хрюкает от злобы.";

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			if (player.fatTril < 3)
			{
				Console.WriteLine($"Но он делает вид, что ничего не услышал.\n");
				return;
			}

			Console.WriteLine($"У Трилла от злости начинает идти пена из рат, у него закатываются глаза, он падает, его трясет. Вскоре Трил Декстор-Пил вытягивает ноги и испускает последний дух, Трил умер. {Player.Instance.Name} разводит руками, ничего не поделаешь, он был слишком толстый, этого следовало ожидать.\n{Player.Instance.Name} садится на кортаны и достает из кармана био-чип.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			if (player.fatTril < 3)
				return;

			SetOtherActionVisible(point, new List<int> { SixthAction.ACTION_NUMBER, SeventhAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FourthAction.ACTION_NUMBER, ThirdAction.ACTION_NUMBER });
		}
	}

	internal class FourthActionMotelPoint : FourthAction
	{
		public override string ActionDescription => "Отдать чип.";

        public FourthActionMotelPoint()
        {
            IsAvailable = true;
			NextPointID = 8;
			MassageAfterAction = $"{Player.Instance.Name} отдает Трилу чип, в обмен Трил даёт {Player.Instance.Name}у две крышки. На одной выцарапана буква 'A', на второй 'B'. {Player.Instance.Name} разворачивается и идет к выходу. Трил Декстор-Пил поднимает пистолет и направляет в затылок {Player.Instance.Name}а, но {Player.Instance.Name} замечает, что у него развязался шнурок и накланяется. Выстрел, пуля рассекает воздух, там где только что была голова. {Player.Instance.Name} не поднимаясь, бьет пяткой в лицо Трилу. Жир полностью гасит удар и начинает пульсировать. Вскоре весь Трил начинает пульсировать словно состоит из одного жира. Жир начинает резонировать сам с собой все сильнее и сильнее. Вскоре вибрация жира достигает ультразвуковой частоты и Трил Декстор-Пил взрывается. {Player.Instance.Name} с трудом избегает встречи с взрывной волной, быстро убегая прочь.\n";
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.letters.Add("a");
			player.letters.Add("b");

			Console.WriteLine(MassageAfterAction);
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class ThirdActionMotelPoint : ThirdAction
	{
		public override string ActionDescription => "Не отдавать чип.";

        public ThirdActionMotelPoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: А знаешь что? Хрен тебе, а не чип.\nТрил Декстор-Пил: Тогда я тебя съем...\nТрил раскрывает рот максимально широко и кидается на {Player.Instance.Name}а. Для сверх жиробаса он слишком быстр. {Player.Instance.Name} успевает отпрыгнуть в сторону и вылетает в окно. Все произошло так внезапно, что у {Player.Instance.Name}а не было времени выбрать траекторию. С высоты 5го этажа {Player.Instance.Name} падает на крышу ДелиМерса. Крышу промяло, но удар получился мягкий. Следом из окна выпрыгивает Трил Декстор-Пил. ДелиМерс газует и уезжает с траектории падения. Трила размазывает по асфальту. Трил мертв.\nДелиМерс мчит по городу, льется дождь. {Player.Instance.Name} поднимается на кортаны прям на крыше ДелиМерса, достает из кармана био-чип.\n";
        }

        public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { SixthAction.ACTION_NUMBER, SeventhAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FourthAction.ACTION_NUMBER, FifthAction.ACTION_NUMBER });
		}
	}

	internal class SecondActionMotelPoint : SecondAction
	{
		public override string ActionDescription => "Это ты убил Ёринобу своим просроченным тако, жиртрес!!";

        public SecondActionMotelPoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"Трил Декстор-Пил краснеет от злобы и его начинает трясти, но он делает вид, что не заметил слово: Жиртрес.\nТрил Декстор-Пил: Ты лжешь!! Эти божественный такос посоветовал мне Покашевари, я ем их каждый день. Согласно моему плану, Ёринобу должен был словить эйфорию от чистоты вкуса и в таком состоянии он бы и слона с своем номере не заметил бы.\n{Player.Instance.Name}: Он и не заметил. Вот только пахла его эйфорию не очень...\nТрил Декстор-Пил: Довольно оправданий, давай чип и разойдёмся на этом. Задание будем считать выполненным и я отдам тебе заветные буквы.\n";

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

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER, FifthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FirstAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionMotelPoint : FirstAction
	{
		public override string ActionDescription => "Это был несчастный случай.";

        public FirstActionMotelPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Трил Декстор-Пил: Люди просто так не умирают, знаешь ли... Ладно, неважно, что ты все засрал. Давай сюда чип и разбежимся. Задание будем считать выполненным и я отдам тебе заветные буквы.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER, FifthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { SecondAction.ACTION_NUMBER });
		}
	}
}
