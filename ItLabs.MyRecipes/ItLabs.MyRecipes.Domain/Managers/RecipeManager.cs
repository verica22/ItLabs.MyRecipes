using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System;
using System.Linq;
using ItLabs.MyRecipes.Data;

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
            var existingRecipe = _recipeRepository.GetRecipes().SingleOrDefault(x => x.Name.ToLower() == recipe.Name.ToLower());
            //Already exists recipe with this name
            if (existingRecipe != null)
            {
               
            }
            else
            {
                 //todo for updates
                // recipe.Id = 82;
                if (recipe.Id == 0)
                {
                    var newRecipe = new Data.Recipe { Name = recipe.Name, Description = recipe.Description, Done = recipe.Done, Favorites = recipe.Favorites };

                    foreach (var i in recipe.RecipeIngredients.ToList())
                    {
                        var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());

                        if (existingIngredient != null)
                        {
                            newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Quantity = i.Quantity, IngredientsId = existingIngredient.Id });
                        }
                        else
                        {
                            var ingredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
                            newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = ingredient, Quantity = i.Quantity });
                        }
                    }
                    var dbRecipe = Mapper.Map<Data.Recipe>(newRecipe);
                    _recipeRepository.Save(dbRecipe);
                }
                else
                {
                    var editRecipe = new Data.Recipe { Id = recipe.Id, Name = recipe.Name, Description = recipe.Description, Done = recipe.Done, Favorites = recipe.Favorites };

                    foreach (var i in recipe.RecipeIngredients.ToList())
                    {
                        var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());

                        if (existingIngredient != null)
                        {
                            editRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Quantity = i.Quantity, IngredientsId = existingIngredient.Id, RecipeId = recipe.Id });
                        }
                        else
                        {
                            var ingredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
                            editRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = ingredient, Quantity = i.Quantity, RecipeId = recipe.Id });
                        }
                    }
                    var dbRecipe = Mapper.Map<Data.Recipe>(editRecipe);
                    _recipeRepository.Save(dbRecipe);

                }

            }
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
