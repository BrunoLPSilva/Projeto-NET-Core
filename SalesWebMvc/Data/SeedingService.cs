using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            //verificar se ja existe algum dado no banco
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //DB já foi populado
            }

            //objeto
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, " Fashion");
            Department d4 = new Department(4, " Books");


            Seller s1 = new Seller(1, "Bob brown", "bob@gmail.com", 1000.0, d1);
            Seller s2 = new Seller(2, "bruno", "boddddb@gmail.com", 1000.0, d1);

            //Seller s2 = new Seller(2, "Alice Green", "alice@gmail.com", new DateTime(1985, 7, 15), 1500.0, d2);
            //Seller s3 = new Seller(3, "John Doe", "john@gmail.com", new DateTime(1990, 1, 30), 2000.0, d3);
            //Seller s4 = new Seller(4, "Maria White", "maria@gmail.com", new DateTime(1992, 11, 25), 1700.0, d4);
            //Seller s5 = new Seller(5, "James Black", "james@gmail.com", new DateTime(1988, 5, 10), 1300.0, d1);
            //Seller s6 = new Seller(6, "Susan Blue", "susan@gmail.com", new DateTime(1995, 3, 22), 1200.0, d2);
            //Seller s7 = new Seller(7, "David Red", "david@gmail.com", new DateTime(1993, 9, 17), 1800.0, d3);


            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, Models.Enums.SaleStatus.Billed, s1);
           // SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, Models.Enums.SaleStatus.Billed, s1);
            //SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 10, 15), 12000.0, Models.Enums.SaleStatus.Billed, s2);
            //SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 08, 20), 8000.0, Models.Enums.SaleStatus.Canceled, s3);
            //SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 11, 30), 15000.0, Models.Enums.SaleStatus.Pending, s4);
            //SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 07, 14), 7000.0, Models.Enums.SaleStatus.Billed, s5);
            //SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 12, 05), 9500.0, Models.Enums.SaleStatus.Billed, s6);
            //SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 06, 23), 20000.0, Models.Enums.SaleStatus.Pending, s7);

            _context.Department.AddRange(d1, d2, d3, d4);
            // _context.Seller.AddRange(s1, s2, s3, s4,s5,s6,s7);
            _context.Seller.AddRange(s1, s2);
            //_context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7);
            _context.SalesRecord.AddRange(r1);


            _context.SaveChanges();
        }
    }

    

}
