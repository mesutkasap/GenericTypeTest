namespace GenericTypeTest.Abstract
{
    /// <summary>
    /// Generic yazma işlemlerine dair işlemlerin yapılacağı arayüz kalıpları...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriteRepository<T> where T : class
    {
        public Task<T> Add(T entity); 

    }
}
