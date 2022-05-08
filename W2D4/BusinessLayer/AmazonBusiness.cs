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

        //AmazonCountry 
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

        //AmazonOrders
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


        //GetAllOrderByCountry
        public async Task<List<AmazonOrder>> GetAllOrderByCountry(string name)
        {
            return await _amazonRepository.GetAllOrderByCountry(name);
        }


        //SumOfOrdersCostByCountryName
        public async Task<SumOfOrderCost> SumOfOrdersCostByCountryName(string name)
        {
            var Orders = await _amazonRepository.SumOfOrdersCostByCountryName(name);

            int CostSum = (int)Orders.Sum(x => x.Cost);

            SumOfOrderCost sum = new SumOfOrderCost();

            sum.CostSum = CostSum;
            return sum;

        }


        //GetAllOrderByCreatedDate
        public async Task<List<AmazonOrder>> GetAllOrderByCreatedDate(DateTime dt)
        {
            return await _amazonRepository.GetAllOrderByCreatedDate(dt);
        }


        //GetAllUserName
        public async Task<List<string>> GetAllUserName()
        {
            return await _amazonRepository.GetAllUserName();
        }

    }
}