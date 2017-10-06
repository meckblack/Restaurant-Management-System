//using System.Data.Entity;
//using FMS_Objects.Enities;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using FMS_DbConnections.DataContext.StaffDataContext;


//namespace FMS_DbConnections.DataContext.StaffDataContext
//{
//    public partial class BankDataContext : DbContext
//    {
//        public BankDataContext()
//            : base("MyFMS_DB")
//        {
//            Database.SetInitializer<BankDataContext>(new MyDbInitializer());
//        }

        
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        }
//    }
//}