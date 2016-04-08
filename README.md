# abp.demo
这是一个采用abp框架部署的多数据项目<br/>
这是一个初始版本，后续会继续更新和完善，有问题 微博：[@大白2013](http://weibo.com/u/2239977692)  <br/>
ABP的官方网站：http://www.aspnetboilerplate.com<br/>
ABP在Github上的开源项目：https://github.com/aspnetboilerplate<br/>
如果对您有帮助，请不要忘记点个赞哦 <br/>


这里部署的是精简版本，抛弃了授权，用户，权限集成模块，保留了审计日志<br/>
对动态webapi添加了一些扩展：
* 全局自定义身份验证
* 全局消息自定义压缩
* 全局Jsonp服务端支持
* 重写了返回格式，以及datetime类型序列化默认格式
* 实现了支持命名空间路由和基于controller版本控制



abp目前实现的功能有：<br/>
服务器端：<br/>
* ASP.NET MVC 5、.Web API 2、C# 5.0<br/>
* DDD领域驱动设计 （Entities、Repositories、Domain Services、Domain Events、Application Services、DTOs等）<br/>
* Castle windsor （依赖注入容器）<br/>
* Entity Framework 6 \ NHibernate，code first数据迁移<br/>
* Log4Net（日志记录）<br/>
* AutoMapper（实现Dto类与实体类的双向自动转换）<br/>

客户端：<br/>
* Bootstrap <br/>
* Less<br/>
* AngularJs<br/>
* jQuery<br/>
* Modernizr
* 其他JS库: jQuery.validate、jQuery.form、jQuery.blockUI、json2

