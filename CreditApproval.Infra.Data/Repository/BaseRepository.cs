using CreditApproval.Domain.Entities;
using CreditApproval.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApproval.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext mySqlContext)
        {
            _appDbContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _appDbContext.Set<TEntity>().Add(obj);
            _appDbContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _appDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appDbContext.Set<TEntity>().Remove(Select(id));
            _appDbContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _appDbContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _appDbContext.Set<TEntity>().Find(id);

    }
}
