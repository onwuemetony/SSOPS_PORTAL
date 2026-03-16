@code
    Layout = ""
End Code

<div class="row">
    <div class="nav">
        <div class="col-lg-2">
            <div class="count-container">
                <div class="count-box red-bg">
                    <div class="count-number">@Iif(Not ViewBag.hcount Is Nothing, ViewBag.hcount, 0)</div>
                    <div class="count-label">High</div>
                </div>
                <div class="count-box amber-bg">
                    <div class="count-number">@IIf(Not ViewBag.hcount Is Nothing, ViewBag.wcount, 0)</div>
                    <div class="count-label">Warning</div>
                </div>
                <div class="count-box green-bg">
                    <div class="count-number">@IIf(Not ViewBag.hcount Is Nothing, ViewBag.ncount, 0)</div>
                    <div class="count-label">Normal</div>
                </div>
            </div>

        </div>

        <div class="col-lg-5">@*Bar chart control*@
            @If Not ViewBag.chart Is Nothing Then
                @<canvas class="piechart" id="PloadbarChart" ></canvas>
                @<script>
var chartbgColors = [
        '#e6194b', // Red
        '#3cb44b', // Green
        '#ffe119', // Yellow
        '#4363d8', // Blue
        '#f58231', // Orange
        '#911eb4', // Purple
        '#46f0f0', // Cyan
        '#f032e6', // Magenta
        '#bcf60c', // Lime
        '#fabebe'  // Pink
    ];
var BchartLabels = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(DirectCast(ViewBag.chart, IEnumerable(Of Object)).Select(Function(x) x.Sample_Time))) ;
var BchartValues = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(DirectCast(ViewBag.chart, IEnumerable(Of Object)).Select(Function(x) x.Pload_Avg))) ;
var Bcharttop = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(DirectCast(ViewBag.chart, IEnumerable(Of Object)).Select(Function(x) x.MBC_Name))) ;

     var ctx = document.getElementById('PloadbarChart').getContext('2d');
        var barChart = new Chart(ctx, {
            type: 'bar',
            borderWidth: 1,
            data: {
                labels: BchartLabels,
                datasets: [{
                    label: 'Top 10 CP Loads vs Time',
                    data: BchartValues,
                    backgroundColor: chartbgColors,
                    datalabels: {
                        anchor: 'end',
                        align: 'top',
                        color: 'black',
                        font: {
                            weight: 'bold'
                        },
                        formatter: function (value, context) {
                            return Bcharttop[context.dataIndex]; // Show Dataset 3 values on top
                        }
                    }
                }],
               
              
            },
            options: {
        responsive: true,
        plugins: {

          
            tooltip: {
                enabled: true
            },
            datalabels: {
                anchor: 'end',
                align: 'top',
                formatter: Math.round,
                font: {
                    weight: 'bold'
                }
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                title: {
                    display: true,
                    text: 'Processor Load(%)'
                }
            },
            x: {
                title: {
                    display: true,
                    text: 'Time'
                }
            }
        }
            },
            plugins: {
                datalabels: {
                    anchor: 'end',
                    align: 'top',
                    color: '#000',
                    font: {
                        weight: 'bold'
                    }
                }
            },
   plugins: [ChartDataLabels]
});
</script>
            End if
        </div>

        <div class="col-lg-5"> @*Pie chart control*@
                @If Not ViewBag.chart Is Nothing Then
                    @<canvas class="piechart" id="PloadpieChart" height="300"></canvas>
                    @<script>
var chartbgColors = [
        '#e6194b', // Red
        '#3cb44b', // Green
        '#ffe119', // Yellow
        '#4363d8', // Blue
        '#f58231', // Orange
        '#911eb4', // Purple
        '#46f0f0', // Cyan
        '#f032e6', // Magenta
        '#bcf60c', // Lime
        '#fabebe'  // Pink
    ];
var chartLabels = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(DirectCast(ViewBag.chart, IEnumerable(Of Object)).Select(Function(x) x.MBC_Name))) ;
var chartValues = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(DirectCast(ViewBag.chart, IEnumerable(Of Object)).Select(Function(x) x.Pload_Avg))) ;

    var ctx = document.getElementById('PloadpieChart').getContext('2d');
        var pieChart = new Chart(ctx, {
            type: 'polarArea',
            data: {
                labels: chartLabels,
                datasets: [{
                    data: chartValues,
                    backgroundColor: chartbgColors
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 10,
                            bottom: 10
                        }
                    },
                    title: {
                        display: true,
                        text: 'Top 10 CP Loads',
                        font: {
                            size: 22
                        },
                        align: 'center'          // or 'start' or 'end'
                    },
                    legend: {
                        position: 'bottom',

                        tooltip: {
                            bodyFont: {
                                size: 18
                            },

                        }
                    }
                }
            }
        });


                    </script>
                End if
            </div>
    </div>
</div>

<div class="row">

    <table id="PloaddetailsTable" class="styled-table" style="width:95%">

        <thead>
            <tr>
                <th>Time</th>
                <th>Group</th>
                <th>Name</th>
                <th>Average(%)</th>
                <th>Maximum(%)</th>
                <th>Max ID</th>
            </tr>
        </thead>
        <tbody>
            @If ViewBag.table IsNot Nothing Then
                For Each item In ViewBag.table
                    @<tr>
                        <td>@String.Format("{0:yyyy-MM-dd HH:00}", item.Sample_Time)</td>
                        <td>@item.MBC_Prefix</td>
                        <td>@item.MBC_Name</td>
                        <td>@item.Pload_Avg</td>
                        <td>@item.Pload_Max</td>
                        <td>@item.Pload_Max_Bladeid</td>
                    </tr>
                Next
            End If
        </tbody>
    </table>

</div>

