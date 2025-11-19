using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgBlazor.Models;
using RpgBlazor.Models.Enuns;
using System.Net.Http.Headers;
using System.Text.Json;
namespace RpgBlazor.Services
{
    public class PersonagemService
    {
        private readonly HttpClient _http;
        public PersonagemService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<PersonagemViewModel>> GetallAsync(string token)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync("Personagens/GetAll");
            var responseContent = await response.Content.ReadAsStringAsync();
            List<PersonagemViewModel> lista = new List<PersonagemViewModel>();

            if (response.IsSuccessStatusCode)
            {
                lista = JsonSerializer.Deserialize<List<PersonagemViewModel>>(responseContent, JsonSerializerOptions.Web);
                return lista;
            }
            else
            {
                throw new Exception(responseContent);
            }            
        }
    }
   
}