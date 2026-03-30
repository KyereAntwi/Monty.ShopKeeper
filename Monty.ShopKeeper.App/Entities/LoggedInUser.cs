namespace Monty.ShopKeeper.App.Entities;

public class LoggedInUser : BaseEntity
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}
