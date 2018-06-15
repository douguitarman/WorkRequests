using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkRequests.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }

        public string ReceiptImageName { get; set; }

        public HttpPostedFileBase ReceiptImage { get; set; }

        public byte[] DisplayReceipt { get; set; }

        public List<Receipt> GetReceipts { get; set; }
    }
}