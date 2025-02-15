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

		public Action<Player>? DoAfterAction { get; set; }
	}
}
