using Monty.ShopKeeper.App.Services;

namespace Monty.ShopKeeper.App.Views;

public partial class CreateStorageFrm : Form
{
    private readonly IStorageServices _storageServices;

    public CreateStorageFrm(IStorageServices storageServices)
    {
        InitializeComponent();
        _storageServices = storageServices;
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void TitleTxt_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TitleTxt.Text) || OrderTxt.Value == 0)
        {
            SaveBtn.Enabled = false;
        }
        else
        {
            SaveBtn.Enabled = true;
        }
    }

    private void OrderTxt_ValueChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TitleTxt.Text) || OrderTxt.Value == 0)
        {
            SaveBtn.Enabled = false;
        }
        else
        {
            SaveBtn.Enabled = true;
        }
    }

    private void SaveBtn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TitleTxt.Text) || OrderTxt.Value == 0)
        {
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = _storageServices.CreateStoragePlaceAsync(TitleTxt.Text, (int)OrderTxt.Value).GetAwaiter().GetResult();

        if (result.IsSuccess)
        {
            MessageBox.Show("Storage place created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            MessageBox.Show($"Failed to create storage place. {string.Join(", ", result.Errors.Select(er => er.Message))}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
