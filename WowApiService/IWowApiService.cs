using WowApiService.Dtos;

namespace WowApiService;

public interface IWowApiService
{
    Task<WowCharacterDto> GetCharacter(string characterName);
}
