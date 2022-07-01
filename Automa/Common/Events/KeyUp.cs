using Automa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa.Common.Events
{
	/// <summary>
	/// Evento che segnala il rilascio di un tasto della tastiera
	/// </summary>
	public class KeyUp : AutomaEvent
	{
		/// <summary>
		/// Restituisce o imposta l'identificativo del tasto che ha scatenato l'evento
		/// </summary>
		public Int32 KeyCode { get; set; }

		/// <summary>
		/// Costruttore di default
		/// </summary>
		public KeyUp()
		{
			this.KeyCode = 0;
		}

		/// <summary>
		/// Costruttore con inizializzazione delle proprietà
		/// </summary>
		/// <param name="keyCode">Identificativo del tasto che ha scatenato l'evento</param>
		public KeyUp(Int32 keyCode)
		{
			this.KeyCode = keyCode;
		}
	}
}
