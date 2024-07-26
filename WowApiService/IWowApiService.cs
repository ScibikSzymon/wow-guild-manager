namespace WowApiService;

public interface IWowApiService
{
    Task GetCharacter(string characterName);
}
