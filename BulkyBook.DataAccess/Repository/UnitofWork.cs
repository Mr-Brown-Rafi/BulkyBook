using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ICtegoryRepository _db;
        public UnitofWork(ICtegoryRepository db) 
        {
            _db = db;
            category = new CategoryRepository(_db);
        }
        public ICategoryRepository category { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
