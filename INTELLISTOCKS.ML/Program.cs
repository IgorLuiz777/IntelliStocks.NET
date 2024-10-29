using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput>()
    .FromFile("MLModel.mlnet");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntelliStocks", Description = "Docs for my ML API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger";
});

app.MapPost("/predict",
    async (PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool, MLModel.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

app.Run();
