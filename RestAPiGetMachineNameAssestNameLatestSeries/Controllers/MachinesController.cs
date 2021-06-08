using System;
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

        private readonly CuttingMachinesAccessories _cuttingMachineAccessories;
        public MachinesController(CuttingMachinesAccessories cuttingMachineAccessories)
        {

            _cuttingMachineAccessories = cuttingMachineAccessories ?? throw new ArgumentNullException(nameof(cuttingMachineAccessories));
        }

        [HttpGet]
        public IActionResult GetAllMachines()
        {
            List<MachineProperties> machines = _cuttingMachineAccessories.GetAllMachineAcessories();
            if (machines == null)
            {
                return NotFound();
            }
            return Ok(machines);
        }

        [HttpGet("assets-name/{machinename}")]
        public IActionResult GetAssestName(string machineName)
        {
            
            
            if (_cuttingMachineAccessories.GetAssetName(machineName).Count == 0)
            {
                return NotFound();
            }
            return Ok(_cuttingMachineAccessories.GetAssetName(machineName));
        }

        [HttpGet("machines-name/{assetname}")]
        public IActionResult GetMachineName(string assetName)
        {


           
            if (_cuttingMachineAccessories.GetMachineName(assetName).Count == 0)
            {
                return NotFound();
            }
            return Ok(_cuttingMachineAccessories.GetMachineName(assetName));
        }

        [HttpGet("latest-series")]
        public IActionResult GetMachineTypeWithLatestSeries()
        {

            var latestMachineSeries = new CuttingMachinesAccessories();
            if (latestMachineSeries.GetMachineTypeWithLatestSeries().Count == 0)
            {
                return NotFound();
            }
            return Ok(latestMachineSeries.GetMachineTypeWithLatestSeries());


        }
    }
}
