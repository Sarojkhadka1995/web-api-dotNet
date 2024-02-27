using Microsoft.AspNetCore.Mvc;

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
    
    public string GetShirtsId(int id)
    {
        return $"Reading shirt :{id}";
        
    }

    [HttpPost]
    
    public string CreateShirt()
    {
        return "Post shirt";
    }

    [HttpPut("/{id}")]
    public string UpdateShirt(int id)
    {
        return $"Update shirt : {id}";
    }

    [HttpDelete("/{id}")]
    public string DeleteShirt(int id)
    {
        return $"Delete shirt: {id}";
    }
}