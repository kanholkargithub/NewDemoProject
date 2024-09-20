using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DeepLearning
{
    public class Services
    {
        private readonly HttpClient _httpClient;
        public Services()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Student>> GetStudentsAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            var students = JsonConvert.DeserializeObject<List<Student>>(response);
            return students;
        }
        public async Task<List<Teacher>> GetTeachersAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            var teachers = JsonConvert.DeserializeObject<List<Teacher>>(response);
            return teachers;
        }
        public async Task<List<CertificateDownload>> GetCertificateDownloadsAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            var certificates = JsonConvert.DeserializeObject<List<CertificateDownload>>(response);
            return certificates;
        }
        public async Task<List<Payment>> GetPaymentsAsync(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            var payments = JsonConvert.DeserializeObject<List<Payment>>(response);
            return payments;
        }

    }

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int FeeAmount { get; set; }
        public string FeeType { get; set; }
        public int InstId { get; set; }
        public string InstitutionName { get; set; }
        public DateTime JoiningDate { get; set; }
        public object MobileNo { get; set; } 
        public int PaidAomunt { get; set; }
        public DateTime RegDate { get; set; }

    }

    public class Teacher
    {
        public string Email { get; set; }
        public string CourseName { get; set; }
        public string Desig { get; set; }
        public object Enddate { get; set; }
        public object Experience { get; set; }
        public string HigherEdu { get; set; }
        public string InstitutionName { get; set; }
        public object MobileNo { get; set; }
        public string Name { get; set; }
        public string selectCourseType { get; set; }
        public object startdate { get; set; }

    }
    public class CertificateDownload
    {
        public int BatchId { get; set; }
        public string CourseName { get; set; }
        public string Name { get; set; }
        public int StudId { get; set; }
    }
    public class Payment
    {
        public int Bill_No { get; set; }
        public int CourseId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PaymentStatus { get; set; }
        public object PaymentDate { get; set; }
        public int PaidAmount { get; set; }



    }
}