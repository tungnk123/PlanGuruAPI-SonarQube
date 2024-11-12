using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlantPosts.Common.GetPlantPosts
{
    public record PlantPostDto(
        string UserNickName,
        string UserAvatar,
        string Title,
        string Description,
        string ImageUrl,
        string Tags,
        string Background,
        int Likes,
        int Comments,
        int Shares,
        DateTime CreatedAt
    );
}
