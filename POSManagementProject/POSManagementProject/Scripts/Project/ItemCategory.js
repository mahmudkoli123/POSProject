

var ItemCategoryDetails = function (id) {

    $.ajax({
        type: "POST",
        url: "/ItemCategory/Details",
        data: { id: id },
        success: function(response) {

            $("#detailsModalContent").html(response);

            $("#detailsModal").modal("show");

        }

    });
}

var ConfirmDeleteItemCategory = function (id,sl) {
    $("#confirmDeleteModal").modal("show");
    $("#hiddenItemCategoryId").val(id);
    $("#hiddenItemCategorySl").val(sl);
}


var DeleteItemCategory = function () {

    var id = $("#hiddenItemCategoryId").val();
    var sl = $("#hiddenItemCategorySl").val();

    $.ajax({
        type: "POST",
        url: "/ItemCategory/Delete",
        data: { id: id },
        success: function(result) {

            $("#confirmDeleteModal").modal("hide");
            $("#row_" + sl).remove();
            $.notify("Item Category Deleted", "error");
            
            window.location.reload(true);
        }

    });

}