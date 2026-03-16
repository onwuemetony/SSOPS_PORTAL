

function loadmainTab(tabname)
{
    $(document).ready(function ()
 {
        
            $('#' + tabname).css('visibility', 'visible');
        $('#' + tabname).tab('show');
       
 }
 );
};

$(document).ready(function () {
    function disablePrev() { window.history.forward() }
    window.onload = disablePrev();
    window.onpageshow = function (evt) { if (evt.persisted) disableBack() }

    

});

