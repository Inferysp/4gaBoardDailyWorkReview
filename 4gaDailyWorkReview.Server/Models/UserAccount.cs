using System;
using System.Collections.Generic;

namespace _4gaDailyWorkReview.Server.Models;

public partial class UserAccount
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public bool IsAdmin { get; set; }

    public string Name { get; set; } = null!;

    public string? Username { get; set; }

    public string? Phone { get; set; }

    public string? Organization { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? PasswordChangedAt { get; set; }

    public string? Avatar { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? SsoGoogleEmail { get; set; }

    public string? SsoGithubId { get; set; }

    public string? SsoMicrosoftId { get; set; }

    public string? SsoGoogleId { get; set; }

    public string? SsoGithubUsername { get; set; }

    public string? SsoMicrosoftEmail { get; set; }

    public long CreatedById { get; set; }

    public long? UpdatedById { get; set; }

    public string? SsoOidcId { get; set; }

    public string? SsoOidcEmail { get; set; }

    public string? SsoGithubEmail { get; set; }
}
