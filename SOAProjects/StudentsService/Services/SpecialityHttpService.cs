using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace StudentsService.Services
{
    public class SpecialityHttpService
    {
        static HttpClient client = new HttpClient();

        public SpecialityHttpService(string baseUri)
        {
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Speciality> GetProductAsync(string path)
        {
            Speciality speciality = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                speciality = await response.Content.ReadAsAsync<Speciality>();
            }
            return speciality;
        }


    }
}