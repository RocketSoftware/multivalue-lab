using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_TO_AZURE_TABLESTORAGE
{
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string category, string sku)

            : base(category, sku) { }

        public CustomerEntity() { }
        public string CUSTID { get; set; }
        public string FNAME { get; set; }
        public string LNAME { get; set; }
        public string PRODID { get; set; }
        public DateTime  BUY_DATE { get; set; }
    }
}
