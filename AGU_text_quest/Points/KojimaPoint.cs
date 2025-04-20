using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class KojimaPoint : PointBase
	{
		public override string Content => $"Кодзима вещает своим слушателям что-то возвышенной, он утверждает, что придумал новый способ взаимодействия со зрителем, но в целом нифига не понятно, потому что он говорит на японском. И слушатели тоже нифига не понимают но делают многозначительный вид и говорят: Угу, ада, да, это гениально...";

        public KojimaPoint()
        {
			Actions = new()
			{
				new FirstActionKojimaPoint(),
				new SecondActionKojimaPoint(),
				new ThirdActionKojimaPoint(),
				new FourthActionKojimaPoint(),
				new FifthActionKojimaPoint(),
			};

			//DoBeforeAction = DoBeforeActionLocal;
		}

		//private void DoBeforeActionLocal()
		//{
		//	Console.OutputEncoding = Encoding.Unicode;
		//	Console.InputEncoding = Encoding.Unicode;
		//}
	}

	internal class FifthActionKojimaPoint : FifthAction
	{
		public override string ActionDescription => "КОДЗИМА ГЕНИЙ!!!";

        public FifthActionKojimaPoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.kojimaNumber = true;
			Console.WriteLine($"{Player.Instance.Name} запрыгивает на стол перед Кодзимой и кричит: Кодзима гений!!! Все вокруг начинают хлопать. Кодзима улыбается и дает {Player.Instance.Name}у свою визитку. {Player.Instance.Name} добился того, чего хотел, теперь можно возвращаться к своим делам.\n");
		}
	}

	internal class FourthActionKojimaPoint : FourthAction
	{
		public override string ActionDescription => "Я сказал Кодзима гений!!";

        public FourthActionKojimaPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Кодзима прерывает монолог, поворачивается к {Player.Instance.Name}у, кивает ему и говорит: 私は天才です, затем продолжает свой монолог: 私は魚が大好きです。私は魚が大好きです。私は魚が大好きです。...";
        }

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { FifthAction.ACTION_NUMBER });
		}
	}

	internal class ThirdActionKojimaPoint : ThirdAction
	{
		public override string ActionDescription => "Кодзима гений.";

        public ThirdActionKojimaPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Кодзима прерывает монолог, поворачивается к {Player.Instance.Name}у, кивает ему, затем продолжает говорить: 麺と魚麺と魚麺と魚麺と魚麺と魚...\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int>() { FourthAction.ACTION_NUMBER });
		}
	}

	internal class SecondActionKojimaPoint : SecondAction
	{
		public override string ActionDescription => "Взять автограф.";

        public SecondActionKojimaPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Кодзима прерывает свой монолог, дает {Player.Instance.Name}у автограф, затем продолжает говорить: 魚のスープ魚のスープ魚のスープ...\n";
        }
    }

	internal class FirstActionKojimaPoint : FirstAction
	{
		public override string ActionDescription => "Уйти.";

        public FirstActionKojimaPoint()
        {
            IsAvailable = true;
			NextPointID = 23;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"Ну и бред, подумал {Player.Instance.Name}, развернулся и ушел.\n");
		}
	}
}
