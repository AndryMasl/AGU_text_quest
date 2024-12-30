using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public abstract class FourthAction : ActionBase
	{
		private const int ACTION_NUMBER = 4;
		public override int Number => ACTION_NUMBER;
	}
}
