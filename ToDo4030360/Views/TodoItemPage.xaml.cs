using ToDo4030360.Data;
using ToDo4030360.Models;

namespace ToDo4030360.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	public TodoItem Item
	{
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }

	TodoItemDatabase database;
	public TodoItemPage(TodoItemDatabase todoItemDatabase)
	{
		InitializeComponent();
		database = todoItemDatabase;
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please insert a name for To Do item", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}