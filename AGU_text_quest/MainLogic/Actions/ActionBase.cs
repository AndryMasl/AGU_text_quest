using System;
using System.Collections.Generic;
using System.Drawing;
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
		/// <summary>
		/// При true - необходимо задать следующий <see cref="PointBase"/> в свойство <see cref="NextPointID"/>. 
		/// При false - смена <see cref="PointBase"/> не происходит.
		/// </summary>
		public bool IsAvailable { get; set; }
		/// <summary>
		/// Выводится  при <see cref="IsAvailable"/> == false
		/// </summary>
		public string? MassageAfterAction { get; set; }
		public int NextPointID { get; set; }

		public virtual void SetVisibleBeforeAction(Player player)
		{
			IsVisible = true;
		}

		public virtual void SetVisibleAfterAction (Player player, PointBase point) 
		{ 
			IsVisible = false; 
		}

		protected void SetOtherActionNotVisible(PointBase point, List<int> actionNumbers) => SetOtherActionVisible(point, actionNumbers, false);

		protected void SetOtherActionVisible(PointBase point, List<int> actionNumbers) => SetOtherActionVisible(point, actionNumbers, true);

		protected void SetOtherActionVisible(PointBase point, List<int> actionNumbers, bool isVisible)
		{
			var actions = point?.Actions?.Where(x => actionNumbers.Contains(x.Number));

			if (actions is null)
				return;

			foreach (var action in actions)
				action.IsVisible = isVisible;
		}

        public Action<Player>? DoAfterAction { get; set; }
	}
}
