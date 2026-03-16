
@Code
    ViewData("Title") = "Main"
End Code

@Section SPAViews

    <div id="work_area" class="container body-content mt-3" style="width: 100%">
      
        <ul id="maintab" class="nav nav-tabs" >
            <li role="presentation" class="nav-item nav_maintabs"><a id="AlarmXapptab" class="nav-link" href="#AlarmXapppane" aria-controls="AlarmXapppane" role="tab" data-bs-toggle="tab"><b>AlarmX</b></a></li>
            <li role="presentation" class="nav-item nav_maintabs"><a id="AlarmXreporttab" class="nav-link" href="#AlarmXreportpane" aria-controls="blanktabpane" role="tab" data-bs-toggle="tab"><b>AlarmX reports</b></a></li>
            <li role="presentation" class="nav-item nav_maintabs"><a id="Ploadreporttab" class="nav-link" href="#Ploadreportpane" aria-controls="Ploadreportpane" role="tab" data-bs-toggle="tab"><b>Pload</b></a></li>
            <li role="presentation" class="nav-item nav_maintabs"><a id="Audittab" class="nav-link" href="#Auditsdocpane" aria-controls="Auditsdocpane" role="tab" data-bs-toggle="tab"><b>Audits</b></a></li>
        </ul>

        <!-- Tab panes --> 
        <div id="mainpanes" class="tab-content vw-100" style="background-color: white;height:75vh;">
            <div role="tabpanel" class="tab-pane fade" id="AlarmXapppane">@Html.Action("AlarmXapp")</div>
            <div role="tabpanel" Class="tab-pane fade" id="Ploadreportpane">@Html.Action("Ploadreport")</div>
            <div role="tabpanel" Class="tab-pane fade" id="Auditsdocpane"></div>
            <div role="tabpanel" Class="tab-pane fade" id="AlarmXreportpane">@Html.Action("AlarmXreport")</div>
        </div>

    </div>
     

End Section 

    