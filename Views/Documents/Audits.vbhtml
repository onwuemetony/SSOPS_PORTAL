@Code
    ViewData("Title") = "Audits"
End Code

<div id="Auditsmodule" class="container-fluid" style="padding:5px 5px 5px 5px; background-color:white; width:100%;height:100%;flex:1">
    <div class="row">
        <!--<div class="col-lg-1">-->
            @*Left Side bar *@
            <!--<div class="btn btn-group-vertical" style="padding:5px 5px 5px 5px; background-color:silver">
            </div>
        </div>-->


        <div class="col-lg-12">
            @* Main Content *@
            <div style=" background-color:silver;width:100%;height:35px">
                <div class="navbar" style="text-align: center">
                    <span style="color:blue;padding-right:100px;font-size:16px">
                        <b>Audits</b>
                        <select id="Select1">
                            <option value="2017">2017</option>
                            <option value="2018">2018</option>
                            <option value="2019">2019</option>
                            <option value="2020">2020</option>
                            <option value="2021">2021</option>
                            <option value="2022">2022</option>
                            <option value="2023">2023</option>
                            <option value="2024">2024</option>
                            <option value="2025">2025</option>
                            <option value="2026">2026</option>
                            <option value="2027">2027</option>
                            <option value="2028">2028</option>
                            <option value="2029">2029</option>
                            <option value="2030">2030</option>
                        </select>
                    </span>
                    <span style="padding-right:10px">
                    </span>
                    <button type="button" class="btn btn-default" style="border-color:black; border-width: 1px; border-color: gray">Display</button>
                    <button type="button" class="btn btn-default" style="border-color: black; border-width: 1px; border-color: gray">Load from Disk </button>
                    <button type="button" class="btn btn-default" style="border-color: black; border-width: 1px; border-color: gray">Upload to Server </button>
                    <button type="button" class="btn btn-default" style="border-color: black; border-width: 1px; border-color: gray">Download from Server</button>
                </div>

            </div>

            <!--<div class="col-lg-1">-->
                <!-- Right side bar-->

            <!--</div>-->
        </div>
    </div>
</div>
