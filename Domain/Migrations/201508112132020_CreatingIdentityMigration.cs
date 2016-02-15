namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingIdentityMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeeComings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Int(),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        BreedingType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.BreedingType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.BreedingType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BeeHoneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        AnimalName = c.String(),
                        HoneyType = c.String(),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        АccountBlocking = c.Boolean(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        Remind = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BreedingCharges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationDate = c.DateTime(),
                        AnimalName = c.String(),
                        Name = c.String(),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        SumCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(nullable: false),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.BreedingComings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        Mass = c.Decimal(precision: 18, scale: 2),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Int(),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(nullable: false),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.BreedingProfits",
                c => new
                    {
                        BreedingId = c.Int(nullable: false),
                        CultureType = c.String(),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(),
                        Motive = c.String(),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BreedingId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.BreedingComings", t => t.BreedingId)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.BreedingId)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.BreedingDailyProfits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        AnimalName = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        СlearCost = c.Decimal(precision: 18, scale: 2),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        FarmerUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FarmerUser_Id)
                .Index(t => t.FarmerUser_Id);
            
            CreateTable(
                "dbo.FishComings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(nullable: false),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.FishProfits",
                c => new
                    {
                        FishId = c.Int(nullable: false),
                        CultureType = c.String(),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(),
                        Motive = c.String(),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FishId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.FishComings", t => t.FishId)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.FishId)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.GrowingCharges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationDate = c.DateTime(),
                        PlantName = c.String(),
                        Name = c.String(),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        SumCost = c.Decimal(precision: 18, scale: 2),
                        GrowingType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.GrowingType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GrowingType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrowingCultures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GrowingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .Index(t => t.GrowingType_Id);
            
            CreateTable(
                "dbo.GrowingFieldComings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandingDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        GrowingType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.GrowingType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GrowingFieldProfits",
                c => new
                    {
                        GrowingFieldId = c.Int(nullable: false),
                        CultureType = c.String(),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(),
                        Remind = c.Boolean(nullable: false),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        ClearCost = c.Decimal(precision: 18, scale: 2),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        GrowingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrowingFieldId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.GrowingFieldComings", t => t.GrowingFieldId)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .Index(t => t.GrowingFieldId)
                .Index(t => t.User_Id)
                .Index(t => t.GrowingType_Id);
            
            CreateTable(
                "dbo.GrowingFruitComings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LandingDate = c.DateTime(),
                        FloweringDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        WasastPlants = c.Int(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        GrowingType_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.GrowingType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GrowingFruitProfits",
                c => new
                    {
                        GrowingFruitId = c.Int(nullable: false),
                        CultureType = c.String(),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(),
                        Remind = c.Boolean(nullable: false),
                        MassType = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Document = c.String(),
                        ClearCost = c.Decimal(precision: 18, scale: 2),
                        ProfitCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        GrowingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrowingFruitId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.GrowingFruitComings", t => t.GrowingFruitId)
                .ForeignKey("dbo.GrowingType", t => t.GrowingType_Id, cascadeDelete: true)
                .Index(t => t.GrowingFruitId)
                .Index(t => t.User_Id)
                .Index(t => t.GrowingType_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        FarmerUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.FarmerUser_Id)
                .Index(t => t.FarmerUser_Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Avatar = c.String(),
                        Growing = c.String(),
                        Breeding = c.String(),
                        Technique = c.String(),
                        Product = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Name = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        Patronymic = c.String(maxLength: 64),
                        Birthday = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        FarmerUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.FarmerUser_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.FarmerUser_Id);
            
            CreateTable(
                "dbo.YoungBreedings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(),
                        CultureType = c.String(),
                        Name = c.String(),
                        MassType = c.String(),
                        Mass = c.Decimal(precision: 18, scale: 2),
                        CurrencyType = c.String(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Amount = c.Int(),
                        Document = c.String(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.BreedingCultures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.BreedingReminders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        Text = c.String(),
                        RemindDate = c.DateTime(),
                        RemindDays = c.Int(),
                        User_Id = c.Int(),
                        BreedingType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.BreedingType", t => t.BreedingType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BreedingType_Id);
            
            CreateTable(
                "dbo.HoneyType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reminding",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ExpirationDate = c.DateTime(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Reminding", "User_Id", "dbo.Users");
            DropForeignKey("dbo.YoungBreedings", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.FishProfits", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.FishComings", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingReminders", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingReminders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BreedingProfits", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingDailyProfits", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingCultures", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingComings", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BreedingCharges", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BeeHoneys", "BreedingType_Id", "dbo.BreedingType");
            DropForeignKey("dbo.BeeHoneys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.YoungBreedings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ApplicationUserRoles", "FarmerUser_Id", "dbo.Users");
            DropForeignKey("dbo.Profiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photo", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicationUserLogins", "FarmerUser_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingFruitComings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingFieldComings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingCharges", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingFruitProfits", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.GrowingFruitComings", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.GrowingFruitProfits", "GrowingFruitId", "dbo.GrowingFruitComings");
            DropForeignKey("dbo.GrowingFruitProfits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingFieldProfits", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.GrowingFieldComings", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.GrowingFieldProfits", "GrowingFieldId", "dbo.GrowingFieldComings");
            DropForeignKey("dbo.GrowingFieldProfits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GrowingCultures", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.GrowingCharges", "GrowingType_Id", "dbo.GrowingType");
            DropForeignKey("dbo.FishComings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.FishProfits", "FishId", "dbo.FishComings");
            DropForeignKey("dbo.FishProfits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ApplicationUserClaims", "FarmerUser_Id", "dbo.Users");
            DropForeignKey("dbo.BreedingDailyProfits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BreedingComings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BreedingProfits", "BreedingId", "dbo.BreedingComings");
            DropForeignKey("dbo.BreedingProfits", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BreedingCharges", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BeeComings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BeeComings", "BreedingType_Id", "dbo.BreedingType");
            DropIndex("dbo.Reminding", new[] { "User_Id" });
            DropIndex("dbo.BreedingReminders", new[] { "BreedingType_Id" });
            DropIndex("dbo.BreedingReminders", new[] { "User_Id" });
            DropIndex("dbo.BreedingCultures", new[] { "BreedingType_Id" });
            DropIndex("dbo.YoungBreedings", new[] { "BreedingType_Id" });
            DropIndex("dbo.YoungBreedings", new[] { "User_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "FarmerUser_Id" });
            DropIndex("dbo.ApplicationUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropIndex("dbo.Photo", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserLogins", new[] { "FarmerUser_Id" });
            DropIndex("dbo.GrowingFruitProfits", new[] { "GrowingType_Id" });
            DropIndex("dbo.GrowingFruitProfits", new[] { "User_Id" });
            DropIndex("dbo.GrowingFruitProfits", new[] { "GrowingFruitId" });
            DropIndex("dbo.GrowingFruitComings", new[] { "User_Id" });
            DropIndex("dbo.GrowingFruitComings", new[] { "GrowingType_Id" });
            DropIndex("dbo.GrowingFieldProfits", new[] { "GrowingType_Id" });
            DropIndex("dbo.GrowingFieldProfits", new[] { "User_Id" });
            DropIndex("dbo.GrowingFieldProfits", new[] { "GrowingFieldId" });
            DropIndex("dbo.GrowingFieldComings", new[] { "User_Id" });
            DropIndex("dbo.GrowingFieldComings", new[] { "GrowingType_Id" });
            DropIndex("dbo.GrowingCultures", new[] { "GrowingType_Id" });
            DropIndex("dbo.GrowingCharges", new[] { "User_Id" });
            DropIndex("dbo.GrowingCharges", new[] { "GrowingType_Id" });
            DropIndex("dbo.FishProfits", new[] { "BreedingType_Id" });
            DropIndex("dbo.FishProfits", new[] { "User_Id" });
            DropIndex("dbo.FishProfits", new[] { "FishId" });
            DropIndex("dbo.FishComings", new[] { "BreedingType_Id" });
            DropIndex("dbo.FishComings", new[] { "User_Id" });
            DropIndex("dbo.ApplicationUserClaims", new[] { "FarmerUser_Id" });
            DropIndex("dbo.BreedingDailyProfits", new[] { "BreedingType_Id" });
            DropIndex("dbo.BreedingDailyProfits", new[] { "User_Id" });
            DropIndex("dbo.BreedingProfits", new[] { "BreedingType_Id" });
            DropIndex("dbo.BreedingProfits", new[] { "User_Id" });
            DropIndex("dbo.BreedingProfits", new[] { "BreedingId" });
            DropIndex("dbo.BreedingComings", new[] { "BreedingType_Id" });
            DropIndex("dbo.BreedingComings", new[] { "User_Id" });
            DropIndex("dbo.BreedingCharges", new[] { "BreedingType_Id" });
            DropIndex("dbo.BreedingCharges", new[] { "User_Id" });
            DropIndex("dbo.BeeHoneys", new[] { "BreedingType_Id" });
            DropIndex("dbo.BeeHoneys", new[] { "User_Id" });
            DropIndex("dbo.BeeComings", new[] { "User_Id" });
            DropIndex("dbo.BeeComings", new[] { "BreedingType_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Reminding");
            DropTable("dbo.HoneyType");
            DropTable("dbo.BreedingReminders");
            DropTable("dbo.BreedingCultures");
            DropTable("dbo.YoungBreedings");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.Profiles");
            DropTable("dbo.Photo");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.GrowingFruitProfits");
            DropTable("dbo.GrowingFruitComings");
            DropTable("dbo.GrowingFieldProfits");
            DropTable("dbo.GrowingFieldComings");
            DropTable("dbo.GrowingCultures");
            DropTable("dbo.GrowingType");
            DropTable("dbo.GrowingCharges");
            DropTable("dbo.FishProfits");
            DropTable("dbo.FishComings");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.BreedingDailyProfits");
            DropTable("dbo.BreedingProfits");
            DropTable("dbo.BreedingComings");
            DropTable("dbo.BreedingCharges");
            DropTable("dbo.Users");
            DropTable("dbo.BeeHoneys");
            DropTable("dbo.BreedingType");
            DropTable("dbo.BeeComings");
        }
    }
}
