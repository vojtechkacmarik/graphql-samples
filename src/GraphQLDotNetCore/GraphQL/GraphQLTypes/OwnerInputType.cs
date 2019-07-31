// --------------------------------------------------------------------------------------------------------------------
// <copyright file = "OwnerInputType.cs" company="Audi AG">
//   Copyright (c) 2018 All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GraphQL.Types;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
    public class OwnerInputType : InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}