using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public abstract class ActionBase
	{
		public abstract int Number { get; }
		public abstract string ActionDescription { get; }
		public bool IsVisible { get; set; }
		public bool IsAvailable { get; set; }
		public string? MassageAfterAction { get; set; }
		public int NextPointID { get; set; }

		public void SetVisibleBeforeAction(Player player)
		{
			IsVisible = true;
		}

		public void SetVisibleAfterAction (Player player) 
		{ 
			IsVisible = false; 
		}

		public Action<Player>? DoAfterAction { get; set; }
	}
}
