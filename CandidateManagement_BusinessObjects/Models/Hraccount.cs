namespace CandidateManagement_BusinessObjects.Models;

public partial class Hraccount
{
    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public int? MemberRole { get; set; }
}
