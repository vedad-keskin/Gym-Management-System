using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace GMS.Helpers
{
    [ApiController]
    
    public abstract class MyBaseEndpoint<Trequest, Tresponse> : ControllerBase
    {

        public abstract Task<Tresponse> Handle(Trequest request);

    }
}
