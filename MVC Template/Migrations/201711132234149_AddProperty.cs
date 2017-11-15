namespace MVC_Template.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        AccountTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.AccountTypeID);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        DeletedBy = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        TutorID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        GroupUserID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupUserID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        DeletedBy = c.Int(),
                        DeletedDate = c.Int(),
                    })
                .PrimaryKey(t => t.NotificationID);
            
            CreateTable(
                "dbo.ProblemAnswers",
                c => new
                    {
                        ProblemAnswerID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Answer = c.String(nullable: false, unicode: false),
                        Attempt = c.Int(nullable: false),
                        TutorID = c.Int(),
                        Score = c.Int(),
                    })
                .PrimaryKey(t => t.ProblemAnswerID);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemID = c.Int(nullable: false),
                        TopicID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, maxLength: 300, unicode: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        DeletedBy = c.Int(),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProblemID);
            
            CreateTable(
                "dbo.ProblemSolutions",
                c => new
                    {
                        ProblemSolutionID = c.Int(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        Solution = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ProblemSolutionID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.TopicID);
            
            CreateTable(
                "dbo.UserLevels",
                c => new
                    {
                        UserLevelID = c.Int(nullable: false, identity: true),
                        TopicID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        DeletedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserLevelID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        AccountTypeID = c.Int(nullable: false),
                        AccountCode = c.String(nullable: false, maxLength: 10, unicode: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.UserLevels");
            DropTable("dbo.Topics");
            DropTable("dbo.ProblemSolutions");
            DropTable("dbo.Problems");
            DropTable("dbo.ProblemAnswers");
            DropTable("dbo.Notifications");
            DropTable("dbo.GroupUsers");
            DropTable("dbo.Groups");
            DropTable("dbo.Areas");
            DropTable("dbo.AccountTypes");
        }
    }
}
