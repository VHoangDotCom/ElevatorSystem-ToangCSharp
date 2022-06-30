namespace ElevatorSystem.Admin.Migrations
{
    using ElevatorSystem.Admin.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ElevatorSystem.Admin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ElevatorSystem.Admin.Models.ApplicationDbContext context)
        {
            var tags = new List<Tag>
            {
                new Tag{Title="building system",Description="outsourcing and installation for enterprise model projects",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
              /*  new Tag{Title="apartment",Description="High-rise apartment building and high-class elevator system",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                new Tag{Title="people's houses",Description="Small and minimalist elevator system",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                new Tag{Title="hospital",Description="system for public facilities",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                new Tag{Title="shopping mall",Description="system for public facilities",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("202-09-01") },*/

            };
            tags.ForEach(s => context.Tags.Add(s));
            context.SaveChanges();
            /*   var tags = new List<Tag>
               {
                   new Tag{Title="building system",Description="outsourcing and installation for enterprise model projects",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                   new Tag{Title="apartment",Description="High-rise apartment building and high-class elevator system",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                   new Tag{Title="people's houses",Description="Small and minimalist elevator system",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                   new Tag{Title="hospital",Description="system for public facilities",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("2022-09-01") },
                   new Tag{Title="shopping mall",Description="system for public facilities",IsPublished=true,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),PublishedAt=DateTime.Parse("202-09-01") },

               };
               tags.ForEach(s => context.Tags.Add(s));
               context.SaveChanges();

               var categories = new List<Category>
               {
                   new Category{Name="Elevator carrying people",Description="This type of elevator specializes in transporting passengers in buildings, people often call these types of elevators: hotel elevators, office elevators, office lifts, home elevators, motel elevators, and elevators. apartment building machines, school elevators, television tower elevators, elevators for the elderly, the elderly..."
                   ,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01")},
                   new Category{Name="Passenger lifts",Description="Passenger lifts with regard to accompanying goods: This type of elevator is often used for supermarkets, exhibition areas, etc..."
                   ,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01")},
                   new Category{Name="Patient lifts",Description="This type of elevator is specialized for hospitals, nursing areas... Its characteristic is that the clearance size of the cabin must be large enough to accommodate the patient's bed or bed, along with the doctors. Staff and first aid equipment included. Currently, the world has produced according to the same size and load standards for this type of elevator."
                   ,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01")},
                   new Category{Name="Cargo elevator",Description="This type of elevator is often used in factories, factories, warehouses, elevators for hotel staff, etc., mainly used to carry goods but accompanied by people to serve."
                   ,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01")},
                   new Category{Name="Unaccompanied cargo elevator",Description="This type of elevator is used to transport materials, and food in hotels, canteens, etc. The feature of this type is that it can only be controlled outside the cabin, and other Other types of elevators mentioned above are controlled both inside and outside the cabin."
                   ,CreatedAt=DateTime.Now,ModifiedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01")},
               };
               categories.ForEach(s => context.Categories.Add(s));
               context.SaveChanges();



               var elevators = new List<Elevator>
               {
                   new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                    new Elevator{Name="Observation elevator FJJX015",SKU="FJJX015",Status=1,Description="FJJX015(Diamond shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel with Ti-gold hairline st.st. decoration\nObservation wall:Glass with Ti-gold hairline st.st. frame\nCar side wall & front wall:Ti-gold mirror st.st.\nCeiling:FJDD015(Mirror st.st.,LED lamp,acrylic light decoration)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F6bd3c5fa8385f9aeac2b1e434275826d.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="801 E 86Th Ave",Slug="Elevator carrying people",Tag="people's houses, shopping mall",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1},
                     new Elevator{Name="Observation elevator FJJX012",SKU="FJJX012",Status=1,Description="FJJX012(Semi-circular observation elevator)\nUpper & Lower shades:Steel plate baked enamel with Ti-gold hairline st.st. and light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS015(Hairline st.st. round handrail)\nFloor:FJDB015(PVC/Marble))"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F43e9b5bb936b64107a0e604538aaed79.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="hospital, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                      new Elevator{Name="Observation elevator FJJX011",SKU="FJJX011",Status=1,Description="FJJX011(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F09d33dc3d84a98836d0ccae77cbea102.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                       new Elevator{Name="Observation elevator FJJX010",SKU="FJJX010",Status=1,Description="FJJX010(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F8a7cb14dae813ce327c8d2ec24b43872.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                        new Elevator{Name="Observation elevator FJJX009",SKU="FJJX009",Status=1,Description="FJJX009(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F88ee08f728daa164e93a29754cb76ff0.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                         new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                          new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                           new Elevator{Name="Dumbwaiter elevator",SKU="FJJX0416",Status=1,Description="FJJ2X016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2F3ce0986a765a745eb0355143a1eeaae0.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                           new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
                             new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1},
                              new Elevator{Name="Observation elevator FJJX016",SKU="FJJX016",Status=1,Description="FJJX016(Ship shape observation elevator)\nUpper & Lower shades:Steel plate baked enamel,hairline st.st. with light decoration\nObservation wall:Glass with hairline st.st. frame\nCar side wall & front wall:Hairline st.st.\nCeiling:FJDD016(Mirror st.st.,LED lamp,acrylic light decoration)\nHandrail:FJFS016(Hairline st.st. round handrail)\nFloor:FJDB016(PVC/Marble)"
                   ,Thumbnails="https://d1c6gk3tn6ydje.cloudfront.net/1532467746216910848%2Fda6206cbdd7282cb17e64fd128f8f722.webp",Capacity=11,Speed=132,Price=134,MaxPerson=12,Location="1800 E Lincoln Rd",Slug="Elevator carrying people",Tag="building system, apartment",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Parse("2022-09-01"),DeletedAt=DateTime.Parse("2022-09-01"),CategoryID=1 },
               };
               elevators.ForEach(s => context.Elevators.Add(s));
               context.SaveChanges();
   */
        }
    }
}
