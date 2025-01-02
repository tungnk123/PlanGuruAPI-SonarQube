using Domain.Entities;
using Domain.Entities.WikiService;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void SeedWikis(PlanGuruDBContext context)
        {
            var firstWiki = context.Wikis.FirstOrDefault();
            var firstUser = context.Users.FirstOrDefault();
            var secondUser = context.Users.Skip(1).FirstOrDefault();
            var thirdUser = context.Users.Skip(4).FirstOrDefault(); 

            Console.WriteLine("Seeding Wikis...");

            var wiki = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = $"Rose Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTgl-cJ0BgNUU8WoEKY11IiFDOphGoK8BGn1w&s",
                Content = @"General Description:
Roses are one of the most popular and iconic flowers in the world. Known for their beauty and fragrance, roses are widely cultivated and available in various colors and forms. They are primarily distributed across the Northern Hemisphere, including Europe, Asia, and North America.

Scientific Classification:
Species: Rosa spp.
Genus: Rosa
Family: Rosaceae
Order: Rosales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Roses contribute to air purification and can absorb certain pollutants. Their dense foliage provides habitats for beneficial insects and small animals.
- Economic Value:
  Roses are highly valued in the perfume industry for their essential oils, and they play a significant role in landscaping and gifting.

Care Instructions:
- Water: Requires regular watering but avoid overwatering.
- Light: Prefers full sunlight for optimal growth.
- Soil: Thrives in well-drained, fertile soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki);


            var wiki2 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Lily Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSORqceeXJ3o-A_EwZk8q-xi5JulC9AqqfHiw&s",
                Content = @"General Description:
Lilies are elegant and fragrant flowers that are popular in gardens and floral arrangements. They are native to temperate regions of the Northern Hemisphere.

Scientific Classification:
Species: Lilium spp.
Genus: Lilium
Family: Liliaceae
Order: Liliales
Class: Liliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Lilies provide nectar for pollinators such as hummingbirds and bees.
- Economic Value:
  Commonly used in the floral industry and religious ceremonies.

Care Instructions:
- Water: Needs consistent moisture but avoid waterlogging.
- Light: Prefers partial to full sunlight.
- Soil: Requires well-drained, loamy soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki2);

            var wiki3 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Orchid Wiki",
                ThumbnailImageUrl = "https://hoatuoi24h.com.vn/wp-content/uploads/2020/10/hoa-orchid-la-gi.jpg",
                Content = @"General Description:
Orchids are exotic and diverse flowering plants that are prized for their beauty and variety. They are found on all continents except Antarctica.

Scientific Classification:
Species: Orchidaceae spp.
Genus: Various
Family: Orchidaceae
Order: Asparagales
Class: Liliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Orchids play a role in maintaining forest ecosystems.
- Economic Value:
  Popular as ornamental plants and cut flowers.

Care Instructions:
- Water: Water weekly or as needed, allowing the soil to dry between waterings.
- Light: Requires bright, indirect light.
- Soil: Best grown in a specialized orchid potting mix.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki3);

            var wiki4 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Daisy Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIoGdPkJLy6MDaf7Em4sg73n05NmoW8aXSfQ&s",
                Content = @"General Description:
Daisies are simple yet charming flowers that symbolize innocence and purity. They are commonly found in grasslands and meadows across Europe, North America, and Africa.

Scientific Classification:
Species: Bellis perennis
Genus: Bellis
Family: Asteraceae
Order: Asterales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Daisies attract beneficial insects and help in maintaining biodiversity.
- Economic Value:
  Frequently used in landscaping and as cut flowers.

Care Instructions:
- Water: Needs moderate watering, avoid overwatering.
- Light: Thrives in full sunlight.
- Soil: Prefers rich, well-drained soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki4);

            var wiki5 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Peony Wiki",
                ThumbnailImageUrl = "https://images.squarespace-cdn.com/content/v1/604c31ef22e44a51184b36cc/1654917745714-7X4NWLS0ACVX4VFO8L1E/unsplash-image-3G_tK4V4lcs.jpg",
                Content = @"General Description:
Peonies are lush and fragrant flowers often associated with romance and prosperity. They are native to Asia, Europe, and western North America.

Scientific Classification:
Species: Paeonia spp.
Genus: Paeonia
Family: Paeoniaceae
Order: Saxifragales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Peonies contribute to soil stability and attract pollinators.
- Economic Value:
  Highly prized in the floral industry and traditional medicine.

Care Instructions:
- Water: Requires deep watering during growth periods.
- Light: Prefers full sun but tolerates partial shade.
- Soil: Thrives in well-drained, fertile soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki5);

            var wiki6 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Marigold Wiki",
                ThumbnailImageUrl = "https://rukminim2.flixcart.com/image/850/1000/kqqykcw0/plant-seed/z/y/m/40-marigold-seeds-onecare-original-imag4zktytrnf7rp.jpeg?q=90&crop=false",
                Content = @"General Description:
Marigolds are vibrant and hardy flowers commonly used in gardens and ceremonies. They are native to the Americas but widely cultivated worldwide.

