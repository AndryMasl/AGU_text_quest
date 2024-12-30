using MainLogic;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, Player!");

		ShowGameManu();
		GetAnswerForManu();
	}

	private static void GetAnswerForManu()
	{
		var flag = true;

		while (flag)
		{
			var answer = Console.ReadLine();

			switch (answer)
			{
				case "start":
					{
						new MainLogicClass().MainCycle();
						flag = false;
						break;
					}
				case "end":
					{
						flag = false;
						break;
					}
				default:
					{
						Console.WriteLine("Команда не опознана, попробуйте еще раз");
						break;
					}
			}
		}
	}

	private static void ShowGameManu()
	{
		Console.WriteLine(
			$"Главное меню\n" +
			$"Введите одну из команд:\n" +
			$"start - начать игру\n" +
			$"end - выйти"
			);
	}
}
