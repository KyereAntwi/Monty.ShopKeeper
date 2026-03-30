using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class PasswordResetFrm : Form
{
    private readonly IApplicationUserServices _applicationUserServices;
    public PasswordResetFrm(IApplicationUserServices applicationUserServices)
    {
        InitializeComponent();
        _applicationUserServices = applicationUserServices;
    }

    private void ResetBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CurrentPasswordTxt.Text.Trim()) || string.IsNullOrEmpty(NewPasswordTxt.Text.Trim()) || string.IsNullOrEmpty(ConfirmPasswordTxt.Text.Trim()))
            return;

        if (NewPasswordTxt.Text.Trim() != ConfirmPasswordTxt.Text.Trim())
        {
            MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var loggedInUser = _applicationUserServices.GetLoggedInUserAsync().GetAwaiter().GetResult().Value?.ApplicationUser;

        var result = _applicationUserServices.UpdatePasswordAsync(
            username: loggedInUser!.UserName,
            currentPassword: CurrentPasswordTxt.Text.Trim(),
            newPassword: NewPasswordTxt.Text.Trim())
            .GetAwaiter()
            .GetResult();

        if (result.IsSuccess)
        {
            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show(result.Errors[0].Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
