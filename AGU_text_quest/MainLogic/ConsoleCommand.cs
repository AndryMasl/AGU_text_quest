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
			Environment.Exit(0);
		}


		public static void GoTo(PointBase point, Player player, int idPoint)
		{
			throw new NotImplementedException();
		}

		public static void Save(PointBase point, Player player, int idPoint)
		{
			throw new NotImplementedException();
		}

		public static void ShowStatus(PointBase point, Player player, int idPoint)
		{
			throw new NotImplementedException();
		}
	}
}
