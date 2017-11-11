using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    class Store
    {
        public int workers;
        public Warehouse<WorkSpace> objPool;

        public void employWorker()
        {
            workers++;
        }

        public void OrderEquipment()
        {
            objPool = Warehouse<WorkSpace>.GetInstance();
            objPool.SetMaxPoolSize(1);
        }

        public int employees()
        {
            return workers;
        }

        public void FireAnEmployee(WorkSpace obj)
        {
            workers--;
            objPool.ReturnEquipmentToWarehouse(obj);
        }

        public void CheckThatWorkerWasFired(WorkSpace obj,bool ifEmployeeWorker)
        {
            if (ifEmployeeWorker == true)
            {
                obj.IfWorkerWasEmployed();
            }
            else if (ifEmployeeWorker == false)
            {
                obj.IfWorkerWasFired();
            }
        }
    }
}
