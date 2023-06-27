function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('Logradrouro').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=preencherDadosEndereco';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            LimpaCamposEndereço();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        LimpaCamposEndereço();
    }
}

function preencherDadosEndereco(conteudo) {
    if (!("erro" in conteudo)) {
        document.getElementById('Logradrouro').value = (conteudo.logradouro);
        document.getElementById('Bairro').value = (conteudo.bairro);
        document.getElementById('Cidade').value = (conteudo.localidade);

        var selectEstado = document.querySelector('#Estado');
        for (var i = 0; i < selectEstado.options.length; i++) {
            if (selectEstado.options[i].text === conteudo.uf.toUpperCase()) {
                selectEstado.selectedIndex = i;
                break;
            }
        }
    }
    else {
        LimpaCamposEndereço();
        alert("CEP não encontrado")
    }
}

function limparCamposEndereco() {
    document.getElementById('Logradrouro').value = "...";
    document.getElementById('Numero').value = "...";
    document.getElementById('Complemento').value = "...";
    document.getElementById('Bairro').value = "...";
    document.getElementById('Cidade').value = "...";
    document.getElementById('Estado').value = "...";
}