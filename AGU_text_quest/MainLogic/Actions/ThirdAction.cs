using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public abstract class ThirdAction : ActionBase
	{
		private const int ACTION_NUMBER = 3;
		public override int Number => ACTION_NUMBER;
	}
}
