 

   
        @For Each item In ViewBag.srchquery


            @<tr>
                <td style="display:none">@item.ID</td>
                <td>@item.Severity</td>
                <td>@item.Node</td>
                <td>@item.Event_Time</td>
                <td>@item.Fault</td>
                <td style="max-width:40%">@item.Description</td>
                <td>@item.Ticket</td>
                <td>@item.Comment</td>
                <td>@item.Status</td>
                <td style="display:none">@item.UnitID</td>
                <td>@item.Name</td>
                <td>@item.Owner</td>
                <td style="display:none">@item.Type</td>
    </tr>

        Next
        @*Select Case A.ID, A.Severity, A.Node, A.Event_Time, A.Fault, A.Description, A.Ticket, A.Comment, A.Status, U.Name, N.Type*@
   