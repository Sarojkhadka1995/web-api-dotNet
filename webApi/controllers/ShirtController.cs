using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.controllers;

[ApiController]
[Route("api/[controller]")]
public class ShirtController : ControllerBase
{
    private List<Shirt> shirts = new List<Shirt>()
    {
        new Shirt { ShirtId = 1, Brand = "Brand1", Color = "Blue", Gender = "Male", Price = 80, Size = 10 },
        new Shirt { ShirtId = 2, Brand = "My Brand2", Color = "Yellow", Gender = "Male", Price = 100, Size = 11 },
        new Shirt { ShirtId = 3, Brand = "My Brand3", Color = "Red", Gender = "Male", Price = 70, Size = 9 },
        new Shirt { ShirtId = 4, Brand = "Brand4", Color = "Black", Gender = "Female", Price = 60, Size = 7 },
        new Shirt { ShirtId = 5, Brand = "Brand5", Color = "Blue", Gender = "Female", Price = 40, Size = 6 },
    };
    
    [HttpGet]
    public string GetShirts()
    {
        return "Reading shirts";
    }

    [HttpGet("/{id}")]
    
    public IActionResult GetShirtsById(int id)
    {
        if (id <= 0) return BadRequest(); 
        var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
        if (shirt == null)
            return NotFound();
        
        return Ok(shirt);
        
        
    }

    [HttpPost]
    
    public IActionResult CreateShirt([FromBody] Shirt shirt)
    {
        return Ok("Post shirt");
    }

    [HttpPut("/{id}")]
    public IActionResult UpdateShirt(int id, [FromQuery] string color)
    {
        return Ok($"Update shirt : {id}, color : {color}");
    }

    [HttpDelete("/{id}")]
    public IActionResult DeleteShirt(int id)
    {
        return Ok($"Delete shirt: {id}");
    }
}