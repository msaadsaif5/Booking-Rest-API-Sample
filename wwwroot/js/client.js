$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        $.ajax(
            {
                url: "api/booking",
                contentType: "application/json",
                method: "POST",
                data: JSON.stringify({ clientName: this.elements["ClientName"].value, location: this.elements["Location"].value }),
                success: function (data) { addTableRow(data); }
            })
    });
});

var addTableRow = function (booking) {
    $("table tbody").append("<tr><td>" + booking.bookingId + "</td><td>" +  booking.clientName + "</td><td>" + booking.location + "</td><td>" + booking.bookedOn + "</td></tr>");
}
