using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace livestockProject.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LIVESTOCK");

            migrationBuilder.CreateTable(
                name: "IMPORTEDMEAL",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEAL_NAME = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ORIGINCOUNTRY = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    GROSSWEIGHT = table.Column<double>(type: "FLOAT", nullable: false),
                    NETWEIGHT = table.Column<double>(type: "FLOAT", nullable: false),
                    COUNT = table.Column<int>(type: "NUMBER(38)", nullable: false),
                    LIVESTOCKTYPE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SHIPPINGDATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    SHIPMENTARRIVALDATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    STATUS = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMPORTEDMEAL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYS_MODUEL",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESC_AR = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    DESC_EN = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    IS_ACTIVE = table.Column<int>(type: "NUMBER(38)", nullable: true),
                    MODULEICON = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MODULEICONEN = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_MODUEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_COUNTRY",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_ARABIC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_COUNTRY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_LIVESTOCK_TYPE",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_ARABIC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_LIVESTOCK_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_USER_GROUP",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    USER_GROUP_ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENU_ID = table.Column<int>(type: "NUMBER(38)", nullable: true),
                    NAME_AR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NAME_EN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYSTEM_USER_GROUP_PK", x => x.USER_GROUP_ID);
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_MENU",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENUNAME_AR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MENUNAME_EN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SYSTEM_FUNCTION = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    MENUORDER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MENU_FLAG = table.Column<bool>(type: "bit", precision: 1, nullable: true),
                    CREATEDUSER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    LAST_UPDATED_USER = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: false),
                    LAST_UPDATE_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    MODULE_ID = table.Column<int>(type: "NUMBER(38)", nullable: true),
                    MENU_CONTROLLER = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MENU_VIEW = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PERANT_ID = table.Column<int>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_MENU", x => x.ID);
                    table.ForeignKey(
                        name: "SYS_MENU_FK",
                        column: x => x.MODULE_ID,
                        principalSchema: "LIVESTOCK",
                        principalTable: "SYS_MODUEL",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SYSTEM_USERS",
                schema: "LIVESTOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(38)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NAME_ARABIC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NAME_ENGLISH = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UPASSWORD = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    USER_GROUP_ID = table.Column<int>(type: "NUMBER(38)", nullable: false),
                    LAST_LOGIN_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    LAST_CHANGE_PASSWORD = table.Column<DateTime>(type: "DATE", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", precision: 1, nullable: true, defaultValueSql: "1 \n")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYSTEM_USERS", x => x.ID);
                    table.ForeignKey(
                        name: "SYS_USER_FK",
                        column: x => x.USER_GROUP_ID,
                        principalSchema: "LIVESTOCK",
                        principalTable: "SYSTEM_USER_GROUP",
                        principalColumn: "USER_GROUP_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_MENU_MODULE_ID",
                schema: "LIVESTOCK",
                table: "SYSTEM_MENU",
                column: "MODULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYSTEM_USERS_USER_GROUP_ID",
                schema: "LIVESTOCK",
                table: "SYSTEM_USERS",
                column: "USER_GROUP_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMPORTEDMEAL",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYSTEM_COUNTRY",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYSTEM_LIVESTOCK_TYPE",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYSTEM_MENU",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYSTEM_USERS",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYS_MODUEL",
                schema: "LIVESTOCK");

            migrationBuilder.DropTable(
                name: "SYSTEM_USER_GROUP",
                schema: "LIVESTOCK");
        }
    }
}
