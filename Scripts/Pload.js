var Userid = $("#Userid").text();
var Ploadapp = { wk: 1, yr: 2021, wspace: 1, user: Userid, editcol: 0, editrow: 0 };
var Ploadreport = { Fromdate: "" , Todate: "",  node: 1 };

var Ploadappclipboard = { ref: "", comment: "", status: "", uid: "", uname: "" };
var Ploadappcol = { id:0, ref: 6, comment: 7, status: 8, uid: 9, uname: 10 };
var mousedown = 0;


$(function () {
    $(document).ready(function ()
    {
       

        $("#Ploadunitsdropdown").addClass("editboxes");
        
        $("input[name='Ploadreportcalendar']").datetimepicker(
            {
                formatDate: 'd.m.y',
                formatTime: 'H',
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: "../images/calendar.gif",
                dateFormat: 'yyyy-mm-dd',
                onChangeDateTime: function (dp, $input) {
                  //  alert($input);
                  // alert($input.val());
                }
              });

      

        $("#Ploadreportbtn").click(function () {
            //Ploadreport = {Fromdate: Fromdate, FromWeek: wk, ToWeek: ToWeek, yr: yr, category: 1, categoryid: categoryid, criteria: criteria};

            Ploadreport.Fromdate = $("#Ploadreportcalendar1").val();
            Ploadreport.Todate = $("#Ploadreportcalendar2").val();
            if (Ploadreport.Fromdate == '') { alert("Select a start date"); return; };
            if (Ploadreport.Todate == '') { alert("Select a Stop date"); return; };
            Ploadreport.node = $("#Ploadreportsummdropdown").val();
            loadPloadreports();
            });
        

        $("#Ploadreportcalendar1").click(function () {
            $("#Ploadreportcalendar1").datetimepicker("show");
        });
        $("#Ploadreportcalendar1").click(function () {
            $("#Ploadreportcalendar1").datetimepicker("show");
        });

              


    });
});



function DisplayDate(message) { alert(message); };





function loadPloadreports() {
    $.ajax(
        {
        type: 'POST',
        url: "Ploadreportread",
        data: JSON.stringify(Ploadreport),
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: "html",
        traditional: true,
        traditional: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
            success: function (result)
            {
                $("#Ploadreporttablediv").html('');
                $("#Ploadreporttablediv").append(result);
                $('#PloaddetailsTable').DataTable
                    ({
                        layout: {
                            topStart: {
                                buttons: ['copyHtml5', 'excelHtml5', 'csvHtml5', 'pdfHtml5']
                            }
                        },
                        "createdRow": function (row, data, dataIndex) {
                            if (data[3] >= 70) { $(row).addClass('row-red'); };
                            if ((data[3] >= 60) && (data[3] < 70)) { $(row).addClass('row-amber'); };
                            if (data[3] < 60 ) { $(row).addClass('row-green'); };
                        }
                    }
                   );
            }
    });
}

