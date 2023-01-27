using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class StudentController:ControllerBase
{

 private readonly StudentService _classroomStudentService;

   public StudentController(StudentService classroomService)
   {
    _classroomStudentService=classroomService;
   }


    [HttpGet("Get")]
        public async Task<List<GetStudentDto>> Gett()
        {
                return await _classroomStudentService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddStudentDto c)
                {
                       await _classroomStudentService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddStudentDto c) => await _classroomStudentService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _classroomStudentService.Delete(id);

  
}






