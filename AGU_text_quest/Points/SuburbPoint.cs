using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class SuburbPoint : PointBase
	{
		public override string Content => $"Погоня закончилась. Dre остановился в пригороде на вершине утеса с которого видно весь город.";

        public SuburbPoint()
        {
			Actions = new()
			{
				new FirstActionSuburbPoint(),
				new SecondActionSuburbPoint(),
				new ThirdActionSuburbPoint(),
				new FourthActionSuburbPoint(),
				new FifthActionSuburbPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.InterrogationResult == 0)
			{
				Console.WriteLine($"Dre открыл капот и с головой ушел в изучение его содержимого.");
			}
			else
			{
				if (Player.Instance.dresMoney == 2)
				{
					Console.WriteLine($"Galant в плачевном состоянии, Dre даже не предпринимает попытки его реанимировать.");
				}
				if (Player.Instance.dresMoney > 2)
				{
					Console.WriteLine($"Да galant'у досталось. Но это Quadra galant, он способен пережить большее. Гораздо большее.");
				}

				Console.WriteLine($"Dre сидит на краю утеса, свесив ноги и о чем-то глубоко задумался.");
			}

			Console.WriteLine($"{Player.Name} вышел из тачки, осмотрелся, сел на траву.\n");

			ConfigureFourthAction(Player.Instance);
		}

		private void ConfigureFourthAction(Player player)
		{
			var fifthAction = Actions.First(x => x.Number == FifthAction.ACTION_NUMBER);

			if (!player.SilverGreg)
			{
				fifthAction.NextPointID = 34;
			}
		}
	}

	internal class FifthActionSuburbPoint : FifthAction
	{
		public override string ActionDescription => "Спасибо, Dre.";

		public FifthActionSuburbPoint()
		{
			IsAvailable = true;

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if(!player.SilverGreg)
			{
				Console.WriteLine($"Продолжать разговор дальше сил у {Player.Instance.Name}а не было, слишком велик урон от вируса. Dre замечает неладное и подходит к {Player.Instance.Name}у.\nDre: Я могу что-то для тебя сделать?\n{Player.Instance.Name}: Боюсь, что нет, мой друг.\n");
			}
			else
			{
				Console.WriteLine($"На крыше galant'а материализуется СильверГрэг: С вирусом покончено, еще поживешь...\nDre: Ебать, слезь с моей тачки!!!\nВсе в ахуе. {Player.Instance.Name} и СильверГрэг, от того, что Dre видит Грэга, хотя это невозможно. А Dre в свою очередь в ахуе с наглости Грэга.\n{Player.Instance.Name}: Ты его видишь?\nDre: Хрена на моей тачке? Конечно вижу, слезай!!\nСильверГрэг нехотя спрыгивает с тачки: Я же голограмма проецируемая на сознание {Player.Instance.Name}а, как ты меня видишь?\nDre: Я в своём познании настолько преисполнен... от слияния с бесконечно вечным...\nКонец.\n");

				player.endGame = true;
			}
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class FourthActionSuburbPoint : FourthAction
	{
		public override string ActionDescription => "Как в качалке дела?";

		public FourthActionSuburbPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Dre заметно приободрился.\nDre: А знаешь, заебись. Разминка 30 мин, подтягивания 5 по 5, потом становая 5 по 10, снова подтягивания, но уже с блином...\n{Player.Instance.Name}: Я вообще-то прост из вежливости спросил.\nDre: Я так и понял.\nОба тихо посмеялись\n";
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

	internal class ThirdActionSuburbPoint : ThirdAction
	{
		public override string ActionDescription => "Найди телку.";

		public ThirdActionSuburbPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Dre: Какую нафиг телку? Ты че издеваешься?\n{Player.Instance.Name}: Ну такую... С сиськами...\nDre: Ага и без мозгов...\n{Player.Instance.Name}: Ну это уже на твое усмотрение.\nDre: Нет, ну ты реально издеваешься...\n";
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

	internal class SecondActionSuburbPoint : SecondAction
	{
		public override string ActionDescription => "Как Galant?";

		public SecondActionSuburbPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Dre обводит взглядом galant.";

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (player.InterrogationResult == 0)
			{
				if (player.dresMoney == 1)
				{
					Console.WriteLine("Galant прогнил практически насквозь. Нет места не затронутого ржавчиной. Гнилые пороги, дыры в днище, стаканы подвески на грани пробития. Однако погоня на состояние автомобиля не повлияло.\nDre: Ничего, в умелых руках заживет новой жизнью.\n");
				}
				if (player.dresMoney == 2)
				{
					Console.WriteLine("Mitsubishi galant 8 выглядит как новенький, года его практически не затронули. Кажется, что он только вчера сошел с конвейера. Видны небольшие царапины и сколы из-за недавней погони.\nDre: Моя гордость, а сколы, не переживай, мелочь, уже через пару часов все залатаю.\n");
				}
				if (player.dresMoney > 2)
				{
					Console.WriteLine($"Quadra galant Turbo Type-8 это не просто машина, это мечта кочевника. Бронирована до нельзя. Укрепленная сталь вместо стекал. Амортизаторы подвески выступают выше капота. Спереди и сзади вмонтированы мощные пулеметы. И как раньше кочевники не додумались ставить пулеметы и сзади??? На крыше установлена многоствольная гаубица. Как такое вообще возможно? - подумал {Player.Instance.Name}.\nDre: ХА, этот заезд для моей тачки легкая прогулочка.\n");
				}
			}
			else
			{
				if (player.dresMoney == 2)
				{
					Console.WriteLine($"От galant'а не осталось практически ничего. Теперь это не машина, а просто груда металла. Надежды на восстановление нет никакой.\nDre: Да ладно, не переживай, это всего лишь машина.\n{Player.Instance.Name}: Правда?\nDre: Нет конечно, ты что издеваешься? Я лишился самого дорогого, что у меня было. Охренеть. И как теперь жить?\n");
				}
				if (player.dresMoney > 2)
				{
					Console.WriteLine("Quadra galant Turbo Type-8 и этим все сказано. Да его потрепало, но эту тачку не уничтожит даже прямое попадание атомной бомбы, что тут говорить.\nDre: Да нормально...\n");
				}
			}
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { FirstAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionSuburbPoint : FirstAction
	{
		public override string ActionDescription => "Смени работу.";

		public FirstActionSuburbPoint()
		{
			IsAvailable = false;
			MassageAfterAction = $"Dre: Ля, ты серьезно? И это все, что ты мне хочешь сказать? После того, что произошло.\n{Player.Instance.Name}: Ну да, ты мой бро и я хочу чтобы у тебя все было офигенно.\nDre: Премного благодарен, но как-то не до этого.\n";
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
			SetOtherActionNotVisible(point, new List<int> { SecondAction.ACTION_NUMBER });
		}
	}
}
