﻿using System.Linq.Expressions;
using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
       
    }
}
