﻿namespace Models.Contracts
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        bool PreserveCreatedOn { get; set; }
    }
}