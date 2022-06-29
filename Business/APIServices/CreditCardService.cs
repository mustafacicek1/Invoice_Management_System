using Entities.Concrete;
using Entities.DTOs;
using System.Net.Http.Json;

namespace Business.APIServices
{
    public class CreditCardService
    {
        private readonly HttpClient _httpClient;

        public CreditCardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5164/api/payment/");
        }

        public async Task<CreatePaymentDTO?> Pay(Invoice invoice)
        {
            var response = await _httpClient.PostAsJsonAsync("pay",invoice);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CreatePaymentDTO>();
            }
            return null;
        }
    }
}
