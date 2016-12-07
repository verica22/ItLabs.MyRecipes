
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


            // Register MVC-related dependencies
            //    var builder = new ContainerBuilder();
            //    builder.RecipeRepository(typeof(IRecipeRepository).Assembly);
            //    builder.RegisterModelBinders(typeof(IRecipeRepository).Assembly);
            //    builder.RegisterModule<AutofacWebTypesModule>();

            //    // Register e-mail service
            //    builder.RegisterType<EmailSenderToDebug>().As<IEmailSender>().InstancePerHttpRequest();

            //    builder.RegisterModelBinderProvider();

            //    // Set the MVC dependency resolver to use Autofac
            //    var container = builder.Build();
            //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //}
        }
    }
}
