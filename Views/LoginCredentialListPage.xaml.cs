using PasswordManager.Data;
using PasswordManager.Models;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace PasswordManager.Views;

public partial class LoginCredentialListPage : ContentPage
{

    private readonly Database database;

    public ObservableCollection<LoginCredential> Items { get; set; } = [];

    public LoginCredentialListPage(Database database)
    {
        InitializeComponent();

        this.database = database;

        BindingContext = this;

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var items = await database.GEtItemsAsync();

        Items.Clear();
        foreach (var item in items)
        {
                Items.Add(item);
        }

    }

    private async void OnSelectionChange(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not LoginCredential item) return;

        await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
        
    }
    private async void OnItemAdd(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginCredentialItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new LoginCredential()
        });
    }
}
