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



        public void Dispose()
        {
            Band.DeleteAll();
        }

    }
}
