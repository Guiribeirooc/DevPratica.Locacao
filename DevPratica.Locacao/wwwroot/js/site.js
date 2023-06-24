$(document).ready(function () {
    $('.maskCPF').inputmask({ mask: ['999.999.999-99'] });
    $('.maskCNPJ').inputmask({ mask: ['99.999.999/9999-99'] });

    $('.maskPlaca').inputmask({ mask: ['AAA9*99'] });

    $('.maskDataHora').inputmask({ mask: ['99/99/9999 99:99'] });
    $('.maskData').inputmask({ mask: ['99/99/9999'] });
    $('.maskHora').inputmask({ mask: ['99:99'] });
    $('.maskCep').inputmask({ mask: ['99999-999'] });
    $('.maskTelefoneCelular').inputmask({
        mask: ["(99) 9999-9999", "(99) 99999-9999",],
        keepStatic: true
    });
    $('.maskTelefone').inputmask({ mask: ['(99) 9999-9999'] });
    $('.maskCelular').inputmask({ mask: ['(99) 99999-9999'] });
    $('.moedaReal').inputmask('decimal', {
        radixPoint: ",",
        groupSeparator: ".",
        autoGroup: true,
        digits: 2,
        digitsOptional: false,
        placeholder: '0',
        rightAlign: false,
        onBeforeMask: function (value, opts) {
            return value;
        }
    });
});

$(function () {
    var displayMessage = function (message, msgType) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicate": false,
            "onclick": null,
            "showDuration": "500",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",
        };
        toastr[msgType](message);
    };

    if ($('#success').val())
        displayMessage($('#success').val(), 'success');
    if ($('#info').val())
        displayMessage($('#info').val(), 'info');
    if ($('#warning').val())
        displayMessage($('#warning').val(), 'warning');
    if ($('#error').val())
        displayMessage($('#error').val(), 'error');
});