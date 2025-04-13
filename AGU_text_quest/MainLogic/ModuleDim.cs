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
			{ "setft", ConsoleCommand.SetFatTril },
			{ "settaco", ConsoleCommand.SetTaco },
			{ "setdm", ConsoleCommand.SetDresMoney },
			{ "setl", ConsoleCommand.SetLetters },
			{ "setha", ConsoleCommand.SetHouseAction },
			{ "setam", ConsoleCommand.SetAm },
			{ "setir", ConsoleCommand.SetInterrogationResult },
			{ "setkn", ConsoleCommand.SetKojimaNumber },

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
			{ 18, new CorridorSectionPoint() },
			{ 19, new WomanWithExplosivesPoint() },
			{ 20, new AfterlifePoint() },
			{ 21, new KonpekiPlazaPoint() },
			{ 22, new HotelRoomPoint() },
			{ 23, new HotelBarPoint() },
			{ 24, new HomelessDrePoint() },
			{ 25, new KojimaPoint() },
			{ 26, new DeliMersPoint() },
			{ 27, new MotelPoint() },
			{ 28, new FightWithSilverGregPoint() },

			{ 30, new SchoolPoint() },
			{ 31, new TutaevsBasementPoint() },
			{ 32, new PitPoint() },
			{ 33, new AmFightPoint() },
			{ 34, new IsHeDyingPoint() },
			{ 35, new SuburbPoint() },
			
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
			{ 121, new InterrogationPoint121() },
			{ 122, new InterrogationPoint122() },
			{ 123, new InterrogationPoint123() },
			{ 124, new InterrogationPoint124() },
			{ 125, new InterrogationPoint125() },
			{ 126, new InterrogationPoint126() },
			{ 127, new InterrogationPoint127() },
			{ 128, new InterrogationPoint128() },
			{ 129, new InterrogationPoint129() },
			{ 130, new InterrogationPoint130() },
			{ 131, new InterrogationPoint131() },
			{ 132, new InterrogationPoint132() },
			{ 133, new InterrogationPoint133() },
			{ 134, new InterrogationPoint134() },
			{ 135, new InterrogationPoint135() },
		};
	}
}
