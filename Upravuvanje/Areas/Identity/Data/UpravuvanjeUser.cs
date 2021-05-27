using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upravuvanje.Areas.Identity.Data
{
    public class UpravuvanjeUser : IdentityUser
    {
        public int? StudentId { get; set; }

        public int? TeacherId { get; set; }
    }
}
