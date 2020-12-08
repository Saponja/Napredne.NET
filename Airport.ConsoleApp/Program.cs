using Airport.Data;
using Airport.Data.UnitOfWork;
using Airport.Domain;
using System;
using System.Collections.Generic;

namespace Airport.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using IUnitOfWork uow = new AirportUnitOfWork(new AirportContext());
            uow.Commit();

            


        }
    }
}
