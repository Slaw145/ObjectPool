using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsynchronousObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Run(() =>
            {
                ObjectPool<PooledObject> objPool = ObjectPool<PooledObject>.GetInstance();
                objPool.SetMaxPoolSize(10);
                PooledObject obj = objPool.acquireReusable();
                objPool.ReleaseReusable(obj);
                Console.WriteLine(obj.CreatedAt);
                Console.WriteLine("This is the first thread");
            });

            Task task2 = Task.Run(() =>
            {
                ObjectPool<PooledObject> objPool = ObjectPool<PooledObject>.GetInstance();
                objPool.SetMaxPoolSize(10);
                PooledObject obj = objPool.acquireReusable();
                objPool.ReleaseReusable(obj);
                Console.WriteLine(obj.CreatedAt);
                Console.WriteLine("This is the second thread");
            });

            Console.ReadKey();
        }
    }

    class PooledObject
    {
        DateTime _createdAt = DateTime.Now;

        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

    }
}
