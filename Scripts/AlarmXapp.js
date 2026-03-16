var Userid = $("#Userid").text();
var AlarmXapp = { wk: 1, yr: 2021, wspace: 1, user: Userid, editcol: 0, editrow: 0 };
var AlarmXreport = { Fromdate: "" , FromWeek: 70, ToWeek: 70, yr: 2021, category: 1, categoryid: 1, criteria: 1 };

var AlarmXappclipboard = { ref: "", comment: "", status: "", uid: "", uname: "" };
var AlarmXappcol = { id:0, ref: 6, comment: 7, status: 8, uid: 9, uname: 10 };
var mousedown = 0;


$(function () {
    $(document).ready(function ()
    {
        $(document).bind("mousedown", function (e) {
            if (!$(e.target).parents(".Alarmxcontextmenu").length > 0) {

                // Hide AlarmX copy/paste context menu
                $(".Alarmxcontextmenu").hide(100); 
            }
        });

        $("#alarmxunitsdropdown").addClass("editboxes");
        
        $("input[name='AlarmXappcalendar']").datepicker(
            {
                changeMonth: true,
                changeYear: true,
                firstDay: 5,
                //showWeek: true,
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: "../images/calendar.gif",
                dateFormat: 'yy-mm-dd',
                onSelect: function (dateText)
                {
                    var searchdate = new Date((new Date(dateText).getTime()) + (3 * 24 * 60 * 60 * 1000));
                    var wk = $.datepicker.iso8601Week(searchdate);
                    var yr = searchdate.getFullYear();
                    if (wk > 52) { yr++; }
                    if (this.id == "AlarmXappcalendar")
                    {
                       $("#AlarmXweeklabel").text("Year " + yr + " Week " + wk + " Alarms");
                        AlarmXapp = { wk: wk, yr: yr, wspace: 1, user: Userid };
                        loadAlarmXtable();  
                    }

                    if (this.id == "AlarmXreportcalendar1") { AlarmXreport.Fromdate = searchdate; AlarmXreport.FromWeek = wk; AlarmXreport.yr = yr; };
                    if (this.id == "AlarmXreportcalendar2") { AlarmXreport.ToWeek = wk; AlarmXreport.yr = yr;  };
                    }
            });

      

        $("#AlarmXreportbtn").click(function () {
            //AlarmXreport = {Fromdate: Fromdate, FromWeek: wk, ToWeek: ToWeek, yr: yr, category: 1, categoryid: categoryid, criteria: criteria};

           
            if ((AlarmXreport.FromWeek < 1) || (AlarmXreport.FromWeek >52)) { alert("Select a start date"); return; }
            if ((AlarmXreport.ToWeek < 1) || (AlarmXreport.ToWeek > 52)) { alert("Select a Stop date"); return; }

            AlarmXreport.category = $("input[name='categoryradio']:checked").val();
            AlarmXreport.criteria = $("input[name='criteriaradio']:checked").val();

             if (AlarmXreport.category == 1) { AlarmXreport.categoryid = $("#alarmxreportsummdropdown").val(); }
             if (AlarmXreport.category == 2) { AlarmXreport.categoryid = $("#alarmxrportNodesdropdown").val(); }
                   
              loadAlarmXreports();
            });
        

        $("#AlarmXappcalendar").click(function () {
            $("#AlarmXappcalendar").datepicker("show");
        });
        $("#AlarmXappcalendar1").click(function () {
            $("#AlarmXappcalendar1").datepicker("show");
        });

        $("#btnAlarmXwspace").click(function ()
        {
            AlarmXapp.wspace = 1;
            loadAlarmXtable();
            $("#alarmxsavebtn").attr("disabled", false);
        });


        $("#btnAlarmXaltwspace").click(function ()
        {
            AlarmXapp.wspace = 2;
            loadAlarmXtable();
            $("#alarmxsavebtn").attr("disabled", false);
        });


        $("#btnAlarmXregional").click(function () {
            AlarmXapp.wspace = 3;
            loadAlarmXtable();
            $("#alarmxsavebtn").attr("disabled", true);
        });

        $("#alarmxsavebtn").click(function ()
        {
            var trows = "#alarmxtablebody tr";
            if ($(trows).length > 1)
            {
                var updata = new Array();
                //var updatas = {};
                $(trows).each(function ()
                {
                    var tcells = $(this).children("td");
                    updatas = {};
                    updatas.ID = tcells.eq(AlarmXappcol.id).text();
                    updatas.Ticket = tcells.eq(AlarmXappcol.ref).text();
                    updatas.Comment = tcells.eq(AlarmXappcol.comment).text();
                    updatas.Status = tcells.eq(AlarmXappcol.status).text();
                    updatas.UnitID = tcells.eq(AlarmXappcol.uid).text();

                    updata.push(updatas);
                    
                })
                
                var data = { wk: AlarmXapp.wk, yr: AlarmXapp.yr, wspace: AlarmXapp.wspace, user: AlarmXapp.user, updata: updata };
                //console.log(updata);
                updateAlarmXtable(data);
            }
            else
            {
                alert("There are no Alarms loaded !")
            }
           
        });

        
       
        $("#alarmxrefbox").focusout(function () { editboxfocusout('#alarmxrefbox',1); });
        $("#alarmxcommentbox").focusout(function () { editboxfocusout('#alarmxcommentbox',1); });
        $("#alarmxstatusdropdown").focusout(function () { editboxfocusout('#alarmxstatusdropdown',2); });
        $("#alarmxunitsdropdown").focusout(function () { editboxfocusout('#alarmxunitsdropdown',3); });

        function editboxfocusout(obj,type)
        {
            if ($(obj).length == 0) return;
           var parent_temp = $(obj).parent();
           if (parent_temp.attr('id') == 'alamxgrideditdiv') {return false; }
            $(obj).appendTo($("#alamxgrideditdiv"));
            if (type == 1) $(parent_temp).text($(obj).val());
            if ((type == 2) || (type == 3)) $(parent_temp).text($(obj + " option:selected").text());
            if (type == 3) $(parent_temp).prev().text($(obj + " option:selected").val());
            
            
        }

   
        $('th').dblclick(function () {
            var table = $(this).parents('table').eq(0);
            var rows = table.find('tr:gt(0)').toArray().sort(comparer($(this).index()));
            this.asc = !this.asc;
            if (!this.asc) { rows = rows.reverse() }
            for (var i = 0; i < rows.length; i++) { table.append(rows[i]); }
        })

        $("#alarmxtablebody").on('click', 'td', function (e)
        {
            
            if (AlarmXapp.wspace != 3)
            {
                var newcol = $(this).index();
                var newrow = $(this).parent('tr').index();
                if ((AlarmXapp.editcol != newcol) || (AlarmXapp.editrow != newrow)) {
                    var txt = $(this).text();
                    var txtt = $(this).parent().find("td:eq(" + ($(this).index() - 1) + ")").text();

                    if ((newcol > 5) && (newcol < 11)) { $(this).text(""); }
                    if (newcol == AlarmXappcol.ref) { $(this).append($("#alarmxrefbox")); $("#alarmxrefbox").val(txt); $("#alarmxrefbox").focus(); }
                    if (newcol == AlarmXappcol.comment) { $(this).append($("#alarmxcommentbox")); $("#alarmxcommentbox").val(txt); $("#alarmxcommentbox").focus(); }
                    if (newcol == AlarmXappcol.status) { $(this).append($("#alarmxstatusdropdown")); $('#alarmxstatusdropdown option[value=' + txt + ']').attr('selected', 'selected'); $("#alarmxstatusdropdown").focus(); }
                    if (newcol == AlarmXappcol.uname) { $(this).append($("#alarmxunitsdropdown")); $('#alarmxunitsdropdown option[value=' + txtt + ']').attr('selected', 'selected'); $("#alarmxunitsdropdown").focus(); }

                    AlarmXapp.editcol = newcol;
                    AlarmXapp.editrow = newrow;
                }

            }
        }
        );

        $("#alarmxtablebody").on('click', 'tr', function ()
        {
            //$("#alarmxtablebody tr").css('background-color', 'white');
            $("#alarmxtablebody tr").removeClass('highlighted');
            $(this).addClass('highlighted');
            //$(this).css('background-color', 'blue');
                if (mousedown == 1) mousedown = 0; else mousedown = 1;                  
        }
        );
     

        $("#alarmxtablebody").on('mouseover', 'tr', function (e)
        {
            //if (mousedown == 0) $("#alarmxtablebody tr").css('background-color', 'white');
            if (mousedown == 0) $("#alarmxtablebody tr").removeClass('highlighted');
            //$(this).css('background-color', 'blue');
            $(this).addClass('highlighted');
        }
        );


        $("#alarmxtablebody").on('contextmenu', 'tr', function (e)
        {
            e.preventDefault();
            if (AlarmXapp.wspace != 3)
            {
               $(".Alarmxcontextmenu").finish().toggle(100).css({ top: e.pageY + "px", left: e.pageX + "px" });
            }
           
        });
        $(".Alarmxcontextmenu").on('click', 'li', function (e)
        {
            switch ($(this).attr("data-action"))
            {
                case "Copy": alarmxcopy(); break;
                case "Paste": alarmxpaste(); break;
             }
             $(".Alarmxcontextmenu").hide(10 );
        });


        function alarmxcopy()
        {
            var copiedrow = ($("#alarmxtablebody tr.highlighted")).first();
            AlarmXappclipboard.ref = getCellValue(copiedrow, AlarmXappcol.ref);
            AlarmXappclipboard.comment = getCellValue(copiedrow, AlarmXappcol.comment);
            AlarmXappclipboard.status = getCellValue(copiedrow, AlarmXappcol.status);
            AlarmXappclipboard.uid = getCellValue(copiedrow, AlarmXappcol.uid);
            AlarmXappclipboard.uname = getCellValue(copiedrow, AlarmXappcol.uname);
            console.log(AlarmXappclipboard);
        }

        function alarmxpaste()
        {
            ($("#alarmxtablebody tr.highlighted")).each(
                function ()
                {
                    var pastecells = $(this).children("td");
                    pastecells.eq(AlarmXappcol.ref).text(AlarmXappclipboard.ref);
                    pastecells.eq(AlarmXappcol.comment).text(AlarmXappclipboard.comment);
                    pastecells.eq(AlarmXappcol.status).text(AlarmXappclipboard.status);
                    pastecells.eq(AlarmXappcol.uid).text(AlarmXappclipboard.uid);
                    pastecells.eq(AlarmXappcol.uname).text(AlarmXappclipboard.uname);
                }
                )

           
        }


        function comparer(index)
          {
            return function (a, b)
            {
                var valA = getCellValue(a, index), valB = getCellValue(b, index);
                return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB);
            }
        }

           function getCellValue(row, col) { return $(row).children('td').eq(col).text(); }


    });
});


