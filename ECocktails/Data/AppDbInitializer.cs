using ECocktails.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Bars.Any())
                {
                    context.Bars.AddRange(new List<Bar>()
                    {
                        new Bar()
                        {
                           Name = "Casa Bar",
                           Logo = "https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-thumbnail/s3/0014/3720/brand.gif?itok=9edvXMBB",
                           Address = "Ѓуро Ѓаковиќ 66 1000 Skopje, Republic of Macedonia"
                        },
                        new Bar()
                        {
                           Name = "Heart Bar",
                           Logo = "https://cdn1.vectorstock.com/i/1000x1000/66/45/isolated-videogame-bar-with-a-heart-shape-icon-vector-24946645.jpg",
                           Address = "MK, Naum Naumovski Borche 50-1/1, Skopje 1000"
                        },
                        new Bar()
                        {
                           Name = "Rock Bar Garson",
                           Logo = "https://fastly.4sqi.net/img/general/600x600/89189276_p5_7691J3FLPVCRmJZdJJfGXUkQxgPnMFjC-io2mJig.jpg",
                           Address = "Dame Gruev, Skopje 1000"
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Barmans.Any())
                {
                    context.Barmans.AddRange(new List<Barman>()
                    {
                        new Barman()
                        {
                            FullName = "Natasha Mesa",
                            PictureUrl = "https://bartendersbusiness.com/en/articles/images/w/800/BartendersBusiness-01242019054128000000-5c4950086b855.jpg",
                            Bio = "Natasha Mesa found her home in the bar community. She currently manages Deadshot, Portland’s most exciting new bar, but Natasha has been a pillar of the Portland bar community since she arrived seven years ago."
                        },
                        new Barman()
                        {
                            FullName = "Jacopo Rosito",
                            PictureUrl = "https://www.liquor.com/thmb/aZxjGpftGB9e7Oerd-YPyyYB9cs=/720x480/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__liquor__2017__06__14115035__You-Ready-for-the-Best-Kind-of-Italian-Bar-Hospitality-54-mint-jacopo-720x480-inline-59e1603dd172468aa126b8c66279f656.jpg",
                            Bio = "In San Francisco, Jacopo Rosito hails from Florence and has helmed the bar at 54 Mint, a Roman Italian restaurant in San Francisco's Mint Plaza, since it took on it liquor license in 2015"
                        },
                        new Barman()
                        {
                            FullName = "Dale DeGroff",
                            PictureUrl = "https://bartendersbusiness.com/cont/blog/imagePot/BartendersBusiness-03112020113100000000-5e68cbf46b2a1.jpg",
                            Bio = "Dale DeGroff (born September 21, 1948, Rhode Island), also known as the King of Cocktails or King Cocktail, is an American bartender and author. The New York Times in 2015 called DeGroff \"one of the world’s foremost cocktail experts\", and wrote that his book \"The Craft of the Cocktail\" is considered an essential bartending reference."
                        }
                    });

                    context.SaveChanges();
                }
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Beefeater Gin",
                            PictureUrl = "https://mediacore.kyuubi.it/anticaenotecagiulianelli/media/img/2020/8/16/165158-large-gin-beefeater-london-dry-40-70cl.jpg",
                            Bio = "Beefeater Gin is a brand of gin owned by Pernod Ricard and bottled and distributed in the United Kingdom, by the company of James Burrough. Beefeater remained in the Burrough's family control until 1987. It is a 47% or 44% alcohol product in the US, and a 40% alcohol product elsewhere in the world.",
                            Type = IngredientType.Alcohol
                        },
                        new Ingredient()
                        {
                            Name = "Lime Juice",
                            PictureUrl = "https://envato-shoebox-0.imgix.net/31ae/457c-07aa-11e2-952c-842b2b692e1a/IMG_33292.jpg?auto=compress%2Cformat&fit=max&mark=https%3A%2F%2Felements-assets.envato.com%2Fstatic%2Fwatermark2.png&markalign=center%2Cmiddle&markalpha=18&w=700&s=ec36e16f2e13181d26821b792a01729f",
                            Bio = "Limes have higher contents of sugars and acids than lemons do. Lime juice may be squeezed from fresh limes, or purchased in bottles in both unsweetened and sweetened varieties.",
                            Type = IngredientType.FruitOrVegetable
                        },
                        new Ingredient()
                        {
                            Name = "Triple Sec",
                            PictureUrl = "https://cdn.caskers.com/catalog/product/cache/ce56bc73870585a38310c58e499d2fd4/d/e/de-kuyper-triple-sec-1.jpg",
                            Bio = "Triple sec is an orange-flavoured liqueur that originated in France. It contains 15–40% alcohol by volume. It is made by macerating sun-dried orange skins in alcohol for at least 24 hours before undergoing a three- step distillation process.",
                            Type = IngredientType.Alcohol
                        },
                        new Ingredient()
                        {
                            Name = "Simple Syrup",
                            PictureUrl = "https://cdn.caskers.com/catalog/product/cache/ce56bc73870585a38310c58e499d2fd4/d/e/de-kuyper-triple-sec-1.jpg",
                            Bio = "Syrup or sirup is a condiment that is a thick, viscous liquid consisting primarily of a solution of sugar in water, containing a large amount of dissolved sugars but showing little tendency to deposit crystals.",
                            Type = IngredientType.Condiment
                        },
                        new Ingredient()
                        {
                            Name = "Orange Juice",
                            PictureUrl = "https://previews.123rf.com/images/denira/denira1801/denira180100033/94253411-orange-juice-in-a-glass-bottle-and-orange-fruit-with-green-leaves-isolated-on-white-background-.jpg",
                            Bio = "Orange juice is a liquid extract of the orange tree fruit, produced by squeezing or reaming oranges. It comes in several different varieties, including blood orange, navel oranges, valencia orange, clementine, and tangerine.",
                            Type = IngredientType.FruitOrVegetable
                        },
                        new Ingredient()
                        {
                            Name = "Grenadine",
                            PictureUrl = "https://pentrubar.ro/5162-large_default/grenadine-syrup-monin-07l.jpg",
                            Bio = "Grenadine is a commonly used, non-alcoholic bar syrup, characterized by a flavor that is both tart and sweet, and by a deep red color. It is popular as an ingredient in cocktails, both for its flavor and to give a reddish or pink tint to mixed drinks and is traditionally made from pomegranate.",
                            Type = IngredientType.NonAlcohol
                        },
                        new Ingredient()
                        {
                            Name = "Soda Water",
                            PictureUrl = "http://cdn.shopify.com/s/files/1/0224/6554/4272/products/Schweppes-Soda-Water_1200x1200.gif?v=1591167630",
                            Bio = "Carbonated water is water containing dissolved carbon dioxide gas, either artificially injected under pressure or occurring due to natural geological processes. Carbonation causes small bubbles to form, giving the water an effervescent quality.",
                            Type = IngredientType.NonAlcohol
                        },
                        new Ingredient()
                        {
                            Name = "Sweet Vermouth",
                            PictureUrl = "https://dydza6t6xitx6.cloudfront.net/ci-martini-rossi-rosso-sweet-vermouth-17925fd6f29021bd.jpeg",
                            Bio = "Sweet vermouth is a fortified wine that has been aromatised with a range of botanicals. It is also known as red vermouth (vermouth rosso) due to its colour or as Italian vermouth due to its origin. ",
                            Type = IngredientType.Alcohol
                        },
                        new Ingredient()
                        {
                            Name = "Campari",
                            PictureUrl = "https://www.paket.mk/wp-content/uploads/2019/05/BBL10016.jpg",
                            Bio = "Campari is an Italian alcoholic liqueur, considered an apéritif, obtained from the infusion of herbs and fruit in alcohol and water. It is a bitters, characterised by its dark red colour.",
                            Type = IngredientType.Alcohol
                        },
                        new Ingredient()
                        {
                            Name = "Salt",
                            PictureUrl = "https://timesofindia.indiatimes.com/thumb/msid-73927404,width-1200,height-900,resizemode-4/.jpg",
                            Bio = "Salt is a mineral composed primarily of sodium chloride, a chemical compound belonging to the larger class of salts.",
                            Type = IngredientType.Condiment
                        },
                        new Ingredient()
                        {
                            Name = "Tequilla",
                            PictureUrl = "https://www.whisky.fr/media/catalog/product/cache/4/image/9df78eab33525d08d6e5fb8d27136e95/m/5/m5655.jpg",
                            Bio = "Tequila is a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila 65 km northwest of Guadalajara, and in the Jaliscan Highlands of the central western Mexican state of Jalisco.",
                            Type = IngredientType.Alcohol
                        },
                    });
                    context.SaveChanges();

                }
                if (!context.Glass.Any())
                {
                    context.Glass.AddRange(new List<Glass>()
                    {
                        new Glass()
                        {
                            PictureUrl = "https://thumbs.dreamstime.com/b/realistic-cocktail-tequila-sunrise-transparent-background-full-empty-glass-realistic-cocktail-tequila-sunrise-vector-137475318.jpg"
                        },
                        new Glass()
                        {
                            PictureUrl = "https://www.acouplecooks.com/wp-content/uploads/2021/03/Ramos-Gin-Fizz-005.jpg"
                        },
                        new Glass()
                        {
                            PictureUrl = "https://www.markenglas.de/media/catalog/product/cache/3/image/9df78eab33525d08d6e5fb8d27136e95/1/1/11150_0_campari_negroni_glas_glcpi08150018_01.jpg"
                        },
                        new Glass()
                        {
                            PictureUrl = "https://www.ikea.com/gb/en/images/products/storsint-martini-glass-clear-glass__0800268_pe767839_s5.jpg?f=s"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Cocktails.Any())
                {
                    context.Cocktails.AddRange(new List<Cocktail>()
                    {
                        new Cocktail()
                        {
                            Name = "Classic Gin Fizz",
                            Description = "This classic cocktail from the 1870’s is perfectly balanced, both sweet and tart with a pop of lemon and a botanical finish.",
                            Price = 200.00,
                            PictureUrl = "https://www.acouplecooks.com/wp-content/uploads/2019/06/Gin-Fizz-112s.jpg",
                            GlassId = 2,
                            BarmanId = 3,
                            BarId = 1
                        },
                        new Cocktail()
                        {
                            Name = "Tequila Sunrise",
                            Description = "The Tequila Sunrise cocktail, with its bright striations of color, evokes a summer sunrise. This classic drink has only three ingredients—tequila, grenadine and orange juice—and is served unmixed to preserve the color of each layer.",
                            Price = 230.00,
                            PictureUrl = "https://www.culinaryhill.com/wp-content/uploads/2019/06/Tequila-Sunrise-Culinary-Hill-HRsquare-02-e1581009496486.jpg",
                            GlassId = 1,
                            BarmanId = 2,
                            BarId = 2
                        },
                        new Cocktail()
                        {
                            Name = "Negroni",
                            Description = "A Negroni is an Italian cocktail, made of one part gin, one part vermouth rosso, and one part Campari, garnished with orange peel. It is considered an apéritif. A traditionally made Negroni is stirred, not shaken, and built over ice in an old-fashioned or rocks glass and garnished with a slice of orange.",
                            Price = 260.00,
                            PictureUrl = "https://www.liquor.com/thmb/FpQjWZNtBBC8PoW8aPfUj7cysYg=/720x720/filters:fill(auto,1)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08110806__negroni-720x720-recipe-7c1b747a616f4659af4008d025ab55df.jpg",
                            GlassId = 3,
                            BarmanId = 1,
                            BarId = 3
                        },
                        new Cocktail()
                        {
                            Name = "Margarita",
                            Description = "A margarita is a Mexican cocktail consisting of tequila, orange liqueur, and lime juice often served with salt on the rim of the glass. The drink is served shaken with ice, blended with ice, or without ice.",
                            Price = 220.00,
                            PictureUrl = "https://i.pinimg.com/originals/30/58/d9/3058d9727e424ddbf7cf7321c6731231.jpg",
                            GlassId = 4,
                            BarmanId = 2,
                            BarId = 1
                        },
                    });
                    context.SaveChanges();
                }
                
                if (!context.Ingredients_Cocktails.Any())
                {
                    context.Ingredients_Cocktails.AddRange(new List<Ingredients_Cocktails>()
                    {
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 6,
                            IngredientId = 1,
                            Quantity = 60.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 6,
                            IngredientId = 2,
                            Quantity = 30.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 6,
                            IngredientId = 4,
                            Quantity = 22.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 6,
                            IngredientId = 7,
                            Quantity = 30.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 5,
                            IngredientId = 11,
                            Quantity = 60.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 5,
                            IngredientId = 5,
                            Quantity = 120.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 5,
                            IngredientId = 6,
                            Quantity = 8.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 4,
                            IngredientId = 1,
                            Quantity = 30.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 4,
                            IngredientId = 9,
                            Quantity = 30.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 4,
                            IngredientId = 8,
                            Quantity = 30.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 3,
                            IngredientId = 11,
                            Quantity = 50.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 3,
                            IngredientId = 2,
                            Quantity = 25.00
                        },
                        new Ingredients_Cocktails()
                        {
                            CocktailId = 3,
                            IngredientId = 3,
                            Quantity = 20.00
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
