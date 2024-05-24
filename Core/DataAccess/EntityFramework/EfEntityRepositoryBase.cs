using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    //TEntity: çalışılacak veri tabanı tablosu
    //TContext: Çalışılacak context tipi yani veri tabanı ile iletişimi sağlayacak bir sınıf ver.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Veri kaynağından (Ilce entity) şeklinde gönderdiğim Ilce'ye bir tane nesneyi eşleştirecek.
                                                         //bu bir ekleme olduğu için eşleştirme yapmak yerine direk ekleme yapacak
                addedEntity.State = EntityState.Added; //EntityState için using'e Microsoft.EntityFrameworkCore; eklenir.
                context.SaveChanges(); //veri kaynağındaki değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted; //EntityState için using'e Microsoft.EntityFrameworkCore; eklenir.
                context.SaveChanges(); //veri kaynağındaki değişiklikleri kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified; //EntityState için using'e Microsoft.EntityFrameworkCore; eklenir.
                context.SaveChanges(); //veri kaynağındaki değişiklikleri kaydet
            }
        }
    }
}
