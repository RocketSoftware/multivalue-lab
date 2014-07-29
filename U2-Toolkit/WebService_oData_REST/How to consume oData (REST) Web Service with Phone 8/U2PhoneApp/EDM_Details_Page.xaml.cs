using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using U2PhoneApp.U2_CodeFirst_oData_Service;
using System.Data.Services.Client;

namespace U2PhoneApp
{
    public class MyModel
    {
        public string Title { get; set; }
        public string Rating { get; set; }
    }
    public partial class EDM_Details_Page : PhoneApplicationPage
    {
        // Declare the data service objects and URIs.
        private ProductContext context;
        private readonly Uri northwindUri =
            new Uri("http://9.72.199.235/U2_oData/U2_CodeFirst_oData_WcfDataService.svc/");
        private DataServiceCollection<Product> products;


        public EDM_Details_Page()
        {
            InitializeComponent();
            //List<MyModel> lList = new List<MyModel>();
            //MyModel l = new MyModel();
            //l.Title = "aaa";
            //l.Rating = "R";
            //lList.Add(l);
            
            //this.MainLongListSelector.ItemsSource = lList;




        }

        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CodeFirst_Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the context and the binding collection 
            context = new ProductContext(northwindUri);
           
            products = new DataServiceCollection<Product>(context);

            context.Products.AddQueryOption("$top", 10);

            // Define a LINQ query that returns all customers.
            var query = from cust in context.Products
                        //where cust.ProductId == 2761685473
                        select cust;

            var query2 = context.Products.Take(10);
            

            // Register for the LoadCompleted event.
            products.LoadCompleted
                += new EventHandler<LoadCompletedEventArgs>(products_LoadCompleted);

            // Load the customers feed by executing the LINQ query.
            products.LoadAsync(query);



        }

        void products_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                // Handling for a paged data feed.
                if (products.Continuation != null)
                {
                    // Automatically load the next page.
                    products.LoadNextPartialSetAsync();
                }
                else
                {
                    // Set the data context of the list box control to the sample data.
                    //this.MainLongListSelector.DataContext = products;
                    this.MainLongListSelector.ItemsSource = products;
                }
            }
            else
            {
                MessageBox.Show(string.Format("An error has occurred: {0}", e.Error.Message));
            }
        }

    }
}