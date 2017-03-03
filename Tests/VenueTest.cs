using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker.Objects
{
    public class VenueTest: IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_TestEmptyList_ReturnEmptyList()
        {
            //Arrange, act
            List<Venue> allVenues = Venue.GetAll();

            //Assert
            List<Venue> expectedResult = new List<Venue>{};
            List<Venue> actualResult = allVenues;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Equals_TrueIfVenueNameIsSame_Bool()
        {
            //Arrange, Act
            Venue firstVenue = new Venue("Madison Square Garden");
            Venue secondVenue = new Venue("Madison Square Garden");

            //Assert
            Assert.Equal(firstVenue, secondVenue);
        }

        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Venue newVenue = new Venue("Madison Square Garden");

            //Act
            newVenue.Save();

            //Assert
            List<Venue> actualResult = Venue.GetAll();
            List<Venue> expectedResult = new List<Venue>{newVenue};

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Save_AssignIdtoObject_int()
        {
            //Arrange
            Venue testVenue = new Venue("Madison Square Garden");

            //Act
            testVenue.Save();
            Venue savedVenue = Venue.GetAll()[0];

            //Assert
            int actualResult = savedVenue.GetId();
            int expectedResult = testVenue.GetId();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetAll_AllVenues_ReturnsListOfVenues()
        {
            //Arrange
            Venue firstVenue = new Venue("Madison Square Garden");
            Venue secondVenue = new Venue("Fifth Avenue Theater");

            //Act
            firstVenue.Save();
            secondVenue.Save();

            //Assert
            List<Venue> actualResult = Venue.GetAll();
            List<Venue> expectedResult = new List<Venue>{firstVenue, secondVenue};

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Find_FindsVenueInDatabase_Venue()
        {
            //Arrange
            Venue testVenue = new Venue("Madison Square Garden");
            testVenue.Save();

            //Act
            Venue foundVenue = Venue.Find(testVenue.GetId());

            //Assert
            Assert.Equal(testVenue, foundVenue);
        }

        [Fact]
        public void GetBands_FindsBandsThatPlayedAtVenue_List()
        {
            //Arrange
            Venue testVenue = new Venue("Madison Square Garden");
            List<Band> allBands = testVenue.GetBands();

            //Assert
            List<Band> actualResult = allBands;
            List<Band> expectedResult = new List<Band>{};
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddBand_ForRowAddedToJoinTable_Row()
        {
            //Arrange
            Venue testVenue = new Venue("Madison Square Garden");
            testVenue.Save();
            Band testBand = new Band("The Beatles");
            testBand.Save();

            //Act
            testVenue.AddBand(testBand);

            //Assert
            List<Band> actualResult = testVenue.GetBands();
            List<Band> expectedResult = new List<Band>{testBand};

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void UpdateVenue_UpdatesVenueNameinDB_void()
        {
            //Arrange
            Venue testVenue = new Venue("Sixth Avenue Theater");
            testVenue.Save();

            string newName = "Fifth Avenue Theater";

            //Act
            testVenue.UpdateVenue(newName);


            //Assert
            string actualResult = testVenue.GetName();
            string expectedResult = newName;

            Assert.Equal(expectedResult, actualResult);
        }



        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
