using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _4gaDailyWorkReview.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialAfterScaffold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateSequence(
                name: "next_id_seq");

            migrationBuilder.CreateTable(
                name: "action",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true),
                    scope = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'card'::character varying"),
                    board_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    project_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("action_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "archive",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    from_model = table.Column<string>(type: "text", nullable: false),
                    original_record_id = table.Column<long>(type: "bigint", nullable: false),
                    original_record = table.Column<string>(type: "json", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("archive_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attachment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    dirname = table.Column<string>(type: "text", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    image = table.Column<string>(type: "jsonb", nullable: true),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("attachment_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "board",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    project_id = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<double>(type: "double precision", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_github_connected = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    github_repo = table.Column<string>(type: "text", nullable: false, defaultValueSql: "''::text"),
                    is_imported_board = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("board_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "board_membership",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    board_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    role = table.Column<string>(type: "text", nullable: false),
                    can_comment = table.Column<bool>(type: "boolean", nullable: true),
                    migrate_added_project_managers = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("board_membership_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    board_id = table.Column<long>(type: "bigint", nullable: false),
                    list_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    cover_attachment_id = table.Column<long>(type: "bigint", nullable: true),
                    position = table.Column<double>(type: "double precision", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    timer = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    comment_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("card_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_label",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    label_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("card_label_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_membership",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("card_membership_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "card_subscription",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    is_permanent = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("card_subscription_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "core",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    registration_enabled = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    local_registration_enabled = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    sso_registration_enabled = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    project_creation_all_enabled = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true),
                    sync_sso_data_on_auth = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    sync_sso_admin_on_auth = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    allowed_register_domains = table.Column<string>(type: "json", nullable: true, defaultValueSql: "'[]'::json")
                },
                constraints: table =>
                {
                    table.PrimaryKey("core_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    board_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("label_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "list",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    board_id = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<double>(type: "double precision", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    is_collapsed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("list_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "migration",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    batch = table.Column<int>(type: "integer", nullable: true),
                    migration_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("migration_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "migration_lock",
                columns: table => new
                {
                    index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_locked = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("migration_lock_pkey", x => x.index);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    action_id = table.Column<long>(type: "bigint", nullable: false),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notification_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    background = table.Column<string>(type: "jsonb", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    background_image = table.Column<string>(type: "jsonb", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("project_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project_manager",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    project_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("project_manager_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    access_token = table.Column<string>(type: "text", nullable: false),
                    remote_address = table.Column<string>(type: "text", nullable: false),
                    user_agent = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("session_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    card_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    position = table.Column<double>(type: "double precision", nullable: false),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("task_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_membership",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    task_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("task_membership_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: true),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    organization = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    password_changed_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    avatar = table.Column<string>(type: "jsonb", nullable: true),
                    last_login = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    sso_google_email = table.Column<string>(type: "text", nullable: true),
                    sso_github_id = table.Column<string>(type: "text", nullable: true),
                    sso_microsoft_id = table.Column<string>(type: "text", nullable: true),
                    sso_google_id = table.Column<string>(type: "text", nullable: true),
                    sso_github_username = table.Column<string>(type: "text", nullable: true),
                    sso_microsoft_email = table.Column<string>(type: "text", nullable: true),
                    created_by_id = table.Column<long>(type: "bigint", nullable: false),
                    updated_by_id = table.Column<long>(type: "bigint", nullable: true),
                    sso_oidc_id = table.Column<string>(type: "text", nullable: true),
                    sso_oidc_email = table.Column<string>(type: "text", nullable: true),
                    sso_github_email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_account_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_prefs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    subscribe_to_own_cards = table.Column<bool>(type: "boolean", nullable: false),
                    language = table.Column<string>(type: "text", nullable: true),
                    description_mode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'edit'::character varying"),
                    description_shown = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    tasks_shown = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    attachments_shown = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    comments_shown = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    comment_mode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'edit'::character varying"),
                    sidebar_compact = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    default_view = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'board'::character varying"),
                    list_view_style = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'compact'::character varying"),
                    list_view_column_visibility = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{\"name\": true, \"tasks\": true, \"timer\": true, \"users\": true, \"labels\": true, \"actions\": true, \"dueDate\": true, \"coverUrl\": false, \"listName\": true, \"createdAt\": false, \"createdBy\": false, \"updatedAt\": false, \"updatedBy\": false, \"description\": false, \"commentCount\": true, \"closestDueDate\": true, \"hasDescription\": true, \"attachmentsCount\": true, \"notificationsCount\": true}'::jsonb"),
                    list_view_fit_screen = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    list_view_items_per_page = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'all'::character varying"),
                    users_settings_style = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "'compact'::character varying"),
                    users_settings_column_visibility = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{\"name\": true, \"email\": true, \"avatar\": true, \"actions\": true, \"username\": true, \"createdAt\": false, \"createdBy\": false, \"lastLogin\": true, \"updatedAt\": false, \"updatedBy\": false, \"ssoOidcEmail\": false, \"administrator\": true, \"ssoGithubEmail\": false, \"ssoGoogleEmail\": false, \"ssoGithubUsername\": false, \"ssoMicrosoftEmail\": false}'::jsonb"),
                    users_settings_fit_screen = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    users_settings_items_per_page = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'all'::character varying"),
                    preferred_details_font = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'default'::character varying"),
                    hide_card_modal_activity = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    hide_closest_due_date = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    theme_shape = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'default'::character varying"),
                    theme = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "'default'::character varying")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_prefs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_project",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "next_id()"),
                    is_collapsed = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    project_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_project_pkey", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "action_card_id_index",
                table: "action",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "action_type_index",
                table: "action",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "archive_from_model_original_record_id_unique",
                table: "archive",
                columns: new[] { "from_model", "original_record_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "attachment_card_id_index",
                table: "attachment",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "board_position_index",
                table: "board",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "board_project_id_index",
                table: "board",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "board_membership_board_id_user_id_unique",
                table: "board_membership",
                columns: new[] { "board_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "board_membership_user_id_index",
                table: "board_membership",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "card_board_id_index",
                table: "card",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "card_list_id_index",
                table: "card",
                column: "list_id");

            migrationBuilder.CreateIndex(
                name: "card_position_index",
                table: "card",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "card_label_card_id_label_id_unique",
                table: "card_label",
                columns: new[] { "card_id", "label_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "card_label_label_id_index",
                table: "card_label",
                column: "label_id");

            migrationBuilder.CreateIndex(
                name: "card_membership_card_id_user_id_unique",
                table: "card_membership",
                columns: new[] { "card_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "card_membership_user_id_index",
                table: "card_membership",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "card_subscription_card_id_user_id_unique",
                table: "card_subscription",
                columns: new[] { "card_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "card_subscription_user_id_index",
                table: "card_subscription",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "label_board_id_index",
                table: "label",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "list_board_id_index",
                table: "list",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "list_position_index",
                table: "list",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "notification_action_id_index",
                table: "notification",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "notification_card_id_index",
                table: "notification",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "notification_is_read_index",
                table: "notification",
                column: "is_read");

            migrationBuilder.CreateIndex(
                name: "notification_user_id_index",
                table: "notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "project_manager_project_id_user_id_unique",
                table: "project_manager",
                columns: new[] { "project_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "project_manager_user_id_index",
                table: "project_manager",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "session_access_token_unique",
                table: "session",
                column: "access_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "session_remote_address_index",
                table: "session",
                column: "remote_address");

            migrationBuilder.CreateIndex(
                name: "session_user_id_index",
                table: "session",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "task_card_id_index",
                table: "task",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "task_position_index",
                table: "task",
                column: "position");

            migrationBuilder.CreateIndex(
                name: "task_membership_task_id_user_id_unique",
                table: "task_membership",
                columns: new[] { "task_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "task_membership_user_id_index",
                table: "task_membership",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_email_unique",
                table: "user_account",
                column: "email",
                filter: "(deleted_at IS NULL)");

            migrationBuilder.CreateIndex(
                name: "user_username_unique",
                table: "user_account",
                column: "username",
                filter: "((username IS NOT NULL) AND (deleted_at IS NULL))");

            migrationBuilder.CreateIndex(
                name: "user_project_project_id_user_id_unique",
                table: "user_project",
                columns: new[] { "project_id", "user_id" },
                unique: true);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "action");

            migrationBuilder.DropTable(
                name: "archive");

            migrationBuilder.DropTable(
                name: "attachment");

            migrationBuilder.DropTable(
                name: "board");

            migrationBuilder.DropTable(
                name: "board_membership");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "card_label");

            migrationBuilder.DropTable(
                name: "card_membership");

            migrationBuilder.DropTable(
                name: "card_subscription");

            migrationBuilder.DropTable(
                name: "core");

            migrationBuilder.DropTable(
                name: "label");

            migrationBuilder.DropTable(
                name: "list");

            migrationBuilder.DropTable(
                name: "migration");

            migrationBuilder.DropTable(
                name: "migration_lock");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "project_manager");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "task_membership");

            migrationBuilder.DropTable(
                name: "user_account");

            migrationBuilder.DropTable(
                name: "user_prefs");

            migrationBuilder.DropTable(
                name: "user_project");

            migrationBuilder.DropSequence(
                name: "next_id_seq");
        }
    }
}
