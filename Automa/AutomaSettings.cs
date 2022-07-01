using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Classe statica contenente le impostazioni di lavoro della macchina a stati
	/// </summary>
	public static class AutomaSettings
	{
		/// <summary>
		/// Restituisce o imposta il flag che indica se il trace degli errori è abilitato
		/// </summary>
		public static Boolean ErrorsTraceEnabled { get; set; } = true;
		/// <summary>
		/// Restituisce o imposta il flag che indica se il trace delle operazioni sugli stati è abilitato
		/// </summary>
		public static Boolean StatesTraceEnabled { get; set; } = true;

		/// <summary>
		/// Restituisce o imposta il flag che indica se il trace delle operazioni sugli eventi è abilitato
		/// </summary>
		public static Boolean EventsTraceEnabled { get; set; } = false;
	}
}
