using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MFCFE2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MFCFE2.Pages.Forms
{
    public class CreateAgreementFormModel : PageModel
    {
        private readonly HttpClient Client;

        public CreateAgreementFormModel(HttpClient httpClient)
        {
            this.Client = httpClient;
        }
        [BindProperty]
        public AgreementModel Agreement { get; set; }

        public List<StorageLocationModel> StorageLocations { get; set; }
        public async Task OnGet()
        {
            var response = await this.Client.GetAsync("http://localhost:56117/storagelocation/get-all");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(responseBody);
            var a = obj["Result"].ToString();
            this.StorageLocations = JsonConvert.DeserializeObject<List<StorageLocationModel>>(a);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string jsonBody = JsonConvert.SerializeObject(this.Agreement);
            var data = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await this.Client.PostAsync("http://localhost:56117/agreement/create", data);

            return Page();
        }
    }
}