using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class PitPoint : PointBase
	{
		public override string Content => $"Все внимание {Player.Instance.Name}а сосредоточено на углублении.";

        public PitPoint()
        {
			Actions = new()
			{
				new FirstActionPitPoint(),
				new SecondActionPitPoint(),
				new ThirdActionPitPoint(),
				new FourthActionPitPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.pitAnswer.Count == 0)
			{
				Console.WriteLine($"{Player.Instance.Name} бежит к нему. На дне стоит Мем. В яму медленно заливается суспензия. Скоро она достигнет уровня яиц. Мему грозит смертельная опасность.\n");
			}
			if (Player.Instance.Am)
			{
				Actions.First(x => x.Number == ThirdAction.ACTION_NUMBER).IsAvailable = true;
			}

			SetVisibleByList(Player.Instance.pitAnswer);
		}
	}

	internal class FourthActionPitPoint : FourthAction
	{
		public override string ActionDescription => "Вытащить Мема из ямы.";

		public override void SetVisibleBeforeAction(Player player)
		{
			if (player.pitAnswer.Count == 0)
				IsVisible = false;
			else
				IsVisible = true;
		}
	}

	internal class ThirdActionPitPoint : ThirdAction
	{
		public override string ActionDescription => "Крахмальный убегает!!";

        public ThirdActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = "Томми Крахмальный-Шелби взбегает по лестнице и скрывается. Он продолжит свои злодеяния где-то в другом месте.";
			NextPointID = 33;

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionPitPoint : SecondAction
	{
		public override string ActionDescription => "Подать руку Мему.";

        public SecondActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} накланяется и протягивает руку Мему. В этот момент сзади подкрадывается Томми Крахмальный-Шелби и вкалывает в спину {Player.Instance.Name}а огромный шприц с вирусными нано роботами. Роботы начинают изнутри разрушать все системы и органы. {Player.Instance.Name} от боли катается по полу. Крахмальный-Шелби убегает.\n";

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);

			if (player.SilverGreg)
			{
				Console.WriteLine($"СильверГрэг: Держись!! Я возьму весь удар нано-роботов на себя!! А ты сосредоточься на спасении Мема!!\n");
			}
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);

			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER, FourthAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionPitPoint : FirstAction
	{
		public override string ActionDescription => "Мем, ты в порядке?";

        public FirstActionPitPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Мем: Все в порядке, Па, я так рад, что ты меня нашел. Какое ужасное место, что здесь было раньше?\n{Player.Instance.Name}: В этом подвали школьников учили стрелять, разбирать автоматы, снаряжать магазины, надевать противогазы...\nМем: Здесь детей готовили к войне?\n{Player.Instance.Name}: Можно и так сказать.\nМем: Какое страшное место.\n{Player.Instance.Name}: Хватит разговоров, пора вытаскивать тебя отсюда.\n";

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.pitAnswer.Add(ACTION_NUMBER);

			if (!player.SilverGreg)
				return;

			Console.WriteLine($"СильвеГрэг спрыгивает в яму и внимательно рассматривает суспензию.\nСильвеГрэг: Хм, знакомый состав, помниться мне в 2012 бомжи вгоняли себе такой состав под...\n{Player.Instance.Name}: Прекрати, ты меня отвлекаешь.\nСильвеГрэг: Будь внимателен, тут подозрительно тихо после взрыва Тутаева, чую опасность.\n");
		}
	}
}
