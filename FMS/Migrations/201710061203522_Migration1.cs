namespace FMS_DbConnections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUsername = c.String(nullable: false, unicode: false),
                        AdminPassword = c.String(nullable: false, unicode: false),
                        AdminComfirmPassword = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.ExpenseCategory",
                c => new
                    {
                        ExpenseCategoryId = c.Int(nullable: false, identity: true),
                        ExpenseCategoryTitle = c.String(nullable: false, unicode: false),
                        ExpenseCategoryDescription = c.String(nullable: false, unicode: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseCategoryId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                        RestaurantAcronym = c.String(nullable: false, unicode: false),
                        RestaurantAddress = c.String(nullable: false, unicode: false),
                        LGA = c.String(nullable: false, unicode: false),
                        Country = c.String(nullable: false, unicode: false),
                        PostalCode = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodImage = c.String(unicode: false),
                        FoodName = c.String(nullable: false, unicode: false),
                        FoodPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodDescription = c.String(nullable: false, unicode: false),
                        RestaurantId = c.Int(nullable: false),
                        FoodType_FoodTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.FoodType", t => t.FoodType_FoodTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.FoodType_FoodTypeId);
            
            CreateTable(
                "dbo.FoodType",
                c => new
                    {
                        FoodTypeId = c.Int(nullable: false, identity: true),
                        FoodTypeName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.FoodTypeId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SaleTitle = c.String(nullable: false, unicode: false),
                        SaleAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleQuantity = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Food", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.IncomeCategory",
                c => new
                    {
                        IncomeCategoryId = c.Int(nullable: false, identity: true),
                        IncomeCategoryTitle = c.String(nullable: false, unicode: false),
                        IncomeCategoryDescription = c.String(nullable: false, unicode: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeCategoryId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        StaffFirstName = c.String(nullable: false, unicode: false),
                        StaffLastName = c.String(nullable: false, unicode: false),
                        StaffMiddleName = c.String(nullable: false, unicode: false),
                        StaffEmail = c.String(nullable: false, unicode: false),
                        StaffGender = c.Int(nullable: false),
                        StaffAddress = c.String(nullable: false, unicode: false),
                        StaffDateOfEmployment = c.DateTime(nullable: false, precision: 0),
                        StaffDateOfBirth = c.DateTime(nullable: false, precision: 0),
                        StaffPhoneNumber = c.String(nullable: false, unicode: false),
                        StaffAccountName = c.String(nullable: false, unicode: false),
                        StaffAccountNumber = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        StaffBank = c.Int(nullable: false),
                        StaffDepartment = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserFirstName = c.String(nullable: false, unicode: false),
                        UserLastName = c.String(nullable: false, unicode: false),
                        UserMiddleName = c.String(nullable: false, unicode: false),
                        UserEmail = c.String(nullable: false, unicode: false),
                        UserAddress = c.String(nullable: false, unicode: false),
                        UserGender = c.Int(nullable: false),
                        UserDateOfBirth = c.DateTime(nullable: false, precision: 0),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.ExpenseItem",
                c => new
                    {
                        ExpenseItemId = c.Int(nullable: false, identity: true),
                        ExpenseItemTitle = c.String(nullable: false, unicode: false),
                        ExpenseItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseItemQuantity = c.String(nullable: false, unicode: false),
                        ExpenseCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseItemId)
                .ForeignKey("dbo.ExpenseCategory", t => t.ExpenseCategoryId, cascadeDelete: true)
                .Index(t => t.ExpenseCategoryId);
            
            CreateTable(
                "dbo.IncomeItem",
                c => new
                    {
                        IncomeItemId = c.Int(nullable: false, identity: true),
                        IncomeItemTitle = c.String(nullable: false, unicode: false),
                        IncomeItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeItemQuantity = c.String(nullable: false, unicode: false),
                        IncomeCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeItemId)
                .ForeignKey("dbo.IncomeCategory", t => t.IncomeCategoryId, cascadeDelete: true)
                .Index(t => t.IncomeCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomeItem", "IncomeCategoryId", "dbo.IncomeCategory");
            DropForeignKey("dbo.ExpenseItem", "ExpenseCategoryId", "dbo.ExpenseCategory");
            DropForeignKey("dbo.User", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Staff", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.IncomeCategory", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Sales", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Sales", "FoodId", "dbo.Food");
            DropForeignKey("dbo.Food", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Food", "FoodType_FoodTypeId", "dbo.FoodType");
            DropForeignKey("dbo.ExpenseCategory", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.IncomeItem", new[] { "IncomeCategoryId" });
            DropIndex("dbo.ExpenseItem", new[] { "ExpenseCategoryId" });
            DropIndex("dbo.User", new[] { "RestaurantId" });
            DropIndex("dbo.Staff", new[] { "RestaurantId" });
            DropIndex("dbo.IncomeCategory", new[] { "RestaurantId" });
            DropIndex("dbo.Sales", new[] { "FoodId" });
            DropIndex("dbo.Sales", new[] { "RestaurantId" });
            DropIndex("dbo.Food", new[] { "FoodType_FoodTypeId" });
            DropIndex("dbo.Food", new[] { "RestaurantId" });
            DropIndex("dbo.ExpenseCategory", new[] { "RestaurantId" });
            DropTable("dbo.IncomeItem");
            DropTable("dbo.ExpenseItem");
            DropTable("dbo.User");
            DropTable("dbo.Staff");
            DropTable("dbo.IncomeCategory");
            DropTable("dbo.Sales");
            DropTable("dbo.FoodType");
            DropTable("dbo.Food");
            DropTable("dbo.Restaurant");
            DropTable("dbo.ExpenseCategory");
            DropTable("dbo.Admin");
        }
    }
}
