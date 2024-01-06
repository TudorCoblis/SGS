using MobileApp.Models;

namespace MobileApp;

public partial class EnrollmentList : ContentPage
{
	public EnrollmentList()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEnrollmentAsync();
    }
    async void OnEnrollmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new Enrollment()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as Enrollment
            });
        }
    }
}