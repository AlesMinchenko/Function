namespace Function.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Function.Models;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("ConnectionUser")
        {
        }

        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Chart> Charts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().HasMany(o => o.Charts)
                .WithOptional(o => o.UserData);

            base.OnModelCreating(modelBuilder);
        }
    }
    //public class DBInitializer : DropCreateDatabaseAlways<UserContext>
    //{
    //    protected override void Seed(UserContext context)
    //    {
    //        UserData userData = new UserData { A = 1, B = 2, C = 3, RangeFrom = -20, RangeTo = 7, Step = 1 };


    //        Chart chart = new Chart { Name = "Chart", UserData = userData };

    //        base.Seed(context);
    //    }
    //}
}