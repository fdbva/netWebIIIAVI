using AV1.Models;

namespace AV1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AV1.Models.FornecedorServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AV1.Models.FornecedorServiceContext context)
        {
            context.Fornecedors.AddOrUpdate(x => x.Id,
        new Fornecedor() { Id = 1, Nome = "Fornecedor1", CNPJ = "11111111111111"},
        new Fornecedor() { Id = 2, Nome = "Fornecedor2", CNPJ = "22222222222222"},
        new Fornecedor() { Id = 3, Nome = "Fornecedor3", CNPJ = "33333333333333"}
        );

            context.Produtoes.AddOrUpdate(x => x.Id,
                new Produto()
                {
                    Id = 1,
                    Nome = "Produto1",
                    Marca = "Marca1",
                    Estoque = 1,
                    Preco = 1.0,
                    FornecedorId = 1
                },
                new Produto()
                {
                    Id = 2,
                    Nome = "Produto2",
                    Marca = "Marca2",
                    Estoque = 2,
                    Preco = 2.0,
                    FornecedorId = 2
                },
                new Produto()
                {
                    Id = 3,
                    Nome = "Produto3",
                    Marca = "Marca3",
                    Estoque = 3,
                    Preco = 3.0,
                    FornecedorId = 3
                },
                new Produto()
                {
                    Id = 4,
                    Nome = "Produto4",
                    Marca = "Marca4",
                    Estoque = 4,
                    Preco = 4.0,
                    FornecedorId = 3
                }
                );
        }
    }
}
