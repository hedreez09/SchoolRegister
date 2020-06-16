using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.DAL.Repository
{
    public class ManagerBase<TEntity> : Repository<TEntity> where TEntity:class
    {
        public ManagerBase(DatabaseContext dbContext):base(dbContext)
        {
            
        }
    }
}
