using ManagerApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MechanicApp.Pages
{
    public partial class TaskEditStatus
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Customer Customer { get; set; }

        [Parameter]
        public string CustomerID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customer = await HttpClient.GetFromJsonAsync<Customer>($"customer/{CustomerID}");
            await base.OnInitializedAsync();
        }

        private async Task SubmitForm()
        {
            await HttpClient.PutAsJsonAsync("customer", Customer);
            NavigationManager.NavigateTo("tasks");
        }
    }
}