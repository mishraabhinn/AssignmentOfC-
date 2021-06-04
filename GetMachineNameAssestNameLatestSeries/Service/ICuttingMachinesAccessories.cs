using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;

namespace GetMachineNameAssestNameLastestAssest.Service
{
    public interface ICuttingMachinesAccessories
    {
        List<MachineProperties> GetAllMachineAcessories();
        List<string> GetAssetName();
        List<string> GetMachineName();
        List<MachineProperties> GetMachineTypeWithLatestSeries();
    }
}