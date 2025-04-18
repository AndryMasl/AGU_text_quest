﻿using System;
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

		public string Name { get; set; }

		public int pointID;

		public bool endGame;

		protected Player() 
		{
			Name = "Юнайс";
			pointID = 0;
			endGame = false;
		}

		#region FlagsForDecision

		#region Local
		
		public bool pullUpHorizontalBarPoint = false;
		public int counterPullUpHorizontalBarPoint = 0;

		public int interrogationStatus = 0;
		public List<int> smellyPantsAnswer = new List<int>();

		public int fatTril = 0;
		public int anecdoteCounter = 0;
		public List<int> hotelBarAnswer = new List<int>();
		public bool kojimaNumber = false;
		public int tacos = 0;
		public List<int> fightWithSilverGregAction = new List<int>();

		public int TutaevCounter = 0;
		public List<int> pitAnswer = new List<int>();
		public List<int> AmAnswer = new List<int>();

		#endregion



		#region Global

		public bool SilverGreg = false;

		public int InterrogationResult 
		{ 
			get 
			{
				if (interrogationStatus >= 4)
					return 1;
				if (interrogationStatus <= -4)
					return -1;
				else
					return 0;
			} 
		}

		public List<int> houseAction = new List<int>();

		public int dresMoney = 0;

		public List<string> letters = new List<string>();

		public bool Am = false;

		#endregion

		#endregion
	}
}
