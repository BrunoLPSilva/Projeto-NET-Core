using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        //Trazendo a migration database
        private readonly SalesWebMvcContext _context;

        //criando instancia dessa classe com a do migration
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //EXEMPLO NORMAL
        // public List<Department> FindAll()
        //{
        //    return _context.Department.OrderBy(x => x.Name).ToList();
        //}

        //EXEMPLO ASSYCRONA
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
