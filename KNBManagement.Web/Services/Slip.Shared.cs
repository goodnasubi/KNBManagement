using System;
using System.Collections.Generic;
using System.Linq;

namespace KNBManagement.Web
{
    public partial class Slip
    {
        public static Slip CreateAddNewSlip(global::System.Guid companyID, DateTime tradingDate)
        {
            return new Slip()
            {
                CompanyID=companyID,
                SlipID = global::System.Guid.NewGuid(),
                TradingDate = tradingDate
            };
        }
    }
}