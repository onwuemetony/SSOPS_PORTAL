<!-- ko with: home -->

@*<div class="row"*@ 
    <div class="col-md-2">
        <h2></h2>
        <p></p>
       </div>
        <div class="col-md-6" style="left:300px;top:150px; width:350px">
                  <div class="panel panel-primary">
                      <div class="panel-heading" style="text-align:center"><span class="glyphicon glyphicon-user"></span>  User Sign-In</div>
                <div class="panel-body">
                    <form class="form-horizontal" action="/action_page.php">
                        <div class="form-group">
                            <label class="control-label col-sm-offset-0 col-sm-6" for="email">MTN username:</label>
                            <div class="col-sm-offset-0 col-sm-6">
                                <input type="text" class="form-control" id="email" value="anthonon">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-offset-0 col-sm-6" for="pwd">Code:</label>
                            <div class="col-sm-6">
                                <input type="password" class="form-control" id="pwd" placeholder="Enter Code">
                            </div>
                        </div>
                        
                        <div class="form-group" style="text-align:center;" >
                            <div >
                                <button type="submit" class="btn-success col-sm-offset-1 col-sm-6">Send code to email</button> 
                                <button type="submit" class="btn-primary col-sm-offset-1 col-sm-3">Sign-In</button>
                             </div>
                        </div>
                    </form>
                </div>
                
            </div>              
    </div>

    <div class="col-md-4">
       
    </div>
@*</div>**@

<!-- /ko -->
