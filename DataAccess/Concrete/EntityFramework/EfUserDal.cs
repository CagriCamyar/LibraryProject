﻿using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, LibraryProjectDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (LibraryProjectDbContext context = new LibraryProjectDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };
                            return result.ToList();
            }
        }
    }
}
