// --------------------------------------------------------------------------------------------------------------------
// <copyright file = "AppSchema.cs" company="Audi AG">
//   Copyright (c) 2018 All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}