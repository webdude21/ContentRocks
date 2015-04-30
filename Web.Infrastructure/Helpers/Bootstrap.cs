namespace Web.Infrastructure.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    // <label>Name</label>
    // <div class="row margin-bottom-20">
    //     <div class="col-md-7 col-md-offset-0">
    //         <input type="text" class="form-control">
    //     </div>
    // </div>
    public static class Bootstrap
    {
        public static MvcHtmlString BootstrapFormTextAreaFor<TModel, TValue>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var propertyName = metaData.PropertyName;

            return BuildFormControl(propertyName, htmlAttributes, GenerateTextArea);
        }

        public static MvcHtmlString BootstrapFormTextInputFor<TModel, TValue>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var propertyName = metaData.PropertyName;

            return BuildFormControl(propertyName, htmlAttributes, GenerateTextBox);
        }

        public static MvcHtmlString BootstrapSubmitButton(
            this HtmlHelper helper,
            string value,
            object htmlAttributes = null)
        {
            var submitButton = new TagBuilder("input");
            submitButton.AddCssClass("btn btn-default");
            submitButton.Attributes.Add("type", "submit");
            submitButton.Attributes.Add("value", value);
            submitButton.ApplyAttributes(htmlAttributes);
            return new MvcHtmlString(submitButton.ToString());
        }

        private static void ApplyAttributes(this TagBuilder tagBuilder, object htmlAttributes)
        {
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tagBuilder.MergeAttributes(attributes);
            }
        }

        private static MvcHtmlString BuildFormControl(
            string name,
            object htmlAttributes,
            Func<string, object, TagBuilder> inputElement)
        {
            var input = inputElement(name, htmlAttributes);
            var label = GenerateLabel(name);
            label.Attributes.Add("for", input.Attributes["id"]);
            var outerDiv = GenerateOuterDiv();
            var innerDiv = GenerateInnerDiv();


            innerDiv.InnerHtml = label + input.ToString();
            outerDiv.InnerHtml = innerDiv.ToString();

            return new MvcHtmlString(outerDiv.ToString());
        }

        private static TagBuilder GenerateInnerDiv()
        {
            var innerDiv = new TagBuilder("div");
            innerDiv.AddCssClass("col-md-10");
            return innerDiv;
        }

        private static TagBuilder GenerateLabel(string name)
        {
            var label = new TagBuilder("label");
            label.AddCssClass("control-label col-md-2");
            label.SetInnerText(name);
            return label;
        }

        private static TagBuilder GenerateOuterDiv()
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("form-group");
            return outerDiv;
        }

        private static TagBuilder GenerateTextArea(string name, object htmlAttributes)
        {
            var textArea = new TagBuilder("textarea");
            textArea.AddCssClass("form-control");
            textArea.Attributes.Add("name", name);
            textArea.Attributes.Add("id", HtmlHelper.GenerateIdFromName(name));
            textArea.ApplyAttributes(htmlAttributes);

            return textArea;
        }

        private static TagBuilder GenerateTextBox(string name, object htmlAttributes)
        {
            var input = new TagBuilder("input");
            input.AddCssClass("form-control");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("name", name);
            input.Attributes.Add("id", HtmlHelper.GenerateIdFromName(name));
            input.ApplyAttributes(htmlAttributes);

            return input;
        }
    }
}