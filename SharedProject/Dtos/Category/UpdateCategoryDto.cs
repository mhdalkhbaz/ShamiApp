using SharedProject.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Dtos
{
    public class UpdateCategoryDto : IEntity<int>
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
}
