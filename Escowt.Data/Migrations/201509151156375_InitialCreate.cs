namespace Escowt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Globalization.Languages",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 10),
                        TitleRu = c.String(maxLength: 50),
                        TitleEn = c.String(maxLength: 50),
                        Description = c.String(maxLength: 1024),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .Index(t => t.Alias, unique: true, name: "IX_LanguageAliasUnique");
            
            CreateTable(
                "Authorization.UserGroupCaptions",
                c => new
                    {
                        UserGroupGuid = c.Guid(nullable: false),
                        LanguageGuid = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => new { t.UserGroupGuid, t.LanguageGuid })
                .ForeignKey("Globalization.Languages", t => t.LanguageGuid, cascadeDelete: true)
                .ForeignKey("Authorization.UserGroups", t => t.UserGroupGuid, cascadeDelete: true)
                .Index(t => t.UserGroupGuid)
                .Index(t => t.LanguageGuid);
            
            CreateTable(
                "Authorization.UserGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Authorization.UserGroupCaptions", "UserGroupGuid", "Authorization.UserGroups");
            DropForeignKey("Authorization.UserGroupCaptions", "LanguageGuid", "Globalization.Languages");
            DropIndex("Authorization.UserGroupCaptions", new[] { "LanguageGuid" });
            DropIndex("Authorization.UserGroupCaptions", new[] { "UserGroupGuid" });
            DropIndex("Globalization.Languages", "IX_LanguageAliasUnique");
            DropTable("Authorization.UserGroups");
            DropTable("Authorization.UserGroupCaptions");
            DropTable("Globalization.Languages");
        }
    }
}
