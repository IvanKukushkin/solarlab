namespace planner09.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class planner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.planners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.planners");
        }
    }
}
