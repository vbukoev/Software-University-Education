using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            ImportCreatorDto[] creatorDtos = Deserialize<ImportCreatorDto[]>(xmlString, "Creators");
            StringBuilder sb = new StringBuilder();

            List<Creator> creators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };

                List<Boardgame> booardgames = new List<Boardgame>();

                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };

                    creator.Boardgames.Add(boardgame);
                }

                creators.Add(creator);

                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Seller> sellers = new List<Seller>();

            var boardgamesIds = context.Boardgames
                .Select(b => b.Id)
                .ToList();

            foreach (var dto in sellerDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller()
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Country = dto.Country,
                    Website = dto.Website,
                    BoardgamesSellers = new List<BoardgameSeller>()
                };

                foreach (var id in dto.Boardgames.Distinct().ToList())
                {
                    if (!boardgamesIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = id,
                        Seller = seller
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }
            context.Sellers.AddRange(sellers);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
    }
}
