using System;
using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;
namespace GetMachineNameAssestNameLastestAssest.Service
{
    public class GetMachineDetails
    {
        string UserInput;
        char UserInputOption;
        List<MachineProperties> machines;
        public GetMachineDetails(char userinputoption, string userinput, List<MachineProperties> machines)
        {
            this.UserInputOption = userinputoption;
            this.UserInput = userinput;
            this.machines = machines;

        }

        public List<string> getAssetName()
        {
            List<string> ans = new List<string>();
            
            
            foreach (MachineProperties machine in machines)
            {
                if (machine.MachineName == UserInput)
                {
                    ans.Add(machine.Assetname);
                }
            }

            
            
            return ans;
        }
        public List<string> getMachineName()
        {
            List<string> ans = new List<string>();
            
            
            foreach (MachineProperties machine in machines)
            {
                if (machine.Assetname == UserInput)
                {
                    ans.Add(machine.MachineName);
                }

            }
            
            return ans;
        }

        public List<MachineProperties> getMachineTypeWithLatestSeries()
        {
            List<MachineProperties> result = new List<MachineProperties>();
            result.Add(machines[0]);
            for (int i = 1; i < machines.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (String.Compare(result[j].Assetname, machines[i].Assetname) == 0)
                    {
                        if (String.Compare(result[j].Series, machines[i].Series) < 0)
                        {
                            result.RemoveAt(j);
                            result.Add(machines[i]);
                            break;
                        }

                    }
                }
            }
            return result;
        }


    }
}
