using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IAmazonRepository
    {
        public Task<List<AmazonCountry>> GetAmazonCountries();
        public Task<AmazonCountry> GetAmazonCountry(int id);
        public Task InsertAmazonCountry(AmazonCountry amazoncountry);
        public Task UpdateAmazonCountry(AmazonCountry amazoncountry);
        public Task DeleteAmazonCountry(int id);
    }
}
