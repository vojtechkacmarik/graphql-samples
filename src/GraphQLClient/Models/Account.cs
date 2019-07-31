using System;

namespace GraphQLClient.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public TypeOfAccount Type { get; set; }
        public string Description { get; set; }
    }
}