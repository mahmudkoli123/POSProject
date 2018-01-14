



$('#departmentId').change(function () {

    var selectId = $(this).val();
    var objData = { id: selectId }

    $.ajax({
        
        type: "POST",
        
        url: rootDirectory + "AjaxJson/GetGroups",

        contentType: "application/json; charset=utf-8",

        data: JSON.stringify(objData),

        dataType: "json",

        success: function (rData) {

            if (rData != undefined && rData != "") {
                $('#groupId').empty();
                $('#groupId').append("<option>---Select---</option>");
                $.each(rData, function (k, v) {

                    $('#groupId').append("<option Value = " + v.Id + ">" + v.Name + "</option>");
                });
            }
            else
            {
                $('#groupId').empty();
                $('#groupId').append("<option>---Select---</option>");
            }
        }

    });


});

$('#groupId').change(function () {

    var selectId = $(this).val();
    var objData = { id: selectId }
    var url = rootDirectory + "AjaxJson/GetStudents";

    $.post(url, objData, function (rData) {

        if (rData != undefined && rData != "") {
            $('#studentId').empty();
            $('#studentId').append("<option>---Select---</option>");
            $.each(rData, function (k, v) {

                $('#studentId').append("<option Value = " + v.Id + ">" + v.Name + "</option>");
            });
        }
        else {
            $('#studentId').empty();
            $('#studentId').append("<option>---Select---</option>");
        }
    });

});