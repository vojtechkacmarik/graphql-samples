// --------------------------------------------------------------------------------------------------------------------
// <copyright file = "OwnerType.cs" company="Audi AG">
//   Copyright (c) 2018 All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(
            IAccountRepository accountRepository,
            IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context =>
                {
                    var loader =
                        dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds",
                            accountRepository.GetAccountsByOwnerIds);
                    return loader.LoadAsync(context.Source.Id);
                });

            //Field<ListGraphType<AccountType>>(
            //    "accounts",
            //    resolve: context => accountRepository.GetAllAccountsPerOwner(context.Source.Id));
        }
    }
}