using System.Collections.Generic;
using SkyTechTest.Dto;


namespace SkyTechTest.ServiceInterfaces
{
    public interface IPersonService
    {
        ICollection<PersonDto> GetList(string dataFilePath);

        int SaveList(PersonDto[] people, string dataFilePath);
    }
}
