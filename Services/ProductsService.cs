using System;
using WantsToBeCanadianBlazorApp.Data;

namespace WantsToBeCanadianBlazorApp.Services;

public class ProductsService
{
    private readonly AppDbContext _context;

    public ProductsService(AppDbContext context)
    {
        _context = context;

        // Ignore this, this is just me seeding the in-memory database with some dummy data
        if (!_context.Products.Any())
        {
            _context.Products.AddRange(new Product { Name = "Milk", Price = 2.99 },
                                       new Product { Name = "Bread", Price = 1.99 },
                                       new Product { Name = "Eggs", Price = 3.99 });
            _context.SaveChanges();
        }
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProduct(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = _context.Products.Find(product.Id);

        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
