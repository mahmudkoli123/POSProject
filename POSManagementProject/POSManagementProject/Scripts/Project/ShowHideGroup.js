
    $(document).ready(function() {

        $("input[name$='categoryRadio']:radio").click(function() {

            var catVal = $(this).val();

            if (catVal == "parent") {
                $("#parentGroup").hide();
            } else if (catVal == "child") {
                $("#parentGroup").show();
            }

        });

    });
