using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machines
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Which Operation You Want To Perform");
			Console.WriteLine("Press a to Get the list of Asset names for given machine type.");
			Console.WriteLine("Press b to Get the list of all machine types on which given asset is used.");
			Console.WriteLine("Press C To Get the machine types which are using the latest series of all the assets that it uses.");



			char userinputoption = Console.ReadLine()[0];
			string userinput="empty";

			if (userinputoption == 'a')
			{
				Console.WriteLine("Enter The Machine Code:");
				userinput = Console.ReadLine();
			}



			else if (userinputoption == 'b')
			{
				Console.WriteLine("Enter The AssetName:");
				userinput = Console.ReadLine();
			}

			else
			{
				Console.WriteLine("Machine types which are using the latest series of all the assets:");
			}
			


			string filePath = @"/Users/abhinnmishra/Downloads/CsharpHandson/ProjectKlingelnberg/Assignment/Data.csv";
			CsvReader reader = new CsvReader(filePath, userinput);

			List<Structure> machines = reader.ReadAllMachines();
			var obj = new Calculations(userinputoption,userinput,machines);

			
			if (userinputoption =='a')
            {
				HashSet<string> ans =obj.ForOptionAAndB();
				foreach (var itr in ans)
				{
					Console.WriteLine(itr);
				}

			}
			else if (userinputoption == 'b')
			{
				HashSet<string> ans = obj.ForOptionAAndB();
				foreach (var itr in ans)
				{
					Console.WriteLine(itr);
				}

			}
			else
            {
				List<Structure> result = obj.ForOptionC();
				foreach(var itr in result)
                {
					Console.WriteLine(itr.MachineName);
                }

			}
		}
	}
}
