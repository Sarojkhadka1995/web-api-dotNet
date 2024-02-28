using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Filters.ExceptionFilters;
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
        return Ok(ShirtRepository.GetShirts());
    }

    [HttpGet("{id}")]
    [Shirt_ValidateShirtIdFilter]
    public IActionResult GetShirtsById(int id)
    {
        return Ok(ShirtRepository.GetShirtById(id));
    }

    [HttpPost]
    [Shirt_ValidateCreateShirtFilter]
    public IActionResult CreateShirt([FromBody] Shirt shirt)
    {
       
        ShirtRepository.AddShirts(shirt);

        return CreatedAtAction(nameof(GetShirtsById), new { id = shirt.ShirtId }, shirt);

    }

    [HttpPut("{id}")]
    [Shirt_ValidateShirtIdFilter]
    [Shirt_ValidateUpdateShirtFilter]
    [Shirt_HandleUpdateExceptionsFilter]
    public IActionResult UpdateShirt(int id, [FromBody] Shirt shirt)
    { 
        ShirtRepository.UpdateShirt(shirt);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Shirt_ValidateShirtIdFilter]
    public IActionResult DeleteShirt(int id)
    {
        var shirt = ShirtRepository.GetShirtById(id);
        ShirtRepository.DeleteShirt(id);
        return Ok(shirt);
    }
}