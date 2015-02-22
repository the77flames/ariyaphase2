using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using ProjectConakry.DomainObjects;

namespace ProjectConakry.DomainObjects
{
    public class CustomPrincipal : GenericPrincipal
    {
        public CustomPrincipal(IIdentity identity, string[] roles)
                : base(identity, roles)
        {
        }

        public Customer Customer { get; set; }
        
    }
}