using System.Data.Entity;
using FMS_Objects.Enities;
using System.Data.Entity.ModelConfiguration.Conventions;
using FMS_DbConnections.DAL;


namespace FMS_DbConnections.DAL
{
    public class FMS_DB : DbContext
    {
        public FMS_DB() : base("MyFMS_DB")
        {
            Database.SetInitializer<FMS_DB>(new MyDbInitializer());
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}