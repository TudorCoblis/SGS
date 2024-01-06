using MobileApp.Models;

namespace MobileApp;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Enrollment)BindingContext;
        slist.EnrollmentDate = DateTime.UtcNow;
        await App.Database.SaveEnrollmentAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Enrollment)BindingContext;
        await App.Database.DeleteEnrollmentAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CoursePage((Enrollment)
       this.BindingContext)
        {
            BindingContext = new Course()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Enrollment)BindingContext;

        listView.ItemsSource = await App.Database.GetCourseEnrollmentsAsync(shopl.EnrollmentID);
    }
}