const inputcep = document.getElementById("inputcep");
const inputendereco = document.getElementById("inputendereco");
const inputnumero = document.getElementById("inputnumero");
const inputcomplemento = document.getElementById("inputcomplemento");
const inputbairro = document.getElementById("inputbairro");
const camposauxiliares = document.getElementById("camposauxiliares");

inputcep.addEventListener('input', async () => {
    if (inputcep.value.length == 8) {
        let resposta = await contatarAPICorreios(inputcep.value);
        if (resposta.logradouro != null && resposta.bairro != null) {
            inputendereco.value = resposta.logradouro;
            inputbairro.value = resposta.bairro;
        }
        camposauxiliares.innerHTML = `
        <input type="hidden" name="estado" value="${resposta.estado}">
        <input type="hidden" name="localidade" value="${resposta.localidade}">
        <input type="hidden" name="uf" value="${resposta.uf}">

        `;
    }
});

document.getElementById("form").addEventListener("click", () => {
    localStorage.setItem("scrollY", window.scrollY);
});

window.addEventListener("DOMContentLoaded", () => {
    const scrollY = localStorage.getItem("scrollY");
    if (scrollY !== null) {
        setTimeout(() => {
            window.scrollTo(0, parseInt(scrollY));
            localStorage.removeItem("scrollY");
        }, 100); 
    }
});



async function contatarAPICorreios(cep) {
    try {
        const API = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
        const data = await API.json();
        const retorno = {
            bairro: data.bairro,
            cep: data.cep,
            complemento: data.complemento,
            ddd: data.ddd,
            estado: data.estado,
            gia: data.gia,
            ibge: data.ibge,
            localidade: data.localidade,
            logradouro: data.logradouro,
            regiao: data.regiao,
            siafi: data.siafi,
            uf: data.uf,
            unidade: data.unidade
        }
        console.log(retorno);
        return retorno;
    } catch (erro) {
        console.error("Nao foi possivel fazer contato com a API: ", erro);
        return null;
    }
    
}