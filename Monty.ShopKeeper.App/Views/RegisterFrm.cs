using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class RegisterFrm : Form
{
    private readonly IApplicationUserServices _services;

    public RegisterFrm(IApplicationUserServices applicationUserServices)
    {
        InitializeComponent();
        _services = applicationUserServices;
    }

    private void UsernameTxt_TextChanged(object sender, EventArgs e)
    {
        ValidateForm();
    }

    private void PasswordTxt_TextChanged(object sender, EventArgs e)
    {
        ValidateForm();
    }

    private void ConfirmPassTxt_TextChanged(object sender, EventArgs e)
    {
        ValidateForm();
    }

    private void ValidateForm()
    {
        if (string.IsNullOrEmpty(UsernameTxt.Text) ||
            string.IsNullOrEmpty(PasswordTxt.Text) ||
            PasswordTxt.Text.Trim().Length < 6 ||
            string.IsNullOrEmpty(ConfirmPassTxt.Text))
        {
            RegisterBtn.Enabled = false;
        }
        else
        {
            RegisterBtn.Enabled = true;
        }
    }

    private void RegisterBtn_Click(object sender, EventArgs e)
    {
        if(!PasswordTxt.Text.Trim().Equals(ConfirmPassTxt.Text.Trim()))
        {
            MessageBox.Show("Password and confirm password should match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var result = _services.AddUserAccountAsync(UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim()).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"There was an error registering user. Error: {result.Errors[0]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MessageBox.Show("Registration was successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }
}
