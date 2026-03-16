
@code
    Layout = ""
End Code
 

 <div id="AlarmXmodule" class="container-fluid" style="padding: 5px 5px 5px 5px; background-color: white; width: 100%; ">
    <div class="row">
        <div class="col-lg-1">
            @*Left Side bar *@
            <div class="btn btn-group-vertical" style="padding:5px 5px 5px 5px; background-color:white">
                <button id="btnAlarmXwspace" type="button" class="btn btn-default" style="height: 80px; border-color:black; border-width: 1px; border-color: gray">My<br />Workspace</button>
                <br />
                <button id="btnAlarmXaltwspace" type="button" class="btn btn-default" style="height: 80px; border-color: black; border-width: 1px; border-color: gray">Alternate<br /> Workspace</button>
                <br />
                <button id="btnAlarmXregional" type="button" class="btn btn-default" style="height: 80px; border-color: black; border-width: 1px; border-color: gray">Regional<br /> Workspace</button>
                <br />
                <img src="~/images/AlarmX.png" style="height:200px" />
            </div>
        </div>


        <div class="col-lg-11">
            @* Main Content *@
            <div style="background-color:white;width:100%;height:100%">
                @* sub Menu bar *@
                <div class="row" >
                    <div  style="background-color: white; color: blue; text-align: center; padding-top: 0px; padding-bottom: 0px; min-height: 35px; height: 35px">
                    <span style="padding-right:100px;font-size:16px">
                        <b><label id="AlarmXweeklabel"></label> </b>
                    </span>
                    <span style="padding-right:10px">
                        @* Select Date:<input type="date" id="AlarmXappcalendar" name="AlarmXappcalendar">*@
                        Select Date:<input id="AlarmXappcalendar" name="AlarmXappcalendar" />
                    </span>
                    <button id="AlarmXMBCbtn" type="button" class="btn btn-sm btn-default" style="border-width: 1px; border-color:gray" onclick="filtertable('#alarmxtablebody','MBC',13)">MBC Alarms()</button>
                    <button id="AlarmXTSCbtn" type="button" class="btn btn-sm btn-default" style="border-width: 1px; border-color: gray" onclick="filtertable('#alarmxtablebody','TSC',13)">TSC Alarms()</button>
                    <button id="AlarmXMGWbtn" type="button" class="btn btn-sm btn-default" style="border-width: 1px; border-color: gray" onclick="filtertable('#alarmxtablebody','MGW',13)">MGW Alarms()</button>
                    <button id="AlarmXOthersbtn" type="button" class="btn btn-sm btn-default" style="border-width: 1px; border-color: gray" onclick="filtertable('#alarmxtablebody','OTHERS',13)">OTHER Alarms()</button>
                </div>
            </div>
                @* Body *@
                <div id="alarmxtablediv" style="overflow-y:scroll; height:calc(60vh); width: auto;">
                    <table id="alarmxtable">
                        <thead>
                            <tr style="background-color:gray;">
                                <th style="display:none">ID</th>
                                <th>Severity</th>
                                <th>Node</th>
                                <th>Event_Time</th>
                                <th>Fault</th>
                                <th style="max-width:40%">Description</th>
                                <th>Ticket</th>
                                <th>Comment</th>
                                <th>Status</th>
                                <th style="display:none">UnitID</th>
                                <th>Unit</th>
                                <th>Owner</th>
                                <th style="display:none">Type</th>
                            </tr>
                        </thead>
                        <tbody id="alarmxtablebody">
                        </tbody>
                    </table>
                </div>



            </div><br />
            <div style="text-align: center;"><button id="alarmxsavebtn" type="button" class="btn btn-sm btn-success" style="border-color:gray; border-width: 1px;width:50%">
                <b>Save Changes to Server</b></button></div>

        </div>

        <!-- Entries div -->
        @*@Html.DropDownList("alarmxgridentrydropdown", CType(ViewBag.Units, List(Of SelectListItem)))*@

        @*<div id="alamxgrideditdiv" style="display:block">*@




    </div>
    <div id="alamxgrideditdiv" style="display:none">
        @Html.DropDownList("alarmxunitsdropdown")
        <select id="alarmxstatusdropdown" class="editboxes">
            <option value="Active">Active</option>
            <option value="Resolved">Resolved</option>
            <option value="Exemption">Exemption</option>
        </select>
        <input id="alarmxcommentbox" class="editboxes" />
        <input id="alarmxrefbox" class="editboxes" />
        <style>
            #alarmxunitsdropdown,
            .editboxes {
                background-color: white;
                color: blue;
                border-width: 0px;
                min-width: 98%;
                width: 100%;
            }
        </style>
    </div>
    <div class='Alarmxcontextmenu'>
        <ul>
            <li data-action="Copy">Copy</li>
            <li data-action="Paste">Paste</li>
        </ul>
    </div>

</div>
