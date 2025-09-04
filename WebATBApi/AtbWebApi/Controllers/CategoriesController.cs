﻿using Core.Interfaces;
using Core.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace AtbWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoriesService categoriesService) : Controller
{
    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        var model = await categoriesService.GetAllAsync();

        return Ok(model);
    }

    [HttpPost("create")]
    //[Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create([FromForm] CategoryCreateModel model)
    {
        var result = await categoriesService.CreateAsync(model);

        return Ok(result);
    }

    [HttpPut("edit")]
    //[Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Update([FromForm] CategoryEditModel model)
    {
        var result = await categoriesService.UpdateAsync(model);

        return Ok(result);
    }

    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug(string slug)
    {
        var result = await categoriesService.GetBySlugAsync(slug);

        return Ok(result);
    }

    [HttpDelete("delete")]
    //[Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Delete([FromBody] CategoryDeleteModel model)
    {
        await categoriesService.DeleteAsync(model);
        return Ok($"Category with id: {model.Id} deleted");
    }
}
