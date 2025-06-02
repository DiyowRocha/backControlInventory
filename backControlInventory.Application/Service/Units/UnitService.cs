
using AutoMapper;
using backControlInventory.Application.External.ViaCep;
using backControlInventory.Application.Service.Addresses;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Repository.Units;

namespace backControlInventory.Application.Service.Units;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IViaCepService _viaCepService;

    public UnitService(IUnitRepository unitRepository, IMapper mapper, IViaCepService viaCepService)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
        _viaCepService = viaCepService;

    }

    public async Task<UnitViewModel> CreateUnitAsync(UnitDto dto)
    {
        if (dto.Address != null && !string.IsNullOrWhiteSpace(dto.Address.ZipCode))
            await FillAddressFromZipCode(dto.Address);

        var createdUnit = _mapper.Map<Unit>(dto);

        await _unitRepository.Add(createdUnit);

        return _mapper.Map<UnitViewModel>(createdUnit);
    }

    public async Task<IEnumerable<UnitViewModel>> GetAllUnitsAsync()
    {
        var units = await _unitRepository.GetAll();

        return _mapper.Map<IEnumerable<UnitViewModel>>(units);
    }

    public async Task<UnitViewModel> GetUnitByIdAsync(int id)
    {
        var unit = await _unitRepository.GetById(id);

        return _mapper.Map<UnitViewModel>(unit);
    }

    public async Task<UnitViewModel> GetUnitByZipCodeAsync(string zipCode)
    {
        var unit = await _unitRepository.GetUnitByZipCode(zipCode);

        return _mapper.Map<UnitViewModel>(unit);
    }

    public async Task<UnitViewModel> UpdateUnitAsync(UnitDto dto, int id)
    {
        var existingUnit = await _unitRepository.GetById(id);

        if (existingUnit == null)
            return null;

        if (id != existingUnit.Id)
            throw new Exception("Route Id and body Id do not match.");

        if (dto.Address != null && !string.IsNullOrWhiteSpace(dto.Address.ZipCode))
        {
            await FillAddressFromZipCode(dto.Address);

            existingUnit.Address.Street = dto.Address.Street;
            existingUnit.Address.Neighborhood = dto.Address.Neighborhood;
            existingUnit.Address.City = dto.Address.City;
            existingUnit.Address.State = dto.Address.State;
            existingUnit.Address.Country = dto.Address.Country;
            existingUnit.Address.ZipCode = dto.Address.ZipCode;
        }

        existingUnit.Name = dto.Name;
        existingUnit.Address.Number = dto.Address.Number;
        existingUnit.Address.Complement = dto.Address.Complement;

        _unitRepository.Update(existingUnit);

        return _mapper.Map<UnitViewModel>(existingUnit);
    }

    public async Task<bool> DeleteUnitAsync(int id)
    {
        var deletedUnit = await _unitRepository.GetById(id);

        if (deletedUnit == null)
            return false;

        _unitRepository.Delete(deletedUnit);

        return true;
    }

    private async Task FillAddressFromZipCode(AddressDto address)
    {
        var viaCep = await _viaCepService.GetAddressByZipCodeAsync(address.ZipCode);

        address.Street = viaCep.Logradouro;
        address.Neighborhood = viaCep.Bairro;
        address.City = viaCep.Localidade;
        address.State = viaCep.Uf;
        address.Country = "Brazil";
        address.ZipCode = viaCep.Cep;
    }
}