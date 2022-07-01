using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Classe rappresentante uno dei possibili stati nei quali può trovarsi la macchina a stati
	/// </summary>
	public abstract class AutomaState
	{
		/// <summary>
		/// Riferimento alla macchina a stati
		/// </summary>
		protected AutomaStateMachine? StateMachine { get; set; }

		/// <summary>
		/// Restituisce o imposta il riferimento allo stato da impostare automaticamente dopo aver impostato lo stato corrente
		/// </summary>
		public AutomaState? AutoSwitchState { get; set; }

		/// <summary>
		/// Costruttore di default privato
		/// </summary>
		private AutomaState()
		{ }

		/// <summary>
		/// Costruttore con inizializzazione delle proprietà
		/// </summary>
		/// <param name="stateMachine">Riferimento alla macchina a stati</param>
		public AutomaState(AutomaStateMachine? stateMachine)
		{
			if (AutomaSettings.ErrorsTraceEnabled)
				Trace.Assert(stateMachine != null, "State machine reference cannot be null!");
			this.StateMachine = stateMachine;
			this.AutoSwitchState = null;
		}

		/// <summary>
		/// Metodo chiamato quando si verifica uno qualsiasi degli eventi possibili
		/// </summary>
		/// <param name="newEvent">Evento appena verificato che richiede di essere segnalato</param>
		/// <returns>Prossimo stato. Deve essere restituito un riferimento a se stesso (this) se lo stato non deve cambiare</returns>
		public abstract AutomaState Signal(AutomaEvent? newEvent);

		/// <summary>
		/// Override del metodo ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.GetType().Name;
		}
	}
}
