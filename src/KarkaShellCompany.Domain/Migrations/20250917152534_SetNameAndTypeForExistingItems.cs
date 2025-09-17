using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarkaShellCompany.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SetNameAndTypeForExistingItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""Items""
                SET ""Name"" = ""ItemJson""->>'name',
                    ""Type"" = ""ItemJson""->>'type'
                WHERE ""Name"" IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No need to revert data changes
        }
    }
}
