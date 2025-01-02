using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.User
{
    public class CreateUserDto
    {
        public int ProduceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
