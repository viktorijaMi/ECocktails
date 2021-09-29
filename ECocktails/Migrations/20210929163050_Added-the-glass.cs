using Microsoft.EntityFrameworkCore.Migrations;

namespace ECocktails.Migrations
{
    public partial class Addedtheglass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingretiens_Cocktails_Cocktails_CocktailId",
                table: "Ingretiens_Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingretiens_Cocktails_Ingredients_IngredientId",
                table: "Ingretiens_Cocktails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingretiens_Cocktails",
                table: "Ingretiens_Cocktails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingretiens_Cocktails",
                newName: "Ingredients_Cocktails");

            migrationBuilder.RenameIndex(
                name: "IX_Ingretiens_Cocktails_CocktailId",
                table: "Ingredients_Cocktails",
                newName: "IX_Ingredients_Cocktails_CocktailId");

            migrationBuilder.AddColumn<int>(
                name: "GlassId",
                table: "Cocktails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Ingredients_Cocktails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients_Cocktails",
                table: "Ingredients_Cocktails",
                columns: new[] { "IngredientId", "CocktailId" });

            migrationBuilder.CreateTable(
                name: "Glass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glass", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_GlassId",
                table: "Cocktails",
                column: "GlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktails_Glass_GlassId",
                table: "Cocktails",
                column: "GlassId",
                principalTable: "Glass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Cocktails_Cocktails_CocktailId",
                table: "Ingredients_Cocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Cocktails_Ingredients_IngredientId",
                table: "Ingredients_Cocktails",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktails_Glass_GlassId",
                table: "Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Cocktails_Cocktails_CocktailId",
                table: "Ingredients_Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Cocktails_Ingredients_IngredientId",
                table: "Ingredients_Cocktails");

            migrationBuilder.DropTable(
                name: "Glass");

            migrationBuilder.DropIndex(
                name: "IX_Cocktails_GlassId",
                table: "Cocktails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients_Cocktails",
                table: "Ingredients_Cocktails");

            migrationBuilder.DropColumn(
                name: "GlassId",
                table: "Cocktails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients_Cocktails");

            migrationBuilder.RenameTable(
                name: "Ingredients_Cocktails",
                newName: "Ingretiens_Cocktails");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_Cocktails_CocktailId",
                table: "Ingretiens_Cocktails",
                newName: "IX_Ingretiens_Cocktails_CocktailId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingretiens_Cocktails",
                table: "Ingretiens_Cocktails",
                columns: new[] { "IngredientId", "CocktailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ingretiens_Cocktails_Cocktails_CocktailId",
                table: "Ingretiens_Cocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingretiens_Cocktails_Ingredients_IngredientId",
                table: "Ingretiens_Cocktails",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
