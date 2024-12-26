﻿

using Microsoft.EntityFrameworkCore;

namespace BookShoppingCartMvcUI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetCategoris()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                         join category in _db.Categories
                         on product.CategoryId equals category.Id
                         join stock in _db.Stocks
                         on product.Id equals stock.ProductId
                         into book_stocks
                         from bookWithStock in book_stocks.DefaultIfEmpty()
                         where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.ProductName.ToLower().StartsWith(sTerm))
                         select new Product
                         {
                             Id = product.Id,
                             Image = product.Image,
                             Description = product.Description,
                             ProductName = product.ProductName,
                             CategoryId = product.CategoryId,
                             Price = product.Price,
                             CategoryName = category.CategoryName,
                             Quantity= product.Quantity   //bookWithStock==null? 0:bookWithStock.Quantity
                         }
                         ).ToListAsync();
            if (categoryId > 0)
            {

                products = products.Where(a => a.CategoryId == categoryId).ToList();
            }
            return products;

        }
    }
}