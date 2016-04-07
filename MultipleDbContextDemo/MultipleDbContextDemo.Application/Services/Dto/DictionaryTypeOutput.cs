using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultipleDbContextDemo.Core;


namespace Demo.Application
{
    [AutoMapFrom(typeof(Dictionary))]
    public class DictionaryTypeOutput : EntityDto, IOutputDto
    {
        public int Id { get; set; }
        public string DataBaseName { get; set; }

        public string TableName { get; set; }
    }

}
