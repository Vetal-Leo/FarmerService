
function convertToName(months) {
    var result = [];
    $.each(months, function (index, value) {
        if (value === 1) result.push(" Январь");
        if (value === 2) result.push(" Февраль");
        if (value === 3) result.push(" Март");
        if (value === 4) result.push(" Апрель");
        if (value === 5) result.push(" Май");
        if (value === 6) result.push(" Июнь");
        if (value === 7) result.push(" Июль");
        if (value === 8) result.push(" Август");
        if (value === 9) result.push(" Сентябрь");
        if (value === 10) result.push(" Октябрь");
        if (value === 11) result.push(" Ноябрь");
        if (value === 12) result.push(" Декабрь");
    });
    return result;
}



//Validation for fruit plants.
var options;
$("#fruitpost").click(function () {
   
    //Determination of the date of planting and flowering
    var plants;
    var flowers;
    $.ajax({
        method: "POST",
        url: "/api/PlantingDatesApi/IsPlantCultureForFruit?id=1&culturetype=" + $("#dropdownlist").val() +
            "&landingdate=" + $("#landingdate").val() + "&floweringdate=" + $("#floweringdate").val()
    }).
        success(function (data) {
            if (data["Rez"] === 0) {
                $("#fruitsend").attr("type", "submit");
                $("#fruitsend").hide();
                $("#fruitsend").click();
                return;
            }
            if (data["Rez"] === 1) {
                plants = convertToName(data["Plants"]);
                $("#incorrectdate1").modal(options);
                $("#plantmonth").text(plants);
                return;
            }
            if (data["Rez"] === 2) {
                flowers = convertToName(data["Flowers"]);
                $("#incorrectdate2").modal(options);
                $("#flowermonth").text(flowers);
                return;
            }
            if (data["Rez"] === 3) {
                plants = convertToName(data["Plants"]);
                flowers = convertToName(data["Flowers"]);
                $("#incorrectdate3").modal(options);
                $("#plant").text(plants);
                $("#flower").text(flowers);
                return;
            }
            if (data["Rez"] === 4) {
                $("#error").modal(options);
                return;
            }
        }); 
});


$("#yes1").click(function () {
    $("#fruitsend").attr("type", "submit");
    $("#fruitsend").hide();
    $("#fruitsend").click();
});
$("#yes2").click(function () {
    $("#fruitsend").attr("type", "submit");
    $("#fruitsend").hide();
    $("#fruitsend").click();
});
$("#yes3").click(function () {
    $("#fruitsend").attr("type", "submit");
    $("#fruitsend").hide();
    $("#fruitsend").click();
});

//Validation for field plants.
//TODO




options = {
    "backdrop": "static"
};

