namespace EntityFrameworkInheritance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPHOnly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TPHCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                        Address = c.String(),
                        URL = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TPHCourses");
        }
    }
}
