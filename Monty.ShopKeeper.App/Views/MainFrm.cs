using Microsoft.Extensions.DependencyInjection;
using Monty.ShopKeeper.App.Entities.Enums;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Views.Controls;

namespace Monty.ShopKeeper.App.Views;

public partial class MainFrm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IApplicationUserServices _applicationUserServices;
    private LoginFrm? _loginForm;
    private bool _suppressCloseConfirmation = false;

    private TabControl? _salesTabControl;
    private int _salesTabCounter = 0;
    private bool _isSalesTabInitialized = false;

    public MainFrm(IServiceProvider serviceProvider, IApplicationUserServices applicationUserServices)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _applicationUserServices = applicationUserServices;

        LoadWelcomeScreen();
    }

    private void ExistApplicationMI_Click(object sender, EventArgs e)
    {
        ShutApp();
    }

    private void ShutApp()
    {
        var result = _applicationUserServices.LogoutAsync().GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show("Failed to log you out of this window. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.Yes)
            Application.Exit();
    }

    private void EnsureSalesTabControl()
    {
        if (_salesTabControl != null)
            return;

        var existing = MainPanel.Controls.OfType<TabControl>().FirstOrDefault(tc => tc.Name == "SalesTabControl");
        if (existing != null)
        {
            _salesTabControl = existing;
            return;
        }

        _salesTabControl = new TabControl
        {
            Name = "SalesTabControl",
            Dock = DockStyle.Fill,
        };

        // simple context menu to close current tab
        var ctx = new ContextMenuStrip();
        var closeItem = new ToolStripMenuItem("Close Tab");
        closeItem.Click += (s, e) => CloseCurrentSaleTab();
        ctx.Items.Add(closeItem);
        _salesTabControl.ContextMenuStrip = ctx;

        MainPanel.Controls.Clear();
        MainPanel.Controls.Add(_salesTabControl);
    }

    // Open a new tab with a SalesCtls instance
    private void OpenNewSaleTab()
    {
        EnsureSalesTabControl();

        _salesTabCounter++;
        var salesControl = _serviceProvider.GetRequiredService<SalesCtls>();
        salesControl.Dock = DockStyle.Fill;

        var title = $"Sale {_salesTabCounter}";
        var tab = new TabPage(title);
        tab.Controls.Add(salesControl);

        _salesTabControl!.TabPages.Add(tab);
        _salesTabControl.SelectedTab = tab;
    }

    // Close the currently selected sales tab (if any)
    private void CloseCurrentSaleTab()
    {
        if (_salesTabControl is null || _salesTabControl.TabPages.Count == 0)
            return;

        var tab = _salesTabControl.SelectedTab;
        if (tab is null)
            return;

        // Dispose contained controls to free resources
        foreach (Control c in tab.Controls.OfType<Control>().ToList())
        {
            tab.Controls.Remove(c);
            c.Dispose();
        }

        _salesTabControl.TabPages.Remove(tab);
        tab.Dispose();
    }

    private void CloseAllOpenedSaleTabs()
    {
        if (_salesTabControl is not null && _salesTabControl.TabPages.Count > 0)
        {
            foreach (TabPage tab in _salesTabControl.TabPages)
            {
                // Dispose contained controls to free resources
                foreach (Control c in tab.Controls.OfType<Control>().ToList())
                {
                    tab.Controls.Remove(c);
                    c.Dispose();
                }

                _salesTabControl.TabPages.Remove(tab);
                tab.Dispose();
            }
        }

        _salesTabControl?.Dispose();
        _salesTabControl = null;
        _salesTabCounter = 0;
        _isSalesTabInitialized = false;
    }

    private void LoadWelcomeScreen()
    {
        _isSalesTabInitialized = true;
        EnsureSalesTabControl();

        // if there are no sale tabs open, create the first one
        if (_salesTabControl!.TabPages.Count == 0)
            OpenNewSaleTab();
        else
            _salesTabControl.SelectedIndex = 0;
    }

    private void logoutCurrentAccountToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to log out of this account?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult != DialogResult.Yes)
            return;
        LogOut();
    }

    private void LogOut()
    {
        try
        {
            var result = _applicationUserServices.LogoutAsync().GetAwaiter().GetResult();

            if (result.IsFailed)
            {
                MessageBox.Show("Failed to log you out of this window. Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _loginForm = _serviceProvider?.GetRequiredService<LoginFrm>();

            if (_loginForm == null)
            {
                MessageBox.Show("Unable to resolve the login form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _loginForm?.FormClosed -= LoginForm_FormClosed;
            _loginForm?.FormClosed += LoginForm_FormClosed;
            _loginForm?.Show();

            _suppressCloseConfirmation = true;
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
        _isSalesTabInitialized = false; // reset sales tab state so next time user clicks "New Sale" it will show the welcome screen instead of opening a new tab
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
        CloseAllOpenedSaleTabs();

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

        CloseAllOpenedSaleTabs();

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
        if (!_isSalesTabInitialized)
            LoadWelcomeScreen();
        else
            OpenNewSaleTab();
    }

    private void registerSystemUserToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var registerFrm = _serviceProvider.GetRequiredService<RegisterFrm>();
        registerFrm.ShowDialog();
    }

    private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.ApplicationExitCall)
            return;

        if (_suppressCloseConfirmation)
        {
            // reset the flag so future user-initiated closes still show confirmation
            _suppressCloseConfirmation = false;
            return;
        }

        var dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult != DialogResult.Yes)
            e.Cancel = true;
    }

    private void viewAllSystemUsersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CloseAllOpenedSaleTabs();

        var usersControl = _serviceProvider.GetRequiredService<SystemUsersListCtls>();
        if (MainPanel.Controls.Contains(usersControl))
            return;

        MainPanel.Controls.Clear();
        usersControl.Dock = DockStyle.Fill;
        MainPanel.Controls.Add(usersControl);
    }

    private void imoprtProductsListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var importProductsForm = _serviceProvider.GetRequiredService<ImportProductsFrm>();
        importProductsForm.ShowDialog();
    }

    private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
    {
        ShutApp();
    }

    private void exportAllProductsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to export all products to a CSV file?", "Export Products", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        var stockServices = _serviceProvider.GetRequiredService<IStockServices>();
        LoaderFrm loaderFrm = new("Processing products to be exported ...", Utils.ExportType.ExportProducts, stockServices);
        loaderFrm.ShowDialog();
    }

    private void exportAllSalesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to export all sales to a CSV file?", "Export Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        var stockServices = _serviceProvider.GetRequiredService<IStockServices>();
        LoaderFrm loaderFrm = new("Processing sales to be exported ...", Utils.ExportType.ExportSales, stockServices);
        loaderFrm.ShowDialog();
    }

    private void exportYourOverviewSummaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Are you sure you want to export your overview summary to a CSV file?", "Export Overview Summary", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult != DialogResult.Yes)
            return;

        var stockServices = _serviceProvider.GetRequiredService<IStockServices>();
        LoaderFrm loaderFrm = new("Processing overview summary to be exported ...", Utils.ExportType.ExportOverviewSummary, stockServices);
        loaderFrm.ShowDialog();
    }

    private void MainFrm_Load(object sender, EventArgs e)
    {
        var loggedInUser = _applicationUserServices.GetLoggedInUserAsync().GetAwaiter().GetResult().Value;

        if (loggedInUser == null)
        {
            LogOut();
            return;
        }

        if (loggedInUser.ApplicationUser?.Role != RoleType.Administrator)
        {
            systemAdministrationToolStripMenuItem.Enabled = false;
            AddProductMI.Enabled = false;
            storageStagesToolStripMenuItem.Enabled = false;
            importsAndExportsToolStripMenuItem.Enabled = false;
        }
    }
}
