using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchronousObjectPool
{
    class ObjectPool<T> where T : new()
    {
        private static List<T> _available = new List<T>();
        private List<T> _inUse = new List<T>();

        private int counter = 0;
        private int MAXTotalObjects;

        private static ObjectPool<T> instance = null;

        public static ObjectPool<T> GetInstance()
        {
            lock (_available)
            {
                if (instance == null)
                {
                    instance = new ObjectPool<T>();
                }
                else
                {
                    Console.WriteLine("This is singleton!");
                }
                return instance;
            }
        }

        public T acquireReusable()
        {
            lock (_available)
            {
                if (_available.Count != 0 && _available.Count < 10)
                {
                    T item = _available[0];
                    _inUse.Add(item);
                    _available.RemoveAt(0);
                    counter--;
                    return item;
                }
                else
                {
                    T obj = new T();
                    _inUse.Add(obj);
                    return obj;
                }
            }
        }

        public void ReleaseReusable(T item)
        {
            lock (_available)
            {
                if (counter < MAXTotalObjects)
                {
                    _available.Add(item);
                    counter++;
                    _inUse.Remove(item);
                }
                else
                {
                    Console.WriteLine("To much object in pool!");
                }
            }
        }

        public void SetMaxPoolSize(int settingPoolSize)
        {
            MAXTotalObjects = settingPoolSize;
        }
    }
}
