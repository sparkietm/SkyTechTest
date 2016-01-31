using SkyTechTest.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkyTechTest.Models
{
    public class PersonIndexViewModel
    {
        public ICollection<PersonDto> People { get; set; }
    }
}