using System;
using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;
namespace GetMachineNameAssestNameLastestAssest.Service
{
    public class CuttingMachinesAccessories
    {
        
        CsvReader reader = new CsvReader(@"/Users/abhinnmishra/MachineDetailsProject/Data.csv");
        List<MachineProperties> machines;
        public CuttingMachinesAccessories()
        {
            this.machines = reader.ReadAllMachines();
        }

        public List<MachineProperties> GetAllMachineAcessories()
        {
            return machines;
        }

        //This function return all the assest name for a particular machine type is using.
        public List<string> GetAssetName(string assetName)
        {
            List<string> assetsName = new List<string>();

            foreach (MachineProperties machine in machines)
            {
                if (machine.MachineName == assetName)
                {
                    assetsName.Add(machine.AssetName);
                }
            }

            return assetsName;
        }

        //This function return all the machine name for a particular asset type given.
        public List<string> GetMachineName(string machineName)
        {
            List<string> machineNames = new List<string>();

            foreach (MachineProperties machine in machines)
            {
                if (machine.AssetName == machineName)
                {
                    machineNames.Add(machine.MachineName);
                }

            }

            return machineNames;
        }

        //This fuction get the machine types which are using the latest series of all the assets that it uses.
        public List<MachineProperties> GetMachineTypeWithLatestSeries()
        {
            List<MachineProperties> latestMachineTypes = new List<MachineProperties>();
            latestMachineTypes.Add(machines[0]);
            for (int i = 1; i < machines.Count; i++)
            {
                for (int j = 0; j < latestMachineTypes.Count; j++)
                {
                    if (String.Compare(latestMachineTypes[j].AssetName, machines[i].AssetName) == 0)
                    {
                        if (String.Compare(latestMachineTypes[j].Series, machines[i].Series) < 0)
                        {
                            latestMachineTypes.RemoveAt(j);
                            latestMachineTypes.Add(machines[i]);
                            break;
                        }

                    }
                }
            }
            return latestMachineTypes;
        }

    }
}