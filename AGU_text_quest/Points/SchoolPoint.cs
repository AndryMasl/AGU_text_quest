using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class SchoolPoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} стоял перед дверьми школы и думал: Да вы издеваетесь, опять в эту тупую школу идти?\nСовладав со своими эмоциями, {Player.Instance.Name} зашел внутрь. Проблем не возникло, никто ему не препятствовал. Школа сильно изменилась, со времен, когда здесь учился {Player.Instance.Name}. Теперь школа была больше похожа на заброшенную полуразрушенную фабрику: стены обветшали, сыпется штукатурка, под ногами какой-то мусор. Но все же общие черты сохранились. Раздевалка, две лестницы, ну как обычно...";

        public SchoolPoint()
        {
			Actions = new()
			{
				new FirstActionSchoolPoint(),
				new SecondActionSchoolPoint(),
				new ThirdActionSchoolPoint(),
				new FourthActionSchoolPoint(),
			};

			DoBeforeAction = DoBeforeActionLocal;
		}

		private void DoBeforeActionLocal()
		{
			if (Player.Instance.SilverGreg)
			{
				Console.WriteLine($"Рядом, на скамейке из 3x черных подушек, появляется СильверГрэг, он выдыхает дым сигары и говорит: Завтра в школу не надо... Ура!!!\n");
			}
		}
	}

	internal class FourthActionSchoolPoint : FourthAction
	{
		public override string ActionDescription => "Поболтать с охранником.";

		// TODO: GREG
	}

	internal class ThirdActionSchoolPoint : ThirdAction
	{
		public override string ActionDescription => "Спуститься в подвал Тутаева.";

        public ThirdActionSchoolPoint()
        {
            IsAvailable = true;
			NextPointID = 31;
        }
    }

	internal class SecondActionSchoolPoint : SecondAction
	{
		public override string ActionDescription => "Зайти к Кабзону.";

		// TODO: GREG
	}

	internal class FirstActionSchoolPoint : FirstAction
	{
		public override string ActionDescription => "Зайти к Тольне.";

		// TODO: GREG
	}
}
