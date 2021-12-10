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
    public partial class CustomerAdd
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Customer Customer { get; set; } = new Customer();

        private async Task SubmitForm()
        {
            await HttpClient.PostAsJsonAsync("customer", Customer);
            NavigationManager.NavigateTo("customers");
        }
    }
}