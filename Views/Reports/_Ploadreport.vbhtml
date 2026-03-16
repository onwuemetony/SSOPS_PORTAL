

@code
    Layout = ""
End Code

<div id="Ploadreportmodule" class="container-fluid mt-1 bg-dark-subtle" >
    <div class="row">
                   @* sub Menu bar *@
        <div>
            <span class="text-muted ">From:<input style="width:150px" id="Ploadreportcalendar1" name="Ploadreportcalendar" type="text" /></span>
            <span class="ps-3"> </span>
            <span class="text-muted">To:<input style="width:150px" id="Ploadreportcalendar2" name="Ploadreportcalendar" type="text" /></span>
            <span class="ps-3"> </span>
            <select id="Ploadreportsummdropdown">
                <option value=1 selected="selected">ALL</option>
                <option value=2>ASMBC</option>
                <option value=3>ABMBC</option>>
                <option value=4>OJMBC</option>
                <option value=5>LGMBC</option>
            </select>
            <span class="ps-3"> </span>
            <button id="Ploadreportbtn" type="button" class="btn btn-sm btn-outline-secondary">GENERATE REPORT</button>

        </div>
        </div>
        @* Body *@

    </div>
    
    <div id="Ploadreporttablediv" style="overflow-y:scroll; height:auto; width: auto;">
      
    </div>
    

