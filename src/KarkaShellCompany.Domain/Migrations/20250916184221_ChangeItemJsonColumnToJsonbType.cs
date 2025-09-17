using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarkaShellCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeItemJsonColumnToJsonbType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"alter table ""Items""
                alter column ""ItemJson"" type jsonb
                using to_jsonb(""ItemJson"")
            ");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ItemJson",
            //    table: "Items",
            //    type: "jsonb",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemJson",
                table: "Items",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "jsonb");
        }
    }
}
