using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    interface IWorkSpace
    {
        void IfWorkerWasEmployed();
        void IfWorkerWasFired();
    }

    class WorkSpace : IWorkSpace
    {
        public void IfWorkerWasEmployed()
        {
            Console.WriteLine("Worker work in shop");
        }

        public void IfWorkerWasFired()
        {
            Console.WriteLine("The employee was released");
        }
    }
}
