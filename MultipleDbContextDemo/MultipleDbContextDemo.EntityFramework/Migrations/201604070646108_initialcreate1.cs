namespace MultipleDbContextDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;

    public partial class initialcreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__AuditLog",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(),
                    ServiceName = c.String(maxLength: 250),
                    MethodName = c.String(maxLength: 250),
                    Parameters = c.String(maxLength: 1024),
                    ExecutionTime = c.DateTime(nullable: false),
                    ExecutionDuration = c.Int(nullable: false),
                    ClientIpAddress = c.String(maxLength: 64),
                    ClientName = c.String(maxLength: 250),
                    ClientUrl = c.String(maxLength: 250),
                    ClientRefererUrl = c.String(maxLength: 250),
                    BrowserInfo = c.String(maxLength: 250),
                    ExceptionKey = c.String(maxLength: 50),
                    Exception = c.String(maxLength: 2000),
                    ImpersonatorUserId = c.Long(),
                    ImpersonatorTenantId = c.Int(),
                    CustomData = c.String(maxLength: 2000),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.__Log4NetLog",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Thread = c.String(maxLength: 255, nullable: false),
                    Level = c.String(maxLength: 50, nullable: false),
                    Logger = c.String(maxLength: 50, nullable: false),
                    Message = c.String(maxLength: 4000, nullable: false),
                    Exception = c.String(maxLength: 2000)
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo._AuditLog",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });

            DropTable("dbo.__Log4NetLog");

        }
    }
}
