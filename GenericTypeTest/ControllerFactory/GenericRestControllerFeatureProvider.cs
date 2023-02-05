using GenericTypeTest.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace GenericTypeTest.ControllerFactory
{
    /// <summary>
    /// EntityTypes sınıfında tanımladığımız entity modellerimizi döngü ile alarak feature controller dizilerine ekliyoruz...
    /// Böylece controller sınıfları oluşturulurken verdiğimiz entity model sınıflarına göre dinamik controller yapıları oluşturulacak...
    /// </summary>
    public class GenericRestControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var model_Type in EntityTypes.model_Types)
            {
                var entity_type = model_Type.Key;
                var entity_request_types = model_Type.Value[0];
                Type[] typeArgs = {entity_type, model_Type.Value[0], model_Type.Value[1] };
                var controller_type = typeof(WriteController<,,>).MakeGenericType(typeArgs).GetTypeInfo();
                feature.Controllers.Add(controller_type);

            }
        }
    }
}
