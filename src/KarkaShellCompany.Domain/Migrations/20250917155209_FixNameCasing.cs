using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarkaShellCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixNameCasing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guilds",
                table: "Guilds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "items");

            migrationBuilder.RenameTable(
                name: "Guilds",
                newName: "guilds");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "items",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ItemJson",
                table: "items",
                newName: "item_json");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "guilds",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Included",
                table: "guilds",
                newName: "included");

            migrationBuilder.RenameColumn(
                name: "Gw2Id",
                table: "guilds",
                newName: "gw2id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "guilds",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "accounts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gw2Name",
                table: "accounts",
                newName: "gw2name");

            migrationBuilder.RenameColumn(
                name: "ApiKey",
                table: "accounts",
                newName: "api_key");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "accounts",
                newName: "account_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_items",
                table: "items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_guilds",
                table: "guilds",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_accounts",
                table: "accounts",
                column: "account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "pk_guilds",
                table: "guilds");

            migrationBuilder.DropPrimaryKey(
                name: "pk_accounts",
                table: "accounts");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "guilds",
                newName: "Guilds");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Items",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "item_json",
                table: "Items",
                newName: "ItemJson");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Guilds",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "included",
                table: "Guilds",
                newName: "Included");

            migrationBuilder.RenameColumn(
                name: "gw2id",
                table: "Guilds",
                newName: "Gw2Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Guilds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Accounts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gw2name",
                table: "Accounts",
                newName: "Gw2Name");

            migrationBuilder.RenameColumn(
                name: "api_key",
                table: "Accounts",
                newName: "ApiKey");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "Accounts",
                newName: "AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guilds",
                table: "Guilds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountId");
        }
    }
}
