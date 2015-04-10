namespace Models.Content
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class DateStamp
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}