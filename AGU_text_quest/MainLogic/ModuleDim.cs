using Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public static class ModuleDim
	{
		public static Dictionary<string, Action<PointBase, Player, int>> ConsoleCommandDic = new Dictionary<string, Action<PointBase, Player, int>>
		{
			{ "end", ConsoleCommand.End },
			{ "goto", ConsoleCommand.GoTo },
			{ "save", ConsoleCommand.Save },
			{ "status", ConsoleCommand.ShowStatus },
		};

		public static Dictionary<int, PointBase> PointDictionary = new Dictionary<int, PointBase>() 
		{
			{ 0, new StartPoint() },
			{ 1, new KitchenPoint() },
			{ 2, new HouseWithSonPoint() },
		};
	}
}
