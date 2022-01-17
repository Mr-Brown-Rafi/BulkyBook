﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ICtegoryRepository _db;
        public CategoryRepository(ICtegoryRepository db): base(db)
        {
            _db = db;
        }
       
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