Scientific Classification:
Species: Tagetes spp.
Genus: Tagetes
Family: Asteraceae
Order: Asterales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Marigolds deter pests and enrich soil with nutrients.
- Economic Value:
  Used in traditional medicine and as natural dyes.

Care Instructions:
- Water: Moderate watering; avoid waterlogging.
- Light: Requires full sunlight for optimal blooming.
- Soil: Prefers well-drained, sandy soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki6);


            var wiki7 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Lavender Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1GxnilH41ZebC9aBYmGsYBv63rMWqpupz0Q&s",
                Content = @"General Description:
Lavender is a fragrant herbaceous plant valued for its soothing properties. It is native to the Mediterranean region.

Scientific Classification:
Species: Lavandula angustifolia
Genus: Lavandula
Family: Lamiaceae
Order: Lamiales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Lavender attracts pollinators and supports biodiversity.
- Economic Value:
  Widely used in cosmetics, essential oils, and aromatherapy.

Care Instructions:
- Water: Drought-tolerant; water sparingly.
- Light: Prefers full sunlight.
- Soil: Grows best in well-drained, sandy soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki7);

            var wiki9 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Jasmine Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUfN93K3dfZVXrK-UVz2mkTgZr2PYCvd4vYA&s",
                Content = @"General Description:
Jasmine is a highly fragrant flower often associated with purity and spirituality. It is widely distributed across tropical and subtropical regions.

Scientific Classification:
Species: Jasminum spp.
Genus: Jasminum
Family: Oleaceae
Order: Lamiales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Jasmine supports local pollinator species like bees and butterflies.
- Economic Value:
  Its essential oils are extensively used in perfumery and aromatherapy.

Care Instructions:
- Water: Requires regular watering during dry spells.
- Light: Thrives in full to partial sunlight.
- Soil: Prefers rich, well-drained soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki9);


            var wiki10 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Cherry Blossom Wiki",
                ThumbnailImageUrl = "https://d384u2mq2suvbq.cloudfront.net/public/spree/products/1597/jumbo/Japanese-Cherry-Blossom-Fragrance-Oil.webp?1704911119",
                Content = @"General Description:
Cherry blossoms are iconic flowers symbolizing the transient beauty of life. They are native to East Asia, especially Japan, Korea, and China.

Scientific Classification:
Species: Prunus serrulata
Genus: Prunus
Family: Rosaceae
Order: Rosales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Cherry blossom trees enhance air quality and provide habitats for birds and insects.
- Economic Value:
  Major attractions during spring festivals and widely used in culinary arts.

Care Instructions:
- Water: Needs consistent watering during dry periods.
- Light: Requires full sunlight to thrive.
- Soil: Prefers fertile, well-drained soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki10);


            var wiki11 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Hibiscus Wiki",
                ThumbnailImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT2FCiVHulIy7GTSTf-e38-cTX6_Q2n7XXDqQ&s",
                Content = @"General Description:
Hibiscus is a large, vibrant flower often used for ornamental and medicinal purposes. It is native to warm and tropical climates worldwide.

Scientific Classification:
Species: Hibiscus rosa-sinensis
Genus: Hibiscus
Family: Malvaceae
Order: Malvales
Class: Magnoliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Attracts pollinators like bees and hummingbirds, contributing to biodiversity.
- Economic Value:
  Used in herbal teas, cosmetics, and as ornamental plants.

Care Instructions:
- Water: Requires regular watering, especially during blooming.
- Light: Prefers full sunlight.
- Soil: Thrives in moist, well-drained soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki11);


            var wiki12 = new Wiki
            {
                Id = Guid.NewGuid(),
                Title = "Tulip Wiki",
                ThumbnailImageUrl = "https://bizweb.dktcdn.net/thumb/1024x1024/100/442/027/products/img-3670-jpg.jpg?v=1723713087120",
                Content = @"General Description:
Tulips are iconic spring flowers known for their vibrant colors and simple elegance. They are native to Central Asia and Turkey but are closely associated with the Netherlands.

Scientific Classification:
Species: Tulipa spp.
Genus: Tulipa
Family: Liliaceae
Order: Liliales
Class: Liliopsida
Phylum: Magnoliophyta

Culture:
- Environmental Protection Value:
  Tulip gardens improve local ecosystems by providing seasonal habitats.
- Economic Value:
  Highly significant in the floral industry and tourism.

Care Instructions:
- Water: Requires moderate watering during growth.
- Light: Prefers full sunlight.
- Soil: Thrives in fertile, well-drained soil.",
                Contributors = new List<User> { firstUser, secondUser, thirdUser },
                AuthorId = firstUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            context.Wikis.Add(wiki12);



            context.SaveChanges();

            if (firstWiki == null || firstUser == null)
            {
                Console.WriteLine("No wikis or users found.");
                return;
            }
            var firstWikiId = firstWiki.Id;
            var firstUserId = firstUser.UserId;

            SeedContributions(context, firstWikiId, firstUserId);
        }
    }
}
