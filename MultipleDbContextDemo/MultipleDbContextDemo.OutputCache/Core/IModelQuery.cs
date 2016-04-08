﻿namespace MultipleDbContextDemo.OutputCache
{
    public interface IModelQuery<in TModel, out TResult>
    {
        TResult Execute(TModel model);
    }
}