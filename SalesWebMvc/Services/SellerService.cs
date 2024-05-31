
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class SellerService
    {

        //Trazendo a migration database
        private readonly SalesWebMvcContext _context;

        //criando instancia dessa classe com a do migration
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
           // obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            //buscando somente o vendedor
           // return _context.Seller.FirstOrDefault(obj => obj.Id == id);
            //join com departamento
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            //verificando se realmente existe esse ID no banco
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
            
            
        }
    }
}
