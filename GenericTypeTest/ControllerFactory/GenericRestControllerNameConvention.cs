using GenericTypeTest.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GenericTypeTest.ControllerFactory
{
    /// <summary>
    /// GenericRestControllerFeatureProvider sınıfı ile EntityTypes üzerinde verdiğimi entity modellerine ait değerleri okuyarak Feature controller dizisine eklemelerini yapılmıştı. Bu diziler sonrasında bu sınıf üzerinde dizi sayısı kadar controller sınıfları oluşturulur...
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericRestControllerNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType || controller.ControllerType.GetGenericTypeDefinition() != typeof(WriteController<,,>))
            {
                return;
            }
            var entityType = controller.ControllerType.GetGenericArguments()[0];    
            controller.ControllerName =  entityType.Name;
            controller.RouteValues["Controller"] = entityType.Name;
        }
    }
}