function filtertable(table, filterstr,col)
{
    var rows = table + ' tr';
    $(rows).show();
        
    $(rows + ' td:nth-child(' + col + ')').each(function ()

    {
        if (filterstr == 'OTHERS')
        {
            if ($(this).html() == 'MBC' || $(this).html() == 'TSC' || $(this).html() == 'MGW') {  $(this).parents('tr').hide(); }
        }

        if (filterstr != 'OTHERS')
        {
            if ($(this).html() != filterstr)
            {
                $(this).parents('tr').hide();
            }
        }
    });
 }


function DisplayDate(message) { alert(message); };

function loadAlarmXtable()
{
    $.ajax({
        type: 'POST',
        url: "AlarmXappread",
        data: JSON.stringify(AlarmXapp),
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: "html",
        traditional: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
        success: function (result) {
            $("#alarmxtablebody").html('');
            $("#alarmxtablebody").append(result);
        }
    });
    
    var typecells = "#alarmxtable tbody td:nth-child(13)";
    var rowcnt = $("#alarmxtable tbody tr").length;
    var MBCcnt = $(typecells + ':contains("MBC")').length;
    var TSCcnt = $(typecells + ':contains("TSC")').length;
    var MGWcnt = $(typecells + ':contains("MGW")').length;
    var Otherscnt = rowcnt - (MBCcnt + TSCcnt + MGWcnt);
    
        $("#AlarmXMBCbtn").text('MBC (' + MBCcnt + ')');
        $("#AlarmXTSCbtn").text('TSC (' + TSCcnt + ')');
        $("#AlarmXMGWbtn").text('MGW (' + MGWcnt + ')');
     $("#AlarmXOthersbtn").text('OTHERS (' + Otherscnt  + ')');
        filtertable('#alarmxtablebody', 'MBC', 13);
}

function updateAlarmXtable(data)
{
    $.ajax(
        {
            type: 'POST',
            url: "AlarmXappupdate",
            data: JSON.stringify(data),
            async: false,
            contentType: 'application/json; charset=utf-8',
            dataType: "html",
            traditional: true,
           error: function (XMLHttpRequest, textStatus, errorThrown) {
                var contentType = XMLHttpRequest.getResponseHeader("Content-Type");
                if (XMLHttpRequest.status === 200) {
                    // assume that our login has expired - reload our current page
                    window.location.reload();
                }
                else
                {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                }
            },
            success: function (result)
            {
                console.log(result);
                if (result == "successfully saved to server") alert(result);
                //else { alert("Your session has expired"); window.location.reload();}
             }
 }
            );

}



function loadAlarmXreports() {
    $.ajax(
        {
        type: 'POST',
        url: "AlarmXreportread",
        data: JSON.stringify(AlarmXreport),
        async: false,
        contentType: 'application/json; charset=utf-8',
        dataType: "html",
        traditional: true,
        traditional: true,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
            success: function (result) {
                $("#alarmxreporttablediv").html('');
                $("#alarmxreporttablediv").append(result);
            }
    });
}

