﻿using System.Linq.Expressions;
using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        void Update(FoodType foodType);
       
    }
}
