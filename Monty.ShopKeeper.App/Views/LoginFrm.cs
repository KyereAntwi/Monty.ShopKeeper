using Microsoft.Extensions.DependencyInjection;
using Monty.ShopKeeper.App.Entities.Enums;
using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views
{
    public partial class LoginFrm : Form
    {
        private readonly IApplicationUserServices _applicationUserServices;
        private readonly IServiceProvider _serviceProvider;
        public bool _isFirstTime;

        public LoginFrm(IApplicationUserServices applicationUserServices, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _applicationUserServices = applicationUserServices;
            _serviceProvider = serviceProvider;

            if (!CheckIfFirstTimeUserage().GetAwaiter().GetResult())
            {
                RegisterBtn.Visible = true;
                ConfirmTxt.Visible = true;
                LoginBtn.Enabled = false;
                _isFirstTime = true;
            }
        }

        private async Task<bool> CheckIfFirstTimeUserage()
        {
            var result = await _applicationUserServices.CheckIfAnyUserExistAsync();
            return result.Value;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameTxt.Text) || string.IsNullOrEmpty(PasswordTxt.Text))
            {
                MessageBox.Show("All fields are required", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = _applicationUserServices.LoginAsync(UserNameTxt.Text, PasswordTxt.Text).GetAwaiter().GetResult();
            if (result.IsSuccess)
            {
                // open mainfrm and close this form
                MainFrm? mainFrm = _serviceProvider?.GetRequiredService<MainFrm>();
                mainFrm!.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameTxt.Text) || string.IsNullOrEmpty(PasswordTxt.Text) || string.IsNullOrEmpty(ConfirmTxt.Text))
            {
                MessageBox.Show("All fields are required", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PasswordTxt.Text != ConfirmTxt.Text)
            {
                MessageBox.Show("Passwords do not match", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = _applicationUserServices.AddUserAccountAsync(UserNameTxt.Text, PasswordTxt.Text, RoleType.Administrator).GetAwaiter().GetResult();
            
            if (result.IsSuccess)
            { 
                MessageBox.Show("User registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // open mainfrm and close this form
                MainFrm? mainFrm = _serviceProvider?.GetRequiredService<MainFrm>();
                mainFrm!.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to register user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
