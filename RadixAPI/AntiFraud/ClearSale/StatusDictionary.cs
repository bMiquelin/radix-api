using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.AntiFraud.ClearSale
{
    public static class StatusDictionary
    {
        public static Dictionary<string, string> Status => new Dictionary<string, string>
        {
            { "APA", "Automatic Approval – the order was automatically approved according to the rules defined." },
            { "APM", "Manual Approval – the order was manually approved by a risk analyst" },
            { "RPM", "Denied without prejudice – Order was denied with no indication of fraud.Usually due to impossibility of contact or invalid document." },
            { "AMA", "Manual Analysis – the order was sent to a manual analysis queue." },
            { "ERR", "Error – An error occurred during the integration. It is necessary to analyze the XML and resend after fixing it." },
            { "NVO", "New Order – the order was imported successfully and was not yet classified." },
            { "SUS", "Fraud Suspicion – the order was denied due to a suspicion of fraud, usually based on contact with the customer or behavior registered in the ClearSale database." },
            { "CAN", "Customer asked for cancellation– the customer asked an analyst to cancel the purchase" },
            { "FRD", "Confirmed Fraud – The order was analyzed and, following contact made, the credit card company confirmed fraud or the owner of the credit card denied awareness of the purchase" },
            { "RPA", "Automatically Denied – the order was denied according to a pre-defined rule (not recommended)" },
            { "RPP", "Denied by Policy – The order was denied due to a policy defined by ClearSale or the client" },

            // Incoming Status List*
            // *Attention: If an order is sent with a status, the order will be saved as history and will not be analyzed by ClearSale. Only orders with status 0 (NVO) or with no status will by analyzed
            { "NVO", "New" },
            { "APM", "Approved" },
            { "CAN", "Cancelled by Client" },
            { "RPM", "Denied" }
        };
    }
}
