using MobileApp.Models;

namespace MobileApp;

public partial class CoursePage : ContentPage
{
    Enrollment enr;
    public CoursePage(Enrollment enrl)
    {
        InitializeComponent();
        enr = enrl;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var Course = (Course)BindingContext;
        await App.Database.SaveCourseAsync(Course);
        listView.ItemsSource = await App.Database.GetCoursesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var Course = (Course)BindingContext;
        await App.Database.DeleteCourseAsync(Course);
        listView.ItemsSource = await App.Database.GetCoursesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetCoursesAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Course c;
        if (listView.SelectedItem != null)
        {
            c = listView.SelectedItem as Course;
            var lc = new CourseEnrollment()
            {
                EnrollmentID = enr.EnrollmentID,
                CourseID = c.CourseID
            };
            await App.Database.SaveCourseEnrollmentAsync(lc);
            c.CourseEnrollments = new List<CourseEnrollment> { lc };
            await Navigation.PopAsync();
        }

    }
}