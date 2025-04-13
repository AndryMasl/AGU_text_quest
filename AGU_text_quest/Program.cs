using MainLogic;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, Player!");

		ShowGameManu();testc git
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
				case "":
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
				case "name":
					{
						Console.WriteLine($"Текущее имя: {Player.Instance.Name}. Введите новое имя для вашего Юниса:");
						string? name = Console.ReadLine();
						Player.Instance.Name = string.IsNullOrEmpty(name) ? "Юнайс" : name;
						Console.WriteLine("Имя успешно изменено.");
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
			$"start - начать игру (или нажми Enter)\n" +
			$"name - изменить имя вашего Юниса\n" +
			$"end - выйти"
			);
	}
}
