using Microsoft.AspNetCore.Mvc;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto;
using Rookies_ASP.NETCoreAPI_2.API.Services;
using Rookies_ASP.NETCoreAPI_2.Common;

namespace Rookies_ASP.NETCoreAPI_2.API.Controllers
{
    [Route("people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ApiResponse GetPeople([FromQuery] ApiFilterPersonDto apiFilterPersonDto)
        {
            var people = _personService.GetPeople(apiFilterPersonDto);
            if (people.Count() == 0)
                return new ApiResponse
                {                  
                    Message = "People list is empty!",
                    Data = people
                };            
            return new ApiResponse
            {
                Data = people,
                Message = "Get People list successfully!"
            };
        }

        [HttpPost]
        public ApiResponse Add([FromBody] RequestPersonDto requestPersonDto)
        {
            int status = _personService.Add(requestPersonDto);
            if (status == ConstantsStatus.Success)
            {
                return new ApiResponse
                {                     
                    Message = "Add a new person successfully!",
                    Data = requestPersonDto
                };
            }           
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Add new a person failed!"
            };            
        }

        [HttpPut("{id}")]
        public ApiResponse Put(Guid id, [FromBody] RequestPersonDto requestPersonDto)
        {
            int status = _personService.Update(id, requestPersonDto);
            if (status == ConstantsStatus.Success)
            {
                return new ApiResponse
                {
                    Message = "Update person successfully!",
                    Data = requestPersonDto
                };
            }   
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Update person failed!"
            };
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(Guid id)
        {
            int status = _personService.Delete(id);
            if (status == ConstantsStatus.Success)
            {
                return new ApiResponse
                {
                    Message = "Delete person successfully!"
                };
            }
            return new ApiResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Delete person failed!"
            };            
        }
    }
}
