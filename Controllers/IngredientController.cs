﻿using Microsoft.AspNetCore.Mvc;
using Proiect_Medii_Restaurantul_Meu.Data;
using Proiect_Medii_Restaurantul_Meu.Models;
using System.Runtime.CompilerServices;

namespace Proiect_Medii_Restaurantul_Meu.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredients;

        public IngredientController(ApplicationDbContext context)
        {
            ingredients = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await ingredients.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {

            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes = "ProductIngredients.Product" }));
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        //Creare ingredient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId, Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        //Eliminare ingredient
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>
            { Includes = "ProductIngredients.Product" }));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient ingredient)
        {
            await ingredients.DeleteAsync(ingredient.IngredientId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "ProductIngredients.Product" }));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await ingredients.UpdateAsync(ingredient);
                return RedirectToAction("Index");

            }
            return View(ingredients);
        }
    }
}
