using System;
using Xunit;
using Machines;
using System.Collections.Generic;

namespace SoftwareDesignAndArchitectureProblem.Tests
{
    public class TestingSoftwareDesignAndArchitectureProblem
    {
        [Fact]
        public void CheckingTheSizeOfCsvFile()
        {

            //arrange
            string userinput="Cutter head";
            string filePath = @"/Users/abhinnmishra/Downloads/CsharpHandson/ProjectKlingelnberg/Assignment/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<Structure> machines = reader.ReadAllMachines();
            int actual = 9;
            //act

            int expected = machines.Count;

            //assert

            Assert.Equal(actual, expected);

        }
        [Fact]
        public void CheckingForOptionAAndB()
        {

            //arrange
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Downloads/CsharpHandson/ProjectKlingelnberg/Assignment/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<Structure> machines = reader.ReadAllMachines();
            var obj = new Calculations('a',"C300",machines);
            int actual = 3;
            //act


            HashSet<string> expected = obj.ForOptionAAndB();

            //assert

            Assert.Equal(actual, expected.Count);

        }

        [Fact]
        public void CheckingForOptionC()
        {

            //arrange
            string userinput = "Cutter head";
            string filePath = @"/Users/abhinnmishra/Downloads/CsharpHandson/ProjectKlingelnberg/Assignment/Data.csv";
            CsvReader reader = new CsvReader(filePath, userinput);
            List<Structure> machines = reader.ReadAllMachines();
            var obj = new Calculations('c', "C300", machines);
            string actual = "C60";
            //act


            List<Structure> expected = obj.ForOptionC();

            //assert

            Assert.Equal(actual, expected[0].MachineName);

        }


    }
}
