using Automa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa.Common.Events
{
	/// <summary>
	/// Evento che segnala il rilascio del pulsante centrale del mouse
	/// </summary>
	public class MidMouseButtonUp : AutomaEvent
	{
		/// <summary>
		/// Restituisce o imposta la posizione X del mouse, in pixel
		/// </summary>
		public Int32 PositionX { get; set; }

		/// <summary>
		/// Restituisce o imposta la posizione Y del mouse, in pixel
		/// </summary>
		public Int32 PositionY { get; set; }

		/// <summary>
		/// Costruttore di default
		/// </summary>
		public MidMouseButtonUp()
		{
			this.PositionX = -1;
			this.PositionY = -1;
		}

		/// <summary>
		/// Costruttore con inizializzazione delle proprietà
		/// </summary>
		/// <param name="positionX">Posizione X del mouse, in pixel</param>
		/// <param name="positionY">Posizione Y del mouse, in pixel</param>
		public MidMouseButtonUp(Int32 positionX, Int32 positionY)
		{
			this.PositionX = positionX;
			this.PositionY = positionY;
		}
	}
}
