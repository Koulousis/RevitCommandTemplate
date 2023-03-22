using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitCommand
{
	[Transaction(TransactionMode.ReadOnly)]
	public class Command : IExternalCommand
	{
		private static Event _handler;
		private static ExternalEvent _externalEvent;

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			if (_handler == null)
			{
				_handler = new Event();
				_externalEvent = ExternalEvent.Create(_handler);
			}

			// Trigger the external event to execute the event handler
			_externalEvent.Raise();

			return Result.Succeeded;
		}
	}
}
