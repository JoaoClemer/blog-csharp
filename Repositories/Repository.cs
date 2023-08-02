using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        => _connection = connection;

        public IEnumerable<T> GetAll()
        => _connection.GetAll<T>();

        public T GetId(int id)
        => _connection.Get<T>(id);

        public void Create(T type)
        => _connection.Insert<T>(type);


        public void Update(T type)
        => _connection.Update<T>(type);


        public void Delete(T type)
        => _connection.Delete<T>(type);

        public void Delete(int id)
        {

            var type = _connection.Get<T>(id);
            _connection.Delete<T>(type);
        }
    }
}
