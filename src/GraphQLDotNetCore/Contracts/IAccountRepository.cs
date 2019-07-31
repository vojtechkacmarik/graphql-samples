using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.Contracts
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAll();

        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);

        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);
    }
}