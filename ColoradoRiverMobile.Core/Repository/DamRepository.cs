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
                Name = "GLEN CANYON DAM",
                Description = "Completed: 1968\n" +
               "Purpose: power generation, water storage, flood control\n" +
                "Operated by: Bureau of Reclamation\n" +
               "Last dam built on the Colorado River due to rising environmental concerns",
                ImageName = "glenCanyonDam",
                GPIO = 7,
                AnswerImageName = "glenAnswer",
                AnswerDescription = "The construction of Glen Canyon Dam created Lake Powell\n" +
                "The lake can store 27 million acre feet of water, equal to 2 years of the Colorado River’s average annual volume\n" +
                "This fact makes Lake Powell a popular vacation spot for millions of visitors each year",
                Answer = "Over 4 Million!",
                Question = "How many people do you think visit Glen Canyon Recreation Area annually?"
            },
            new Dam { // done
                DamId = 2,
                Name = "HOOVER DAM",
                Description = "Completed: 1936\n" +
                "Purpose: power generation, water storage, flood control\n" +
                "Operated by: U.S. Bureau of Reclamation\n" +
                "Tallest dam on the Colorado River at 246.4 ft.",
                ImageName = "hooverDam",
                GPIO = 11,
                AnswerImageName = "hooverAnswer",
                AnswerDescription = "Concrete placement began on June 6, 1933 and ended on May 29, 1935\n" +
                "The dam is composed of individually poured, concrete vertical columns\n" +
                "Only 5 feet of concrete could be added to each column every 72 hours (3 days)\n"+
                "Ice water circulated through steel pipes in the concrete to cool and harden the mixture",
                Answer = "3.25 Million Cubic Yards!",
                Question = "How much concrete do you think is in the Hoover Dam?"
            },
            new Dam { //done
                DamId = 3,
                Name = "DAVIS DAM",
                Description = "Completed: 1951\n" +
                "Purpose: generates power, regulates water delivers to Mexico through integrated Davis and Hoover power plants\n" +
                "Operated by: U.S. Bureau of Reclamation\n" +
                "Originally named Bullshead Dam",
                ImageName = "davisDam",
                GPIO = 12,
                AnswerImageName = "davisAnswer",
                AnswerDescription =  "On February 3, 1944, the United States signed the Utilization of Waters Treaty with Mexico\n" +
                "Through this treaty, the U.S. agrees to send 1.5 million acre feet of water from the Colorado River into Mexico every year\n" +
                "Davis Dam helps regulate the amount of water that is delivered to Mexico from the Colorado River",
                Answer = "1944 U.S. – Mexico Water Treaty!",
                Question = "Why do you think the United States has to regulate the water that it sends to Mexico?"
            },
            new Dam { // done
                DamId = 4,
                Name = "PARKER DAM",
                Description = "Completed: 1938\n" +
                "Purpose: generate power, divert water to Colorado River Aqueduct and Central Arizona Project Aqueduct\n" +
                "Operated by: U.S. Bureau of Reclamation\n" +
                "Deepest dam in the world, reaching 235 feet below the riverbed",
                ImageName = "parkerDam",
                GPIO = 13,
                AnswerImageName = "parkerAnswer",
                AnswerDescription = "The Colorado River Aqueduct (CRA) spans 242 miles from Parker Dam to Los Angeles and San Diego\n" +
                "The CRA provides approximately 50% of the drinking water for Los Angeles and San Diego\n" +
                "Along the CRA are numerous siphons that help the water move through multiple mountain ranges\n" +
                "The Central Arizona Project Aqueduct (CAP) spans 336 miles from Parker Dam to Phoenix and Tucson\n" +
                "The CAP primarily provides water for irrigation, but is also a major source of drinking water for Phoenix and Tucson",
                Answer = "578 Miles Combined!",
                Question = "How many miles do you think the Colorado River Aqueduct and the Central Arizona Project Aqueduct span?"
            },
            new Dam { // done
                DamId = 5,
                Name = "HEADGATE ROCK DAM",
                Description = "Completed: 1942\n" +
                "Purpose: provides irrigation water to the Colorado River Indian Tribes (CRIT) Reservation\n" +
                "Operated by: Bureau of Indian Affairs\n" +
                "Created Lake Moovalya",
                ImageName = "headgateRockDam",
                GPIO = 15,
                AnswerImageName = "headgateAnswer",
                AnswerDescription = "The Navajo, Hopi, Mojave, Chemehuevi, Cocopah, Quechan, Havasupai, and Hualapai all have reservations along the Colorado River\n" +
                "Two of these tribes have reservations near Yuma: the Cocopah and the Quechan\n" +
                "The Quechan tribe has long controlled the Yuma Crossing, which has historically been considered the best place to cross the lower Colorado River",
                Answer = "Eight",
                Question = "How many federally recognized American Indian tribes do you think live along the lower Colorado River?"
            },
            new Dam { // done
                DamId = 6,
                Name = "PALO VERDE DAM",
                Description = "Completed: 1957\n" +
                "Purpose: divert water into irrigation canals serving the Palo Verde Irrigation District\n" +
                "Operated by: Palo Verde Irrigation District\n" +
                "Built by the Bureau of Reclamation to replace a temporary rock weir constructed during WWII",
                ImageName = "paloVerdeDam",
                GPIO = 16,
                AnswerImageName = "paloVerdeAnswer",
                AnswerDescription = "In the 1870s, Thomas Blythe owned a third of what is today known as the Palo Verde Valley. He cultivated his land by diverting some of the Colorado River with gravity\n" +
                "Today, the Palo Verde Dam is located near the town of Blythe, California",
                Answer = "Thomas Blythe!",
                Question = "Who was the first, non-native settler recorded to have built an irrigation system at this point on the Colorado River?"
            },
            new Dam { // done
                DamId = 7,
                Name = "SENATOR WASH DAM",
                Description = "Completed: 1966\n" +
                "Purpose: water storage\n" +
                "Operated by: Imperial Irrigation District\n" +
                "Improves water release schedules to Mexico",
                ImageName = "senatorWashDam",
                GPIO = 18,
                AnswerImageName = "senatorAnswer",
                AnswerDescription = "1.5 million acre feet of water is equal to almost 2 trillion liters!\n" +
                "Because of the 1944 U.S. – Mexico Water Treaty, the United States has to monitor the amount of Colorado River water that it sends to Mexico each year. Senator Wash Dam was built specifically to store water that is not yet ready to be sent to Mexico",
                Answer = "1.5 Million Acre Feet!",
                Question = "How much water does the United States send to Mexico each year?"
            },
            new Dam { // done
                DamId = 8,
                Name = "IMPERIAL DAM",
                Description = "Completed: 1938\n" +
                "Purpose: diverts water to the All-American Canal and the Gila Gravity Main Canals for irrigation and drinking\n" +
                "Operated by: Imperial Irrigation District\n" +
                "90% of the Colorado River’s remaining water flow is diverted at Imperial Dam",
                ImageName = "imperialDam",
                GPIO = 22,
                AnswerImageName = "imperialAnswer",
                AnswerDescription = "Historically, the water in the Colorado River was a brownish-red color\n" +
                "The water was this color because of the large amounts of sediment that it carried\n" +
                "Today, that sediment is removed at Imperial Dam in their three desilting basins and then returned to the Colorado River through the California Sluiceway",
                Answer = "Colored Red",
                Question = "What do you think “Colorado” means?"
            },
            new Dam { // done
                DamId = 9,
                Name = "LAGUNA DAM",
                Description = "Completed: 1909\n" +
                "Purpose: water diversion for irrigation\n" +
                "Operated by: Imperial Irrigation District\n" +
                "First dam built on the Colorado River",
                ImageName = "lagunaDam",
                GPIO = 29,
                AnswerImageName = "lagunaAnswer",
                AnswerDescription = "The Bureau of Reclamation was headquartered here from 1904-1949\n" +
                "They used the Corral House for their offices and the Storehouse as a machine shop\n" +
                "While here, the Bureau of Reclamation constructed the Yuma Irrigation Project, turning Yuma into an agricultural powerhouse",
                Answer = "True!",
                Question = "True or False:\nThe Bureau of Reclamation built Laguna Dam from their Yuma Project office at the Colorado River State Historic Park."
            },
            new Dam {
                DamId = 10,
                Name = "MORELOS DAM",
                Description = "Completed: 1950\n" +
                "Purpose: divert irrigation and drinking water to the Mexicali Valley\n" +
                "Operated by: International Boundary and Water Commission\n" +
                "Last dam on the river and the only one located in Mexico",
                ImageName = "morelosDam",
                GPIO = 31, AnswerImageName = "morelosAnswer",
                AnswerDescription = "In the past, the Colorado River flowed into its delta at the Gulf of California\n" +
                "Today, the river ends just below the Morelos Dam, where the last of the water is diverted\n" +
                "The supply of Colorado River water is unable to meet increasing demands, making the future of the river uncertain\n" +
                "Our challenge is to find the balance between human consumption and nature. So much depends upon this lifeline in the desert",
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
