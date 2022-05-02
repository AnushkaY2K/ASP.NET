using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AmazonBusiness : IAmazonBusiness
    {
        private readonly IAmazonRepository _amazonRepository;

        public AmazonBusiness(IAmazonRepository amazonRepository)
        {
            _amazonRepository = amazonRepository;
        }

        //country 
        public async Task DeleteCountry(int id)
        {
            await _amazonRepository.DeleteCountry(id);
        }

        public async Task<AmazonCountry> GetCountry(int id)
        {
            return await _amazonRepository.GetCountry(id);
        }

        public async Task<List<AmazonCountry>> GetCountries()
        {
            return await _amazonRepository.GetCountries();
        }

        public async Task InsertCountry(AmazonCountry country)
        {
            await _amazonRepository.InsertCountry(country);
        }



        public async Task UpdateCountry(AmazonCountry country)
        {
            await _amazonRepository.UpdateCountry(country);
        }

        //orders
        public async Task<List<AmazonOrder>> GetOrders()
        {
            return await _amazonRepository.GetOrders();
        }

        public async Task DeleteOrder(int id)
        {
            await _amazonRepository.DeleteOrder(id);
        }

        public async Task<AmazonOrder> GetOrder(int id)
        {
            return await _amazonRepository.GetOrder(id);
        }
        public async Task InsertOrder(AmazonOrder order)
        {
            await _amazonRepository.InsertOrder(order);
        }

        public async Task UpdateOrder(AmazonOrder order)
        {
            await _amazonRepository.UpdateOrder(order);
        }

    }
}