using Microsoft.Extensions.DependencyInjection;
using Monty.ShopKeeper.App.Views.Controls;

namespace Monty.ShopKeeper.App.Views;

public partial class MainFrm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private LoginFrm? _loginForm;

    public MainFrm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        LoadWelcomeScreen();
    }

    private void ExistApplicationMI_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        Application.Exit();
    }

    private void LoadWelcomeScreen()
    {
        var welcomeControl = _serviceProvider.GetRequiredService<SalesCtls>();
        if (MainPanel.Controls.Contains(welcomeControl))
            return;

        MainPanel.Controls.Clear();
        welcomeControl.Dock = DockStyle.Fill;
        MainPanel.Controls.Add(welcomeControl);
    }

    private void logoutCurrentAccountToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to log out of this account?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult != DialogResult.Yes)
            return;

        try
        {
            _loginForm = _serviceProvider?.GetRequiredService<LoginFrm>();

            if (_loginForm == null)
            {
                MessageBox.Show("Unable to resolve the login form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _loginForm.FormClosed -= LoginForm_FormClosed;
            _loginForm.FormClosed += LoginForm_FormClosed;
            _loginForm.Show();
            this.Hide();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while trying to log out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoginForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void AddProductMI_Click(object sender, EventArgs e)
    {
        var addProductForm = _serviceProvider?.GetRequiredService<AddProductFrm>();
        addProductForm?.ShowDialog();
    }

    private void ListProductsMI_Click(object sender, EventArgs e)
    {
        var productsUserControl = _serviceProvider.GetRequiredService<ProductListCtls>();

        if (MainPanel.Controls.Contains(productsUserControl))
            return;

        MainPanel.Controls.Clear();

        productsUserControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        productsUserControl.Dock = DockStyle.Fill;
        MainPanel.Controls.Add(productsUserControl);
    }

    private void NewStorageMI_Click(object sender, EventArgs e)
    {
        var storageForm = _serviceProvider?.GetRequiredService<CreateStorageFrm>();
        storageForm?.ShowDialog();
    }

    private void AllStorageMI_Click(object sender, EventArgs e)
    {
        var storageListControl = _serviceProvider.GetRequiredService<StoragePlacesListCtls>();

        if (MainPanel.Controls.Contains(storageListControl))
            return;

        MainPanel.Controls.Clear();

        storageListControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        storageListControl.Dock = DockStyle.Fill;
        MainPanel.Controls.Add(storageListControl);
    }

    private void SalesHistoryMI_Click(object sender, EventArgs e)
    {
        var salesHistoryControl = _serviceProvider.GetRequiredService<SalesHistoryCtls>();
        if (MainPanel.Controls.Contains(salesHistoryControl))
            return;

        MainPanel.Controls.Clear();
        salesHistoryControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        salesHistoryControl.Dock = DockStyle.Fill;
        MainPanel.Controls.Add(salesHistoryControl);
    }

    private void SaleMI_Click(object sender, EventArgs e)
    {
        LoadWelcomeScreen();
    }
}
