namespace Web.Infrastructure.ModelBinders
{
    using System.Web.Mvc;

    using Models;

    using Services.Contracts;

    public class EntityModelBinder<TEntity> : IModelBinder where TEntity : BaseModel
    {
        private readonly IEntityService<TEntity> service;

        public EntityModelBinder(IEntityService<TEntity> service)
        {
            this.service = service;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = int.Parse(value.AttemptedValue);
            var entity = this.service.GetBy(id);
            return entity;
        }
    }
}
