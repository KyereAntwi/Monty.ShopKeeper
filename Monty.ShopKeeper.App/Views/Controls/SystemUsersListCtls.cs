using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views.Controls;

public partial class SystemUsersListCtls : UserControl
{
    private readonly IApplicationUserServices _services;

    public SystemUsersListCtls(IApplicationUserServices applicationUserServices)
    {
        InitializeComponent();
        _services = applicationUserServices;

        LoadUsers().GetAwaiter().GetResult();
    }

    private async Task LoadUsers()
    {
        var result = await _services.GetAllUsersAsync();

        if (result.IsFailed)
            return;

        var users = result.Value;

        foreach (var user in users)
        {
            UsersLB.Items.Add(user.UserName);
        }
    }
}
