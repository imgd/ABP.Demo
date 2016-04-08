using System;

namespace MultipleDbContextDemo.OutputCache
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class IgnoreCacheOutputAttribute : Attribute
    {
    }
}