using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace real_estate.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Clients_clientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_employeeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_cityId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Status_PropertyStatusId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Types_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_propertyId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "propertyId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_propertyId",
                table: "Contracts",
                column: "propertyId",
                unique: true,
                filter: "[propertyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Clients_clientId",
                table: "Contracts",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_employeeId",
                table: "Contracts",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_cityId",
                table: "Properties",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Status_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Types_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Clients_clientId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_employeeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_cityId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Status_PropertyStatusId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Types_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_propertyId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "propertyId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_propertyId",
                table: "Contracts",
                column: "propertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Clients_clientId",
                table: "Contracts",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_employeeId",
                table: "Contracts",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_cityId",
                table: "Properties",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Employees_EmployeeId",
                table: "Properties",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Status_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Types_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "Types",
                principalColumn: "Id");
        }
    }
}
