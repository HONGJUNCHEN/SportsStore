using StevenChen.SportStore.Domain.Concrete;
using StevenChen.SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevenChen.SportStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new EFDbContext())
            {
                ctx.Products.RemoveRange(ctx.Products);
                for (int i = 0; i < 100; i++)
                {
                    var product = new Product()
                    {
                        Name = "product1",
                        Price = 1m,
                        Description="desc",
                        Category="cate"
                    };
                    ctx.Products.Add(product);
                    ctx.SaveChanges();
                }
               
            }

            Console.ReadLine();
        }
    }
}
