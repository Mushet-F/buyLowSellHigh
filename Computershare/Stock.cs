using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computershare
{
    class Stock
    {

        public Stock(double[] prices)
        {
            this.Prices = prices;
        }

        public double[] Prices
        {
            get; set;
        }

        public static string GetBestTrade(double[] Prices)
        {

            double maxProfit = Prices[1] - Prices[0];
            double minPrice = Prices[0];

            double buyPrice = Prices[0];
            int buyDate = 1;
            int potentialBuyDate = 0;

            double sellPrice = Prices[0];
            int sellDate = 1;

            for (int i = 1; i < Prices.Length; i++)
            {

                double currentProfit = Prices[i] - minPrice;

                minPrice = Math.Min(minPrice, Prices[i]);
                maxProfit = Math.Max(maxProfit, currentProfit);

                if (minPrice == Prices[i])
                {
                    potentialBuyDate = i + 1;
                }

                if (Prices[i] == minPrice + maxProfit)
                {
                    sellDate = i + 1;
                    sellPrice = Prices[i];
                }

                if (sellDate > potentialBuyDate && potentialBuyDate != 0)
                {
                    buyDate = potentialBuyDate;
                    buyPrice = Prices[buyDate - 1];
                    potentialBuyDate = 0;
                }


            }

            string output = $"{buyDate}({buyPrice}){sellDate}({sellPrice})";

            return output;

        }

    }

}
