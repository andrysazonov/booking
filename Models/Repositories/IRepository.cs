namespace HostBooking.Models.Repositories
{
    internal interface IRepository<TDbEntity>
        where TDbEntity : IDbEntity
    {
        public void Insert(TDbEntity entity);
        public void Update(TDbEntity entity);
    }
}