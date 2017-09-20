namespace DataAccess.DAO
{
    public abstract class BaseDao
    {
        protected PuffContext context;

        protected BaseDao()
        {
              context = new PuffContext();
        }
    }
}