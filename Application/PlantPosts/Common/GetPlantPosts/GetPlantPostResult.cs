using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlantPosts.Common.GetPlantPosts
{
    public record GetPlantPostResult
        (List<PlantPostDto> PlantPostDtos, 
        int NumberOfPage);
}
