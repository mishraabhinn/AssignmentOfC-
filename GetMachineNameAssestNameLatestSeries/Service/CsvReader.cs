using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GetMachineNameAssestNameLastestAssest.Model;

namespace GetMachineNameAssestNameLastestAssest.Service
{
	public class CsvReader
	{
		private string _csvFilePath;

		//Constructor get the file path when an instance of the class is created.
		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		//This function is used to read the lines in the csv files and append in a list and return that list.
		public List<MachineProperties> ReadAllMachines()
		{
			List<MachineProperties> machines = new List<MachineProperties>();
			
			using (StreamReader sr = new StreamReader(_csvFilePath))
			{
				// read header line
				sr.ReadLine();
				string csvLine;

				while ((csvLine = sr.ReadLine()) != null)
				{


					machines.Add(ReadMachineFromCsvLine(csvLine));
				}

			}

			return machines;
		}
		//This function spilts the line on the basis on comma(,) create a new instance of class MachineProperties and return to the Funtion ReadAllMAchines.
		public MachineProperties ReadMachineFromCsvLine(string csvLine)
		{
			string[] parts = csvLine.Split(',');
			string machinename = parts[0];
			string assetname = parts[1];
			string series = parts[2];

			return new MachineProperties(machinename, assetname, series);
		}


	}
}
