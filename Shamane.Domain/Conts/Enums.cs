using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain.Conts
{
    public enum CenterOrderBy
    {
        Null,

    }
    public enum OrderStaus
    {
        Null,
        NoState,
        Accepted,
        SendToDelivery,
        Rejected,
        Completed
    }
    public enum OrderDeliverType
    {
        Null,
        InCenter,
        WithDelivery
    }
}
