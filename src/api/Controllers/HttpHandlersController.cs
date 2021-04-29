using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using NRK.Dotnetskolen.Api.Dto;

namespace NRK.Dotnetskolen.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HttpHandlersController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "pong";
        }

        [HttpGet]
        [Route("epg/{dateString}")]
        public ActionResult<object> Epg(string dateString)
        {
            DateTime? date = ParseAsDateTime(dateString);
            if (date == null)
                return BadRequest();

            return Ok(new EpgDto
            {
                Nrk1 = new List<SendingDto> { new () { Tittel = "Tittelen", StartTidspunkt = date.Value.ToString("yyyy-MM-ddTHH:mm:ss"), SluttTidspunkt = date.Value.ToString("yyyy-MM-ddTHH:mm:ss") } },
                Nrk2 = new List<SendingDto> { new() { Tittel = "Tittelen", StartTidspunkt = date.Value.ToString("yyyy-MM-ddTHH:mm:ss"), SluttTidspunkt = date.Value.ToString("yyyy-MM-ddTHH:mm:ss") } }
            });
        }

        private static DateTime? ParseAsDateTime(string dateAsString)
        {
            if (DateTime.TryParseExact(dateAsString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                return date;

            return null;
        }
    }
}