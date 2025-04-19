using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class DeliMersPoint : PointBase
	{
		public override string Content => $"Пора сваливать!!! {Player.Instance.Name} выбил ногой окно и ломанулся на крышу, Цой за ним. Со всех сторон летают бронированные ави, один из дронов заметил невезучих похитителей и открыл огонь из крупнокалиберного пулемета. Пришлось прыгать с крыши. Цоя жестко цепануло очередью. С трудом друганы добрались до ДелиМерса.\nНа улице дождь, ДелиМерс мчится на полном ходу, Цой истекает кровью.";

        public DeliMersPoint()
        {
			Actions = new()
			{
				new FirstActionDeliMersPoint(),
				new SecondActionDeliMersPoint(),
				new ThirdActionDeliMersPoint(),
				new FourthActionDeliMersPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.kojimaNumber)
			{
				var act = Actions.First(x => x.Number == FourthAction.ACTION_NUMBER);
				
				act.IsVisible = true;
			}
		}
	}

	internal class FourthActionDeliMersPoint : FourthAction
	{
		public override string ActionDescription => "Позвонить Кодзиме.";

        public FourthActionDeliMersPoint()
        {
			IsAvailable = true;
			NextPointID = 27;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} достает визитку Кодзимы и набирает номер.\n{Player.Instance.Name}: Ало, Кодзима, помоги!!!\nПосле этих слов, Кодзима вылезает из бардачка ДелиМерса, в одной руке у него скальпель, на другой перчатка рипера.\nКодзима: 魚のスープ、私は魚のスープが大好きです.\nКодзима оперирует Цоя, все хорошо, Цой будет жить, а Кодзима настоящий гений!!\nДелиМерс останавливается у мотеля.\nЦой: Все хорошо, {Player.Instance.Name}, иди без меня, мне нужно отдохнуть. Только помни, этому жиртресу нельзя доверять.\n{Player.Instance.Name} жмет руку Цою и выходит из машины.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class ThirdActionDeliMersPoint : ThirdAction
	{
		public override string ActionDescription => "Нужно что-то сделать.";

        public ThirdActionDeliMersPoint()
        {
			IsAvailable = true;
			NextPointID = 27;
			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} шарит по карманам в поиске стимулятора, ничего нет, конечно же это же не какой-то там шутер от первого лица, тут все по серьезному. {Player.Instance.Name} нашел в машине аптечку но бинтами и антисептиком пулевую рану не вылечишь... Цой медленно умирает на руках {Player.Instance.Name}а. Перед смертью Цой приказал {Player.Instance.Name}у жить долго и счастливо.\nДелиМерс подъехал к мотелю. {Player.Instance.Name} долго не хотел вылезать из авто, но в итоге решился.\n");
		}

		public override void SetVisibleBeforeAction(Player player)
		{
			IsVisible = false;
		}
	}

	internal class SecondActionDeliMersPoint : SecondAction
	{
		public override string ActionDescription => "Гони в больницу.";

        public SecondActionDeliMersPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"ДелиМерс: Маршрут строго зафиксирован, не имею права отклоняться от него.\n{Player.Instance.Name} бьет по экрану: Тупая жестянка...\nДелиМерс: Цой в критическом положении.\n{Player.Instance.Name}: Без тебя вижу...\n";
        }

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			base.SetVisibleAfterAction(player, point);
			SetOtherActionVisible(point, new List<int> { ThirdAction.ACTION_NUMBER });
		}
	}

	internal class FirstActionDeliMersPoint : FirstAction
	{
		public override string ActionDescription => "Держись бро!!";

        public FirstActionDeliMersPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"Цой: Прости братка, лучше бы я остался чиллить дома. Передай той девушке с ресепшена, что я любил ее.\n{Player.Instance.Name}: Не мели ерунду экономь силы.\n";
        }
    }
}
