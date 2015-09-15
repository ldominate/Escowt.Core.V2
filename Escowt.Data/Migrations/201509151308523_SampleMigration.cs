namespace Escowt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Authorization.UserGroups", "Name", unique: true, name: "IX_LanguageAliasUnique");
        }
        
        public override void Down()
        {
            DropIndex("Authorization.UserGroups", "IX_LanguageAliasUnique");
        }
    }
}
