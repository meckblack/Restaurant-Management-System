using System.Data.Entity;
using FMS_Objects.Enities;
using FMS_Objects.Entities.SystemManagement;
using System.Data.Entity.ModelConfiguration.Conventions;
using FMS_DbConnections.DataContext.StaffDataContext;


namespace FMS_DbConnections.DataContext.StaffDataContext
{
    public partial class StaffDataContext : DbContext
    {
        public StaffDataContext() : base("MyFMS_DB")
        {
            Database.SetInitializer<StaffDataContext>(new MyDbInitializer());
        }

        public DbSet<Admin> admin { get; set; }
        public DbSet<Restaurant> restaurant { get; set; }
        public DbSet<Staff> staff { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Food> food { get; set; }
        public DbSet<IncomeCategory> incomeCategory { get; set; }
        public DbSet<IncomeItem> incomeItem { get; set; }
        public DbSet<ExpenseCategory> expenseCategory { get; set; }
        public DbSet<ExpenseItem> expenseItem { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<Gender> gender { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<State> state { get; set; }
        public DbSet<FoodType> foodType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}