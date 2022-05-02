using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAmazonBusiness
    {

        // Country
        public Task<List<AmazonCountry>> GetCountries();
        public Task<AmazonCountry> GetCountry(int id);
        public Task InsertCountry(AmazonCountry country);
        public Task UpdateCountry(AmazonCountry country);
        public Task DeleteCountry(int id);

        //Orders
        public Task<List<AmazonOrder>> GetOrders();
        public Task<AmazonOrder> GetOrder(int id);
        public Task InsertOrder(AmazonOrder order);
        public Task UpdateOrder(AmazonOrder order);
        public Task DeleteOrder(int id);
    }
}