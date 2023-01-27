using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class SubjectController:ControllerBase
{

 private readonly SubjectService _classroomStudentService;

   public SubjectController(SubjectService classroomService)
   {
    _classroomStudentService=classroomService;
   }


    [HttpGet("Get")]
        public async Task<List<GetSubjectDto>> Gett()
        {
                return await _classroomStudentService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddSubjectDto c)
                {
                       await _classroomStudentService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddSubjectDto c) => await _classroomStudentService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _classroomStudentService.Delete(id);

  
}




