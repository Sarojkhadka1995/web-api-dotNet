using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.controllers;

[ApiController]
[Route("api/[controller]")]
public class ShirtController : ControllerBase
{
    [HttpGet]
    public IActionResult GetShirts()
    {
        return Ok("Reading shirts");
    }

    [HttpGet("{id}")]
    [Shirt_ValidateShirtIdFilter]
    public IActionResult GetShirtsById(int id)
    {
        return Ok(ShirtRepository.GetShirtById(id));
    }

    [HttpPost]
    
    public IActionResult CreateShirt([FromBody] Shirt shirt)
    {
        return Ok("Post shirt");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateShirt(int id, [FromQuery] string color)
    {
        return Ok($"Update shirt : {id}, color : {color}");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteShirt(int id)
    {
        return Ok($"Delete shirt: {id}");
    }
}