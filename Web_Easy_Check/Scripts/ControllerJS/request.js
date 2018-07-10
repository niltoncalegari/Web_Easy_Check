function GetPonto() {
    debugger
    var de = $('#from').val();
    var partsDe = de.split('-');
    var dmyDateDe = partsDe[2] + '-' + partsDe[1] + '-' + partsDe[0];

    var ate = $('#to').val();
    var dmyDateAte = '';
    if (ate != '') {
        var partsAte = de.split('-');
        dmyDateAte = partsAte[2] + '-' + partsAte[1] + '-' + partsAte[0];
    }

    if (ate == '') {
        dmyDateAte = dmyDateDe;
    }

    var url = window.URL_POST_PONTO;
    if (de == '') {
        alert("Por favor preencha as datas para fazer o request do espelho ponto")
        return;
    }

    var params = JSON.stringify({
        "DataInicial": dmyDateDe,
        "DataFinal": dmyDateAte
    });

    $.ajax({
        url: url,
        data: params,
        type: 'POST',
        async: 'false',
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            alert(JSON.stringify(response.result));
        },
        failure: function (response) {
            alert('falhou')
        },

        error: function (response) {
            alert('Error')
        }
    });
}

function GetFolha() {
    debugger
    var mes = $('#gMes').find(":selected").val();    
    var ano = $('#gAno').find(":selected").val();
    var tipo = $('#gTipo').find(":selected").val();

    if (mes == '' || ano == '' || tipo == '') {
        alert("Por favor preencha os valores para o request de contracheque")
        return;
    }
    var url = window.URL_POST_FOLHA;

    var params = JSON.stringify({
        "MesPeriodo": mes,
        "AnoPeriodo": ano,
        "Tipo": tipo
    });

    $.ajax({
        url: url,
        data: params,
        type: 'POST',
        async: 'false',
        cache: 'false',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            alert(JSON.stringify(response.result));
        },
        failure: function (response) {
            alert('falhou')
        },

        error: function (response) {
            alert('Error')
        }
    });
}

function GetImg() {

    var img = 'data:image/gif;base64,' + IMG;
    return img;
}




$(function () {
    var dateFormat = "dd/mm/yyyy",
        from = $("#from")
            .datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 3
            })
            .on("change", function () {
                to.datepicker("option", "minDate", getDate(this));
            }),
        to = $("#to").datepicker({
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 3
        })
            .on("change", function () {
                from.datepicker("option", "maxDate", getDate(this));
            });
    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }
});