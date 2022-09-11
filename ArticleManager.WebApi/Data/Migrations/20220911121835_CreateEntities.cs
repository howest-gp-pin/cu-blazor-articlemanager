using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleManager.WebApi.Data.Migrations
{
    public partial class CreateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Boardgames and computer games", "Games" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Enhance your programming skills", "Books" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Computer hardware", "Hardware" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Search for gold in de California Gold Rush", "Coloma" },
                    { 2, 1, "Examine mines and herd animals with your dwarves", "Caverna" },
                    { 3, 1, "Connect your production cites with boats and trains.", "Brass Birmingham" },
                    { 4, 2, "Step-by-step guide written in a lucid language for mastering C#", "Mastering C#" },
                    { 5, 2, "Become a more productive programmer by leveraging the newest features available to you in C#. ", "Exploring Advanced Features in C#" },
                    { 6, 2, "Implement rich Azure SAAS-PAAS-IAAS ecosystems using containers, serverless services, and storage solutions", "Learn Microsoft Azure" },
                    { 7, 3, "Have a clear sight on your code", "Monitor" },
                    { 8, 3, "Click your way to succes", "Mouse" },
                    { 9, 3, "Type great code", "Keyboard" },
                    { 10, 3, "Scan all kinds of cards", "Cardreader" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
