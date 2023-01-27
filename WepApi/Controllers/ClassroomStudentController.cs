using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class ClassroomStudentController:ControllerBase
{

 private readonly ClassroomStudentService _classroomStudentService;

   public ClassroomStudentController(ClassroomStudentService classroomService)
   {
    _classroomStudentService=classroomService;
   }


    [HttpGet("Get")]
        public async Task<List<GetClassroomStudentDto>> Gett()
        {
                return await _classroomStudentService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddClassroomStudentDto c)
                {
                       await _classroomStudentService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddClassroomStudentDto c) => await _classroomStudentService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _classroomStudentService.Delete(id);

  
}









