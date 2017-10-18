using Service.Interface;

namespace DataAccess.DAO
{
    public abstract class BaseDao : IBaseDao
    {
        protected readonly PuffContext context;

        protected BaseDao()
        {
              context = new PuffContext();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}