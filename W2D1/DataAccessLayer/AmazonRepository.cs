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
        public async Task<List<AmazonCountry>> GetCountries()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var countries = await dbContext.Amazons.ToListAsync();


                List<AmazonCountry> domainModels = new List<AmazonCountry>();

                foreach (var emp in countries)
                {
                    domainModels.Add(new AmazonCountry
                    {

                        Id = emp.Id,
                        Name = emp.Name,


                    });
                }

                return domainModels;
            }
        }

        public async Task InsertCountry(AmazonCountry country)
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Amazon
                {

                    Id = country.Id,
                    Name = country.Name,


                };

                dbContext.Amazons.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCountry(AmazonCountry country)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findCountry = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == country.Id);


                findCountry.Id = country.Id;
                findCountry.Name = country.Name;




                dbContext.Amazons.Update(findCountry);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task DeleteCountry(int id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findCountry = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Amazons.Remove(findCountry);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task<AmazonCountry> GetCountry(int id)
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var country = await dbContext.Amazons.FirstOrDefaultAsync(x => x.Id == id);
                AmazonCountry domainModel = new AmazonCountry
                {

                    Id = country.Id,
                    Name = country.Name,

                };

                return domainModel;
            }

        }

        //AmazonOrder 
        public async Task<List<AmazonOrder>> GetOrders()
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orders = await dbContext.Orders.ToListAsync();


                List<AmazonOrder> domainModels = new List<AmazonOrder>();

                foreach (var ord in orders)
                {
                    domainModels.Add(new AmazonOrder
                    {

                        Id = ord.Id,
                        UserName = ord.UserName,
                        Cost = ord.Cost,
                        ItemQty = ord.ItemQty,
                        CreatedDate = ord.CreatedDate,
                        UpdatedDate = ord.UpdatedDate,
                        AmazonId = ord.AmazonId,
                    });
                }

                return domainModels;
            }
        }

        
        public async Task<AmazonOrder> GetOrder(int id)
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
                AmazonOrder domainModel = new AmazonOrder
                {

                    Id = order.Id,
                    UserName = order.UserName,
                    Cost = order.Cost,
                    ItemQty = order.ItemQty,
                    CreatedDate = order.CreatedDate,
                    UpdatedDate = order.UpdatedDate,
                    AmazonId = order.AmazonId,

                };

                return domainModel;
            }

        }

        public async Task InsertOrder(AmazonOrder order)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {

                    Id = order.Id,
                    UserName = order.UserName,
                    Cost = order.Cost,
                    ItemQty = order.ItemQty,
                    CreatedDate = order.CreatedDate,
                    UpdatedDate = order.UpdatedDate,
                    AmazonId = order.AmazonId,

                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(AmazonOrder order)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);
                findOrder.Id = order.Id;
                findOrder.UserName = order.UserName;
                findOrder.Cost = order.Cost;
                findOrder.ItemQty = order.ItemQty;
                findOrder.UpdatedDate = order.UpdatedDate;
                findOrder.AmazonId = order.AmazonId;
                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }

        public async Task DeleteOrder(int id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            };
        }


        public async Task<List<AmazonOrder>> GetAllOrderByCountry(string name)
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var count = await dbContext.Orders.Include(x => x.Amazon).Where(x => x.Amazon.Name == name).ToListAsync();
                List<AmazonOrder> domainModels = new List<AmazonOrder>();



                foreach (var c in count)
                {
                    domainModels.Add(new AmazonOrder
                    {

                        Id = c.Id,
                        UserName = c.UserName,
                        ItemQty = c.ItemQty,
                        Cost = c.Cost,
                        CreatedDate = c.CreatedDate,
                        UpdatedDate = c.UpdatedDate,
                        AmazonId = c.AmazonId,


                    });

                }
                return domainModels;
            }

        }

       /* public async Task<List<AmazonOrder>> GetallOrdersBycountry(string name)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var count = await dbContext.Orders.Include(x => x.Amazon).Where(x => x.Amazon.Name == name).ToListAsync();


                List<AmazonOrder> domainModels = new List<AmazonOrder>();

                foreach (var c in count)
                {
                    domainModels.Add(new AmazonOrder
                    {

                        Id = c.Id,
                        UserName = c.UserName,
                        ItemQty = c.ItemQty,
                        Cost = c.Cost,
                        CreatedDate = c.CreatedDate,
                        UpdatedDate = c.UpdatedDate,
                        AmazonId = c.AmazonId,


                    }); 

                }

                return domainModels;


            }
        }*/



        public async Task<List<AmazonOrder>> SumOfOrdersCostByCountryName(string name)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {

                var count = await dbContext.Orders.Include(x => x.Amazon).Where(x => x.Amazon.Name == name).ToListAsync();

                List<AmazonOrder> domainModels = new List<AmazonOrder>();

                foreach (var c in count)
                {
                    domainModels.Add(new AmazonOrder
                    {

                        Id = c.Id,
                        UserName = c.UserName,
                        ItemQty = c.ItemQty,
                        Cost = c.Cost,

                    }); ;

                }

                return domainModels;

            }
        }

        
    }
}
