
$('#ButtonSubmitDown').click(function (event) {
    event.preventDefault();
    var IsValid = ValidateInputFields();
    if (IsValid) {
        try {
            InsertData();
        }
        catch {
            GetMessageBox(err, 500);
        }
    }
});
$('#ButtonUpdateDown').click(function (event) {
    event.preventDefault();
    var IsValid = ValidateInputFields();
    if (IsValid) {
        try {
            DBOperation("Edit");
        }
        catch {
            GetMessageBox(err, 500);
        }
    }
});

function InsertData() {
    var VendorId = $('#TextBoxVendorId').val();
    var VendorCode = $('#TextBoxVendorCode').val();
    var VendorTitle = $('#TextBoxVendorTitle').val();
    var JsonArg = {
        VendorId: VendorId,
        Code: VendorCode,
        Title: VendorTitle,
    }
    $.ajax({
        type: "POST",
        url: BasePath + "/ABilling/VendorUI/InsertIntoDB",
        dataType: 'json',
        data: { 'PostedData': (JsonArg) },
        beforeSend: function () {
            startLoading();
        },
        success: function (data) {
            debugger
            table.ajax.reload();

            GetMessageBox(data.Message, data.Code);
            debugger
           // ClearInputFields();

        },
        complete: function () {
            stopLoading();
            table.ajax.reload();

           // ClearInputFields();

        },
        error: function (jqXHR, error, errorThrown) {
            GetMessageBox("The Transaction Can Not Be Performed Due To Serve Activity", 500);

        },
    });

}
function ValidateInputFields() {
    if ($('#TextBoxVendorId').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxVendorCode').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxVendorTitle').RequiredTextBoxInputGroup() == false) {
        return false;
    }
   
    return true;
}
var table = "";
$(document).ready(function () {
    table=  $('#zero-config').DataTable({
        "ajax": {
            "url": BasePath+ "/ABilling/VendorUI/VendorsList", // Update with your controller and action method
            "type": "GET",
            "dataSrc": "data"
        },
        "oLanguage": {
            "oPaginate": {
                "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>',
                "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>'
            },
            "sInfo": "Showing page _PAGE_ of _PAGES_",
            "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
            "sSearchPlaceholder": "Search...",
            "sLengthMenu": "Results :  _MENU_"
        },
        "columns": [
            { "data": "Id", "title": "Id" },
            { "data": "Title","title":"Name" },
            { "data": "Code", "title":"Code" },
            {
                "data": null,
                "title": "Action",
                "render": function (data, type, row) {
                    return `
                        <button class="btn btn-primary edit btn-sm">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-eye"><circle cx="12" cy="12" r="3"></circle><path d="M21 12c-2.25 4-6 7-9 7s-6.75-3-9-7 6-7 9-7 6.75 3 9 7z"></path></svg>
                        </button>
                        <button class="btn btn-secondary delete  btn-sm">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-edit"><path d="M11 4h2v6h-2z"></path><path d="M5 12h14v8H5zm4-6h6m-6 0V8m0 4h6m-6 0V16m-2-6H5m14 0h-2"></path></svg>
                        </button>
                    `;
                }
            }
        ],
        "stripeClasses": [],
        "lengthMenu": [7, 10, 20, 50],
        "pageLength": 7
    });
    $('#zero-config tbody').on('click', '.edit', function (e) {
        var selectedRow = $(this).closest('tr');
        var RIdx = table.row(selectedRow).index();
        // Get the data before removing the row
        var VendorId = table.cell(RIdx, 0).data();
        var Title = table.cell(RIdx, 1).data();
        var Code = table.cell(RIdx, 2).data();
        $('#DivButtonSave').hide();
        $('#DivButtonUpdate').show();
        $('#TextBoxVendorId').val(VendorId);
        $('#TextBoxVendorCode').val(Code);
        $('#TextBoxVendorTitle').val(Title);

    });
    $('#zero-config tbody').on('click', '.delete', function (e) {
        var selectedRow = $(this).closest('tr');
        var RIdx = table.row(selectedRow).index();
        // Get the data before removing the row
        var VendorId = table.cell(RIdx, 0).data();
        var Action = "Delete";
        var JsonArg = {
            Id_: VendorId,
            Action:Action
        }
     

        $.ajax({
            type: "POST",
            url: BasePath + "/ABilling/VendorUI/DBOperation",
            dataType: 'json',
            data: { 'PostedData': (JsonArg) },
            beforeSend: function () {
                startLoading();
            },
            success: function (data) {
                table.ajax.reload();
                GetMessageBox(data.Message, data.Code);
                ClearInputFields();

            },
            complete: function () {
                stopLoading();
                ClearInputFields();

            },
            error: function (jqXHR, error, errorThrown) {
                GetMessageBox("The Transaction Can Not Be Performed Due To Serve Activity", 500);

            },
        });



    });

});
function DBOperation(Action) {
    var VendorId = $('#TextBoxVendorId').val();
    var VendorCode = $('#TextBoxVendorCode').val();
    var VendorTitle = $('#TextBoxVendorTitle').val();
    var JsonArg = {
        Id_: VendorId,
        Code: VendorCode,
        Title: VendorTitle,
        Action: Action,

    }
  
    $.ajax({
        type: "POST",
        url: BasePath + "/ABilling/VendorUI/DBOperation",
        dataType: 'json',
        data: { 'PostedData': (JsonArg) },
        beforeSend: function () {
            startLoading();
        },
        success: function (data) {
            debugger
            table.ajax.reload();

            GetMessageBox(data.Message, data.Code);
            debugger
            ClearInputFields();

        },
        complete: function () {
            stopLoading();
            ClearInputFields();

        },
        error: function (jqXHR, error, errorThrown) {
            GetMessageBox("The Transaction Can Not Be Performed Due To Serve Activity", 500);

        },
    });

}