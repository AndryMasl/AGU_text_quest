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
			{ "setsg", ConsoleCommand.SetSilverGreg },
		};

		public static Dictionary<int, PointBase> PointDictionary = new Dictionary<int, PointBase>() 
		{
			{ 0, new StartPoint() },
			{ 1, new KitchenPoint() },
			{ 2, new HouseWithSonPoint() },
			{ 3, new WalkWithSonPoint() },
			{ 4, new HorizontalBarPoint() },
			{ 5, new RunChasePoint() },
			{ 6, new FlyChasePoint() },
			{ 7, new CarChasePoint() },
			{ 8, new HousePoint() },
			{ 9, new PoliceStationPoint() },
			{ 10, new InterrogationPoint() },
			{ 11, new InterrogationPoint2() },

			{ 100, new InterrogationPoint100() },
			{ 101, new InterrogationPoint101() },
			{ 102, new InterrogationPoint102() },
			{ 103, new InterrogationPoint103() },
			{ 104, new InterrogationPoint104() },
			{ 105, new InterrogationPoint105() },
			{ 106, new InterrogationPoint106() },
			{ 107, new InterrogationPoint107() },
			{ 108, new InterrogationPoint108() },
			{ 109, new InterrogationPoint109() },
			{ 110, new InterrogationPoint110() },
			{ 111, new InterrogationPoint111() },
			{ 112, new InterrogationPoint112() },
			{ 113, new InterrogationPoint113() },
			{ 114, new InterrogationPoint114() },
			{ 115, new InterrogationPoint115() },
			{ 116, new InterrogationPoint116() },
			{ 117, new InterrogationPoint117() },
			{ 118, new InterrogationPoint118() },
			{ 119, new InterrogationPoint119() },
			{ 120, new InterrogationPoint120() },
		};
	}
}
