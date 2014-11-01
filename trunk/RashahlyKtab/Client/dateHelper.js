strToDate = function (strDate) {
    var dateParts = strDate.split(".");
    return new Date(dateParts[2], (dateParts[1] - 1), dateParts[0]);
};

addDays = function (originalDate, days) {    
    originalDate.setDate(originalDate.getDate() + days);
    return originalDate;
};