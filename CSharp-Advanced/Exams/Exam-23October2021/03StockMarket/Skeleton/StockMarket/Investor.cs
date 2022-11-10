using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }
        public int Count => Portfolio.Count;
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >=stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (Portfolio.Where(x=>x.CompanyName==companyName).FirstOrDefault() == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice<Portfolio.First(x=>x.CompanyName == companyName).PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.First(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio) sb.AppendLine(item.ToString().TrimEnd());
            return sb.ToString();
        }
    }
}
