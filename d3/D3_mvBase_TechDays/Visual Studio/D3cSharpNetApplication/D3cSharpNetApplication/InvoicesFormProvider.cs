using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3cSharpNetApplication
{
   public class InvoicesFormProvider
    {
        public static Invoices invoices
        {
            get
            {
                if (_InvoicesFrm == null)
                {
                    _InvoicesFrm = new Invoices();
                }
                return _InvoicesFrm;
            }
        }
            
        private static Invoices _InvoicesFrm;
    }
}
