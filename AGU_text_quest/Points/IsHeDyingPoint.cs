using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class IsHeDyingPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} окончательно ослаб, силы покидают его тело. Могучий {Player.Instance.Name} ложится на землю и смотрит в облака. ";

        public IsHeDyingPoint()
        {
			Actions = new()
			{
				new FirstActionIsHeDyingPoint(),
				new SecondActionIsHeDyingPoint(),
				new ThirdActionIsHeDyingPoint(),
				new FourthActionIsHeDyingPoint(),
				new FifthActionIsHeDyingPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.SilverGreg)
			{
				Console.WriteLine($"Ранения {Player.Instance.Name}а слишком серьезные, обычный смертный уже бы давно умер. Рядом с {Player.Instance.Name}ом на землю садиться СильверГрэг.\nСильверГрэг: Думаю, ты уже догадался, что я уничтожил вирус, он больше не наносит твоему организму урон. Но боюсь этого недостаточно, твои ранения слишком серьезные и с этим я ничего не могу сделать.\n{Player.Instance.Name}: Не переживай, СильверГрэг, я знал на что иду и чем рискую.\n");
			}
			else
			{
				Console.WriteLine($"Вирус разрушает последние живые клетки организма. Остались считанные минуты. ");
			}

			Console.WriteLine($"Над лежащим {Player.Instance.Name}ом склоняется Мем, он опустился на колени, лицо полно печали.\n{Player.Instance.Name}: Послушай, Мем, мне нужно сказать тебе кое что важное. Возможно это будут последние мои слова.\n");
		}
	}

	internal class FifthActionIsHeDyingPoint : FifthAction
	{
		public override string ActionDescription => "Не грусти.";

        public FifthActionIsHeDyingPoint()
        {
			IsAvailable = true;

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Player.Instance.endGame = true;

			Console.WriteLine($"{Player.Instance.Name}: Не грусти, у тебя все будет хорошо.\nПосле этих слов {Player.Instance.Name} закрывает глаза и показалось, что он наконец все понял, но что именно...\n");

			Console.WriteLine($"Вот и настал день когда {Player.Instance.Name} умер. Небеса разверзлись и сам господь спустился, чтобы встретить его душу. Господь сказал: Нееее, так не пойдет, {Player.Instance.Name}. Мы же с тобой договорились!!! Я там, а ты здесь!!!...\nКонец?\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class FourthActionIsHeDyingPoint : FourthAction
	{
		public override string ActionDescription => "Девчонки это заебись.";

        public FourthActionIsHeDyingPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: Женский ГГ в играх это офигенно. ГГ Цири лучшее решение CD Projekt Red. Благодаря этому решению игра будет в 10 раз круче Ведьмака 3. У Tomb raider офигенная задница, там 10000 полигонов. И вообще и о реальных девчонках не забывай. Если счастлива девушка, то счастлив и ты.\nМем: Я так и знал, суперрр.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { FifthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { ThirdAction.ACTION_NUMBER });
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class ThirdActionIsHeDyingPoint : ThirdAction
	{
		public override string ActionDescription => "Тачки это заебись.";

        public ThirdActionIsHeDyingPoint()
        {
            IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: Хорошая тачка, это твое второе Я. Всегда заботься о своей тачке и помни: чем больше сил и средств ты вложишь в тачку, тем больше она тебе вернет. Это прямая зависимость. Вкладываясь в тачку, ты вкладываешься в будущее. Она тебя не подведет, всегда вытащит.\nМем: Я понял, моя тачка будет самой быстрой и самой подготовленной к неожиданностям.\n";
        }

        public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { FifthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FourthAction.ACTION_NUMBER });
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionIsHeDyingPoint : SecondAction
	{
		public override string ActionDescription => "Чиль всю жизнь.";

        public SecondActionIsHeDyingPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: Кайфую всю свою жизнь, нет ничего важнее чилла. Смотри офигенные кинчины, кидай снюсик, балдей от каждой минуты. Не делай то, что не подарит тебе уймы положительных эмоций. Жизнь слишком коротка, нужно жить здесь и сейчас.\nМем: Обещаю, я сделаю каждую минуту своей жизни такой же счастливой как у тебя.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FirstAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionIsHeDyingPoint : FirstAction
	{
		public override string ActionDescription => "Качайся всю жизнь.";

        public FirstActionIsHeDyingPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name}: Качайся всю свою жизнь, нет ничего важнее бицухи. Турничок, выход силы, передний вис... Ты должен полностью управлять своим телом, владеть всеми его возможностями.\nМем: Обещаю, я стану таким же качком как и ты.\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { SecondAction.ACTION_NUMBER });
		}
	}
}
