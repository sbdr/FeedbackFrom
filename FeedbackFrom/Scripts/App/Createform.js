$(document).ready(function () {
    var currentDate = new Date();
    $("#StartDate").datepicker("setDate", currentDate);
    $("#EndDate").datepicker("setDate", currentDate);
    $("#StartDate").datepicker("minDate", currentDate);
    $("#EndDate").datepicker("minDate", currentDate);
})