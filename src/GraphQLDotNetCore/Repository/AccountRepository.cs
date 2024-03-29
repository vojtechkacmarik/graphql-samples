﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;
using GraphQLDotNetCore.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDotNetCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAll() => _context.Accounts;

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
            .Where(a => a.OwnerId.Equals(ownerId))
            .ToList();

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts
                .Where(a => ownerIds.Contains(a.OwnerId))
                .ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }
    }
}