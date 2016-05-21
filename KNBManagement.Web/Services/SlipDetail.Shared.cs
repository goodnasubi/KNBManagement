using System;
using System.Collections.Generic;
using System.Linq;

namespace KNBManagement.Web
{
    public partial class SlipDetail
    {
        public static SlipDetail CreateAddNewSlipDetail(global::System.Guid companyID, global::System.Guid slipID)
        {
            //return CreateSlipDetail(
            //    companyID,
            //    slipID,
            //    global::System.Guid.NewGuid(),
            //    global::System.Guid.Empty,
            //    0,
            //    0,
            //    new byte[1]);
            return new SlipDetail
            {
                CompanyID = companyID,
                SlipID = slipID,
                SlipDetailID = global::System.Guid.NewGuid()//,
                //TS = new byte[1]
            };
        }
    }
}