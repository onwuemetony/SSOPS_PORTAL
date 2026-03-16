
<div id="alarmxtablediv" style="overflow-y:scroll; height:calc(20vh); width: auto;">

    <table id="alarmxreporttable">
        <thead>
            <tr>

                @For Each col In ViewBag.table1(0).split(",")
                    @<th>@col</th>
                    'Dim gd As New WebGrid()
                Next
            </tr>
        </thead>
        <tbody id="alarmxreporttablebody">
            @For Each row In ViewBag.table1
                @If row <> ViewBag.table1(0) Then
                    @<tr>
                        @For Each col In row.split(",")
                            @<td>@col</td>
                        Next
                    </tr>

                End If
            Next
        </tbody>
    </table>
</div>
<br />

<div id="alarmxtabledetaildiv" style="overflow-y:scroll; height:calc(45vh); width: auto;">
    <table id="alarmxreportdetailstable">
        <thead>
            <tr>
                <th>Week</th>
                <th>Severity</th>
                <th>Node</th>
                <th>Event Time</th>
                <th>Fault</th>
                <th style="max-width:40%">Description</th>
                <th>Ticket</th>
                <th>Comment</th>
                <th>Status</th>
                <th>unit</th>
                <th>Owner</th>
            </tr>
        </thead>
        <tbody id="alarmxreporttablebody">
            @For Each row In ViewBag.table2
                @<tr>
    <td>@row.Week</td>
    <td>@row.Severity</td>
    <td>@row.Node</td>
    <td>@row.Event_Time</td>
    <td>@row.Fault</td>
    <td style="max-width:40%">@row.Description</td>
    <td>@row.Ticket</td>
    <td>@row.Comment</td>
    <td>@row.Status</td>
    <td>@row.Name</td>
    <td>@row.Owner</td>
</tr>
            Next
        </tbody>                                                                                                                                                                                                                                                                                           
        
    </table>
</div> 

<script type="text/javascript">
    $(document).ready(function () {
        $("#alarmxreporttable").DataTable(
            {
                dom: 'Bflrt',
                buttons: ['copy', 'excel'],
                 "searching": false,
            });
      var Table =  $("#alarmxreportdetailstable").DataTable(
            {
              dom: 'Bflrtip',
              buttons: ['copy', 'excel']
                //"paging": false,
                //"searching": false,
                //"info": false
                
          });
        //table.buttons().container().insertBefore('#alarmxtabledetaildiv');
        
    });
</script>