using PasswordManager.Data;
using PasswordManager.Models;
using System.Threading.Tasks;

namespace PasswordManager.Views;

[QueryProperty("Item", "Item")]
public partial class LoginCredentialItemPage : ContentPage
{
    private readonly Database database;

    public LoginCredential Item
    {
        get => BindingContext as LoginCredential;
        set => BindingContext = value;
    }
    public LoginCredentialItemPage(Database database)
    {
        InitializeComponent();

        this.database = database;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Website))
        {
            await DisplayAlert("Site obligatoire", "Veuillez entrer le nom d'un site web pour continuer", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..", true);
    }
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..", true);
    }

    private async void OnDeletedClicked(object sender, EventArgs e)
    {
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..", true);
    }

    private void OnPasswordFocused(object sender, FocusEventArgs e)
    {
        if (e.IsFocused)
            ((Entry)(sender)).IsPassword = false;
        else
            ((Entry)(sender)).IsPassword = true;
    }
}