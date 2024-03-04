using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanCuocCongDan_NhanVien_NhanVienID",
                table: "CanCuocCongDan");

            migrationBuilder.DropIndex(
                name: "IX_CanCuocCongDan_NhanVienID",
                table: "CanCuocCongDan");

            migrationBuilder.AlterColumn<string>(
                name: "NhanVienID",
                table: "CanCuocCongDan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "CanCuocCongDanEntityNhanVienEntity",
                columns: table => new
                {
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanCuocCongDanEntityNhanVienEntity", x => new { x.NhanVienID, x.NhanVienID1 });
                    table.ForeignKey(
                        name: "FK_CanCuocCongDanEntityNhanVienEntity_CanCuocCongDan_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "CanCuocCongDan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanCuocCongDanEntityNhanVienEntity_NhanVien_NhanVienID1",
                        column: x => x.NhanVienID1,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanCuocCongDanEntityNhanVienEntity_NhanVienID1",
                table: "CanCuocCongDanEntityNhanVienEntity",
                column: "NhanVienID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanCuocCongDanEntityNhanVienEntity");

            migrationBuilder.AlterColumn<string>(
                name: "NhanVienID",
                table: "CanCuocCongDan",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CanCuocCongDan_NhanVienID",
                table: "CanCuocCongDan",
                column: "NhanVienID");

            migrationBuilder.AddForeignKey(
                name: "FK_CanCuocCongDan_NhanVien_NhanVienID",
                table: "CanCuocCongDan",
                column: "NhanVienID",
                principalTable: "NhanVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
