﻿using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System;

namespace ItLabs.MyRecipes.Domain.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public IRecipeRepository _recipeRepository { get; set; }

        public RecipeManager(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            var dbRecipes = _recipeRepository.GetRecipes();
            var recipes = Mapper.Map<IEnumerable<Recipe>>(dbRecipes);
            return recipes;
        }

        public void Save(Recipe recipe)
        {
            var dbRecipe = Mapper.Map<Data.Recipe>(recipe);

            _recipeRepository.Save(dbRecipe);
        }

        public void Remove(int Id)
        {
            _recipeRepository.Remove(Id);
        }
        public void Edit(Recipe recipe)
        {
            var dbRecipe = Mapper.Map<Data.Recipe>(recipe);
            _recipeRepository.Edit(dbRecipe);
        }
        public Recipe FindById(int Id)
        {
            var result = _recipeRepository.FindById(Id);
            return Mapper.Map<Recipe>(result);
           
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            var dbIngredients = _recipeRepository.GetIngredients();
            var ingredient = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredient;
        }

        
    }
}
