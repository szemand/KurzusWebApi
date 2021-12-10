using ManagerApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ManagerApp.Pages
{
    public partial class CustomerDetails
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Parameter]
        public string CustomerID { get; set; }

        public Customer Customer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customer = await HttpClient.GetFromJsonAsync<Customer>($"customer/{CustomerID}");
            await base.OnInitializedAsync();
        }
    }
}