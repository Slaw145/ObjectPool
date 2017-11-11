using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Warehouse<T> where T : new()
    {
        private static List<T> _availableEquipment = new List<T>();
        private List<T> _inUseEquipment = new List<T>();

        public int counter = 0;
        private int MAXTotalObjects;

        private static Warehouse<T> instance = null;

        public static Warehouse<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new Warehouse<T>();
            }
            else
            {
                Console.WriteLine("This is singleton!");
            }
            return instance;
        }

        public T GiveEquipmentWorker()
        {
            if (_availableEquipment.Count != 0 && _availableEquipment.Count < 10)
            {
                T item = _availableEquipment[0];
                _inUseEquipment.Add(item);
                _availableEquipment.RemoveAt(0);
                counter--;
                return item;
            }
            else
            {
                T obj = new T();
                _inUseEquipment.Add(obj);
                return obj;
            }
        }

        public void ReturnEquipmentToWarehouse(T item)
        {
            if (counter <= MAXTotalObjects)
            {
                _availableEquipment.Add(item);
                counter++;
                _inUseEquipment.Remove(item);
            }
            else
            {
                Console.WriteLine("To much object in pool!");
            }
        }

        public void SetMaxPoolSize(int settingPoolSize)
        {
            MAXTotalObjects = settingPoolSize;
        }
    }
}
