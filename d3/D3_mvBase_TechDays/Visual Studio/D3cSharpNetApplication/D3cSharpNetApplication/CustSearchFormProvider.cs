using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3cSharpNetApplication
{
    public class CustSearchFormProvider
    {
        public static CustomerSearch custsearch
        {
            get
            {
                if (_CustFrm == null)
                {
                    _CustFrm = new CustomerSearch();
                }
                return _CustFrm;
            }
        }
            
        private static CustomerSearch _CustFrm;
    }
}
