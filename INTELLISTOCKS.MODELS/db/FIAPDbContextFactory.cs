using Microsoft.Extensions.Configuration;
using System.IO;
using INTELLISTOCKS.MODELS.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class FIAPDbContextFactory : IDesignTimeDbContextFactory<FIAPDbContext>
{
    public FIAPDbContext CreateDbContext(string[] args)
    {
        // Criação da configuração
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Define o diretório base
            .AddJsonFile("appsettings.Development.json")   // Adiciona o arquivo JSON de configuração
            .Build();                                      // Constrói a configuração

        // Obtém a connection string do arquivo de configuração
        var connectionString = configuration.GetConnectionString("FIAPDatabase");

        // Criação do DbContextOptions com a connection string
        var optionsBuilder = new DbContextOptionsBuilder<FIAPDbContext>();
        optionsBuilder.UseOracle(connectionString);

        return new FIAPDbContext(optionsBuilder.Options);
    }
}