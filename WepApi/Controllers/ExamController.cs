using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class ExamController:ControllerBase
{

 private readonly ExamService _classroomStudentService;

   public ExamController(ExamService classroomService)
   {
    _classroomStudentService=classroomService;
   }


    [HttpGet("Get")]
        public async Task<List<GetExamDto>> Gett()
        {
                return await _classroomStudentService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddExamDto c)
                {
                       await _classroomStudentService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddExamDto c) => await _classroomStudentService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _classroomStudentService.Delete(id);

  
}













