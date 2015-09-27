namespace Escowt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUniqueIndex : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "Authorization.UserGroups", name: "IX_LanguageAliasUnique", newName: "IX_UserGroupsNameUnique");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Authorization.UserGroups", name: "IX_UserGroupsNameUnique", newName: "IX_LanguageAliasUnique");
        }
    }
}
