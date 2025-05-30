namespace backControlInventory.Application.External.ViaCep;

public interface IViaCepService
{
    Task<ViaCepResponse> GetAddressByZipCodeAsync(string zipCode);
}