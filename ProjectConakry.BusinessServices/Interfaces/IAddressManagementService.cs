using MongoDB.Bson;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public interface IAddressManagementService
    {
        void AddNewAddress(CustomerAddress customerAddress);
        CustomerAddress GetAddressByCustomerId(ObjectId customerId);
    }
}
