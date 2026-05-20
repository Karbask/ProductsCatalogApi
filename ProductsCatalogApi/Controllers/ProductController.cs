using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductController: ControllerBase
{
    private static List<Product> products = new List<Product> ();
    
    //GET: Retrieve all products
    [HttpGet]
    public ActionResult<List<Product>> GetAll() => products;
    //GET: Retrieve a specific product by ID
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return product;
    }
    //POST: Create a new product
    [HttpPost]
    public ActionResult<Product> Create(Product newProduct)
    {
        newProduct.Id = products.Count  + 1;
        products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    //PUT: Update an existing product
    [HttpPut("{id}")]
    public ActionResult Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        
        product.Name = updatedProduct.Name;
        product.Description = updatedProduct.Description;
        product.Price = updatedProduct.Price;

        return Ok(product);
    }

    //DELETE: Remove a product
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        
        products.Remove(product);
        return NoContent();
    }



}