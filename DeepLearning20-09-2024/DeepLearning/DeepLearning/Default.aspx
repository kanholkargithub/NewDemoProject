<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DeepLearning._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head >
        <link href="StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script  >
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(function ()
            {
                drawPieChart();
            });

            function drawPieChart() {
                // Prepare data for Google Charts
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Course Name');
                data.addColumn('number', 'Student Count');

                courseWiseData.forEach(function (item) {
                    data.addRow([item.CourseName, item.StudentCount]);
                });

                // Set chart options
                var pieoptions = {
                    title: 'Course Wise Student Count',
                    is3D: true,
                };

                // Instantiate and draw the chart
                var chart = new google.visualization.PieChart(document.getElementById('courseWiseChart'));
                chart.draw(data, pieoptions);
                
            }
            

        </script>
    </head>
    <div>
        <!-- Panel to hold the student count and other information -->
        
            <div class="panel-section">
                <asp:Label ID="lblStudentCount" runat="server" Text="Total Students:"></asp:Label>
            </div>
            <div class="panel-section">
                <!-- You can add additional information here if needed -->
                <asp:Label ID="lblActiveStudentCount" runat="server" Text="Active Students:"></asp:Label>
            </div>
            <div class="panel-section">
                <!-- You can add other statistics or information here -->
                <asp:Label ID="lblNewStudentCount" runat="server" Text="New Students:"></asp:Label>
            </div>
       
        <div class="panel-section">
            <asp:Label ID="lblCourse" runat="server" Text="Course"></asp:Label><br />
        </div>
        <div>
            <asp:Label ID="lblStudentCompletedCoursesCount" runat="server" Text="Ratio of Completed Course:"></asp:Label><br />
        </div>
        <asp:Label ID="lblSuccessPayment" runat="server" Text="Successful Payments:"></asp:Label><br />

        <asp:Label ID="lblFailedPayment" runat="server" Text="Failed Payments:"></asp:Label><br />

        <asp:Label ID="lblregstudenttocertdownload" runat="server" Text="Ratio of students:"></asp:Label><br />

        <asp:Label ID="lblCertificateDownload" runat="server" Text="Completed Course:"></asp:Label><br />

        <asp:Label ID="lblRevenueGenerated" runat="server" Text="Revenue:"></asp:Label><br />
        
        <div id="courseWiseChart" style="width: 900px; height: 500px;"></div>

       
    </div>
</asp:Content>


