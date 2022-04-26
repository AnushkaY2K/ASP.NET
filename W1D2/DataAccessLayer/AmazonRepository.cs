using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AmazonRepository : IAmazonRepository
    {
        public async Task<List<AmazonCountry>> GetAmazonCountries()
        {
            return TempData.Data;
        }

        public async Task InsertAmazonCountry(AmazonCountry amazoncountry)
        {
            TempData.Data.Add(amazoncountry);
        }

        public async Task UpdateAmazonCountry(AmazonCountry amazoncountry)
        {
            foreach (var ac in TempData.Data)
            {
                if (ac.Id == amazoncountry.Id)
                {
                    ac.Name = amazoncountry.Name;
                }
            }
        }

        public async Task DeleteAmazonCountry(int id)
        {
            TempData.Data = TempData.Data.Where(x => x.Id != id).ToList();
        }

        public async Task<AmazonCountry> GetAmazonCountry(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            return TempData.Data.FirstOrDefault(x => x.Id == id);
        }

    }
}
