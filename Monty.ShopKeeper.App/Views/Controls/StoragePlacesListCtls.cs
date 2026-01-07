using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views.Controls;

public partial class StoragePlacesListCtls : UserControl
{
    private readonly IStorageServices _storageServices;
    private IEnumerable<StoragePlace> _storagePlaces = [];

    public StoragePlacesListCtls(IStorageServices storageServices)
    {
        InitializeComponent();
        _storageServices = storageServices;

        LoadStoragePlaces();
    }

    private void StoragePlacesListCtls_Load(object sender, EventArgs e)
    {
        LoadStoragePlaces();
    }

    private void LoadStoragePlaces()
    {
        _storagePlaces = _storageServices.GetAllStoragesAsync().GetAwaiter().GetResult().Value;

        StorageLb.Items.Clear();
        foreach (var storage in _storagePlaces)
        {
            StorageLb.Items.Add($"{storage.Title} (Order: {storage.Order})");
        }
    }

    private void DeleteMI_Click(object sender, EventArgs e)
    {
        if (StorageLb.SelectedItems.Count <= 0)
        {
            MessageBox.Show("No storage place selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var selectedStorage = _storagePlaces.ElementAt(StorageLb.SelectedIndex);
        var confirmResult = MessageBox.Show("Are you sure to delete this storage place?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirmResult != DialogResult.Yes)
            return;

        var result = _storageServices.DeleteStoargePlaceAsync(selectedStorage.Id).GetAwaiter().GetResult();

        if (result.IsFailed)
        {
            MessageBox.Show($"Failed to delete storage. {string.Join(", ", result.Errors.Select(er => er.Message))}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show("Storage place deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStoragePlaces();
        }
    }

    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }
}
