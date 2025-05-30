using System.Text.Json;

namespace backControlInventory.Application.External.ViaCep;

public class ViaCepService : IViaCepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<ViaCepResponse> GetAddressByZipCodeAsync(string zipCode)
    {
        var url = $"https://viacep.com.br/ws/{zipCode}/json";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to fetch address from ViaCEP.");

        var content = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<ViaCepResponse>(content, options);

        if (result == null || string.IsNullOrEmpty(result.Logradouro))
            throw new Exception("Invalid ZIP code");

        return result;
    }
}