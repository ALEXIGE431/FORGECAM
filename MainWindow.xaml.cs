using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace forgecam;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Workspace_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { Tag: string workspace })
        {
            WorkspaceTitle.Text = workspace;
            StatusText.Text = $"{workspace} · schermo dimostrativo; funzioni CAM non ancora implementate";
        }
    }

    private void AddOperation_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button { Tag: string operation })
        {
            return;
        }

        if (operation == "Setup")
        {
            StatusText.Text = "Setup dimostrativo aggiunto; configurazione macchina e WCS non ancora disponibili";
            return;
        }

        OperationList.Items.Add($"{OperationList.Items.Count + 1:00}  {operation}  ·  non calcolato");
        OperationName.Text = operation;
        StatusText.Text = $"{operation} aggiunta alla lista; nessun percorso utensile è stato calcolato";
    }

    private void OperationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (OperationList.SelectedItem is string selected)
        {
            OperationName.Text = selected.Split("  ·", StringSplitOptions.None)[0].TrimStart('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ');
        }
    }

    private void Post_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = "Postprocessor non disponibile: Centroid CNC e Siemens 808D TURN richiedono validazione sulla macchina";
        MessageBox.Show(
            "La bozza non genera G-code. I post Centroid CNC e Siemens 808D TURN saranno implementati solo dopo aver verificato modello del controllo, configurazione macchina e documentazione del costruttore.",
            "Postprocessor non ancora implementato",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}