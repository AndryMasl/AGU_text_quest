using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public class Player
	{
		private static Player? _player;
		public static Player Instance
		{
			get
			{
				if (_player == null)
					_player = new Player();

				return _player;
			}
		}

		public string Name { get; }

		public int pointID;

		public bool endGame;

		protected Player() 
		{
			Name = "Юнайс";
			pointID = 0;
			endGame = false;
		}

		#region FlagsForDecision



		#endregion
	}
}
