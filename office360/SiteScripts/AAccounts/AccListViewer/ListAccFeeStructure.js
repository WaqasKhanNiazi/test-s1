var Table = "";
function PopulateAppSessions() {
    $.ajax({
        type: "POST",
        url: BasePath + "/AAccounts/AccListViewer/PopulateAppSessions",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListSession").html(s);
        },
    });
}
function PopulateChallanMethods() {
    $.ajax({
        type: "POST",
        url: BasePath + "/AAccounts/AccListViewer/PopulateChallanMethods",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListChallanMethod").html(s);
        },
    });
}
function PopulateAppClassBySessionId() {
    var JsonArg = {
        SessionId: $('#DropDownListSession :selected').val(),
    }
    $.ajax({
        type: "POST",
        url: BasePath + "/AAccounts/AccListViewer/PopulateAppClassBySessionId",
        data: { PostedData: (JsonArg) },
        success: function (data) {
            debugger
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + ' - ' + data[i].Code + '[ ' + data[i].StudyLevel + ' ( ' + data[i].StudyGroup + ' ) ]' + '</option>';
            }
            $("#DropDownListClass").html(s);
        },
    });
}
function Picker_DataTable() {
    var JsonArg = {
        SessionId: $('#DropDownListSession :selected').val(),
        ChallanMethodId: $('#DropDownListChallanMethod :selected').val(),
        ClassId: $('#DropDownListClass :selected').val(),
    };

    // Assuming BasePath is defined and holds the base URL of your application

    Table = $('#TableFeeInformation').DataTable({
        "responsive": true,
        "ordering": true,
        "searching": true,
        "bPaginate": true,
        "ajax": {
            "url": BasePath + "/AAccounts/AccListViewer/FeeStructureForClass",
            "type": "GET",
            "data": function (d) {
                return $.extend({}, d, JsonArg);
            }
        },
        "columns": [
            { "data": null, "title": "#" }, 
            { "data": "CCode", "title": "Code" }, 
            { "data": "CClassName", "title": "Class" }, 
            {
                "data": null,"title": "Start Date","defaultContent": "",
                "render": function (data, type, full, meta) {
                    return ParseData(full.SessionStartOn);
                }
            },
            {
                "data": null,"title": "Start Date","defaultContent": "",
                "render": function (data, type, full, meta) {
                    return ParseData(full.SessionEndOn);
                }
            },
            {
                "data": null, "title": "Start Date", "defaultContent": "",
                "render": function (data, type, full, meta) {
                    return GetDecimalValue(full.FSTotalAmount);
                }
            },
            {
                "data": null, "title": "Start Date", "defaultContent": "",
                "render": function (data, type, full, meta) {
                    return GetViewbtn("PrintReport('" + data["Id"] + "')", "Fee Report", "View");

                }
            },
        ],
        "columnDefs": [
            // Add any column definitions, like visibility or custom renderers, here
        ],
        "order": [[0, 'desc']]
    });
    Table.on('order.dt search.dt', function () {
        Table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();/*for serial No*/
}
function ChangeCase() {
    $('#DropDownListSession').change(function (event) {
        event.preventDefault();
        PopulateAppClassBySessionId();
    });
    $('#DropDownListClass').change(function (event) {
        event.preventDefault();
        Picker_DataTable();
    });
}
$(document).ready(function (event) {
    PopulateAppSessions();
    PopulateChallanMethods();
    ChangeCase();
});



function PrintReport(Id) {
    $.ajax({
        type: "POST",
        url: BasePath + "/AReports/FeeViewer/Rp_FeeStructureByClassId?Id=" + Id,
        xhrFields: { responseType: 'blob' },
        beforeSend: function () {
            startLoading();
        },
        success: function (response, status, xhr) {
            OpenReport(response, status, xhr);
        },
        complete: function () {
            stopLoading();
        },
        error: function (jqXHR, error, errorThrown) {
            errors(jqXHR, error, errorThrown);
            stopLoading();
        }
    });
}
