using System;
using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;
using GetMachineNameAssestNameLastestAssest.Service;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        ///Get all Asset Name for a particular machine name  
        /// </summary>
        /// <param name="machineName"> The name of machine </param>
        /// <returns> All the assets name with the particular machine name </returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("assets-name/{machineName}")]
        public IActionResult GetAssestName(string machineName)
        {
            
            
            if (_cuttingMachineAccessories.GetAssetName(machineName).Count == 0)
            {
                return NotFound();
            }
            return Ok(_cuttingMachineAccessories.GetAssetName(machineName));
        }

        /// <summary>
        ///Get all machines name for a particular asset name  
        /// </summary>
        /// <param name="assetName"> The name of asset </param>
        /// <returns> All the machines name with the particular asset name </returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("machines-name/{assetName}")]
        public IActionResult GetMachineName(string assetName)
        {


           
            if (_cuttingMachineAccessories.GetMachineName(assetName).Count == 0)
            {
                return NotFound();
            }
            return Ok(_cuttingMachineAccessories.GetMachineName(assetName));
        }
        /// <summary>
        ///Get all machines name that are using latest series of assets 
        /// </summary>
        /// <returns> All the machines name with latest series </returns> 
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
