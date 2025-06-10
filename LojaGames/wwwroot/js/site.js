
let todositenscarrinho = document.querySelectorAll("[data-quantidadeitem]");

for (let itens of todositenscarrinho) {
    executarQuantidade(itens.getAttribute("data-listacar"), "nenhuma")
}


function executarQuantidade(id, acao) {
     fetch('/ProcuraControler/Quantidade', {method: 'POST', headers: {'Content-Type': 'application/json','RequestVerificationToken': document.querySelector('[name="__RequestVerificationToken"]').value}, body: JSON.stringify({ id: id, acao: acao })
     })
        .then(controler => controler.json())
        .then(data => {
            if (data.quantidadefinal) {
                console.log(data.quantidadefinal);
                let itemcarrinho = document.querySelector(`[data-listacar="${id}"]`);
                itemcarrinho.innerHTML = data.quantidadefinal;
                itemcarrinho.setAttribute("data-quantidadeitem", data.quantidadefinal);
                let saidavalorcarrinho = document.querySelector(`[data-saidavaloritem="${id}"]`);
                let primeirovalor = parseFloat(saidavalorcarrinho.getAttribute("data-valoritem"));
                let segundovalor = parseFloat(data.quantidadefinal);
                let valortotal = primeirovalor * segundovalor;
                saidavalorcarrinho.innerHTML = valortotal.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

                AtualizarQuantidade();
            }
        })
}
function AtualizarQuantidade() {
    let itensquantidade = document.querySelectorAll("[data-quantidadeitem]");
    let brutofinal = 0;
    let quantidadefinal = 0;
    let descontofinal = 0;

    for (let item of itensquantidade) {
        let c = parseFloat(item.getAttribute("data-desconto"))
        let a = parseFloat(item.getAttribute("data-valoritemc"));
        console.log("a = " + a);
        let b = parseFloat(item.getAttribute("data-quantidadeitem"));
        console.log("a = " + b);
        quantidadefinal = quantidadefinal + (a * b);
        descontofinal = descontofinal + ((c - a) * b);
        brutofinal = brutofinal + c * b;


        console.log("a = " + quantidadefinal);
    }

    document.getElementById("saidavalortotal").innerHTML = quantidadefinal.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
    document.getElementById("saidadesconto").innerHTML = descontofinal.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
    document.getElementById("saidapresobruto").innerHTML = brutofinal.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
}