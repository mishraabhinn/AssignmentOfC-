using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMachineNameAssestNameLastestAssest.Model
{
    public class MachineProperties
    {
        public string MachineName { get; }
        public string AssetName { get; }
        public string Series { get; }


        public MachineProperties(string machineName, string assetName, string series)
        {
            this.MachineName = machineName;
            this.AssetName = assetName;
            this.Series = series;

        }
    }

}
