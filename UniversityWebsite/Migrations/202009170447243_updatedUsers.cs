namespace UniversityWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        ContactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            DropColumn("dbo.AspNetUsers", "ContactNumber");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
