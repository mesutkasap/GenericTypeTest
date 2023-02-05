using GenericTypeTest.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GenericTypeTest.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        /// <summary>
        /// DB Context sınıfımız...
        /// </summary>
        private readonly DataContext _context;
        /// <summary>
        /// Generic tipte gelen değeri dbset ile türettiğimiz sınıf...
        /// </summary>
        private readonly DbSet<T> dbSet;
        /// <summary>
        /// Task iptal işlemlerinden kullanılacak sınıf...
        /// </summary>
        private readonly CancellationToken cancellationToken;
        /// <summary>
        /// Constructor sınıfımız...
        /// </summary>
        /// <param name="context"></param>
        public WriteRepository(DataContext context)
        {
            _context = context;
            //Gelen generic tipi context.set ile dbSet sınıfımıza atıyoruz...
            dbSet = context.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            dbSet.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        } 
    }
}
