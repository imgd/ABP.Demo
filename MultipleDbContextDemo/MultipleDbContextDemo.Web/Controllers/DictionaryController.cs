using System;
using System.Web.Mvc;
using Abp.Extensions;
using Abp.Json;
using Demo.Application;
using System.Web;
using System.IO;
using Abp.Auditing;
using MultipleDbContextDemo.Application;

namespace MultipleDbContextDemo.Web.Controllers
{
    /// <summary>
    /// 开启审计日志 table:AbpAuditLogs
    /// </summary>
    [Audited]
    public class DictionaryController : MultipleDbContextDemoControllerBase
    {
        private readonly IDictionaryAppService _dicAppService;
        public DictionaryController(IDictionaryAppService dicAppService)
        {
            _dicAppService = dicAppService;
        }


        /// <summary>
        /// webuploder 上传控件 后台
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="lastModifiedDate"></param>
        /// <param name="size"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpLoad(string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file)
        {
            string filePathName = string.Empty;

            string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            if (Request.Files.Count == 0)
            {
                return Json(new { jsonrpc = 2.0, error = new { code = 102, message = "保存失败" }, id = "id" });
            }

            string ex = Path.GetExtension(file.FileName);
            filePathName = Guid.NewGuid().ToString("N") + ex;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(Path.Combine(localPath, filePathName));

            return Json(new
            {
                jsonrpc = "2.0",
                id = id,
                filePath = "/Upload/" + filePathName
            });

        }
        //关闭审计日志
        //[DisableAuditing]
        public ActionResult UpLoad()
        {
            return View();
        }
        public ActionResult UpLoad2()
        {
            return View();
        }

        public ActionResult Index()
        {
            //var orders = _irp.GetModel();
            var results = _dicAppService.GetDictionaryList(20, 1, (d => d.Id < 20), (d => d.Id), OrderBy.DESC);
            return View(results);
        }

        public ActionResult Insert()
        {
            var results = _dicAppService.GetALlDataBasesType();
            ViewBag.database = results;

            //_dicAppService.InsertDictionary(new DictionaryInput()
            //{
            //    DataBaseName = "THAccountsDB",
            //    TableName = "RecordDrawInfo",
            //    ByteCounts = "4",
            //    CloumName = "test",
            //    CloumSort = "0",
            //    CloumType = "bit",
            //    DefaultValue = String.Empty,
            //    Description = "测试",
            //    IsIdentity = "",
            //    IsPrimaryKey = "",
            //    IsNullable = "√"
            //});

            return View();
        }

        [HttpPost]
        public string Insert(DictionaryInput input)
        {
            var result = _dicAppService.InsertDictionary(input);
            return new Result(result ? "SUCCESS" : "FAIL", result ? "保存成功" : "保存失败").ToJsonString();
        }

        [HttpPost]
        public string Tables(string databaseName)
        {
            if (databaseName.IsNullOrWhiteSpace())
            {
                return new Result("ERROR", "数据库名称不能为空").ToJsonString();
            }

            var results = _dicAppService.GetAllTablesType(databaseName);
            return new Result("SUCCESS", "查询成功", results).ToJsonString();
        }
    }
}