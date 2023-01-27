using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class AttendanceTeacherController:ControllerBase
{

 private readonly AttendanceTeacherService _attendanceService;

   public AttendanceTeacherController(AttendanceTeacherService attendanceService)
   {
    _attendanceService=attendanceService;
   }


    [HttpGet("Get")]
        public async Task<List<GetAttendanceTeacherDto>> Gett()
        {
                return await _attendanceService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddAttendanceTeacherDto c)
                {
                       await _attendanceService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddAttendanceTeacherDto c) => await _attendanceService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _attendanceService.Delete(id);

  
}




