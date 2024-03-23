namespace UporabiskiVmesniki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class globalni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        naslovFilma = c.String(),
                        opisFilma = c.String(),
                        igralci = c.String(),
                        direktorji = c.String(),
                        pomagači = c.String(),
                        potDoSlike = c.String(),
                        ID_žanra = c.Int(nullable: false),
                        ocenaFilma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Žanr",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        imeŽanra = c.String(),
                        Film_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Films", t => t.Film_ID)
                .Index(t => t.Film_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Žanr", "Film_ID", "dbo.Films");
            DropIndex("dbo.Žanr", new[] { "Film_ID" });
            DropTable("dbo.Žanr");
            DropTable("dbo.Films");
        }
    }
}
