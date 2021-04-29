using System.Collections.Generic;

namespace NRK.Dotnetskolen.Api.Dto
{
    public class EpgDto
    {
        public List<SendingDto> Nrk1 { get; set; }
        public List<SendingDto> Nrk2 { get; set; }
    }
}