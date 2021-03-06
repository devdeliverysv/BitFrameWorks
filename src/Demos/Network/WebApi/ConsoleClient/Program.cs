﻿
using DevExpress.Xpo;
using XpoDemoOrm;
using System;


namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            RestClientNetProvider.Register();

            //https://localhost:44389
            //http://localhost/DeliverySV.Server/WebApiHttpDataTransferImp
            //var ConnectionString = RestClientNetProvider.GetConnectionString("https://localhost:44389", "/WebApiHttpDataTransferImp", string.Empty, "001");
            var ConnectionString = RestClientNetProvider.GetConnectionString("http://localhost/DeliverySV.Server", "/WebApiHttpDataTransferImp", string.Empty, "001");

            XpoInitializer xpoInitializer = new XpoInitializer(ConnectionString, typeof(Invoice), typeof(Customer));
            xpoInitializer.InitXpo(XpoDefault.GetConnectionProvider(ConnectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema));
            using (var UoW = xpoInitializer.CreateUnitOfWork())
            {
                var faker = new Bogus.Faker<Customer>().CustomInstantiator(c => new Customer(UoW))
                            .RuleFor(p => p.Name, f => f.Name.FullName())
                            .RuleFor(p => p.Active, p => p.Random.Bool());

                var Customers = faker.Generate(100);
                if (UoW.InTransaction)
                    UoW.CommitChanges();
            }
;
        }
    }
}
