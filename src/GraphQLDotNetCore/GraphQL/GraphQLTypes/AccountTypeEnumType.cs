// --------------------------------------------------------------------------------------------------------------------
// <copyright file = "AccountTypeEnumType.cs" company="Audi AG">
//   Copyright (c) 2018 All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GraphQL.Types;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}