using DomainLayer;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public interface IAmazonRepository
    {

        //Country 
        public Task<List<AmazonCountry>> GetCountries();

        public Task<AmazonCountry> GetCountry(int id);

        public Task InsertCountry(AmazonCountry country);
        public Task UpdateCountry(AmazonCountry country);

        public Task DeleteCountry(int id);

        //order 
        public Task<List<AmazonOrder>> GetOrders();
        public Task<AmazonOrder> GetOrder(int id);

        public Task InsertOrder(AmazonOrder order);
        public Task UpdateOrder(AmazonOrder order);

        public Task DeleteOrder(int id);

    }
}
