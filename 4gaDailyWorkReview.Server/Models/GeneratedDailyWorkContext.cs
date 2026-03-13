using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _4gaDailyWorkReview.Server.Models;

public partial class GeneratedDailyWorkContext : DbContext
{
    public GeneratedDailyWorkContext()
    {
    }

    public GeneratedDailyWorkContext(DbContextOptions<GeneratedDailyWorkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Archive> Archives { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Board> Boards { get; set; }

    public virtual DbSet<BoardMembership> BoardMemberships { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardLabel> CardLabels { get; set; }

    public virtual DbSet<CardMembership> CardMemberships { get; set; }

    public virtual DbSet<CardSubscription> CardSubscriptions { get; set; }

    public virtual DbSet<Core> Cores { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<MigrationLock> MigrationLocks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectManager> ProjectManagers { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskMembership> TaskMemberships { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserPref> UserPrefs { get; set; }

    public virtual DbSet<UserProject> UserProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=4gaBoardDbInstance;Username=kkdev;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("action_pkey");

            entity.ToTable("action");

            entity.HasIndex(e => e.CardId, "action_card_id_index");

            entity.HasIndex(e => e.Type, "action_type_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.BoardId)
                .HasMaxLength(255)
                .HasColumnName("board_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(255)
                .HasColumnName("project_id");
            entity.Property(e => e.Scope)
                .HasMaxLength(255)
                .HasDefaultValueSql("'card'::character varying")
                .HasColumnName("scope");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Archive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("archive_pkey");

            entity.ToTable("archive");

            entity.HasIndex(e => new { e.FromModel, e.OriginalRecordId }, "archive_from_model_original_record_id_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FromModel).HasColumnName("from_model");
            entity.Property(e => e.OriginalRecord)
                .HasColumnType("json")
                .HasColumnName("original_record");
            entity.Property(e => e.OriginalRecordId).HasColumnName("original_record_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attachment_pkey");

            entity.ToTable("attachment");

            entity.HasIndex(e => e.CardId, "attachment_card_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Dirname).HasColumnName("dirname");
            entity.Property(e => e.Filename).HasColumnName("filename");
            entity.Property(e => e.Image)
                .HasColumnType("jsonb")
                .HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("board_pkey");

            entity.ToTable("board");

            entity.HasIndex(e => e.Position, "board_position_index");

            entity.HasIndex(e => e.ProjectId, "board_project_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.GithubRepo)
                .HasDefaultValueSql("''::text")
                .HasColumnName("github_repo");
            entity.Property(e => e.IsGithubConnected)
                .HasDefaultValue(false)
                .HasColumnName("is_github_connected");
            entity.Property(e => e.IsImportedBoard)
                .HasDefaultValue(false)
                .HasColumnName("is_imported_board");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<BoardMembership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("board_membership_pkey");

            entity.ToTable("board_membership");

            entity.HasIndex(e => new { e.BoardId, e.UserId }, "board_membership_board_id_user_id_unique").IsUnique();

            entity.HasIndex(e => e.UserId, "board_membership_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.CanComment).HasColumnName("can_comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.MigrateAddedProjectManagers)
                .HasDefaultValue(false)
                .HasColumnName("migrate_added_project_managers");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_pkey");

            entity.ToTable("card");

            entity.HasIndex(e => e.BoardId, "card_board_id_index");

            entity.HasIndex(e => e.ListId, "card_list_id_index");

            entity.HasIndex(e => e.Position, "card_position_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.CommentCount)
                .HasDefaultValue(0)
                .HasColumnName("comment_count");
            entity.Property(e => e.CoverAttachmentId).HasColumnName("cover_attachment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("due_date");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Timer)
                .HasColumnType("jsonb")
                .HasColumnName("timer");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<CardLabel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_label_pkey");

            entity.ToTable("card_label");

            entity.HasIndex(e => new { e.CardId, e.LabelId }, "card_label_card_id_label_id_unique").IsUnique();

            entity.HasIndex(e => e.LabelId, "card_label_label_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.LabelId).HasColumnName("label_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<CardMembership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_membership_pkey");

            entity.ToTable("card_membership");

            entity.HasIndex(e => new { e.CardId, e.UserId }, "card_membership_card_id_user_id_unique").IsUnique();

            entity.HasIndex(e => e.UserId, "card_membership_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<CardSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_subscription_pkey");

            entity.ToTable("card_subscription");

            entity.HasIndex(e => new { e.CardId, e.UserId }, "card_subscription_card_id_user_id_unique").IsUnique();

            entity.HasIndex(e => e.UserId, "card_subscription_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IsPermanent).HasColumnName("is_permanent");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Core>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("core_pkey");

            entity.ToTable("core");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.AllowedRegisterDomains)
                .HasDefaultValueSql("'[]'::json")
                .HasColumnType("json")
                .HasColumnName("allowed_register_domains");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.LocalRegistrationEnabled)
                .HasDefaultValue(true)
                .HasColumnName("local_registration_enabled");
            entity.Property(e => e.ProjectCreationAllEnabled)
                .HasDefaultValue(true)
                .HasColumnName("project_creation_all_enabled");
            entity.Property(e => e.RegistrationEnabled)
                .HasDefaultValue(true)
                .HasColumnName("registration_enabled");
            entity.Property(e => e.SsoRegistrationEnabled)
                .HasDefaultValue(true)
                .HasColumnName("sso_registration_enabled");
            entity.Property(e => e.SyncSsoAdminOnAuth)
                .HasDefaultValue(false)
                .HasColumnName("sync_sso_admin_on_auth");
            entity.Property(e => e.SyncSsoDataOnAuth)
                .HasDefaultValue(false)
                .HasColumnName("sync_sso_data_on_auth");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("label_pkey");

            entity.ToTable("label");

            entity.HasIndex(e => e.BoardId, "label_board_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_pkey");

            entity.ToTable("list");

            entity.HasIndex(e => e.BoardId, "list_board_id_index");

            entity.HasIndex(e => e.Position, "list_position_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.IsCollapsed)
                .HasDefaultValue(false)
                .HasColumnName("is_collapsed");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("migration_pkey");

            entity.ToTable("migration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.MigrationTime).HasColumnName("migration_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MigrationLock>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("migration_lock_pkey");

            entity.ToTable("migration_lock");

            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.IsLocked).HasColumnName("is_locked");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_pkey");

            entity.ToTable("notification");

            entity.HasIndex(e => e.ActionId, "notification_action_id_index");

            entity.HasIndex(e => e.CardId, "notification_card_id_index");

            entity.HasIndex(e => e.IsRead, "notification_is_read_index");

            entity.HasIndex(e => e.UserId, "notification_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.Background)
                .HasColumnType("jsonb")
                .HasColumnName("background");
            entity.Property(e => e.BackgroundImage)
                .HasColumnType("jsonb")
                .HasColumnName("background_image");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<ProjectManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_manager_pkey");

            entity.ToTable("project_manager");

            entity.HasIndex(e => new { e.ProjectId, e.UserId }, "project_manager_project_id_user_id_unique").IsUnique();

            entity.HasIndex(e => e.UserId, "project_manager_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("session_pkey");

            entity.ToTable("session");

            entity.HasIndex(e => e.AccessToken, "session_access_token_unique").IsUnique();

            entity.HasIndex(e => e.RemoteAddress, "session_remote_address_index");

            entity.HasIndex(e => e.UserId, "session_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.RemoteAddress).HasColumnName("remote_address");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("task");

            entity.HasIndex(e => e.CardId, "task_card_id_index");

            entity.HasIndex(e => e.Position, "task_position_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DueDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("due_date");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
        });

        modelBuilder.Entity<TaskMembership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_membership_pkey");

            entity.ToTable("task_membership");

            entity.HasIndex(e => new { e.TaskId, e.UserId }, "task_membership_task_id_user_id_unique").IsUnique();

            entity.HasIndex(e => e.UserId, "task_membership_user_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pkey");

            entity.ToTable("user_account");

            entity.HasIndex(e => e.Email, "user_email_unique").HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => e.Username, "user_username_unique").HasFilter("((username IS NOT NULL) AND (deleted_at IS NULL))");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasColumnType("jsonb")
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Organization).HasColumnName("organization");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PasswordChangedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("password_changed_at");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.SsoGithubEmail).HasColumnName("sso_github_email");
            entity.Property(e => e.SsoGithubId).HasColumnName("sso_github_id");
            entity.Property(e => e.SsoGithubUsername).HasColumnName("sso_github_username");
            entity.Property(e => e.SsoGoogleEmail).HasColumnName("sso_google_email");
            entity.Property(e => e.SsoGoogleId).HasColumnName("sso_google_id");
            entity.Property(e => e.SsoMicrosoftEmail).HasColumnName("sso_microsoft_email");
            entity.Property(e => e.SsoMicrosoftId).HasColumnName("sso_microsoft_id");
            entity.Property(e => e.SsoOidcEmail).HasColumnName("sso_oidc_email");
            entity.Property(e => e.SsoOidcId).HasColumnName("sso_oidc_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<UserPref>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_prefs_pkey");

            entity.ToTable("user_prefs");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.AttachmentsShown)
                .HasDefaultValue(true)
                .HasColumnName("attachments_shown");
            entity.Property(e => e.CommentMode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'edit'::character varying")
                .HasColumnName("comment_mode");
            entity.Property(e => e.CommentsShown)
                .HasDefaultValue(true)
                .HasColumnName("comments_shown");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultView)
                .HasMaxLength(255)
                .HasDefaultValueSql("'board'::character varying")
                .HasColumnName("default_view");
            entity.Property(e => e.DescriptionMode)
                .HasMaxLength(255)
                .HasDefaultValueSql("'edit'::character varying")
                .HasColumnName("description_mode");
            entity.Property(e => e.DescriptionShown)
                .HasDefaultValue(true)
                .HasColumnName("description_shown");
            entity.Property(e => e.HideCardModalActivity)
                .HasDefaultValue(false)
                .HasColumnName("hide_card_modal_activity");
            entity.Property(e => e.HideClosestDueDate)
                .HasDefaultValue(false)
                .HasColumnName("hide_closest_due_date");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.ListViewColumnVisibility)
                .HasDefaultValueSql("'{\"name\": true, \"tasks\": true, \"timer\": true, \"users\": true, \"labels\": true, \"actions\": true, \"dueDate\": true, \"coverUrl\": false, \"listName\": true, \"createdAt\": false, \"createdBy\": false, \"updatedAt\": false, \"updatedBy\": false, \"description\": false, \"commentCount\": true, \"closestDueDate\": true, \"hasDescription\": true, \"attachmentsCount\": true, \"notificationsCount\": true}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("list_view_column_visibility");
            entity.Property(e => e.ListViewFitScreen)
                .HasDefaultValue(true)
                .HasColumnName("list_view_fit_screen");
            entity.Property(e => e.ListViewItemsPerPage)
                .HasMaxLength(255)
                .HasDefaultValueSql("'all'::character varying")
                .HasColumnName("list_view_items_per_page");
            entity.Property(e => e.ListViewStyle)
                .HasMaxLength(255)
                .HasDefaultValueSql("'compact'::character varying")
                .HasColumnName("list_view_style");
            entity.Property(e => e.PreferredDetailsFont)
                .HasMaxLength(255)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnName("preferred_details_font");
            entity.Property(e => e.SidebarCompact)
                .HasDefaultValue(false)
                .HasColumnName("sidebar_compact");
            entity.Property(e => e.SubscribeToOwnCards).HasColumnName("subscribe_to_own_cards");
            entity.Property(e => e.TasksShown)
                .HasDefaultValue(true)
                .HasColumnName("tasks_shown");
            entity.Property(e => e.Theme)
                .HasMaxLength(255)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnName("theme");
            entity.Property(e => e.ThemeShape)
                .HasMaxLength(255)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnName("theme_shape");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsersSettingsColumnVisibility)
                .HasDefaultValueSql("'{\"name\": true, \"email\": true, \"avatar\": true, \"actions\": true, \"username\": true, \"createdAt\": false, \"createdBy\": false, \"lastLogin\": true, \"updatedAt\": false, \"updatedBy\": false, \"ssoOidcEmail\": false, \"administrator\": true, \"ssoGithubEmail\": false, \"ssoGoogleEmail\": false, \"ssoGithubUsername\": false, \"ssoMicrosoftEmail\": false}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("users_settings_column_visibility");
            entity.Property(e => e.UsersSettingsFitScreen)
                .HasDefaultValue(true)
                .HasColumnName("users_settings_fit_screen");
            entity.Property(e => e.UsersSettingsItemsPerPage)
                .HasMaxLength(255)
                .HasDefaultValueSql("'all'::character varying")
                .HasColumnName("users_settings_items_per_page");
            entity.Property(e => e.UsersSettingsStyle)
                .HasMaxLength(255)
                .HasDefaultValueSql("'compact'::character varying")
                .HasColumnName("users_settings_style");
        });

        modelBuilder.Entity<UserProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_project_pkey");

            entity.ToTable("user_project");

            entity.HasIndex(e => new { e.ProjectId, e.UserId }, "user_project_project_id_user_id_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_id()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IsCollapsed)
                .HasDefaultValue(false)
                .HasColumnName("is_collapsed");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });
        modelBuilder.HasSequence("next_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
