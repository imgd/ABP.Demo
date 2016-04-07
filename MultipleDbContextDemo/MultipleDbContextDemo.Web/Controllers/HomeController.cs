using System.Web.Mvc;
using Abp.Json;
using Demo.EntityFramework.Common;
using MultipleDbContextDemo.Application;
using MultipleDbContextDemo.Services;

namespace MultipleDbContextDemo.Web.Controllers
{

    public class HomeController : MultipleDbContextDemoControllerBase
    {
        private readonly IAccountInfoAppService _aiaService;
        private readonly ITestAppService _tappservice;
        public HomeController(IAccountInfoAppService aiaService, ITestAppService tappservice)
        {
            _aiaService = aiaService;
            _tappservice = tappservice;
        }

        public ActionResult Index()
        {
            ViewBag.d1 = _tappservice.GetPeople();
            return View();
            //if (Session.IsNull() || Session["userid"].IsNull())
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            //else
            //{
            //    var userid = Session["userid"].ParseInt32();
            //    var userinfo = _aiaService.GetAdminBaseInfo(userid);
            //    return View(userinfo);
            //}

        }



        public ActionResult LayOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(string accounts, string password)
        {
            //验证码图片验证


            //验证用户名和密码信息
            if (string.IsNullOrWhiteSpace(accounts) || string.IsNullOrWhiteSpace(password))
            {
                return new Result("NULL", "用户名或密码不能为空。").ToJsonString();
            }

            var results = _aiaService.Login(accounts, password.StringToMd5());
            if (results.Data.ParseInt32() > 0)
            {
                //此处记录用户当前信息 cookie或者session
                "userid".UpdateSession(results.Data);
            }

            return results.ToJsonString();
        }
    }
}