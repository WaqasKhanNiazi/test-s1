$(document).ready(function () {
    debugger
    PopulateDropDownLists();
    ChangeCase();
});



//----------------------------ALL DROP DOWNS
function ValidateInputFields() {
    if ($('#DropDownListCompanyName').RequiredDropdown() == false) {
        return false;
    }
    if ($('#TextBoxDescription').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#DropDownListCampusType').RequiredDropdown() == false) {
        return false;
    }
    if ($('#DropDownListCountry').RequiredDropdown() == false) {
        return false;
    }
    if ($('#DropDownListCity').RequiredDropdown() == false) {
        return false;
    }
    if ($('#TextBoxAddress').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxContactNo').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxEmailAddress').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxNTNNo').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    if ($('#TextBoxRemarks').RequiredTextBoxInputGroup() == false) {
        return false;
    }
    return true;
}
function ChangeCase() {
    $('#DropDownListCountry').change(function () {
        PopulateCityListByCountryId();
    });
}
function PopulateCompanyList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/BranchUI/PopulateCompanyList",
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
function PopulateCountryList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/BranchUI/PopulateCountryList",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListCountry").html(s);
        },
    });
}
function PopulateCityListByCountryId() {
    var CountryId = $("#DropDownListCountry :selected").val();
    var JsonArg = {
        CountryId: CountryId,
    }
    $.ajax({

        type: "POST",
        url: BasePath + "/ABranches/BranchUI/PopulateCityListByCountryId",
        data: { 'PostedData': (JsonArg) },
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListCity").html(s);
        },
    });

}
function PopulateCampusTypesList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/BranchUI/PopulateCampusTypesList",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListCampusType").html(s);
        },
    });
}
function PopulateOrganizationTypesList() {
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/BranchUI/PopulateOrganizationTypesList",
        data: "{}",
        success: function (data) {
            var s = '<option  value="-1">Select an option</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<center><option  value="' + data[i].Id + '">' + data[i].Description + '' + '</option>';
            }
            $("#DropDownListOrganizationType").html(s);

        },

    });
}
function PopulateDropDownLists() {
    PopulateCompanyList();
    PopulateCampusTypesList();
    PopulateCountryList();
    PopulateOrganizationTypesList();
}
//----------------------------INSERT INTO DATABASE
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
function InsertData() {
    var CompanyId = $('#DropDownListCompanyName :selected').val();
    var Description = $('#TextBoxDescription').val();
    var CampusTypeId = $('#DropDownListCampusType :selected').val();
    var OrganizationTypeId = $('#DropDownListOrganizationType :selected').val();
    var CountryId = $('#DropDownListCountry :selected').val();
    var CityId = $('#DropDownListCity :selected').val();
    var Address = $('#TextBoxAddress').val();
    var ContactNo = $('#TextBoxContactNo').val();
    var EmailAddress = $('#TextBoxEmailAddress').val();
    var NTNNo = $('#TextBoxNTNNo').val();
    var Remarks = $('#TextBoxRemarks').val();

    var JsonArg = {
        CompanyId: CompanyId,
        Description: Description,
        CampusTypeId: CampusTypeId,
        OrganizationTypeId: OrganizationTypeId,
        CountryId: CountryId,
        CityId: CityId,
        Address: Address,
        ContactNo: ContactNo,
        EmailAddress: EmailAddress,
        NTNNo: NTNNo,
        Remarks: Remarks,
    }
    $.ajax({
        type: "POST",
        url: BasePath + "/ABranches/BranchUI/Insert_GeneralBranches",
        dataType: 'json',
        data: { 'PostedData': (JsonArg) },
        beforeSend: function () {
            startLoading();
        },
        success: function (data) {
            debugger
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

function ClearInputFields() {

    $('.form-control').val('');
    $('.select2').val('-1').change();
    $('form').removeClass('Is-Valid');
}