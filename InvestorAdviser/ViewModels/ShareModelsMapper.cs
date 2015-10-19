using InvestorAdviser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestorAdviser.ViewModels
{
    public static class ShareModelsMapper
    {
        public static ShareViewModel convertTo(Models.Share model)
        {
            ShareViewModel shareViewModel = new ShareViewModel()
            {
                Code = model.Code,
                CompanyName = model.CompanyName,
                ID = model.ID,
                MarketPrice = model.MarketPrice
            };
            decimal totalShares = 0;
            if (model.Purchases != null)
            {
                foreach (Purchase aPurchase in model.Purchases)
                {
                    totalShares = aPurchase.NumberOfShares + totalShares;
                }
            }
            shareViewModel.TotalShares = totalShares;

            return shareViewModel;
        }
    }
}