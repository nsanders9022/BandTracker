using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class BandTest: IDisposable
    {
        public BandTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_TestEmptyList_ReturnEmptyList()
        {
            //Arrange, act
            List<Band> allBands = Band.GetAll();

            //Assert
            List<Band> expectedResult = new List<Band>{};
            List<Band> actualResult = allBands;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Equals_TrueIfBandNameIsSame_Bool()
        {
            //Arrange, Act
            Band firstBand = new Band("The Beatles");
            Band secondBand = new Band("The Beatles");

            //Assert
            Assert.Equal(firstBand, secondBand);
        }

        //tests if instances are saved to db
        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Band newBand = new Band("The Beatles");

            //Act
            newBand.Save();

            //Assert
            List<Band> actualResult = Band.GetAll();
            List<Band> expectedResult = new List<Band>{newBand};

            Assert.Equal(expectedResult, actualResult);
        }



        public void Dispose()
        {
            Band.DeleteAll();
        }

    }
}
