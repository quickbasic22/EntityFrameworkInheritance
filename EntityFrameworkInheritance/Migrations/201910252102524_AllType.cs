namespace EntityFrameworkInheritance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TPHCourses", name: "Discriminator", newName: "Type");
            CreateTable(
                "dbo.TPCOnlineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        URL = c.String(),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.TPCOfflineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Address = c.String(),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.TPTCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        Trainer = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.TPTOnlineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.TPTCourse", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TPTOfflineCourse",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.TPTCourse", t => t.CourseId)
                .Index(t => t.CourseId);
            
            AlterColumn("dbo.TPHCourses", "Type", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TPTOfflineCourse", "CourseId", "dbo.TPTCourse");
            DropForeignKey("dbo.TPTOnlineCourse", "CourseId", "dbo.TPTCourse");
            DropIndex("dbo.TPTOfflineCourse", new[] { "CourseId" });
            DropIndex("dbo.TPTOnlineCourse", new[] { "CourseId" });
            AlterColumn("dbo.TPHCourses", "Type", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.TPTOfflineCourse");
            DropTable("dbo.TPTOnlineCourse");
            DropTable("dbo.TPTCourse");
            DropTable("dbo.TPCOfflineCourse");
            DropTable("dbo.TPCOnlineCourse");
            RenameColumn(table: "dbo.TPHCourses", name: "Type", newName: "Discriminator");
        }
    }
}
