using SkyTechTest.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkyTechTest.Dto;
using Newtonsoft.Json;
using System.IO;

namespace SkyTechTest.Services
{
    public class PersonService : IPersonService
    {

    //    private string dataFilePath = HttpRuntime.AppDomainAppPath + "People.json";

        public ICollection<PersonDto> GetList(string dataFilePath)
        {
          
            var serializer = new JsonSerializer();
            var streamReader = File.OpenText(dataFilePath);

            var jsonReader = new JsonTextReader(streamReader);
            var people = serializer.Deserialize<List<PersonDto>>(jsonReader);

            streamReader.Close();
            streamReader.Dispose();

            return people;
        }

        public int SaveList(PersonDto[] people, string dataFilePath)
        {
            try
            {
               var json = JsonConvert.SerializeObject(people);
                File.WriteAllText(dataFilePath, json);
                return 1;
            }
            catch
            {
                return -1;
            }

            // TODO - structured exception handling, logging of errors ...
        }

        
    }
}