using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Domian;

namespace TRPOFirst.Controllers.Hospital;

public class GetPacientController : Controller
{
    private List<Pacients> _pacients;
    
    public GetPacientController()
    {
        _pacients = new List<Pacients>();
        for (int i = 0; i < 5; i++)
        {
            _pacients.Add(new Pacients
            {
                IdPacient = Guid.NewGuid(),
                FirstName = "Имя",
                LastName = "Фамилия",
                MiddleName = "Отчество",
                Age = 20,
                Polis = Convert.ToString((12345678912 + i))
            });
        }
    }
    [HttpGet(ApiRoutes.Hospital.GetAllPacients)]
    public IActionResult GetAll()
    {
        return Ok(_pacients);
    }
    
    [HttpPost(ApiRoutes.Hospital.CreatePacients)]
    public IActionResult Create([FromBody] CreatePaceintRequest pacientRequest)
    {
        var pacient = new Pacients
        {
            IdPacient = pacientRequest.IdPacient,
            FirstName = pacientRequest.FirstName,
            LastName = pacientRequest.LastName,
            MiddleName = pacientRequest.MiddleName,
            Age = pacientRequest.Age,
            Polis = pacientRequest.Polis
        };
        
        if (pacient.IdPacient != Guid.Empty)
            pacient.IdPacient = Guid.NewGuid();
        
        _pacients.Add(pacient);
    
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
    
        var locationUri = baseUrl + "/" + ApiRoutes.Hospital.GetPacients.Replace("{IdPacient}", pacient.IdPacient.ToString());
        
        var response = new PacientResponse
        {
            IdPacient = pacientRequest.IdPacient,
            FirstName = pacientRequest.FirstName,
            LastName = pacientRequest.LastName,
            MiddleName = pacientRequest.MiddleName,
            Age = pacientRequest.Age,
            Polis = pacientRequest.Polis
        };
        
        return Created(locationUri, response);
    }
}