namespace Common
{
    using System.Collections.Generic;
    using System.IO;

    using Common.Contracts;

    using Config;

    using Models.Content;
    using Models.SEO;

    public class ContentFactory : IContentFactory
    {
        private readonly IRandomDataGenerator randomGenerator;

        public ContentFactory(IRandomDataGenerator randomDataGenerator)
        {
            this.randomGenerator = randomDataGenerator;
        }

        public Category GetCategory(int id)
        {
            return new Category { Id = id, Title = this.randomGenerator.GetString(10, 255) };
        }

        public Post GetPost(int id)
        {
            return new Post
                       {
                           Id = id,
                           FriendlyUrl = this.randomGenerator.GetUrlSafeString(4, 10),
                           MetaDescription = this.randomGenerator.GetString(4, 10),
                           Tags = new List<Tag> { new Tag { Name = this.randomGenerator.GetString(5, 10) },
                               new Tag { Name = this.randomGenerator.GetString(5, 10) } },
                           Title = this.randomGenerator.GetString(4, 10),
                           MetaTitle = this.randomGenerator.GetString(5, 10),
                           PostedOn = this.randomGenerator.GeneraDateTime(),
                           ModifiedOn = this.randomGenerator.GeneraDateTime(),
                           CreatedOn = this.randomGenerator.GeneraDateTime()
                       };
        }

        public Post GetRealisticPost()
        {
            return new Post
                       {
                           FriendlyUrl = "css-градиенти-от-изображение",
                           MetaDescription = this.randomGenerator.GetString(4, 10),
                           Tags = new List<Tag> { new Tag { Name = this.randomGenerator.GetString(3, 10) } },
                           Title = "КАК ДА ГЕНЕРИРАМЕ CSS КОД ЗА ПО-СЛОЖНИ ГРАДИЕНТИ (ПРЕЛИВКИ) ОТ ДАДЕНО ИЗОБРАЖЕНИЕ",
                           MetaTitle = "КАК ДА ГЕНЕРИРАМЕ CSS КОД ЗА ПО-СЛОЖНИ ГРАДИЕНТИ (ПРЕЛИВКИ) ОТ ДАДЕНО ИЗОБРАЖЕНИЕ",
                           PostedOn = this.randomGenerator.GeneraDateTime(),
                           ModifiedOn = this.randomGenerator.GeneraDateTime(),
                           CreatedOn = this.randomGenerator.GeneraDateTime(),
                           Content = @"<div class=""entry-content"">
    <p style=""text-align: justify;"">Генерирането на градиенти от 2, 3 или 4 цветови точки е сравнително лесно и е много по-добре да се прави с mixin-и, но когато зададения ни градиент е сложен, а нямаме време да го налучкваме, може да се възползваме от възможността за генериране на CSS код за градиент от картинка.</p>
    <p style=""text-align: justify;"">Това става доста бързо, и според мен е точно. Ето как става:</p>
    <p style=""text-align: justify;"">В случая съм използвал генератора на градиенти на ColorZilla, но вероятно има и други варианти.</p>
    <p style=""text-align: justify;"">1-во – отиваме в любимия си (или който имаме) редактор на изображения и изрязваме парче от градиента. Както може би се досещате е важно да изрежете целия градиент по оста по която няма повторения (в този случаи по вертикалната), а по-другата ос изрежете колкото можете/искате. След това запишете файла във формат който е некомпресиран и не губи цветова информация (jpeg не е такъв).</p>
    <p style=""text-align: justify;"">2-ро – след като вече имате файла отивате на генератора на градиенти на <a href=""http://www.colorzilla.com/gradient-editor/"" rel=""nofollow"">ColorZilla</a> в секцията „CSS” (където стои кода) и натискате „import from image”, след това „Choose File”, избирате файла който сте направили и натискате “import”. След това вече имате готов генериран градиент и ви остава само да си го копирате в кода.</p>
    <p style=""text-align: justify;"">Малко изображения в случай, че не ви е станало ясно:</p>
    <p style=""text-align: justify;"">
    </p>
</div>"
                       };
        }
    }
}