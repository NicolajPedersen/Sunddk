namespace Sunddk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketId = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketId)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Calories = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.MealId);
            
            CreateTable(
                "dbo.MealPlans",
                c => new
                    {
                        MealPlanId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxCalories = c.Double(nullable: false),
                        Description = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MealPlanId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        IsAdmin = c.Boolean(nullable: false),
                        Gender = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Int(nullable: false),
                        BMR = c.Double(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MeasurementId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonMealPlans",
                c => new
                    {
                        PersonMealPlanId = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        MealPlan_MealPlanId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonMealPlanId)
                .ForeignKey("dbo.MealPlans", t => t.MealPlan_MealPlanId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.MealPlan_MealPlanId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.MealPlanMeals",
                c => new
                    {
                        MealPlan_MealPlanId = c.Int(nullable: false),
                        Meal_MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealPlan_MealPlanId, t.Meal_MealId })
                .ForeignKey("dbo.MealPlans", t => t.MealPlan_MealPlanId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_MealId, cascadeDelete: true)
                .Index(t => t.MealPlan_MealPlanId)
                .Index(t => t.Meal_MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonMealPlans", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PersonMealPlans", "MealPlan_MealPlanId", "dbo.MealPlans");
            DropForeignKey("dbo.Baskets", "PersonId", "dbo.People");
            DropForeignKey("dbo.Measurements", "PersonId", "dbo.People");
            DropForeignKey("dbo.Baskets", "MealId", "dbo.Meals");
            DropForeignKey("dbo.MealPlanMeals", "Meal_MealId", "dbo.Meals");
            DropForeignKey("dbo.MealPlanMeals", "MealPlan_MealPlanId", "dbo.MealPlans");
            DropIndex("dbo.MealPlanMeals", new[] { "Meal_MealId" });
            DropIndex("dbo.MealPlanMeals", new[] { "MealPlan_MealPlanId" });
            DropIndex("dbo.PersonMealPlans", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonMealPlans", new[] { "MealPlan_MealPlanId" });
            DropIndex("dbo.Measurements", new[] { "PersonId" });
            DropIndex("dbo.Baskets", new[] { "PersonId" });
            DropIndex("dbo.Baskets", new[] { "MealId" });
            DropTable("dbo.MealPlanMeals");
            DropTable("dbo.PersonMealPlans");
            DropTable("dbo.Measurements");
            DropTable("dbo.People");
            DropTable("dbo.MealPlans");
            DropTable("dbo.Meals");
            DropTable("dbo.Baskets");
        }
    }
}
