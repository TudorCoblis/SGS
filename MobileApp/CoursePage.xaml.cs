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
        if (listView.SelectedItem != null)
        {
            Course c = listView.SelectedItem as Course;

            if (c != null)
            {
                var lc = new CourseEnrollment()
                {
                    EnrollmentID = enr.EnrollmentID,
                    CourseID = c.CourseID
                };

                await App.Database.SaveCourseEnrollmentAsync(lc);

                if (c.CourseEnrollments == null)
                {
                    c.CourseEnrollments = new List<CourseEnrollment>();
                }

                c.CourseEnrollments.Add(lc);

                listView.ItemsSource = await App.Database.GetCourseEnrollmentsAsync(enr.EnrollmentID);

                await Navigation.PopAsync();
            }
        }
    }
}
