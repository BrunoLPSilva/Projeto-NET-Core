
using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SellerService
    {

        private readonly SalesWebMvcContext _context;
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //RETORNAR LISTA COM TODOS VENDEDOREN BANCO
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        //INSERIR DADOS NO BANCO
        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
