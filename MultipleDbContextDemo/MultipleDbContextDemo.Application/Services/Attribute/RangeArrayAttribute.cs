using System;
using System.ComponentModel.DataAnnotations;
using Demo.EntityFramework.Common;


namespace MultipleDbContextDemo.Application
{
    /// <summary>
    /// T范围验证
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RangeArrayAttribute : ValidationAttribute
    {
        private object[] _paras { get; set; }
        public RangeArrayAttribute(params object[] para)
        {
            _paras = para;
        }

        public override bool IsValid(object value)
        {
            return value.IsInArray(_paras);
        }
    }
}
