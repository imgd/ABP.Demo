using System.Net.Http.Headers;
using System.Web.Http.Controllers;

namespace MultipleDbContextDemo.OutputCache
{
    public interface ICacheKeyGenerator
    {
        string MakeCacheKey(HttpActionContext context, MediaTypeHeaderValue mediaType, bool excludeQueryString = false);
    }
}
