using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkyTechTest.ServiceInterfaces;
using SkyTechTest.Dto;
using SkyTechTest.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace SkyTechTest.Tests.Services
{
    
    [TestClass]
    public class PersonServiceTests
    {
        public PersonServiceTests()
        {
            mockService = new Mock<IPersonService>();
            mockService.Setup(ps => ps.GetList(It.IsAny<string>())).Returns(dummyList); // should maybe be in ClassInitialize
            mockController = new Mock<PersonController>();
          
          
        }
        
        Mock<IPersonService> mockService;
        Mock<PersonController> mockController;
        Mock<HttpServerUtilityBase> server;
        
        //private string dummyJson = "[{\"Id\":1, \"Firstname\":\"Sid\", \"Surname\":\"Haha\"},{\"Id\":2,\"Firstname\":\"Mike\",\"Surname\":\"Hutton\"},{\"Id\":3,\"Firstname\":\"Pat\",\"Surname\":\"Phelan\"}]";

        private List<PersonDto> dummyList = new List<PersonDto> {
            new PersonDto {
                Id = 1,
                Firstname = "Dude",
                Surname = "Walker"
            },
            new PersonDto {
                Id = 1,
                Firstname = "Manny",
                Surname = "Thing"
            },
            new PersonDto {
                Id = 1,
                Firstname = "Lassie",
                Surname = "Dog"
            }
        };
                

        

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PersonService_GetData_Returns_Valid_Data()
        {
            
            // Act            
            var people = mockService.Object.GetList("PathToTheData");

            // Assert
            // We get something back ..
            Assert.IsNotNull(people);
            //  .. the right type .. 
            Assert.IsInstanceOfType(people, typeof(List<PersonDto>));
            // .. and length ..
            Assert.IsTrue(people.Count.Equals(3));
        }

        [TestMethod]
        public void PersonController_GetData_Returns_Valid_Data()
        {
            // Set up the mocks
            var personController = new PersonController();

            //create mock of HttpServerUtilityBase
            var server = new Mock<HttpServerUtilityBase>();
            
            // Make it give us the path to the data
            server.Setup(x => x.MapPath(It.IsAny<string>())).Returns("C:\\Users\\Mark\\Source\\Repos\\SkyTechTest\\SkyTechTest\\SkyTechTest\\");

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Server).Returns(server.Object);
            personController.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), personController);

            // Act
            var response = personController.GetList();


            // Assert
            // We get something back ..
            Assert.IsNotNull(response);
            //  .. the right type .. 
            Assert.IsInstanceOfType(response, typeof(ActionResult));
        }

        [TestMethod]
        public void PersonController_SaveData_Returns_Valid_Data()
        {
            // Set up the mocks
            var personController = new PersonController();

            //create mock of HttpServerUtilityBase
            var server = new Mock<HttpServerUtilityBase>();

            // Make it give us the path to the data
            server.Setup(x => x.MapPath(It.IsAny<string>())).Returns("C:\\Users\\Mark\\Source\\Repos\\SkyTechTest\\SkyTechTest\\SkyTechTest\\");

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Server).Returns(server.Object);
            personController.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), personController);

            // Act
            var response = personController.SaveList(dummyList.ToArray());

            // Assert
            // We get something back ..
            Assert.IsNotNull(response);
            //  .. the right type .. 
            Assert.IsInstanceOfType(response, typeof(int));
        }

    }
}
