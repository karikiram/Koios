// nisam radio novi .js file, pošto imam konkretno jedan modalni, pa nema potrebe

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })


    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        form.validate();
        if (!form.valid()) {

            return false;
        }
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
            window.location.reload();
        }).fail(function (request, message, error) {
            $('#nonUnique').html('Postojeći unos, unesite novi grad ili promijenite poštanski broj');
        })
        //}).fail(function (data) {
        //    jQuery.error = alert("Postojeći unos, unesite novi grad ili promijenite poštanski broj");
        //})
    })
})