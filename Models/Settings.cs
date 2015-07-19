namespace Models
{
    public class Settings : BaseModel
    {
        public string FacebookApiKey { get; set; }

        public string FacebookSecretKey { get; set; }

        public string HomeAdvert { get; set; }

        public int PageSize { get; set; }

        public string FooterLink { get; set; }
    }
}