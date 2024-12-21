public class AccountCreationReqDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public DateOnly RequestDate { get; set; }
}