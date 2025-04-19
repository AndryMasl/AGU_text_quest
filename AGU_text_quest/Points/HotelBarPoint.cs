using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class HotelBarPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} почесал затылок: Ох уж это Компеко Плаза.";

		public HotelBarPoint()
		{
			Actions = new()
			{
				new FirstActionHotelBarPoint(),
				new SecondActionHotelBarPoint(),
				new ThirdActionHotelBarPoint(),
				new FourthActionHotelBarPoint(),
				new FifthActionHotelBarPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			SetVisibleByList(Player.Instance.hotelBarAnswer);

			if (Player.Instance.hotelBarAnswer.Count == 0)
			{
				Console.WriteLine($"{Player.Name} огляделся и увидел бар. То что надо, - подумал {Player.Name} и зашел внутрь. Бар как бар, ничего особенного, только отовсюду веет псевдо роскошью. В воздухе витает аромат тупых мажоров. Вот только в одном из углов примостился бомж, откуда он здесь? В другой стороне, как противоположность бомжу, на роскошном диване примостился какой-то япошка, вокруг него собралось множество слушателей. {Player.Name} присмотрелся и понял что это Кодзима!!! За барной стойкой, какой-то корпорат травит анекдоты. А за столиком у окна, солидный чел ест макароны.\n");
			}
			else
			{
				Console.WriteLine($"{Player.Instance.Name} продолжил изучать бар.\n");
			}
		}
	}

	internal class FifthActionHotelBarPoint : FifthAction
	{
		public override string ActionDescription => "Я увидел достаточно, пора в номер.";

        public FifthActionHotelBarPoint()
        {
            IsAvailable = true;
			NextPointID = 22;
			DoAfterAction = DoAfterActionLocal;

		}

		private void DoAfterActionLocal(Player player)
		{
			Console.WriteLine($"{Player.Instance.Name} пошел к лифту и поднялся в номер, где его ждал Цой.\n");
		}
	}

	internal class FourthActionHotelBarPoint : FourthAction
	{
		public override string ActionDescription => "Подойти к окну.";

        public FourthActionHotelBarPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} подошел к окну, вид на море был неплохой, но все свое внимание {Player.Instance.Name} отдал солидному челу, который сидел за столом в паре метров от окна, чел доел макароны.\n" + $"Солидный чел: Официант макароны!!\n" + $"Официант принес еще одну тарелку макарон.\n" + $"{Player.Instance.Name} подумал: интересно, что будет дальше.\n" + $"Чел не без труда доел макароны. Он начал озираться по сторонам и сказал: Официант макароны.\n" + $"Официант принес еще одну тарелку макарон.\n" + $"{Player.Instance.Name}: Нифига, походу чел на массе, как Дре в свои лучшие годы.\n" + $"Солидный чел вздохнул и снова начал есть макароны. Осилив половину тарелки он встал, снял штаны и обосрал всю стену. Дерьмо струями скатывалось вниз.\nПодбежали работники: Что Это?\n" + $"Уже чуть менее солидный чел: Макароны.\n" + $"Работники: Кто это сделал?\n" + $"Солидный чел: Официант.\n" +
				$"{Player.Instance.Name}: Типичный посетитель Компеко плаза...\n" ;

			DoAfterAction = DoAfterActionLocal;
        }

		private void DoAfterActionLocal(Player player)
		{
			player.hotelBarAnswer.Add(Number);
		}
	}

	internal class ThirdActionHotelBarPoint : ThirdAction
	{
		public override string ActionDescription => "Подойти к барной стойке.";

        public ThirdActionHotelBarPoint()
        {
			IsAvailable = false;
			MassageAfterAction = $"{Player.Instance.Name} невзначай подходит к барной стойке, облокачивается на нее рукой и прислушивается.\n";
			DoAfterAction = DoAfterActionLocal;

		}

		public override void SetVisibleAfterAction(Player player, PointBase point)
		{
			if (player.anecdoteCounter > 10)
			{
				IsVisible = false;
			}
		}

		private void DoAfterActionLocal(Player player)
		{
			switch(player.anecdoteCounter)
			{
				case 0:
					{
						Console.WriteLine("Если на других планетах есть разумная жизнь, то когда-нибудь будет и на нашей!\n");
						break;
					}
				case 1:
					{
						Console.WriteLine("Штирлиц и Мюллер ездили по очереди на танке. Очередь редела, но не расходилась...\n");
						break;
					}
				case 2:
					{
						Console.WriteLine("Долголетие — это месть пенсионера обобравшему его государству.\n");
						break;
					}
				case 3:
					{
						Console.WriteLine("Подвыпившие Штирлиц и Мюллер вышли из бара.\r\n- Давайте снимем девочек, - предложил Штирлиц.\r\n- У вас очень доброе сердце - ответил Мюллер. - Но пусть все-таки повисят до утра.\n");
						break;
					}
				case 4:
					{
						Console.WriteLine("Умение ничего не делать с крайне деловым видом — это первая ступенька карьерной лестницы.\n");
						break;
					}
				case 5:
					{
						Console.WriteLine("Штирлиц вытащил из сейфа записку Мюллера. Мюллеру было очень больно и он сильно ругался.\n");
						break;
					}
				case 6:
					{
						Console.WriteLine("Штирлиц стоял над картой мира. Его неудержимо рвало на родину.\n");
						break;
					}
				case 7:
					{
						Console.WriteLine("Во время секретного совещания в бункер Гитлера с шашкой наголо ворвался Штирлиц и закричал:\r\n- Порублю, гады.\r\nГады скинулись по рублю. Штирлиц собрал деньги и ушел.\n");
						break;
					}
				case 8:
					{
						Console.WriteLine("Штирлиц всегда спал как убитый. Его даже пару раз обводили мелом...\n" +
							"После этих слов корп рухнул головой на стойку и задремал.\n");
						break;
					}
				default:
					{
						Console.WriteLine($"Корпорат все еще дремлет, пуская слюни на стойку, по видимому анекдотов сегодня больше не будет.\n");
						break;
					}
			}

			player.anecdoteCounter++;
		}
	}

	internal class SecondActionHotelBarPoint : SecondAction
	{
		public override string ActionDescription => "Подойти к Кодзиме.";

		public SecondActionHotelBarPoint()
		{
			IsAvailable = true;
			NextPointID = 25;
			DoAfterAction = DoAfterActionLocal;
		}

		private void DoAfterActionLocal(Player player)
		{
			player.hotelBarAnswer.Add(Number);
			Console.WriteLine($"{Player.Instance.Name} подошел к Кодзиме.\n");
		}
	}

	internal class FirstActionHotelBarPoint : FirstAction
	{
		public override string ActionDescription => "Подойти к бомжу.";

        public FirstActionHotelBarPoint()
        {
            IsAvailable = true;
			NextPointID = 24;
			DoAfterAction = DoAfterActionLocal;
        }

        private void DoAfterActionLocal(Player player)
		{
			player.hotelBarAnswer.Add(Number);
			Console.WriteLine($"{Player.Instance.Name} подошел к бомжу. Присмотревшись {Player.Instance.Name} понял, что это не просто бомж, а бомж Дрэ. От бомжа воняло.\n");
		}
	}
}