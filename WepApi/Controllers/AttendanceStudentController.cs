using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class AttendanceStudentController:ControllerBase
{

 private readonly AttendanceService _attendanceService;

   public AttendanceStudentController(AttendanceService attendanceService)
   {
    _attendanceService=attendanceService;
   }


    [HttpGet("Get")]
        public async Task<List<GetAttendanceDto>> Gett()
        {
                return await _attendanceService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddAttendanceDto c)
                {
                       await _attendanceService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddAttendanceDto c) => await _attendanceService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _attendanceService.Delete(id);

  
}
