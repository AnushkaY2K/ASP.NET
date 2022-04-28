using DataAccessLayer.Models;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
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
            //return TempData.Data;
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orders = await dbContext.Orders.ToListAsync();

                List<AmazonCountry> domainModels = new List<AmazonCountry>();
                // For reading convert dbModel to domain model 
                foreach (var ord in orders)
                {
                    domainModels.Add(new AmazonCountry
                    {
                        ID = ord.Id,
                        UserName = ord.UserName,
                        Cost = ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonID = ord.AmazonId
                    });
                }
                return domainModels;

            }
        }

        public async Task InsertAmazonCountry(AmazonCountry order)
        {
            // TempData.Data.Add(amazoncountry);
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                // For inserting convert domain model to dbmodel 

                var dbModel = new Order
                {
                    
                    UserName = order.UserName,
                    Cost = (int?)order.Cost,
                    ItemQty = order.ItemQty,
                    CreatedDate = (DateTime?)order.CreatedDate,
                    UpdatedDate = (DateTime?)order.UpdatedDate,
                    AmazonId = (int)order.AmazonID
                    
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAmazonCountry(AmazonCountry orders)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orders.ID);

                findOrder.UserName = orders.UserName;
                findOrder.Cost = (int?)orders.Cost;
                findOrder.ItemQty = orders.ItemQty;
                findOrder.CreatedDate = (DateTime?)orders.CreatedDate;
                findOrder.UpdatedDate = (DateTime?)orders.UpdatedDate;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }

            // foreach (var ac in TempData.Data)
            // {
            //     if (ac.Id == amazoncountry.Id)
            //     {
            //         ac.Name = amazoncountry.Name;
            //     }
            // }
        }

        public async Task DeleteAmazonCountry(int id)
        {
            // TempData.Data = TempData.Data.Where(x => x.Id != id).ToList();
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AmazonCountry> GetAmazonCountry(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            // return TempData.Data.FirstOrDefault(x => x.Id == id);
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                AmazonCountry domainModel = new AmazonCountry
                {
                    AmazonID = order.AmazonId,
                    ID = order.Id,
                    UserName = order.UserName,
                    Cost = (int)order.Cost,
                    ItemQty = order.ItemQty,
                    CreatedDate = (DateTime?)order.CreatedDate,
                    UpdatedDate = (DateTime?)order.UpdatedDate

                };

                return domainModel;

            }
        }

    }
}
