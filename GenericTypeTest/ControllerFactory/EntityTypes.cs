using GenericTypeTest.Dtos.CategoryDto;
using GenericTypeTest.Dtos.ProductDto;
using GenericTypeTest.Models;
using System.Reflection;

namespace GenericTypeTest.ControllerFactory
{
    /// <summary>
    /// Oluşturduğumuz entity modellerinin response ve request sınıflarını typeInfo ile aldığımı sınıf...
    /// Bu sınıf ile verdiğimiz entity modelleri generic sınıflarda typeInfo tiplerinden tespit edilerek sınıfın iletilmesini sağlar...
    /// </summary>
    public class EntityTypes
    {
        public static Dictionary<TypeInfo, List<TypeInfo>> model_Types => new Dictionary<TypeInfo, List<TypeInfo>>()
        {
            {
                typeof(Product).GetTypeInfo(),new List<TypeInfo>(){typeof(ProductWriteDto).GetTypeInfo(), typeof(ProductReadDto).GetTypeInfo()}
            },
            {
                typeof(Category).GetTypeInfo(),new List<TypeInfo>(){typeof(CategoryWriteDto).GetTypeInfo(), typeof(ProductReadDto).GetTypeInfo() }
            }
        };
    }
}
