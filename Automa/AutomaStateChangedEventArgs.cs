using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Oggetto da passare ai gestori degli eventi chiamti al cambio di stato
	/// </summary>
	public class AutomaStateChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Restituisce o imposta lo stato precedente
		/// </summary>
		public AutomaState? PreviousState { get; set; }

		/// <summary>
		/// Restituisce o imposta lo stato attuale
		/// </summary>
		public AutomaState? ActualState { get; set; }

		/// <summary>
		/// Costruttore di default
		/// </summary>
		public AutomaStateChangedEventArgs()
		{
			this.PreviousState = null;
			this.ActualState = null;
		}

		/// <summary>
		/// Costruttore con inizializzazione delle proprietà
		/// </summary>
		/// <param name="previousState">Stato precedente</param>
		/// <param name="actualState">Stato attuale</param>
		public AutomaStateChangedEventArgs(AutomaState? previousState, AutomaState? actualState)
		{
			this.PreviousState = previousState;
			this.ActualState = actualState;
		}
	}
}
