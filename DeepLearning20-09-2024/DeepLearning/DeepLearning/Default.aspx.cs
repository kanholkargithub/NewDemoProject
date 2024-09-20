using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace DeepLearning
{
    public partial class _Default : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var Services = new Services();
                List<Student> students =await  Services.GetStudentsAsync("http://192.168.1.106/api/student/studentList?loginId=Admin&password=Dotcom@123");
                List<Teacher> teachers = await Services.GetTeachersAsync("http://192.168.1.106/api/student/teacherList?loginId=Admin&password=Dotcom@123");
                List<CertificateDownload> certificates = await Services.GetCertificateDownloadsAsync("http://192.168.1.106/api/student/certDownList?loginId=Admin&password=Dotcom@123");
                List<Payment> payments = await Services.GetPaymentsAsync("http://192.168.1.106/api/student/paymentList?loginId=Admin&password=Dotcom@123");

                int studentCount = (from a in students select new { a.Name, a.Email }).Distinct().Count();
                lblStudentCount.Text = $"Total Students: {studentCount}";

                //int activeStudent = students.Count(student => student.IsActive);
                DateTime threeMonthsAgo = DateTime.Now.AddMonths(-1);
                int newStudentCount = (from student in students where (student.RegDate >= threeMonthsAgo) && (student.RegDate <  DateTime.Now) select new { student.Name, student.Email }).Count();
                lblNewStudentCount.Text = $"New Students: {newStudentCount}";

                int cousreCount = (from c in teachers select new { c.CourseName}).Distinct().Count();
                lblCourse.Text = $"Total Courses: {cousreCount}";

                int studentCompletedCoursesCount = (from student in certificates select student).Count();
                lblCertificateDownload.Text = $"Certificates Downloaded: {studentCompletedCoursesCount}";

                string courseCompletionRatio = studentCount > 0 ? $"{studentCompletedCoursesCount} / {studentCount}" : "0 / 0";
                lblStudentCompletedCoursesCount.Text = $"Ratio of Student Successfully Completed Course: {courseCompletionRatio}";
                


                int successfulPayment = (from p in payments where p.PaymentStatus == "Success" select p).Count();
                lblSuccessPayment.Text = $"Successful Payments: {successfulPayment}";

                int failedPayment = (from payment in payments where payment.PaymentStatus == "Not Done" select payment).Count();
                lblFailedPayment.Text = $"Failed Payments: {failedPayment}";

                int revenueGenerated = (from p in payments where p.PaymentStatus == "Success" select p.PaidAmount).Sum();
                lblRevenueGenerated.Text = $"Revenue Generated from Certificates: {revenueGenerated}";

                string studentToCertDownload = studentCount > 0 ? $"{(studentCompletedCoursesCount * 100.0 / studentCount):F2}%" : "0.00%";
                lblregstudenttocertdownload.Text = $"Ratio of students: {studentToCertDownload}";

                var courseWiseCount = students.GroupBy(s => new { s.CourseId , CourseName= s.CourseName}).Select(g=> new 
                { 
                    CourseId = g.Key.CourseId,
                    CourseName= g.Key.CourseName,
                    StudentCount= g.Count()
                }).ToList();


                var jsonSerializer = new JavaScriptSerializer();
                string jsonData1 = jsonSerializer.Serialize(courseWiseCount);
                
                
                // Pass the JSON data to the front-end
                Page.ClientScript.RegisterStartupScript(this.GetType(), "chartData", $"var courseWiseData = {jsonData1};", true);
                

            }
        }
    }
}