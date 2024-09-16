using System;
using Bogus;
using CS058_ASP.NET_Razor_09.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS058_ASP.NET_Razor_09.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
            // Insert Data
            // Fake Data

            Randomizer.Seed = new Random(8675309);
            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31)));
            fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            Article article = fakeArticle.Generate();

            /*migrationBuilder.InsertData(
                table: "articles",
                columns: new[] {"Title","Created","Content"},
                values: new object[]
                {
                    "Bai viet 1",
                    new DateTime(2024,09,15),
                    "Noi dung 1"
                }
                );
            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Title", "Created", "Content" },
                values: new object[]
                {
                    "Bai viet 2",
                    new DateTime(2024,09,16),
                    "Noi dung 2"
                }
                );*/
            for (int i = 0; i < 150; i++)
            {
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[]
                    {
                    article.Title,
                    article.Created,
                    article.Content
                    }
                    );
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
