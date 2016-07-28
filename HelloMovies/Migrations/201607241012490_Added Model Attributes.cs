namespace HelloMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
