using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automa
{
	/// <summary>
	/// Classe rappresentante uno dei possibili eventi gestiti della macchina a stati
	/// </summary>
	public abstract class AutomaEvent
	{
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
