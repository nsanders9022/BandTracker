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




        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
