function logar() {
    debugger;
    var user = $('.usuario').val();
    var pass = $('.senha').val();
    var _url = window.URL_ACESSO_LOGIN;

    if ((user == null) || (user == "")) {
        alert("Usuario Vazio");
        return;

    } else if ((pass == null) || ((pass == ""))) {
        alert("Senha Vazia");
        return;
    }

    var params = JSON.stringify({
        'Usuario': user,
        'Senha': pass
    });

    if ((params == null)) {
        alert("Erro de requisição");
        return;
    }

    $.ajax({
        url: _url,
        data: params,
        type: "POST",
        async: "false",
        cache: "false",
        contentType: "application/json",
        success: function (response) {

            if (response.statusExecution) {
                alert("Logado com Sucesso");

            } else {
                $('.usuario').val("");
                $('.senha').val("");
            }

        },
        failure: function (response) {
            alert("Ih falhou");
        },

        error: function (response) {
            alert("Ops Error 404");
        }
    });
}