namespace Web.Models
{
    using System.Collections.Generic;

    public class SeoViewModel
    {
        public string Description { get; set; }

        public string FriendlyUrl { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string Title { get; set; }
    }
}