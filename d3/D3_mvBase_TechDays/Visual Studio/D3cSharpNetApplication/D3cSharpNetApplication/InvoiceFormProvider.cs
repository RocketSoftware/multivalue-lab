using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3cSharpNetApplication
{
    public class InvoiceFormProvider
    {
        public static Invoice invoice_frm
        {
            get
            {
                if (_InvoiceFrm == null)
                {
                    _InvoiceFrm = new Invoice();
                }
                return _InvoiceFrm;
            }
        }
            
        private static Invoice _InvoiceFrm;
    }
}
