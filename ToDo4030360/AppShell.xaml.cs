using ToDo4030360.Views;

namespace ToDo4030360;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TodoItemPage), typeof(TodoItemPage));
	}
}