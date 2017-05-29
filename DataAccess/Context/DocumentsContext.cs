using System.Data.Entity;

namespace DataAccess.Utils
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    internal class DocumentsContext : DbContext
    {
        #region Constructor

        public DocumentsContext() 
            : base(Settings.MySqlConnectionString)
        {

        }

        #endregion

        #region DbSets

        public DbSet<Entities.Users.User> Users { get; set; }
        public DbSet<Entities.Documents.Attachment> Attachments { get; set; }
        public DbSet<Entities.Documents.Category> Categories { get; set; }
        public DbSet<Entities.Documents.Galery> Galeries { get; set; }
        public DbSet<Entities.Documents.Document> Documents { get; set; }

        #endregion
    }
}
