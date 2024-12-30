using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public abstract class SecondAction : ActionBase
	{
		private const int ACTION_NUMBER = 2;
		public override int Number => ACTION_NUMBER;
	}
}
