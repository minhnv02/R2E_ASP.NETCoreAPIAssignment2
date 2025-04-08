using Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto;

namespace Rookies_ASP.NETCoreAPI_2.API.Services
{
    public interface IPersonService
    {
        List<ResponsePersonDto> GetPeople(ApiFilterPersonDto filterPersonDto);
        int Add(RequestPersonDto personDto);
        int Delete(Guid id);
        int Update(Guid id, RequestPersonDto personDto);
    }
}
