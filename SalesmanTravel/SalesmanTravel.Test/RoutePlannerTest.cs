using SalesmanTravel.App;
using Xunit;

namespace SalesmanTravel.Test
{
    public class RoutePlannerTest
    {
        static string ad = "123 Main Street St. Louisville OH 43071,432 Main Long Road St. Louisville OH 43071,786 High Street Pollocksville NY 56432,"
        + "54 Holy Grail Street Niagara Town ZP 32908,3200 Main Rd. Bern AE 56210,1 Gordon St. Atlanta RE 13000,"
        + "10 Pussy Cat Rd. Chicago EX 34342,10 Gordon St. Atlanta RE 13000,58 Gordon Road Atlanta RE 13000,"
        + "22 Tokyo Av. Tedmondville SW 43098,674 Paris bd. Abbeville AA 45521,10 Surta Alley Goodtown GG 30654,"
        + "45 Holy Grail Al. Niagara Town ZP 32908,320 Main Al. Bern AE 56210,14 Gordon Park Atlanta RE 13000,"
        + "100 Pussy Cat Rd. Chicago EX 34342,2 Gordon St. Atlanta RE 13000,5 Gordon Road Atlanta RE 13000,"
        + "2200 Tokyo Av. Tedmondville SW 43098,67 Paris St. Abbeville AA 45521,11 Surta Avenue Goodtown GG 30654,"
        + "45 Holy Grail Al. Niagara Town ZP 32918,320 Main Al. Bern AE 56215,14 Gordon Park Atlanta RE 13200,"
        + "100 Pussy Cat Rd. Chicago EX 34345,2 Gordon St. Atlanta RE 13222,5 Gordon Road Atlanta RE 13001,"
        + "2200 Tokyo Av. Tedmondville SW 43198,67 Paris St. Abbeville AA 45522,11 Surta Avenue Goodville GG 30655,"
        + "2222 Tokyo Av. Tedmondville SW 43198,670 Paris St. Abbeville AA 45522,114 Surta Avenue Goodville GG 30655,"
        + "2 Holy Grail Street Niagara Town ZP 32908,3 Main Rd. Bern AE 56210,77 Gordon St. Atlanta RE 13000";


        [Fact]
        public void TravelTest1()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test1 = routePlanner.Travel(ad, "AA 45522");

            //Assert
            testCheck(test1, "AA 45522:Paris St. Abbeville,Paris St. Abbeville/67,670");
        }

        [Fact]
        public void TravelTest2()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test2 = routePlanner.Travel(ad, "EX 34342");

            //Assert
            testCheck(test2, "EX 34342:Pussy Cat Rd. Chicago,Pussy Cat Rd. Chicago/10,100");
        }

        [Fact]
        public void TravelTest3()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test3 = routePlanner.Travel(ad, "EX 34345");

            //Assert
            testCheck(test3, "EX 34345:Pussy Cat Rd. Chicago/100");
        }

        [Fact]
        public void TravelTest4()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test4 = routePlanner.Travel(ad, "AA 45521");

            //Assert
            testCheck(test4, "AA 45521:Paris bd. Abbeville,Paris St. Abbeville/674,67");
        }

        [Fact]
        public void TravelTest5()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test5 = routePlanner.Travel(ad, "AE 56215");

            //Assert
            testCheck(test5, "AE 56215:Main Al. Bern/320");
        }

        [Fact]
        public void TravelTest6()
        {
            //Arrange
            IRoutePlanner routePlanner = new RoutePlanner();

            //Act
            var test5 = routePlanner.Travel(ad, "NY 5643");

            //Assert
            testCheck(test5, "NY 5643:/");
        }

        private void testCheck(string actual, string expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}
