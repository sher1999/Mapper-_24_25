using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]

public class ClassroomController:ControllerBase
{

 private readonly ClassroomService _classroomService;

   public ClassroomController(ClassroomService classroomService)
   {
    _classroomService=classroomService;
   }


    [HttpGet("Get")]
        public async Task<List<GetClassroomDto>> Gett()
        {
                return await _classroomService.Get();
        }
        [HttpPost("Add")]
                public async Task<bool> Addd(AddClassroomDto c)
                {
                       await _classroomService.Add(c);
                        return true;
                }

                  [HttpPut("Update")]
    public async Task Updatee([FromBody] AddClassroomDto c) => await _classroomService.Update(c);
    
 [HttpDelete("{id}")]
    public async Task Deletee(int id) => await _classroomService.Delete(id);

  
}




