using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace U2_oData_WebApplication
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class U2_EDM_oData_WcfDataService : DataService< XDEMOEntities >
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
             config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        protected override void HandleException(HandleExceptionArgs e)
        {
            try
            {
                e.UseVerboseErrors = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
