using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConfigurationModels
{
    public class EmailSettings
    {
        public string? SmtpHost { get; set; }
        public int SmptPort { get; set;}

        public string? SmptUserName { get; set; }
        
        public string? SmptPassword { get; set;}

        public string? AppName {  get; set; }
    }
}
