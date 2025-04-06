using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLogic
{
	public abstract class PointBase
	{
		protected Player? _player;
		public Player Player
		{
			get
			{
				if (_player is null) _player = Player.Instance;
				return _player;
			}
			set { _player = value; }
		}
		public abstract string Content { get; }
		public List<ActionBase>? Actions { get; set; }
		public Action? DoBeforeAction { get; set; }
		public Action? DoAfterAction { get; set; }

		public void SetActions()
		{
			foreach (var action in Actions)
				action.SetVisibleBeforeAction(Player.Instance);
		}

		public void ShowActions()
		{
			foreach (var action in Actions?.Where(x => x.IsVisible))
				Console.WriteLine(action.Number + ". " + action.ActionDescription);
		}


		public void SetVisibleByList(List<int> ansvers, bool value = false)
		{
			foreach (var action in Actions)
			{
				if (ansvers.Contains(action.Number))
				{
					action.IsVisible = value;
				}
			}
		}
	}
}
