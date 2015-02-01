using ProjectConakry.Data;
using ProjectConakry.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.BusinessServices
{
    public class AddressManagementService: IAddressManagementService
    {
        private static AddressRepository _addressRepostory;

        public AddressManagementService(AddressRepository addressRepository)
        {
            _addressRepostory = addressRepository;
        }


        public void AddNewAddress(DomainObjects.CustomerAddress customerAddress)
        {
            _addressRepostory.Create(customerAddress);
         }

        public CustomerAddress GetAddressByCustomerId(int customerId)
        {
           return _addressRepostory.GetAddressByCustomerId(customerId);
        }
    }
}
