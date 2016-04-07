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
                "dbo.AccountInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accounts = c.String(),
                        PassWord = c.String(),
                        NickName = c.String(),
                        RegTime = c.DateTime(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false),
                        LastLoginIp = c.String(),
                        LoginCounts = c.Int(nullable: false),
                        AccountStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.WH_Dictionary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataBaseName = c.String(),
                        TableName = c.String(),
                        CloumName = c.String(),
                        CloumSort = c.String(),
                        IsIdentity = c.String(),
                        IsPrimaryKey = c.String(),
                        CloumType = c.String(),
                        ByteCounts = c.String(),
                        IsNullable = c.String(),
                        DefaultValue = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persons");
            DropTable("dbo.WH_Dictionary");
            DropTable("dbo._AuditLog",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AccountInfo");
        }
    }
}
