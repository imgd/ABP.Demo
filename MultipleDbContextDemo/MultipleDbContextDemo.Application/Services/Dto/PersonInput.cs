
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultipleDbContextDemo.Core;


namespace Demo.Application
{
    [AutoMapFrom(typeof(Person))]
    public class PersonInput : EntityDto, IInputDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
