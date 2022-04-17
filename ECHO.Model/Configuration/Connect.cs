using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECHO.MODEL.Configuration
{
    public class Connect
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string? DlHost { get; set; }
        public string? DlId { get; set; }
        public string? DlPassw { get; set; }

    }
}
