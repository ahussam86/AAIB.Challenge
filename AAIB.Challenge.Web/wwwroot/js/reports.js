function blockHandler(e) {
    e.preventDefault();
    var id = $(this).data('id')
    console.log("BLOCKED: " + id);
    $.ajax({
        type: "PUT",
        url: "reports/block/" + id,
        data: { "ticketState": "BLOCKED" },
        success: function (data) {
            console.log(data);
            disableBlockButton(id);

        }
    });
}

function resolveHandler(e) {
    e.preventDefault();
    var id = $(this).data('id');
    console.log("RESOLVED: " + id);

    $.ajax({
        type: "PUT",
        url: "reports/" + id,
        data: { "ticketState": "CLOSED" },
        success: function (data) {
            console.log(data);
            removeTicket(id);

        }
    });
}

function disableBlockButton(id) {

    $(".block-button[data-id='" + id + "']").prop('disabled', true);
}

function removeTicket(id) {
    $(".ticket-item[data-id='" + id + "']").fadeOut(700, function () { $(this).remove(); });
}