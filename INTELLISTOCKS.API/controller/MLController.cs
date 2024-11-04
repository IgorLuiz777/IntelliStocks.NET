using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace INTELLISTOCKS.API.controller;

[ApiController]
[Route("api/[controller]")]
public class MlController : ControllerBase
{
    private readonly PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> _predictionEnginePool;

    public MlController(PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool)
    {
        _predictionEnginePool = predictionEnginePool;
    }

    [HttpPost("predict")]
    public async Task<IActionResult> Predict([FromBody] MLModel.ModelInput input)
    {
        if (input == null)
        {
            return BadRequest("Input cannot be null.");
        }

        var prediction = await Task.FromResult(_predictionEnginePool.Predict(input));
        return Ok(prediction);
    }
}