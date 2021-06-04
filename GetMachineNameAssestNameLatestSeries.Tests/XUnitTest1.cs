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
            //var obj = new CuttingMachinesAccessories();
            ICuttingMachinesAccessories obj = new CuttingMachinesAccessories();
            List<MachineProperties> machines = obj.GetAllMachineAcessories();
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

            var obj = new CuttingMachinesAccessories("C300");
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

            var obj = new CuttingMachinesAccessories("Cutter head");
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

            var obj = new CuttingMachinesAccessories("C300");
            string actual = "C60";

            //act
            List<MachineProperties> expected = obj.GetMachineTypeWithLatestSeries();

            //assert
            Assert.Equal(actual, expected[0].MachineName);

        }


    }
}
