using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points;

internal class AmFightPoint : PointBase
{
	public override string Content => "Ам стоял у запасного выхода школы и кушал протеиновые батончики, один за другим. Тут мимо него пробегает Томми Крахмальный-Шелби.\nАм: Гребаный Крахмал, бесишь.\nАм отбрасывает фантик батончика и устремляется за Крахмальным.";

    public AmFightPoint()
    {
		Actions = new()
			{
				new FirstActionAmFightPoint(),
				new SecondActionAmFightPoint(),
				new ThirdActionAmFightPoint(),
				new FourthActionAmFightPoint(),
			};
	}
}

internal class FourthActionAmFightPoint : FourthAction
{
	public override string ActionDescription => "Добить Крахмльного.";

	public FourthActionAmFightPoint()
	{
		IsAvailable = true;
		NextPointID = 32;

		DoAfterAction = DoAfterActionLocal;
	}

	private void DoAfterActionLocal(Player player)
	{
		Console.WriteLine("Ам делает пару ударов по воздуху.\nЕле живой Крахмал: Тебе пизда, Амирхан.\nКрахмал достает нож.\nАм со злобой в голосе: Как ты меня назвал?\nАм бьет воздух в третий раз, но на этот рсз удар настолько силен, что ударная волна отбрасывает Крахмального прямо в мусоро-дробилку. Это конец для Томми Крахмального-Шелби, больше он никого не потревожит.\n");
	}

	public override void SetVisibleBeforeAction(Player player)
	{
		IsVisible = false;
	}
}

internal class ThirdActionAmFightPoint : ThirdAction
{
	public override string ActionDescription => "Light weight baby!";

	public ThirdActionAmFightPoint()
	{
		IsAvailable = false;
		MassageAfterAction = $"Эти слова дают буст x10 на мышцы спины и ног. Ам подкидывает Крахмала, тот взвывает в небо и спустя несколько секунд Крахмальный начинает падать вниз с ускорением 9.81 м/с^2. Когда Крахмал приближается к земле на огромной скорости, Ам бьет нижний апперкот.\nАм: Это называется физика, неуч.\n";

		DoAfterAction = DoAfterActionLocal;
	}

	private void DoAfterActionLocal(Player player)
	{
		player.AmAnswer.Add(ACTION_NUMBER);
	}

	public override void SetVisibleAfterAction(Player player, PointBase point)
	{
		base.SetVisibleAfterAction(player, point);

		if (player.AmAnswer.Count >= 2)
			SetOtherActionVisible(point, new List<int>() { FourthAction.ACTION_NUMBER });
	}
}

internal class SecondActionAmFightPoint : SecondAction
{
	public override string ActionDescription => "Yeah Buddy!";
	public SecondActionAmFightPoint()
	{
		IsAvailable = false;
		MassageAfterAction = $"Эти слова дают Аму буст x3 на силу грудных и мышц рук. Ам бьет 100 килограммовой штангой по башке Крахмальному.\nАм: Будешь знать как ходить в Дикси в ласинах.\n";

		DoAfterAction = DoAfterActionLocal;
	}

	private void DoAfterActionLocal(Player player)
	{
		player.AmAnswer.Add(ACTION_NUMBER);
	}

	public override void SetVisibleAfterAction(Player player, PointBase point)
	{
		base.SetVisibleAfterAction(player, point);

		if (player.AmAnswer.Count >= 2)
			SetOtherActionVisible(point, new List<int>() { FourthAction.ACTION_NUMBER });
	}
}

internal class FirstActionAmFightPoint : FirstAction
{
	public override string ActionDescription => "Ора-Ора.";

    public FirstActionAmFightPoint()
    {
		IsAvailable = false;
		MassageAfterAction = $"Ам бьет Крахмального и его рука увязает в жиру. Кархмальный смеется.\nАм: Рано радуешься.\n Ам выдергивает руку и решает брать скоростью. На Крахмала обрушивается град ударов. Их скорость крайне велика, а частота ударов в секунду переваливает за 100. Встречая удары такой скорости жир становится тверд как стена и весь урон достигает цели.\nАм: Это тебе за твое убогое чувство юмора.\n";

		DoAfterAction = DoAfterActionLocal;
    }

	private void DoAfterActionLocal(Player player)
	{
		player.AmAnswer.Add(ACTION_NUMBER);
	}

	public override void SetVisibleAfterAction(Player player, PointBase point)
	{
		base.SetVisibleAfterAction(player, point);

		if (player.AmAnswer.Count >= 2)
			SetOtherActionVisible(point, new List<int>() { FourthAction.ACTION_NUMBER });
	}
}