using Microsoft.Maui.Devices.Sensors;
using MobileApp.Models;
using Plugin.LocalNotification;
using System.Net;

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
        var description = slist.Description;

        var request = new NotificationRequest
        {
            Title = "Notificare de confirmare",
            Description = "Te-ai inscris cu succes la: " + description,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5)
            }
        };
        LocalNotificationCenter.Current.Show(request);

        await App.Database.SaveEnrollmentAsync(slist);
        listView.ItemsSource = await App.Database.GetCourseEnrollmentsAsync(slist.EnrollmentID);
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
        await Navigation.PushAsync(new CoursePage((Enrollment)this.BindingContext)
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