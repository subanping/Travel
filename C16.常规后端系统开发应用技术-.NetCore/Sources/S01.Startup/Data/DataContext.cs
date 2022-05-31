namespace WebApiStartup.Data
{
    /// <summary>
    /// EF 数据库上下文定义模型
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student>? Students { get; set; }
        public DbSet<TeachClass>? TeachClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
