using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_TO_AZURE_TABLESTORAGE
{
    public class SportingProductEntity : TableEntity
    {

        public SportingProductEntity(string category, string sku)

            : base(category, sku) { }



        public SportingProductEntity() { }



        public string ProductName { get; set; }

        public string Description { get; set; }

    }

}
