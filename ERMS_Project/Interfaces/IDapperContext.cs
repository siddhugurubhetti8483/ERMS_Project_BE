using System.Data;

namespace ERMS_Project.Interfaces
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
