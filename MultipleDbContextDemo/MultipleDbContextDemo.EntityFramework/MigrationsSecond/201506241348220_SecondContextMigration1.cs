using System.Collections.Generic;

namespace MultipleDbContextDemo.MigrationsSecond
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondContextMigration1 : DbMigration
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
            DropTable("dbo.AccountInfo");
        }
    }
}
