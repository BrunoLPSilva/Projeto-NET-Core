
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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        ////INSERIR DADOS NO BANCO
        ////exemplo antigo
        //public void Insert(Seller obj)
        //{
        //    // obj.Department = _context.Department.First();
        //    _context.Add(obj);
        //    _context.SaveChanges();
        //}

        public async Task InsertAsync(Seller obj)
        {
           // obj.Department = _context.Department.First();
            _context.Add(obj);
          await  _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            //buscando somente o vendedor
           // return _context.Seller.FirstOrDefault(obj => obj.Id == id);
            //join com departamento
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Seller obj)
        {
            //verificando se realmente existe esse ID no banco
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
            
            
        }
    }
}
