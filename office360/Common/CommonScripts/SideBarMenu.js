﻿var Menu ;

$(document).ready(function () {
    PopulateMenu_CompanySetup();
    PopulateMenu_Accounts();
});


function PopulateMenu_CompanySetup() {
    debugger
    Menu = $('#CompanySetupHeaderSideMenue').text();
    var JsonArg = {
        Menu: Menu,
    }
    $.ajax({

        type: "POST",
        url: BasePath + "/Home/PopulateAllowedRights",
        data: { 'Parameter': JsonArg},
        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<li><a href="' + BasePath + data[i].Description +'?RightId='+data[i].Id+'">' + data[i].DisplayName + '</a><li>';
                $("#CompanySetupHeaderAllowedFormCount").text(data[i].ParentDisplay);

            }
            $("#CompanySetupAllowedFormsList").html(s);


        },
    });
}
function PopulateMenu_Accounts() {
    debugger
    Menu = $('#AccountsHeaderSideMenue').text();
    var JsonArg = {
        Menu: Menu,
    }
    $.ajax({

        type: "POST",
        url: BasePath + "/Home/PopulateAllowedRights",
        data: { 'Parameter': JsonArg},

        success: function (data) {
            var s = "";
            for (var i = 0; i < data.length; i++) {
                s += '<li><a href="' + BasePath + data[i].Description + '?RightId=' + data[i].Id + '">' + data[i].DisplayName + '</a><li>';
                $("#AccountsAllowedFormCount").text(data[i].ParentDisplay);

            }
            $("#AccountsAllowedFormsList").html(s);


        },
    });
}




// Extend jQuery prototype
