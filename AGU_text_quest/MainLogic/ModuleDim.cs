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
			{ 12, new SmellyPantsPoint() },
			{ 13, new FightWithPolicePoint() },
			{ 14, new InterrogationPoint3() },
			{ 15, new InterrogationPoint4() },
			{ 16, new InterrogationPoint5() },
			{ 17, new InterrogationEndPoint() },
		};
	}
}
