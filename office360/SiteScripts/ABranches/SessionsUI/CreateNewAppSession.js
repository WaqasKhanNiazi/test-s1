var OpenClassIds;
$(document).ready(function () {
    PopulateDropDownLists();
    ChangeCase();
    InitDatePick();



});
function InitDatePick() {
    $('.date_masking').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
        orientation: "bottom"
    }).datepicker("setDate", 'now');
}
function PopulateDropDownLists() {
    PopulateCompanyList();
    PopulateEnrollmentTypes();
    PopulateAppClassList();
}
function PopulateAppClassList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/SessionsUI/PopulateAppClassList",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListSessionClasses").html(s);
        },
    });
}
function PopulateCompanyList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/SessionsUI/PopulateCompanyList",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].CompanyName + '' + '</option>';
            }
            $("#DropDownListCompanyName").html(s);
        },
    });
}
function PopulateEnrollmentTypes() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/SessionsUI/PopulateEnrollmentTypes",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListEnrollmentType").html(s);
        },
    });
}

function PopulateBranchListByCompanyId() {
    var CompanyId = $("#DropDownListCompanyName :selected").val();
    var JsonArg = {
        CompanyId: CompanyId,
    }
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/SessionsUI/PopulateBranchListByCompanyId",
        data: { 'PostedData': (JsonArg) },
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + ' ( ' + data[i].Code+ ' )'+'</option>';
            }
            $("#DropDownListCampusName").html(s);
        },
    });
}

function ChangeCase() {
    $('#DropDownListCompanyName').change(function () {
        PopulateBranchListByCompanyId();
    });
    $("#DropDownListSessionClasses").attr('data-width', '100%').select2({
        placeholder: 'Select an Option',
        multiple: true,
    }).change(function (event) {
        if (event.target == this) {
            OpenClassIds = $(this).val();
        }

    });
}
function ValidateInputFields() {
    debugger
    if ($('#DropDownListCompanyName').RequiredDropdown() == false) {
        return false;
    }
    if ($('#DropDownListCampusName').RequiredDropdown() == false) {
        return false;
    }
    if ($('#DropDownListEnrollmentType').RequiredDropdown() == false) {
        return false;
    }
    if ($('#TextBoxSessionDescription').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxSessionStartDate').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxSessionEndDate').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#DropDownListSessionClasses').RequiredDropdown() == false) {
        return false;
    }
    return true;
}
function ClearInputFields() {

    $('.form-control').val('');
    $('.select2').val('-1').change();
    $('form').removeClass('Is-Valid');
}
$('#ButtonSubmitDown').click(function (event) {
    event.preventDefault();
    var IsValid = ValidateInputFields();
    debugger
    if (IsValid) {
        try {
            InsertData();
        }
        catch (err) {
            GetMessageBox(err, 500);

        }
    }
});
function InsertData() {
    var Description = $('#TextBoxSessionDescription').val();
    var EnrollmentTypeId = $('#DropDownListEnrollmentType :selected').val();
    var SessionStartDate = $('#TextBoxSessionStartDate').val();
    var SessionEndDate = $('#TextBoxSessionEndDate').val();
    var JsonArg = {
        Description: Description,
        EnrollmentTypeId: EnrollmentTypeId,
        SessionStartDate: SessionStartDate,
        SessionEndDate: SessionEndDate,
        OpenClassIds: OpenClassIds.toString(),
    }
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/SessionsUI/Insert_AppSession",
        dataType: 'json',
        data: { 'PostedData': (JsonArg) },
        beforeSend: function () {
            debugger
            startLoading();
        },
        success: function (data) {
            GetMessageBox(data.Message, data.Code);
            ClearInputFields();
        },
        complete: function () {
            stopLoading();
        },
        error: function (jqXHR, error, errorThrown) {
            GetMessageBox("The Transaction Can Not Be Performed Due To Serve Activity", 500);

        },
    });
}

