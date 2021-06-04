using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;
using GetMachineNameAssestNameLastestAssest.Service;
using Microsoft.AspNetCore.Mvc;

namespace GetMachineNameAssestNameLatestSeries.Controllers
{

    [ApiController]
    [Route("api/cutting-machines-accessories")]
    public class MachinesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMachines()
        {
            string csvFilePath = @"/Users/abhinnmishra/Projects/GetMachineNameAssestNameLatestSeries/Data.csv";
            CsvReader reader = new CsvReader(csvFilePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            if(machines==null)
            {
                return NotFound();
            }
            return Ok(machines);
        }

        [HttpGet("assets-name/{machinename}")]
        public IActionResult GetAssestName(string machineName)
        {
            string csvFilePath = @"/Users/abhinnmishra/Projects/GetMachineNameAssestNameLatestSeries/Data.csv";
            CsvReader reader = new CsvReader(csvFilePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var assestNames = new CuttingMachinesAccessories(machineName, machines);
            if (assestNames.GetAssetName().Count == 0)
            {
                return NotFound();
            }
            return Ok(assestNames.GetAssetName());
        }

        [HttpGet("machines-name/{assetname}")]
        public IActionResult GetMachineName(string assetName)
        {
            string csvFilePath = @"/Users/abhinnmishra/Projects/GetMachineNameAssestNameLatestSeries/Data.csv";
            CsvReader reader = new CsvReader(csvFilePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var machineName = new CuttingMachinesAccessories(assetName, machines);
            if (machineName.GetMachineName().Count == 0)
            {
                return NotFound();
            }
            return Ok(machineName.GetMachineName());
        }

        [HttpGet("latest-series")]
        public IActionResult GetMachineTypeWithLatestSeries()
        {
            string csvFilePath = @"/Users/abhinnmishra/Projects/GetMachineNameAssestNameLatestSeries/Data.csv";
            CsvReader reader = new CsvReader(csvFilePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var latestMachineSeries = new CuttingMachinesAccessories(machines);
            if(latestMachineSeries.GetMachineTypeWithLatestSeries().Count==0)
            {
                return NotFound();
            }
            return Ok(latestMachineSeries.GetMachineTypeWithLatestSeries());
            

        }
    }
}
