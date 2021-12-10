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
    public partial class CustomerList
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public Customer[] Customers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = await HttpClient.GetFromJsonAsync<Customer[]>("customer");
            await base.OnInitializedAsync();
        }
    }
}