using WowApiService.Dtos;

namespace WowApiService;

public interface IWowApiService
{
    Task<WowCharacterDto> GetCharacterAsync(string characterName, string realm, CancellationToken cancellationToken = default);
    Task<WowGuildDto> GetGuildAsync(string guildName, string realm, CancellationToken cancellationToken = default);
}
