namespace Guild.Manager.Application.Common.Dtos;

public record MemberDto
{
    public int MemberId { get; set; }
    public int GuildId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public DateTime JoinDate { get; set; }

}
