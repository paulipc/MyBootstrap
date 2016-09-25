/// <reference path="../typings/jquery/jquery.d.ts" />
var AssignTaloModel = (function () {
    function AssignTaloModel() {
    }
    return AssignTaloModel;
}());
function initTaloAssignment() {
    $("#AssignTaloButton").click(function () {
        var nykyLampo = $("#NykyLampo").val();
        var tavoiteLampo = $("#TavoiteLampo").val();
        alert("L: " + nykyLampo + ", A: " + tavoiteLampo);
        var data = new AssignTaloModel();
        data.NykyLampo = nykyLampo;
        data.TavoiteLampo = tavoiteLampo;
        // lähetetään JSON-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/Talo/AssignTalo",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {
                if (data.success == true) {
                    alert("Talo successfully assigned.");
                }
                else {
                    alert("There was an error: " + data.error);
                }
            },
            dataType: "json"
        });
    });
}
//# sourceMappingURL=Logic.js.map