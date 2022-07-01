using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Classe rappresentante la macchina a stati
	/// </summary>
	public abstract class AutomaStateMachine
	{
		/// <summary>
		/// Restituisce o imposta lo stato iniziale della macchina a stati
		/// </summary>
		public AutomaState InitialState { get; protected set; }

		/// <summary>
		/// Restituisce o imposta lo stato precedente
		/// </summary>
		public AutomaState PreviousState { get; protected set; }

		/// <summary>
		/// Restituisce o imposta lo stato attuale
		/// </summary>
		public AutomaState ActualState { get; protected set; }

		/// <summary>
		/// Evento scatenato quando viene ricevuto un evento
		/// </summary>
		public event EventHandler<AutomaEventReceivedEventArgs> EventReceived;

		/// <summary>
		/// Evento scatenato quando lo stato è cambiato
		/// </summary>
		public event EventHandler<AutomaStateChangedEventArgs> StateChanged;

		/// <summary>
		/// Costruttore di default
		/// </summary>
		public AutomaStateMachine()
		{
			this.InitialState = null;
			this.PreviousState = null;
			this.ActualState = null;

			this.EventReceived = null;
			this.StateChanged = null;
		}

		/// <summary>
		/// Inizializza la macchina a stati
		/// </summary>
		/// <param name="initialState">Stato iniziale della macchina a stati</param>
		public void Initialize(AutomaState initialState)
		{
			// Inizializzazione della macchina a stati
			if (AutomaSettings.ErrorsTraceEnabled)
				Trace.Assert(initialState != null, "Cannot create state machine object: initial state not set!");
			this.InitialState = initialState;
			this.PreviousState = null;
			this.ActualState = initialState;

			// Eventuale scatenamento dell'evento che segnala il cambio di stato
			if (this.StateChanged != null)
				this.StateChanged(this, new AutomaStateChangedEventArgs(this.PreviousState, this.ActualState));
		}

		/// <summary>
		/// Ripristina la macchina a stati nel suo stato iniziale
		/// </summary>
		public void Reset()
		{
			// Reset della macchina a stati nel suo stato iniziale
			if (AutomaSettings.ErrorsTraceEnabled)
				Trace.Assert(this.InitialState != null, "Cannot reset state machine: initial state not set!");
			this.PreviousState = null;
			this.ActualState = this.InitialState;

			// Eventuale scatenamento dell'evento che segnala il cambio di stato
			if (this.StateChanged != null)
				this.StateChanged(this, new AutomaStateChangedEventArgs(this.PreviousState, this.ActualState));
		}

		/// <summary>
		/// Metodo chiamato quando si verifica uno qualsiasi degli eventi possibili
		/// </summary>
		/// <param name="newEvent">Evento appena verificato che richiede di essere segnalato</param>
		public void Signal(AutomaEvent newEvent)
		{
			// Controllo che il nuovo evento sia stato indicato
			if (newEvent == null)
			{
				if (AutomaSettings.ErrorsTraceEnabled)
					Trace.WriteLine("Cannot update state machine: new event is null!");
				throw new InvalidOperationException("Cannot update state machine: new event is null!");
			}

			// Controllo che esista uno stato attuale
			if (this.ActualState == null)
			{
				if (AutomaSettings.ErrorsTraceEnabled)
					Trace.WriteLine("Cannot update state machine: actual state is null!");
				throw new InvalidOperationException("Cannot update state machine: actual state is null!");
			}

			// Visualizzazione delle informazioni di debug
			if (AutomaSettings.EventsTraceEnabled)
				Trace.WriteLine($"Received event \"{newEvent.ToString()}\" in state \"{this.ActualState.ToString()}\"");

			// Eventuale scatenamento dell'evento che segnala la ricezione di un nuovo evento
			if (this.EventReceived != null)
				this.EventReceived(this, new AutomaEventReceivedEventArgs(this.ActualState, newEvent));

			// Chiedo allo stato attuale quale sarà il prossimo stato
			AutomaState nextState = this.ActualState.Signal(newEvent);
			if (nextState == null)
			{
				if (AutomaSettings.ErrorsTraceEnabled)
					Trace.WriteLine("Cannot update state machine: next state is null!");
				throw new InvalidOperationException("Cannot update state machine: next state is null!");
			}

			// Cicla finché lo stato attuale ha uno stato al quale passare automaticamente
			do
			{
				// Se il nuovo stato è identico allo stato precedente, non c'è nulla da fare
				if (this.ActualState == nextState)
					return;

				// Aggiornamento degli stati
				this.PreviousState = this.ActualState;
				this.ActualState = nextState;

				// Eventuale scatenamento dell'evento che segnala il cambio di stato
				if (this.StateChanged != null)
				{
					if (AutomaSettings.StatesTraceEnabled)
					{
						String stateChangedTraceMsg = $"State changed from \"{this.PreviousState.ToString()}\" to \"{this.ActualState.ToString()}\"";
						stateChangedTraceMsg += this.PreviousState.AutoSwitchState != null ? " (AutoSwitch)" : "";
						Trace.WriteLine(stateChangedTraceMsg);
					}
					this.StateChanged(this, new AutomaStateChangedEventArgs(this.PreviousState, this.ActualState));
				}

				// Eventuale stato in cui passare automaticamente
				nextState = this.ActualState.AutoSwitchState;
			} while (nextState != null);
		}
	}
}
