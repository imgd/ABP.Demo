using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MultipleDbContextDemo.Application
{
    /// <summary>
    /// 条件范围验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RangeIfAttribute : RangeAttribute
    {
        public string Property { get; set; }
        public string Value { get; set; }

        public RangeIfAttribute(string property, string value, double minimum, double maximum)
            : base(minimum, maximum)
        {
            this.Property = property;
            this.Value = value ?? "";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            PropertyInfo property = validationContext.ObjectType.GetProperty(this.Property);
            object propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            propertyValue = propertyValue ?? "";
            if (propertyValue.ToString() != this.Value)
            {
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }

        private object typeid;
        public override object TypeId
        {
            get { return typeid ?? (typeid = new object()); }
        }
    }
}
