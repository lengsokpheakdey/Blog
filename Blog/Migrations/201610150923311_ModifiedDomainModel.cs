namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ModifiedDomainModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostStatus", "Status", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PostStatus", "Remark", c => c.String(nullable: false, maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("dbo.PostStatus", "Remark", c => c.String(maxLength: 50));
            AlterColumn("dbo.PostStatus", "Status", c => c.String(maxLength: 50));
        }
    }
}
