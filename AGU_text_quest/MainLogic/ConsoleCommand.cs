using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public static class ConsoleCommand
	{
		public static void End(PointBase point, Player player, int idPoint)
		{
			player.endGame = true;
		}
	}
}
