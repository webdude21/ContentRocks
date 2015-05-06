namespace Web.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Models;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(BaseModel).IsAssignableFrom(modelType))
            {
                return null;
            }

            var modelBinderType = typeof(EntityModelBinder<>).MakeGenericType(modelType);
            var modelBinder = ObjectFactory.GetInstance(modelBinderType);

            return (IModelBinder)modelBinder;
        }
    }
}
