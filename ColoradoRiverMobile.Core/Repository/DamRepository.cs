using System;
using System.Collections.Generic;
using System.Linq;
using ColoradoRiverMobile.Core.Models;

namespace ColoradoRiverMobile.Core.Repository
{
    public class DamRepository
    {

        private static readonly List<Dam> AllDams = new List<Dam>()
        {
            new Dam { // done
                DamId = 1,
                Name = "Glen Canyon Dam",
                Description = "\u2022 Completed: 1968\n\n\u2022 Purpose: power generation, water shortage, flood control\n\n\u2022 " +
                "Operated by: Bureau of Reclamation\n\n\u2022 Last dam built on the Colorado River due to rising environmental concerns",
                ImageName = "GlenCanyonDamImage",
                GPIO = 7,
                AnswerImageName = "wahweapMarinaGlenCanyonDam",
                AnswerDescription = "\u2022The construction of Glen Canyon Dam created Lake Powell\n\n" +
                "\u2022The lake can store 27 million acre feet of water, equal to 2 years of the Colorado River’s average annual volume\n\n" +
                "\u2022This fact makes Lake Powell a popular vacation spot for millions of visitors each year",
                Answer = "Over 4 Million!",
                Question = "How many people do you think visit Glen Canyon Recreation Area annually?"
            },
            new Dam { // done
                DamId = 2,
                Name = "Hoover Dam",
                Description = "\u2022 Completed: 1936\n\n\u2022 Purpose: power generation, water storage, flood control\n\n\u2022 Operated by: U.S. Bureau of Reclamation" +
                "Tallest dam on the Colorado River at 246.4 ft.",
                ImageName = "HooverDamImage",
                GPIO = 11,
                AnswerImageName = "HooverDamUnderConstructionAnswerImage",
                AnswerDescription = "\u2022 Concrete placement began on June 6, 1933 and ended on May 29, 1935\n\n" +
                "\u2022 The dam is composed of individually poured, concrete vertical columns\n\n" +
                "\u2022 Only 5 feet of concrete could be added to each column every 72 hours (3 days)\n\n"+
                "\u2022 Ice water circulated through steel pipes in the concrete to cool and harden the mixture\n\n",
                Answer = "3.25 million cubic yards!",
                Question = "How much concrete do you think is in the Hoover Dam?"
            },
            new Dam { //done
                DamId = 3,
                Name = "Davis Dam",
                Description = "\u2022 Completed: 1951\n\n" +
                "\u2022 Purpose: generates power, regulates water delivers to Mexico through integrated Davis and Hoover power plants\n\n" +
                "\u2022 Operated by: U.S. Bureau of Reclamation\n\n" +
                "\u2022 Originally named Bullshead Dam",
                ImageName = "DavisDamImage",
                GPIO = 12,
                AnswerImageName = "DavisDamImageDescription",
                AnswerDescription =  "\u2022 On February 3, 1944, the United States signed the Utilization of Waters Treaty with Mexico\n\n" +
                "\u2022 Through this treaty, the U.S. agrees to send 1.5 million acre feet of water from the Colorado River into Mexico every year\n\n" +
                "\u2022 Davis Dam helps regulate the amount of water that is delivered to Mexico from the Colorado River\n\n",
                Answer = "1944 U.S. – Mexico Water Treaty!",
                Question = "Why do you think the United States has to regulate the water that it sends to Mexico?"
            },
            new Dam { // done
                DamId = 4,
                Name = "Parker Dam",
                Description = "\u2022 Completed: 1938\n\n" +
                "\u2022 Purpose: generate power, divert water to Colorado River Aqueduct and Central Arizona Project Aqueduct\n\n" +
                "\u2022 Operated by: U.S. Bureau of Reclamation\n\n" +
                "\u2022 Deepest dam in the world, reaching 235 feet below the riverbed",
                ImageName = "ParkerDamImage",
                GPIO = 13,
                AnswerImageName = "ParkerDamImageDescription",
                AnswerDescription = "\u2022 The Colorado River Aqueduct (CRA) spans 242 miles from Parker Dam to Los Angeles and San Diego\n\n" +
                "\u2022 The CRA provides approximately 50% of the drinking water for Los Angels and San Diego\n\n" +
                "\u2022 Along the CRA are numerous siphons that help the water move through multiple mountain ranges\n\n" +
                "\u2022 The Central Arizona Project Aqueduct (CAP) spans 336 miles from Parker Dam to Phoenix and Tucson\n\n" +
                "\u2022 The CAP primarily provides water for irrigation, but is also a major source of drinking water for Phoenix and Tucson\n\n",
                Answer = "578 miles combined!",
                Question = "How many miles do you think the Colorado River Aqueduct and the Central Arizona Project Aqueduct span?"
            },
            new Dam { // done
                DamId = 5,
                Name = "Headgate Rock Dam",
                Description = "\u2022 Completed: 1942\n\n" +
                "\u2022 Purpose: provides irrigation water to the Colorado River Indian Tribes (CRIT) Reservation\n\n" +
                "" +
                "\u2022 Operated by: Bureau of Indian Affairs\n\n" +
                "\u2022 Created Lake Moovalya",
                ImageName = "HeadgateRockDamImage",
                GPIO = 15,
                AnswerImageName = "HeadgateRockDamImageDescription",
                AnswerDescription = "\u2022 The Navajo, Hopi, Mojave, Chemehuevi, Cocopah, Quechan, Havasupai, and Hualapai all have reservations along the Colorado River\n\n" +
                "\u2022 Two of these tribes have reservations near Yuma: the Cocopah and the Quechan\n\n" +
                "\u2022 The Quechan tribe has long controlled the Yuma Crossing, which has historically been considered the best place to cross the lower Colorado River",
                Answer = "Eight",
                Question = "How many federally recognized American Indian tribes do you think live along the lower Colorado River?"
            },
            new Dam { // done
                DamId = 6,
                Name = "Palo Verde Dam",
                Description = "\u2022 Completed: 1957\n\n" +
                "\u2022 Purpose: divert water into irrigation canals serving the Palo Verde Irrigation District\n\n" +
                "\u2022 Operated by: Palo Verde Irrigation District\n\n" +
                "\u2022 Built by the Bureau of Reclamation to replace a temporary rock weir constructed during WWII",
                ImageName = "PaloVerdeDamImage",
                GPIO = 16,
                AnswerImageName = "PaloVerdeDamImageDescription",
                AnswerDescription = "\u2022 In the 1870s, Thomas Blythe owned a third of what is today known as the Palo Verde Valley. He cultivated his land by diverting some of the Colorado River with gravity\n\n" +
                "\u2022 Today, the Palo Verde Dam is located near the town of Blythe, California",
                Answer = "Thomas Blythe!",
                Question = "Who was the first, non-native settler recorded to have built an irrigation system at this point on the Colorado River?"
            },
            new Dam { // done
                DamId = 7,
                Name = "Senator Wash Dam",
                Description = "\u2022 Completed: 1966\n\n" +
                "\u2022 Purpose: water storage\n\n" +
                "\u2022 Operated by: Imperial Irrigation District\n\n" +
                "\u2022 Improves water release schedules to Mexico\n\n",
                ImageName = "SenatorWashDamImage",
                GPIO = 18,
                AnswerImageName = "SenatorWashDamImageDescription",
                AnswerDescription = "\u2022 1.5 million acre feet of water is equal to almost 2 trillion liters!\n\n" +
                "\u2022 Because of the 1944 U.S. – Mexico Water Treaty, the United States has to monitor the amount of Colorado River water that it sends to Mexico each year. Senator Wash Dam was built specifically to store water that is not yet ready to be sent to Mexico\n\n",
                Answer = "1.5 million acre feet!",
                Question = "How much water does the United States send to Mexico each year?"
            },
            new Dam { // done
                DamId = 8,
                Name = "Imperial Dam",
                Description = "\u2022 Completed: 1938\n\n" +
                "\u2022 Purpose: diverts water to the All-American Canal and the Gila Gravity Main Canals for irrigation and drinking\n\n" +
                "\u2022 Operated by: Imperial Irrigation District\n\n" +
                "\u2022 90% of the Colorado River’s remaining water flow is diverted at Imperial Dam",
                ImageName = "ImperialDamImage",
                GPIO = 22,
                AnswerImageName = "ImperialDamImageDescription",
                AnswerDescription = "\u2022 Historically, the water in the Colorado River was a brownish-red color\n\n" +
                "\u2022 The water was this color because of the large amounts of sediment that it carried\n\n" +
                "\u2022 Today, that sediment is removed at Imperial Dam in their three desilting basins and then returned to the Colorado River through the California Sluiceway",
                Answer = "Colored Red",
                Question = "What do you think “Colorado” means?"
            },
            new Dam { // done
                DamId = 9,
                Name = "Laguna Dam",
                Description = "\u2022 Completed: 1909\n\n" +
                "\u2022 Purpose: water diversion for irrigation\n\n" +
                "\u2022 Operated by: Imperial Irrigation District\n\n" +
                "\u2022 First dam built on the Colorado River",
                ImageName = "LagunaDamImage",
                GPIO = 29,
                AnswerImageName = "LagunaDamImageDescription",
                AnswerDescription = "\u2022 The Bureau of Reclamation was headquartered here from 1904-1949\n\n" +
                "\u2022 They used the Corral House for their offices and the Storehouse as a machine shop\n\n" +
                "\u2022 While here, the Bureau of Reclamation constructed the Yuma Irrigation Project, turning Yuma into an agricultural powerhouse",
                Answer = "True!",
                Question = "True or False:\nThe Bureau of Reclamation built Laguna Dam from their Yuma Project office at the Colorado River State Historic Park."
            },
            new Dam {
                DamId = 10,
                Name = "Morelos Dam",
                Description = "\u2022 Completed: 1950\n\n" +
                "\u2022 Purpose: divert irrigation and drinking water to the Mexicali Valley\n\n" +
                "\u2022 Operated by: International Boundary and Water Commission\n\n" +
                "\u2022 Last dam on the river and the only one located in Mexico",
                ImageName = "MorelosDamImage",
                GPIO = 31, AnswerImageName = "MorelosDamImageDescription",
                AnswerDescription = "\u2022 In the past, the Colorado River flowed into its delta at the Gulf of California\n\n" +
                "\u2022 Today, the river ends just below the Morelos Dam, where the last of the water is diverted\n\n" +
                "\u2022 The supply of Colorado River water is unable to meet increasing demands, making the future of the river uncertain\n\n" +
                "\u2022 Our challenge is to find the balance between human consumption and nature. So much depends upon this lifeline in the desert",
                Answer = "It Depends On Us!",
                Question = "Where do you think the Colorado River ends?"
            }

        };
        public List<Dam> GetAllDams()
        {
            return AllDams;
        }
        public Dam GetDamById(int id) {

            return AllDams.FirstOrDefault(d => d.DamId == id);

        }
    }
}
