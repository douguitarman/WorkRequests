/* General Purpose Modal */
function popGenModal(args) {

    let defaults = {
        target: null,
        url: null,
        size: null,
        heading: null,
        isPdf: false
    }

    // Extend the args with the defaults to create a settings array.
    let settings = $.extend({}, defaults, args);

    let _target = settings.target;
    let _url = settings.url;
    let _size = settings.size;
    let _heading = settings.heading;
    let _isPdf = settings.isPdf;

    let modalPdf = "<div class='modal-dialog modal-lg'><iframe src=" + _url + " style='min-height: 900px; width: 100%;'></iframe></div>";
    let _modal = "<div class='modal-dialog " + _size + "'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button><h4 class='modal-title'>" + _heading + "</h4></div><div class='modal-body'></div><div class='modal-footer'><button type='button' class='btn btn-default' data-dismiss='modal'>Close</button></div></div></div>";

    if (_isPdf) {
        $('body').append("<div class='modal fade' id='" + _target + "' tabindex='-1' role='dialog' aria-labelledby='" + _target + "Label' aria-hidden='true'>" + _modalPdf + "</div>");
    }
    else {
        $('body').append("<div class='modal fade' id='" + _target + "' tabindex='-1' role='dialog' aria-labelledby='" + _target + "Label' aria-hidden='true'>" + _modal + "</div>");
    }

    // Load url then show modal
    $('#' + _target + ' .modal-body').load(_url, function () {
        console.log('loaded');
        $('#' + _target).modal('show');
    });

    // Empty and remove modal
    $('#' + _target).on('hide.bs.modal', function () {
        $('#' + _target).empty().remove();
        $('body').removeClass('model-open');
        //_url = null;
    });
}


