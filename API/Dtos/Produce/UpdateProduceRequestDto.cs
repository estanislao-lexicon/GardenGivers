using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Produce
{
    public class UpdateProduceRequestDto
    {
        public int ProduceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
