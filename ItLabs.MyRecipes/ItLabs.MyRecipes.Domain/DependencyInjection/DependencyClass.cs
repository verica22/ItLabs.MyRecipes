
using Autofac;
using ItLabs.MyRecipes.Data.Repository;
using ItLabs.MyRecipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ItLabs.MyRecipes.Domain.DependencyInjection
{
    public class DependencyClass
    {
        static void main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RecipeRepository>().As<IRecipeRepository>();

            var container = builder.Build();
            container.Resolve<IRecipeRepository>();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
