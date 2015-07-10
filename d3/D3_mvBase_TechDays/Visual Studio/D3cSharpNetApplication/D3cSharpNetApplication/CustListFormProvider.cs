using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3cSharpNetApplication
{
  public class CustListFormProvider
    {
        public static CustList custlist
        {
            get
            {
                if (_CustListFrm == null)
                {
                    _CustListFrm = new CustList();
                }
                return _CustListFrm;
            }
        }        
        private static CustList _CustListFrm;
        
    }
}
