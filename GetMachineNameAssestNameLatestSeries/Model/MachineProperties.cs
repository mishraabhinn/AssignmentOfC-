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