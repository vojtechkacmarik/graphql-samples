// --------------------------------------------------------------------------------------------------------------------
// <copyright file = "AppQuery.cs" company="Audi AG">
//   Copyright (c) 2018 All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.GraphQL.GraphQLTypes;

namespace GraphQLDotNetCore.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        private const string OWNER_ID_ARGUMENT_NAME = "ownerId";

        public AppQuery(
            IOwnerRepository ownerRepository,
            IAccountRepository accountRepository)
        {
            Field<ListGraphType<OwnerType>>(
                "owners",
                resolve: context => ownerRepository.GetAll());

            Field<OwnerType>(
                "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = OWNER_ID_ARGUMENT_NAME }),
                resolve: context =>
                {
                    if (!Guid.TryParse(context.GetArgument<string>(OWNER_ID_ARGUMENT_NAME), out var id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for Guid."));
                        return null;
                    }

                    return ownerRepository.GetById(id);
                }
            );

            Field<ListGraphType<AccountType>>(
                "accounts",
                resolve: context => accountRepository.GetAll());
        }
    }
}