using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using U2_oData_WebApplication;


namespace U2_oData_WebApplication
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class U2_Subroutine_oData_WcfDataService : DataService< XDEMOEntities1 >
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
             config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
             config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            
            config.UseVerboseErrors = true;

            config.SetEntitySetPageSize("*", 10);
           
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

        //[WebGet]

        //public IQueryable<ProductComplexType> GetProducts()
        //{
           
            
        //    XDEMOEntities ctx = new XDEMOEntities();
        //    var q = ctx.GetProducts();
            
        //    return q.AsQueryable<ProductComplexType>();
        //   // return q.AsQueryable();

        //}

        [WebGet]
        public IQueryable<PRODUCT3> GetProducts()
        {


            XDEMOEntities1 ctx = new XDEMOEntities1();
            return ctx.f_XDEMO_GETPRODUCTS().AsQueryable<PRODUCT3>();

        }

        
    }
}
