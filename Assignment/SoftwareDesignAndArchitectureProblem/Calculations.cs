using System;
using System.Collections.Generic;

namespace Machines
{
    public class Calculations
    {
        string userinput;
        char userinputoption;
        List<Structure> machines;
        public Calculations(char userinputoption, string userinput, List<Structure> machines)
        {
            this.userinputoption = userinputoption;
            this.userinput = userinput;
            this.machines = machines;

        }

        public HashSet<string> ForOptionAAndB()
        {
            HashSet<string> ans = new HashSet<string>();
            if (userinputoption=='a')
            {
                foreach (Structure machine in machines)
                {
                    if (machine.MachineName == userinput)
                    {
                        ans.Add(machine.Assetname);
                    }
                }
                
            }
            else
            {
                foreach (Structure machine in machines)
                {
                    if (machine.Assetname == userinput)
                    {
                        ans.Add(machine.MachineName);
                    }

                }
            }
            return ans;
        }

        public List<Structure> ForOptionC()
        {
            List<Structure> result = new List<Structure>();
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
