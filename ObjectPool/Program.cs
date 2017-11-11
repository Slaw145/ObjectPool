using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectPool<PooledObject> objPool = ObjectPool<PooledObject>.GetInstance();
            objPool.SetMaxPoolSize(10);
            PooledObject obj = objPool.acquireReusable();
            objPool.ReleaseReusable(obj);
            Console.WriteLine(obj.CreatedAt);
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
