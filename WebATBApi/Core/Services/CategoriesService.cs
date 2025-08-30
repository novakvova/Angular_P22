﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;
using Core.Interfaces;
using Core.Models.Category;

namespace Core.Services;

public class CategoriesService(
    AppDbAtbContext context,
    IMapper mapper,
    IImageService imageService) : ICategoriesService
{
    public async Task<CategoryItemModel> CreateAsync(CategoryCreateModel model)
    {
        var entity = mapper.Map<CategoryEntity>(model);
        if (model.ImageFile != null)
        {
            entity.Image = await imageService.SaveImageAsync(model.ImageFile);
        }
        await context.Categories.AddAsync(entity);
        await context.SaveChangesAsync();

        var mapped = mapper.Map<CategoryItemModel>(entity);
        return mapped;
    }

    public async Task<CategoryItemModel> UpdateAsync(CategoryEditModel model)
    {

        var existing = await context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);
        existing = mapper.Map(model, existing);

        if (model.ImageFile != null)
        {
            await imageService.DeleteImageAsync(existing.Image);
            existing.Image = await imageService.SaveImageAsync(model.ImageFile);
        }

        await context.SaveChangesAsync();

        var mapped = mapper.Map<CategoryItemModel>(existing);
        return mapped;
    }

    public async Task<CategoryItemModel> GetByIdAsync(int id)
    {
        var model = await context.Categories
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectTo<CategoryItemModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return model;
    }

    public async Task<CategoryItemModel> GetBySlugAsync(string slug)
    {
        var model = await context.Categories
            .AsNoTracking()
            .Where(x => x.Slug == slug)
            .ProjectTo<CategoryItemModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return model;
    }

    public async Task<IEnumerable<CategoryItemModel>> GetAllAsync()
    {
        return await context.Categories
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .ProjectTo<CategoryItemModel>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task DeleteAsync(CategoryDeleteModel model)
    {
        var entity = await context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

        entity.IsDeleted = true;

        await context.SaveChangesAsync();

    }
}
