namespace Models.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public interface IFriendlyUrl
    {
        [Required]
        [MaxLength(50)]
        [RegularExpression(ModelConstants.FriendlyUrlsRegexValidator,
            ErrorMessage = ModelConstants.FriendlyUrlsValidatorErrorMessage)]
        string FriendlyUrl { get; set; }
    }
}