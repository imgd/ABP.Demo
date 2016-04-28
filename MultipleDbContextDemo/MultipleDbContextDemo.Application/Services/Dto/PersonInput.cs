
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MultipleDbContextDemo.Application.WebApi2.Demo.Service;
using MultipleDbContextDemo.Core;


namespace Demo.Application
{
    [AutoMapFrom(typeof(Person))]
    public class PersonInput : EntityDto, IInputDto
    {
        [Required]
        //说明这里参数要实现自动验证需要 绑定参数类型为自定义类型
        [Verify(VerifyType.mobile)]
        public string Name { get; set; }
    }
}
