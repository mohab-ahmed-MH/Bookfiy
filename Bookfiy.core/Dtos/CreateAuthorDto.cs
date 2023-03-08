using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiy.Core.Dtos
{
    public class CreateAuthorDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; }
    }
}
