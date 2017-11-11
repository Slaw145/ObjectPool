using System;
using System.Collections.Generic;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.employWorker();
            store.OrderEquipment();
            WorkSpace obj = store.objPool.GiveEquipmentWorker();

            Console.WriteLine("Wartosc licznika w klasie Warehouse: " + store.objPool.counter);

            store.CheckThatWorkerWasFired(obj,true);

            Console.WriteLine(store.workers);

            store.FireAnEmployee(obj);

            Console.WriteLine("Wartosc licznika w klasie Warehouse: "+store.objPool.counter);

            store.CheckThatWorkerWasFired(obj, false);

            Console.WriteLine(store.workers);

            Console.ReadKey();
        }
    }
}
