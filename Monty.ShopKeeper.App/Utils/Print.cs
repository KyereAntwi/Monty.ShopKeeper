using Monty.ShopKeeper.App.Entities;
using System.Drawing.Printing;
using System.Text;

namespace Monty.ShopKeeper.App.Utils;

public static class Print
{
    public static void PrintReceipt(Basket basket)
    {
        if (basket == null)
            return;

        // Prepare lines to print (simple monospace layout)
        var lines = new List<string>();
        var storeName = "Monty Store";
        lines.Add(storeName);
        lines.Add($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        if (basket.Id != 0) lines.Add($"Receipt #: {basket.Id}");
        lines.Add(new string('-', 40));
        lines.Add("Item                      Qty    Unit      Total");
        lines.Add(new string('-', 40));

        decimal subtotal = 0m;
        foreach (var li in basket.LineItems)
        {
            var name = li.Product?.Name ?? li.Product?.UniqueIdentifier ?? "Item";
            if (name.Length > 22) name = name.Substring(0, 22);
            decimal unit = li.CurrentPricePaid;
            decimal lineTotal = li.Quantity * unit;
            subtotal += lineTotal;

            // format columns: name (left), qty (right 3), unit (right 8), total (right 8)
            lines.Add(string.Format("{0,-22} {1,3} {2,9} {3,9}",
                name,
                li.Quantity,
                $"GHC{unit:0.00}",
                $"GHC{lineTotal:0.00}"
            ));
        }

        lines.Add(new string('-', 40));
        lines.Add($"Subtotal: {String.Empty,23}GHC{subtotal:0.00}");
        lines.Add($"Paid:     {String.Empty,25}GHC{basket.TotalAmountPaid:0.00}");
        lines.Add($"Change:   {String.Empty,24}GHC{basket.BalancePaid:0.00}");

        if (!string.IsNullOrWhiteSpace(basket.Comments))
        {
            lines.Add(new string('-', 40));
            lines.Add("Comments:");
            foreach (var commentLine in SplitToLines(basket.Comments, 36))
                lines.Add(commentLine);
        }

        lines.Add(new string('-', 40));
        lines.Add("Thank you for your purchase!");
        lines.Add(string.Empty);

        // Create PrintDocument and handler
        using var printDoc = new PrintDocument()
        {
            DocumentName = $"Receipt_{basket.Id}_{DateTime.Now:yyyyMMddHHmmss}",
            DefaultPageSettings = new PageSettings()
            {
                Margins = new Margins(50, 50, 50, 50), // 0.5 inch margins
                PaperSize = new PaperSize("Receipt", 300, 1000) // 3 inch wide, length can be long
            }
        };

        // ensure a printer is available
        if (!printDoc.PrinterSettings.IsValid)
        {
            MessageBox.Show("No valid printer found. Please connect a printer or select one from the Print dialog.", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Optionally show printer selection dialog
        using (var pdialog = new PrintDialog())
        {
            pdialog.AllowSomePages = false;
            pdialog.AllowSelection = false;
            pdialog.Document = printDoc;

            var dlgResult = pdialog.ShowDialog();
            if (dlgResult != DialogResult.OK)
                return;

            printDoc.PrinterSettings = pdialog.PrinterSettings;
        }

        // Attach PrintPage handler
        void OnPrintPage(object? sender, PrintPageEventArgs e)
        {
            const string fontName = "Consolas";
            using var font = new Font(fontName, 10);
            float lineHeight = font.GetHeight(e.Graphics!) + 2;
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            foreach (var line in lines)
            {
                e.Graphics!.DrawString(line, font, Brushes.Black, new RectangleF(x, y, e.MarginBounds.Width, lineHeight));
                y += lineHeight;

                // simple pagination guard
                if (y + lineHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        printDoc.PrintPage += OnPrintPage;

        try
        {
            printDoc.Print();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Printing failed: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            printDoc.PrintPage -= OnPrintPage;
        }
    }

    static IEnumerable<string> SplitToLines(string text, int maxWidth)
    {
        if (string.IsNullOrEmpty(text)) yield break;
        var words = text.Split(' ');
        var sb = new StringBuilder();
        foreach (var w in words)
        {
            if (sb.Length + w.Length + 1 > maxWidth)
            {
                yield return sb.ToString();
                sb.Clear();
            }

            if (sb.Length > 0) sb.Append(' ');
            sb.Append(w);
        }
        if (sb.Length > 0) yield return sb.ToString();
    }
}
