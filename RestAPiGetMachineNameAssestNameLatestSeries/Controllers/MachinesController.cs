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

            var assetNames = new CuttingMachinesAccessories(machineName);
            if (assetNames.GetAssetName().Count == 0)
            {
                return NotFound();
            }
            return Ok(assetNames.GetAssetName());
        }

        [HttpGet("machines-name/{assetname}")]
        public IActionResult GetMachineName(string assetName)
        {


            var machineName = new CuttingMachinesAccessories(assetName);
            if (machineName.GetMachineName().Count == 0)
            {
                return NotFound();
            }
            return Ok(machineName.GetMachineName());
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
