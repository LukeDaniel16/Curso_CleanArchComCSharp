using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, ImagePath, CategoryId) " +
                "VALUES('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, ImagePath, CategoryId) " +
                "VALUES('Estojo escolar', 'Estojo escolar simples cinza', 4.50, 35, 'estojo1.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, ImagePath, CategoryId) " +
                "VALUES('Calculadora', 'Calculadora científica', 25.00, 25, 'calculadora1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
