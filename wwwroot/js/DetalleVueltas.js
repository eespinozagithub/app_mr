    $(document).ready(function() {
        $("#ValorViaje").keyup(function() {
        var value = ($(this).val() * 10 / 100);
            $("#gananciaCdt").val(value);
    });
});
