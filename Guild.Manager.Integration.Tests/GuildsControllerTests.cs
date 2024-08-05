using FluentAssertions;
using Guild.Manager.Integration.Tests.Constants;
using Guild.Manager.Integration.Tests.Extensions;
using System.Text.Json;

namespace Guild.Manager.Integration.Tests;

public class GuildsControllerTests : IClassFixture<GuildManagerWebAppFactory>
{
    private readonly GuildManagerWebAppFactory _guildManagerWebAppFactory;

    public GuildsControllerTests(GuildManagerWebAppFactory guildManagerWebAppFactory)
    {
        _guildManagerWebAppFactory = guildManagerWebAppFactory;
    }

    [Fact]
    public async void CreateNewGuild_ValidData_Returns201()
    {
        //Arrange
        var client = _guildManagerWebAppFactory.HttpClient;
        var newGuild = JsonSerializer.Serialize(
            new
            {
                Name = "test-guild"
            });

        //Act
        var response = await client.PostAsync(Routes.Guilds.Create, newGuild.ToHtttpContent());

        //Arrance
        response.Should().Be201Created();
    }
}