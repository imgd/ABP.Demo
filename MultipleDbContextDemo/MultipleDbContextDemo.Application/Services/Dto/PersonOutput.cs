using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultipleDbContextDemo.Core;


namespace Demo.Application
{
    //
    [AutoMapFrom(typeof(Person))]
    public class PersonOutput : EntityDto, IOutputDto
    {
        public string Name { get; set; }
        public DateTime AddTime { get; set; }

        public PersonOutput()
        {
            AddTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
