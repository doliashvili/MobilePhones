using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WandioMobilePhones.Domain.DomainObjects;

namespace WandioMobilePhones.Infrastructure.Configuration
{
    class DbInitialaizer
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            var imagesforIphone11 = new List<Image>{
                                            new Image("fb.com"){Id=Guid.NewGuid()},
                                            new Image("fb.com"){Id=Guid.NewGuid()}
                                                 };

            var phones = new List<PhoneMobileAggregate>{
                new PhoneMobileAggregate(Guid.Parse("55dc3d14-5b55-4da2-9f69-b864a72c6cb2"),
                                        "IPhone 10",
                                        "Apple",
                                        "XL",
                                        200.5,
                                        "500px",
                                        "AppleI8Proccess",
                                        "32gb",
                                        "IOS",
                                        1000,
                                        null,
                                        "youtube.com"),

                new PhoneMobileAggregate(Guid.NewGuid(),
                                        "IPhone 11",
                                        "Apple",
                                        "X",
                                        200.5,
                                        "500px",
                                        "AppleI8Proccess",
                                        "32gb",
                                        "IOS",
                                        1500,
                                        null,
                                        "youtube.com"),

                new PhoneMobileAggregate(Guid.NewGuid(),
                                        "Galaxy",
                                        "Samsung",
                                        "XL",
                                        200.5,
                                        "500px",
                                        "SAMSUNGI8Proccess",
                                        "64gb",
                                        "Android",
                                        500,
                                         null
                                        ,
                                        "youtube.com"),
            };


            
            modelBuilder.Entity<Image>().HasData(imagesforIphone11);
            modelBuilder.Entity<PhoneMobileAggregate>().HasData(phones);
        }
    }
}
