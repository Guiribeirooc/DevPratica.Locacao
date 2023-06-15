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