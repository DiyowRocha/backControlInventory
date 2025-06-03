using backControlInventory.Domain.Enum;

namespace backControlInventory.Application.Service.ChipInfos;

public class ChipInfoDto
{
    public string Line { get; set; }
    public ChipType Type { get; set; }
}