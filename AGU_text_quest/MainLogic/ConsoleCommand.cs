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
			player.pointID = idPoint;
		}

		public static void Save(PointBase point, Player player, int idPoint)
		{
			throw new NotImplementedException();
		}

		public static void ShowStatus(PointBase point, Player player, int idPoint)
		{
			throw new NotImplementedException();
		}

		internal static void SetSilverGreg(PointBase point, Player player, int value)
		{
			if (value > 0)
				player.SilverGreg = true;
			else 
				player.SilverGreg = false;
		}

		internal static void SetFatTril(PointBase point, Player player, int value)
		{
			player.fatTril = value;
		}

		internal static void SetTaco(PointBase point, Player player, int value)
		{
			player.tacos = value;
		}

		internal static void SetDresMoney(PointBase point, Player player, int value)
		{
			player.dresMoney = value;
		}
	}
}
