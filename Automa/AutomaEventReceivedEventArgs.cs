using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Oggetto da passare ai gestori degli eventi chiamati alla ricezione di un evento
	/// </summary>
	public class AutomaEventReceivedEventArgs : EventArgs
	{
		/// <summary>
		/// Restituisce o imposta lo stato attuale
		/// </summary>
		public AutomaState ActualState { get; set; }

		/// <summary>
		/// Restituisce o imposta l'evento segnalato
		/// </summary>
		public AutomaEvent EventSignaled { get; set; }

		/// <summary>
		/// Costruttore di default
		/// </summary>
		public AutomaEventReceivedEventArgs()
		{
			this.ActualState = null;
			this.EventSignaled = null;
		}

		/// <summary>
		/// Costruttore con inizializzazione delle proprietà
		/// </summary>
		/// <param name="actualState">Stato attuale</param>
		/// <param name="eventSignaled">Evento segnalato</param>
		public AutomaEventReceivedEventArgs(AutomaState actualState, AutomaEvent eventSignaled)
		{
			this.ActualState = actualState;
			this.EventSignaled = eventSignaled;
		}
	}
}
