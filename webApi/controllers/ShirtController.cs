using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.controllers;

[ApiController]
[Route("api/[controller]")]
public class ShirtController : ControllerBase
{
    [HttpGet]
    
    public string GetShirts()
    {
        return "Reading shirts";
    }

    [HttpGet("/{id}")]
    
    public string GetShirtsById(int id, [FromHeader(Name = "color")] string color)
    {
        return $"Reading shirt :{id}, color :{color}";
        
    }

    [HttpPost]
    
    public string CreateShirt([FromBody] Shirt shirt)
    {
        return "Post shirt";
    }

    [HttpPut("/{id}")]
    public string UpdateShirt(int id, [FromQuery] string color)
    {
        return $"Update shirt : {id}, color : {color}";
    }

    [HttpDelete("/{id}")]
    public string DeleteShirt(int id)
    {
        return $"Delete shirt: {id}";
    }
}