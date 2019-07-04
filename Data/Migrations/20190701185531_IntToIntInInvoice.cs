using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS2019.Data.Migrations
{
    public partial class IntToIntInInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Article_ArticleId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Article_ArticleId1",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Company_CompanyId1",
                table: "Invoice");

            migrationBuilder.AlterColumn<int>(
                name: "Qantity1",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId1",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId1",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Article_ArticleId",
                table: "Invoice",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Article_ArticleId1",
                table: "Invoice",
                column: "ArticleId1",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Company_CompanyId1",
                table: "Invoice",
                column: "CompanyId1",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Article_ArticleId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Article_ArticleId1",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Company_CompanyId1",
                table: "Invoice");

            migrationBuilder.AlterColumn<int>(
                name: "Qantity1",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId1",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId1",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Article_ArticleId",
                table: "Invoice",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Article_ArticleId1",
                table: "Invoice",
                column: "ArticleId1",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Company_CompanyId1",
                table: "Invoice",
                column: "CompanyId1",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
