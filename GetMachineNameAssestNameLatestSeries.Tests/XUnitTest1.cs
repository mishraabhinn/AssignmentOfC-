using System;
using Xunit;
using System.Collections.Generic;
using GetMachineNameAssestNameLastestAssest.Model;
using GetMachineNameAssestNameLastestAssest.Service;

namespace GetMachineNameAssestNameLastestAssest.Tests
{
    public class TestingSoftwareDesignAndArchitectureProblem
    {
        [Fact]
        public void TestingTheSizeOfCsvFile()
        {

            //arrange
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            int actual = 9;

            //act
            int expected = machines.Count;

            //assert
            Assert.Equal(actual, expected);

        }
        [Fact]
        public void TestingForOptionA()
        {

            //arrange
            string filePath = @"/Users/abhinnmishra/MachineDetailsProject/Data.csv";
            CsvReader reader = new CsvReader(filePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new CuttingMachinesAccessories("C300", machines);
            int actual = 3;

            //act
            List<string> expected = obj.GetAssetName();

            //assert
            Assert.Equal(actual, expected.Count);

        }
        [Fact]
        public void TestingForOptionB()
        {

            //arrange
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new CuttingMachinesAccessories("Cutter head", machines);
            int actual = 3;

            //act
            List<string> expected = obj.GetMachineName();

            //assert
            Assert.Equal(actual, expected.Count);

        }

        [Fact]
        public void TestingForOptionC()
        {

            //arrange
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new CuttingMachinesAccessories("C300", machines);
            string actual = "C60";

            //act
            List<MachineProperties> expected = obj.GetMachineTypeWithLatestSeries();

            //assert
            Assert.Equal(actual, expected[0].MachineName);

        }


    }
}
