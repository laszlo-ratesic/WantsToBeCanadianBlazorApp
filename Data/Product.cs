using System;

namespace WantsToBeCanadianBlazorApp.Data;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
}
