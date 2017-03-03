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

        //tests that each instance is assigned corresponding db id
        [Fact]
        public void Save_AssignIdtoObject_int()
        {
            //Arrange
            Band testBand = new Band("The Beatles");

            //Act
            testBand.Save();
            Band savedBand = Band.GetAll()[0];

            //Assert
            int actualResult = savedBand.GetId();
            int expectedResult = testBand.GetId();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetAll_AllBands_ReturnsListOfBands()
        {
            //Arrange
            Band firstBand = new Band("The Beatles");
            Band secondBand = new Band("Madonna");

            //Act
            firstBand.Save();
            secondBand.Save();

            //Assert
            List<Band> actualResult = Band.GetAll();
            List<Band> expectedResult = new List<Band>{firstBand, secondBand};

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Find_FindsBandInDatabase_Band()
        {
            //Arrange
            Band testBand = new Band("The Beatles");
            testBand.Save();

            //Act
            Band foundBand = Band.Find(testBand.GetId());

            //Assert
            Assert.Equal(testBand, foundBand);
        }

        [Fact]
        public void GetVenues_FindsVenuesBandPlayedAt_List()
        {
            //Arrange
            Band testBand = new Band("The Beatles");
            List<Venue> allVenues = testBand.GetVenues();

            //Assert
            List<Venue> actualResult = allVenues;
            List<Venue> expectedResult = new List<Venue>{};
            Assert.Equal(expectedResult, actualResult);
        }



        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }

    }
}
