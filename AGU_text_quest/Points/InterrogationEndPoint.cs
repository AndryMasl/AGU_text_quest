using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class InterrogationEndPoint : PointBase
	{
		public override string Content => $"Либовски: На этом наши вопросы закончены. Благодарю за сотрудничество. С Вами свяжутся в течении 10 рабочих дней. В течении этого времени, не покидайте город, не приобретайте недвижимость, не делайте перевод на иностранные счета...\n" +
			$"10 замков отварились, но это еще не значит, что {Player.Name} больше не под подозрением.";

		public InterrogationEndPoint()
		{
			Actions = new()
			{
				new FirstActionInterrogationEndPoint(),
				new SecondActionInterrogationEndPoint(),
				new ThirdActionInterrogationEndPoint(),
				new FourthActionInterrogationPoint2(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (!Player.Instance.SilverGreg)
				return;

			Console.WriteLine($"СильверГрэг вскакивает со стола и двигается к двери.\n" +
				$"СильверГрэг: Как же они меня достали... Идем же.\n");
		}
	}

	internal class ThirdActionInterrogationEndPoint : ThirdAction
	{
		public override string ActionDescription => "Уйти.";

        public ThirdActionInterrogationEndPoint()
        {
			IsAvailable = true;
			NextPointID = 8;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} выходит из комнаты допроса, затем покидает здание. Ему бы не хотелось сюда возвращаться, никогда.");

			if (!player.SilverGreg)
				return;

			Console.WriteLine("СильверГрэг: Что ж, мудрое решение, возвращаться сюда себе дороже.\n");
		}
	}

	internal class SecondActionInterrogationEndPoint : SecondAction
	{
		public override string ActionDescription => "Каков Ваш вердикт по поводу допроса?";

		public SecondActionInterrogationEndPoint()
		{
			IsAvailable = false;
			MassageAfterAction = "Либовски: Здесь явно есть над чем подумать, с Вами свяжутся.";

			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			if (!player.SilverGreg)
				return;

			Console.WriteLine("СильверГрэг: Нашел у кого спрашивать... Да он искренен только в койке проститутки. Я тебе так скажу ");

			if (Player.Instance.InterrogationResult)
				Console.WriteLine("можешь забыть о них, больше не встретимся.");
			else 
				Console.WriteLine("они от нас уже не отвяжутся.");
		}
	}

	internal class FirstActionInterrogationEndPoint : FirstAction
	{
		public override string ActionDescription => "Покачаться на стуле.";

        public FirstActionInterrogationEndPoint()
        {
            IsAvailable = false;
			MassageAfterAction = "Либовски: Не качайтесь на стуле, имущество казённое.";
        }
    }
}
