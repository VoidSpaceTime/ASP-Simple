using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostServicInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostUpdate250417 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tag_TagId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Category_Posts_OwnerPostId",
                table: "T_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Comment_Posts_OwnerPostId",
                table: "T_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_T_Comment_User_OwnerUserId",
                table: "T_Comment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_T_Category_OwnerPostId",
                table: "T_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Comment",
                table: "T_Comment");

            migrationBuilder.DropIndex(
                name: "IX_T_Comment_OwnerPostId",
                table: "T_Comment");

            migrationBuilder.DropIndex(
                name: "IX_T_Comment_OwnerUserId",
                table: "T_Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TagId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "T_Comment");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "T_Comment",
                newName: "T_Comments");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "T_Posts");

            migrationBuilder.RenameColumn(
                name: "Context",
                table: "T_Posts",
                newName: "Files");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerPostId",
                table: "Tag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "OwnerPostId",
                table: "T_Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "T_Category",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "T_Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "T_Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReplyToCommentId",
                table: "T_Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReplyToUserId",
                table: "T_Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "T_Posts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "T_Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "CommentsId",
                table: "T_Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "T_Posts",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "T_Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "T_Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Comments",
                table: "T_Comments",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Posts",
                table: "T_Posts",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_T_Comments_OwnerPostId_IsDeleted",
                table: "T_Comments",
                columns: new[] { "OwnerPostId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_T_Comments_PostId",
                table: "T_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Posts_Categories_IsDeleted",
                table: "T_Posts",
                columns: new[] { "Categories", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_T_Posts_Tags_IsDeleted",
                table: "T_Posts",
                columns: new[] { "Tags", "IsDeleted" });

            migrationBuilder.AddForeignKey(
                name: "FK_T_Comments_T_Posts_PostId",
                table: "T_Comments",
                column: "PostId",
                principalTable: "T_Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Comments_T_Posts_PostId",
                table: "T_Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Posts",
                table: "T_Posts");

            migrationBuilder.DropIndex(
                name: "IX_T_Posts_Categories_IsDeleted",
                table: "T_Posts");

            migrationBuilder.DropIndex(
                name: "IX_T_Posts_Tags_IsDeleted",
                table: "T_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Comments",
                table: "T_Comments");

            migrationBuilder.DropIndex(
                name: "IX_T_Comments_OwnerPostId_IsDeleted",
                table: "T_Comments");

            migrationBuilder.DropIndex(
                name: "IX_T_Comments_PostId",
                table: "T_Comments");

            migrationBuilder.DropColumn(
                name: "OwnerPostId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "T_Posts");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "T_Posts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "T_Posts");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "T_Posts");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "T_Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "T_Comments");

            migrationBuilder.DropColumn(
                name: "ReplyToCommentId",
                table: "T_Comments");

            migrationBuilder.DropColumn(
                name: "ReplyToUserId",
                table: "T_Comments");

            migrationBuilder.RenameTable(
                name: "T_Posts",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "T_Comments",
                newName: "T_Comment");

            migrationBuilder.RenameColumn(
                name: "Files",
                table: "Posts",
                newName: "Context");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerPostId",
                table: "T_Category",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "T_Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<long>(
                name: "TagId",
                table: "Posts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "T_Comment",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "T_Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Comment",
                table: "T_Comment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Category_OwnerPostId",
                table: "T_Category",
                column: "OwnerPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagId",
                table: "Posts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Comment_OwnerPostId",
                table: "T_Comment",
                column: "OwnerPostId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Comment_OwnerUserId",
                table: "T_Comment",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tag_TagId",
                table: "Posts",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Category_Posts_OwnerPostId",
                table: "T_Category",
                column: "OwnerPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Comment_Posts_OwnerPostId",
                table: "T_Comment",
                column: "OwnerPostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Comment_User_OwnerUserId",
                table: "T_Comment",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
