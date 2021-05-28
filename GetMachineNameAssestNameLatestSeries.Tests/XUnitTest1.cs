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
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
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
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new GetMachineDetails('a', "C300", machines);
            int actual = 3;

            //act
            List<string> expected = obj.getAssetName();

            //assert
            Assert.Equal(actual, expected.Count);

        }
        [Fact]
        public void TestingForOptionB()
        {

            //arrange
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new GetMachineDetails('b', "Cutter head", machines);
            int actual = 3;

            //act
            List<string> expected = obj.getMachineName();

            //assert
            Assert.Equal(actual, expected.Count);

        }

        [Fact]
        public void TestingForOptionC()
        {

            //arrange
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Projects/SoftwareDesignAndArchitectureProblem/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<MachineProperties> machines = reader.ReadAllMachines();
            var obj = new GetMachineDetails('c', "C300", machines);
            string actual = "C60";

            //act
            List<MachineProperties> expected = obj.getMachineTypeWithLatestSeries();

            //assert
            Assert.Equal(actual, expected[0].MachineName);

        }


    }
}
