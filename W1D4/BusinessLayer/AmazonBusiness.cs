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

        public async Task DeleteAmazonCountry(int id)
        {
            await _amazonRepository.DeleteAmazonCountry(id);
        }

        public async Task<AmazonCountry> GetAmazonCountry(int id)
        {
            return await _amazonRepository.GetAmazonCountry(id);
        }

        public async Task<List<AmazonCountry>> GetAmazonCountries()
        {
            return await _amazonRepository.GetAmazonCountries();
        }

        public async Task InsertAmazonCountry(AmazonCountry amazoncountry)
        {
            await _amazonRepository.InsertAmazonCountry(amazoncountry);
        }

        public async Task UpdateAmazonCountry(AmazonCountry amazoncountry)
        {
            await _amazonRepository.UpdateAmazonCountry(amazoncountry);
        }

    }
}
