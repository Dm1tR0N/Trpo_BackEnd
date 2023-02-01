using Microsoft.AspNetCore.Mvc;
using TRPOFirst.Contracts.Hospital;
using TRPOFirst.Contracts.Hospital.Requests;
using TRPOFirst.Contracts.Hospital.Responses;
using TRPOFirst.Domian;
using System.Collections.Generic;
using TRPOFirst.Services;

namespace TRPOFirst.Controllers.Hospital;

public class GetDoctorsController : Controller
{

    private readonly IDoctorService _doctorService;
    
    public GetDoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    [HttpGet(ApiRoutes.Hospital.GetAllDoctors)]
    public IActionResult GetAll()
    {
        return Ok(_doctorService.GetDoctors());
    }
    
    [HttpGet(ApiRoutes.Hospital.GetDoctors)] // Проклетая строчка из за которой 2 дня еб23424к23к2я №;№";
    public IActionResult Get([FromRoute]Guid idDoctor)
    {
        var doctor = _doctorService.GetDoctorById(idDoctor);

        return Ok(doctor);
    }
    
    [HttpPost(ApiRoutes.Hospital.CreateDoctors)]
    public IActionResult Create([FromBody] CreateDoctorRequest doctorsRequest)
    {
        var doctors = new Doctors()
        {
            IdDoctor = doctorsRequest.IdDoctor,
            FirstName = doctorsRequest.FirstName,
            LastName = doctorsRequest.LastName,
            MiddleName = doctorsRequest.MiddleName,
            post = doctorsRequest.post,
            receptionSchedule = doctorsRequest.receptionSchedule,
            DoctorInfo = doctorsRequest.DoctorInfo
        };
        
        if (doctors.IdDoctor != Guid.Empty)
            doctors.IdDoctor = Guid.NewGuid();
        
        _doctorService.GetDoctors().Add(doctors);
    
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
    
        var locationUri = baseUrl + "/" + ApiRoutes.Hospital.GetDoctors.Replace("{IdDoctor}", doctors.IdDoctor.ToString());
        
        var response = new DoctorResponse
        {
            IdDoctor = doctorsRequest.IdDoctor,
            FirstName = doctorsRequest.FirstName,
            LastName = doctorsRequest.LastName,
            MiddleName = doctorsRequest.MiddleName,
            post = doctorsRequest.post,
            receptionSchedule = doctorsRequest.receptionSchedule,
            DoctorInfo = doctorsRequest.DoctorInfo
        };
        
        return Created(locationUri, response);
    }
}