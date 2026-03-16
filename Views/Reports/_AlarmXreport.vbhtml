
@code
    Layout = ""
End Code

<div id="AlarmXreportmodule" class="container-fluid mt-1 bg-dark-subtle " >

    @* sub Menu bar  *@
    <div class="row">
        <div>

            <span style="padding-right:5px">From:<input style="width:100px" id="AlarmXreportcalendar1" name="AlarmXappcalendar" /></span>
            <span style="padding-right:5px">To:<input style="width:100px" id="AlarmXreportcalendar2" name="AlarmXappcalendar" /></span>
            <span class="ps-3"> </span>
            <span style="padding-right:5px">Criteria</span>
            <label class="labelrad"><input  type="radio" name="criteriaradio" value="1" checked>None</label>
            <label class="labelrad"><input type="radio" name="criteriaradio" value="2">Aged</label>
            <label class="labelrad"><input type="radio" name="criteriaradio" value="3">Recent</label>
            <span class="ps-4"> </span>
            <span style="padding-right:5px">Category</span>
            <label class="labelrad"><input type="radio" name="categoryradio" checked value="1">Summaries</label>
            <select id="alarmxreportsummdropdown">
                <option value=1>Alarm Status</option>
                <option value=2>Alarm Severity</option>>
                <option value=3>Alarm Owner Units</option>
                <option value=4>Resolution by Units</option>
                <option value=5>Exemption bucket</option>
                <option value=6>MBCs</option>
                <option value=7>TSCs</option>
                <option value=8>MGWs</option>
                <option value=9>HBCs</option>
                <option value=10>CUDBs</option>
                <option value=11>HSS</option>
                <option value=12>STPs</option>
            </select> <span class="ps-4"> </span>
            <label class="labelrad"><input type="radio" name="categoryradio" value="2">Individual Nodes</label>@Html.DropDownList("alarmxrportNodesdropdown") <span class="ps-4"> </span>
            <button id="AlarmXreportbtn" type="button" class="btn btn-sm btn-default" style="border-width: 1px; border-color: gray">GENERATE REPORT</button>

        </div>


        @* Body *@

    </div>
</div>

         <div id="alarmxreporttablediv" style="overflow-y:scroll; height:calc(60vh); width: auto;"></div>
        

      
  
  