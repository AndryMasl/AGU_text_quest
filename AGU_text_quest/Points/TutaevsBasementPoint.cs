﻿using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class TutaevsBasementPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} спускается в подвал, перед ни как и раньше стоит стол Tутаева, вот ток сам Тутаев врос в стену.\n{Player.Instance.Name}: Андрей Владимировиччччч?\nТутаев: Часть команды - часть корабля.\n{Player.Instance.Name}: Ясно, понятно.\n{Player.Instance.Name} осматривается. Дальнейший путь преграждает дверь бункера Тутаева, такую фиг вскроешь и как на зло, дверь заперта. Нужно что-то придумать.";

        public TutaevsBasementPoint()
        {
			Actions = new()
			{
				new FirstActionTutaevsBasement(),
				new SecondActionTutaevsBasement(),
				new ThirdActionTutaevsBasement(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг: Тяжелая ситуация, такую дверь не возьмет даже взрыв Арасака-Тауер. Доебись как до этого Tутаева.\nСильверГрэг взял журнал Тутаева и начал рассматривать его записи.\n");
		}
	}

	internal class ThirdActionTutaevsBasement : ThirdAction
	{
		public override string ActionDescription => "Взять муляж калаша.";

		// TODO: GREG
	}

	internal class SecondActionTutaevsBasement : SecondAction
	{
		public override string ActionDescription => "Взять ключи от мотиса.";

		// TODO: GREG
	}

	internal class FirstActionTutaevsBasement : FirstAction
	{
		public override string ActionDescription => "Андрей Владимирович?";

        public FirstActionTutaevsBasement()
        {
			IsAvailable = false;
			NextPointID = 32;
			DoAfterAction = DoAfterActionLocal;

		}

		private void DoAfterActionLocal(Player player)
		{
			if (Player.Instance.TutaevCounter == 0)
			{
				Console.WriteLine($"Весь подвал начинает трястись. Землятресение? Нет это Тутаве дрыгается в стене.\nТутаев: Вот так я в молодости, вот так!\n");

				if (player.SilverGreg)
				{
					Console.WriteLine("СильверГрэг: Хехе, я тоже помню как Тутаев танцевал на сборах. А еще он любил выбегать на огневой рубеж с фотиком...\n");
				}
			}
			if (Player.Instance.TutaevCounter == 1)
			{
				Console.WriteLine($"Тутаев: У меня все хорошо.\n");
			}
			if (Player.Instance.TutaevCounter == 2)
			{
				Console.WriteLine($"Тутаев: Мне ничего не мешает.\n");
				if (player.SilverGreg)
				{
					Console.WriteLine("СильверГрэг: Ох, сейчас что-то будет...\n");
					IsAvailable = true;
				}
			}
			if (Player.Instance.TutaevCounter == 3)
			{
				Console.WriteLine($"Тутаев: Я к стрельбе готов!!\nБАБАХ!!!\nТутаев взрывается, а вместе с ним пол подвала. {Player.Instance.Name} прикрыл лицо руками от летящих камней. Теперь не нужно искать проход, теперь здесь вообще нет стен.\n");
			}

			player.TutaevCounter++;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			if (player.TutaevCounter >= 4)
				IsVisible = false;
		}
	}
}
