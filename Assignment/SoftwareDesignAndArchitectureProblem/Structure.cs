using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machines
{
	public class Structure
	{
		public string MachineName { get; }
		public string Assetname { get; }
		public string Series { get; }


		public Structure(string machinename, string assetname, string series)
		{
			this.MachineName = machinename;
			this.Assetname = assetname;
			this.Series = series;

		}
	}

}
