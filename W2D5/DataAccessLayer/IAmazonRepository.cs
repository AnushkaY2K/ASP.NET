using BusinessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public interface IAmazonRepository
    {

        //AmazonCountry 
        public Task<List<AmazonCountry>> GetCountries();

        public Task<AmazonCountry> GetCountry(int id);

        public Task InsertCountry(AmazonCountry country);
        public Task UpdateCountry(AmazonCountry country);

        public Task DeleteCountry(int id);

        //AmazonOrder 
        public Task<List<AmazonOrder>> GetOrders();
        public Task<AmazonOrder> GetOrder(int id);

        public Task InsertOrder(AmazonOrder order);
        public Task UpdateOrder(AmazonOrder order);

        public Task DeleteOrder(int id);

        //SumOfOrdercost and GetAllOrderByCountry
        public Task<List<AmazonOrder>> GetAllOrderByCountry(string name);
        public Task<List<AmazonOrder>> SumOfOrdersCostByCountryName(string name);

        //GetAllOredrsByCreatedDate and GetAllUserName
        public Task<List<AmazonOrder>> GetAllOrderByCreatedDate(DateTime dt);

        public Task<List<string>> GetAllUserName();

        //SumOfOrdercost2 and GetAllOrderByCountry2
        public Task<List<AmazonOrder>> GetAllOrderByCountry2(List<string> AC);
        public Task<List<SumOfOrdersByCountry>> SumOfOrdersByCountry();
    }
}
