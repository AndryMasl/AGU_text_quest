using MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points
{
	internal class FightWithPolicePoint : PointBase
	{
		public override string Content => $"{Player.Instance.Name} опрокидывает стол вперед. Как только столешница превращается в стену между {Player.Instance.Name}ом и ментами, {Player.Instance.Name} бьет фронт-кик. Стол со свистом улетает вперед, впечатывая в стену Либовски. Никитин умудрился увернуться. На капитана обрушивается град ударов: Ора-Ора Ора-Ора Ора-Ора Ора-Ора Ора-Ора. У Никитина нет шансов, он падает без сознания. Не зря {Player.Instance.Name} приберег силы на потом. Однака комната заперта, чо же делать?";
	}
}
