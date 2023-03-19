namespace VaporStore.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (ImportGameDto gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game g = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer gameDev = developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (gameDev == null)
                {
                    Developer newGameDev = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(newGameDev);

                    g.Developer = newGameDev;
                }
                else
                {
                    g.Developer = gameDev;
                }

                Genre gameGenre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (gameGenre == null)
                {
                    Genre newGenre = new Genre()
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(newGenre);
                    g.Genre = newGenre;
                }
                else
                {
                    g.Genre = gameGenre;
                }

                foreach (string tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag gameTag = tags
                        .FirstOrDefault(t => t.Name == tagName);

                    if (gameTag == null)
                    {
                        Tag newGameTag = new Tag()
                        {
                            Name = tagName
                        };

                        tags.Add(newGameTag);
                        g.GameTags.Add(new GameTag()
                        {
                            Game = g,
                            Tag = newGameTag
                        });
                    }
                    else
                    {
                        g.GameTags.Add(new GameTag()
                        {
                            Game = g,
                            Tag = gameTag
                        });
                    }
                }

                if (g.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(g);
                sb.AppendLine(String.Format(SuccessfullyImportedGame, g.Name, g.Genre.Name, g.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            List<User> users = new List<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Card> userCards = new List<Card>();

                bool areAllCardsValid = true;
                foreach (ImportUserCardDto cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    Object cardTypeRes;
                    bool isCardTypeValid = Enum.TryParse(typeof(CardType), cardDto.Type, out cardTypeRes);

                    if (!isCardTypeValid)
                    {
                        areAllCardsValid = false;
                        break;
                    }

                    CardType cardType = (CardType)cardTypeRes;

                    userCards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    });
                }

                if (!areAllCardsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User u = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userCards
                };

                users.Add(u);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, u.Username, u.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(stringReader);

            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object purchaseTypeObj;
                bool isPurchaseTypeValid =
                    Enum.TryParse(typeof(PurchaseType), purchaseDto.PurchaseType, out purchaseTypeObj);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType = (PurchaseType)purchaseTypeObj;

                DateTime date;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context
                    .Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context
                    .Games
                    .FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Type = purchaseType,
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Game = game,
                    Card = card
                };

                purchases.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, p.Game.Name, p.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}