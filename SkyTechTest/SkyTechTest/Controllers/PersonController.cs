using SkyTechTest.Dto;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using SkyTechTest.ServiceInterfaces;
using SkyTechTest.Services;
using System.Diagnostics;

namespace SkyTechTest.Controllers
{
    public class PersonController : Controller
    {

        // Ideally use IOC container to specify service impementations at runtime - e.g.
        /*
            IPersonService _personService;

            public PersonController(IPersonService personService) // IOC container passes in implementation
            {
                _personService = personService;   
            }
        */

        IPersonService _personService = new PersonService();

        // GET: Person
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public int SaveList(PersonDto[] people)
        {
            var dataFilePath = Server.MapPath("~") + "People.json";
            var json = JsonConvert.SerializeObject(people);
            return _personService.SaveList(people, dataFilePath);
        }

        [HttpPost]
        public ActionResult GetList()
        {
            var dataFilePath = Server.MapPath("~") + "People.json";
            var people = _personService.GetList(dataFilePath);

            return Json(people);
        }


    }
}
