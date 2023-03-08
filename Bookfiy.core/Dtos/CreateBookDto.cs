using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiy.Core.Dtos
{
    public class CreateBookDto
    {
        [Required, MaxLength(250)]
        public string Title { get; set; }

        public int AuthorId { get; set; }
    }
}
