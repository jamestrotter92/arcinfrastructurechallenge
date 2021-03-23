using ArcInfrastructure.ShapeAreaCalculator.Core;
using ArcInfrastructure.ShapeAreaCalculator.Core.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace ArcInfrastructure.ShapeAreaCalculator.Web.Extensions
{
    public static class ShapeFactoryServiceCollectionExtensions
    {
        public static IServiceCollection AddShapeFactoryWithDefaults(this IServiceCollection services)
        {
            var shapeFactory = new ShapeFactory();

            var defaults = DefaultRegistrations.AllDefaults;

            foreach (var registration in defaults)
            {
                shapeFactory.RegisterShape(registration);
            }

            return services.AddSingleton<IShapeFactory>(shapeFactory);
        }
    }
}
