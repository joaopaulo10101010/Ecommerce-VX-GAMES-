const botaoboleto = document.getElementById("btboleto");
const botaopix = document.getElementById("btpix");
const botaocardcred = document.getElementById("btcartaocredito");
const botaocarddebt = document.getElementById("btcartaodebito");

botaoboleto.addEventListener('click', () => {
	document.getElementById("listadeformulario").innerHTML = `				
		<div class="divbotaoboleto pt-5">
			<label>Boleto: </label>
			<a download="boleto" class="btn btn-success botaoboleto" type="button" href="~/assets/files/boletofake.pdf">Baixe seu Boleto</a>
			<input type="hidden" name="formulario" value="boleto">
		</div>`;
});

botaocardcred.addEventListener('click', () => {
	document.getElementById("listadeformulario").innerHTML = `
		<label>Dados do Cartão de Credito:</label>
		<div class="backcartao credito">
			<div class="row">
				<div class="listaopc w-100">
					<label for="numerocartao">Numero do cartão:</label>
					<input required name="numerocartao" id="numerocartao" maxlength="16" minlength="16" class="w-100" type="text">
				</div>
			</div>
			<div class="row">
				<div class="listaopc w-50">
					<label for="datacartao">Data do vencimento:</label>
					<input required name="datacartao" type="month">
				</div>
				<div class="listaopc w-50">
					<label for="cvccartao">CVC</label>
					<input required name="cvccartao" maxlength="3" minlength="3" type="text">
				</div>
			</div>
			<input type="hidden" name="formulario" value="cartaocredito">
			<div class="row">
				<div class="listaopc">
					<label for="nomecartao">Nome do cartão:</label>
					<input required type="text" name="nomecartao">
					<img id="bande" class="bandeira" src="" />
				</div>
			</div>
		</div>`;

	// 🟢 MODIFICAÇÃO: adiciona o listener após o HTML ser inserido
	const inputCartao = document.getElementById("numerocartao");
	const logobandeira = document.getElementById("bande");

	inputCartao.addEventListener("input", () => {
		const numero = inputCartao.value.replace(/\D/g, '');
		const bandeira = detectarBandeira(numero);
		TrocarBandeira(bandeira, logobandeira); // 🟢 Passa o logobandeira
	});
});

botaocarddebt.addEventListener('click', () => {
	document.getElementById("listadeformulario").innerHTML = `				
		<label>Dados do Cartão de Debito:</label>
		<div class="backcartao debito">
			<div class="row">
				<div class="listaopc w-100">
					<label for="numerocartao">Numero do cartão:</label>
					<input required name="numerocartao" id="numerocartao" maxlength="16" minlength="16" class="w-100" type="text">
				</div>
			</div>
			<div class="row">
				<div class="listaopc w-50">
					<label for="datacartao">Data do vencimento:</label>
					<input required name="datacartao" type="month">
				</div>
				<div class="listaopc w-50">
					<label for="cvccartao">CVC</label>
					<input required name="cvccartao" maxlength="3" minlength="3" type="text">
				</div>
			</div>
			<input type="hidden" name="formulario" value="cartaodebito">
			<div class="row">
				<div class="listaopc">
					<label for="nomecartao">Nome do cartão:</label>
					<input required type="text" name="nomecartao">
					<img id="bande" class="bandeira" src="" />
				</div>
			</div>
		</div>`;

	// 🟢 MODIFICAÇÃO: adiciona o listener após o HTML ser inserido
	const inputCartao = document.getElementById("numerocartao");
	const logobandeira = document.getElementById("bande");

	inputCartao.addEventListener("input", () => {
		const numero = inputCartao.value.replace(/\D/g, '');
		const bandeira = detectarBandeira(numero);
		TrocarBandeira(bandeira, logobandeira); // 🟢 Passa o logobandeira
	});
});

botaopix.addEventListener('click', () => {
	document.getElementById("listadeformulario").innerHTML = `
		<label>Dados do PIX:</label>
		<img class="qrcode" src="/assets/image/qrcode.svg" />
		<input type="hidden" name="formulario" value="qrcode">`;
});

function TrocarBandeira(a, imgEl) { // 🟢 Adiciona parâmetro para o elemento img
	switch (a) {
		case "Visa":
			imgEl.src = "/assets/image/icones/visa.svg";
			break;
		case "MasterCard":
			imgEl.src = "/assets/image/icones/mastercard.svg";
			break;
		case "American Express":
			imgEl.src = "/assets/image/icones/americaexpress.svg";
			break;
		case "Diners Club / Hipercard":
			imgEl.src = "/assets/image/icones/icons8-diners-club.svg";
			break;
		case "Discover":
			imgEl.src = "/assets/image/icones/discovery.svg";
			break;
		case "Elo":
			imgEl.src = "/assets/image/icones/elologo.png";
			break;
		case "Hipercard":
			imgEl.src = "/assets/image/icones/hipercardlogo.png";
			break;
		default:
			imgEl.src = "/assets/image/icones/cartaoazu.png";
			break;
	}
}

function detectarBandeira(numero) {
	if (/^4[0-9]{5}/.test(numero)) return "Visa";
	if (/^5[1-5][0-9]{4}/.test(numero) || /^2(2[2-9]|[3-6][0-9]|7[01])[0-9]{3}/.test(numero)) return "MasterCard";
	if (/^3[47][0-9]{4}/.test(numero)) return "American Express";
	if (/^3(6|8)/.test(numero)) return "Diners Club / Hipercard";
	if (/^6011|65[0-9]{2}|64[4-9][0-9]/.test(numero)) return "Discover";
	if (/^5067|5090|6277|6363|6504/.test(numero)) return "Elo";
	if (/^606282|3841/.test(numero)) return "Hipercard";
	return "Bandeira desconhecida";
}


document.addEventListener("DOMContentLoaded", function () {
	const enderecos = document.querySelectorAll(".divendereco");
	const selecionadoDiv = document.getElementById("itemselecionado");

	enderecos.forEach(function (endereco) {
		endereco.addEventListener("click", function () {
			enderecos.forEach(e => e.classList.remove("selecionado"));
			this.classList.add("selecionado");
			const cep = this.getAttribute("data-cep");
			const numero = this.getAttribute("data-numero");
			selecionadoDiv.innerHTML = `
                <input type="hidden" name="cepSelecionado" value="${cep}" required/>
                <input type="hidden" name="numeroSelecionado" value="${numero}" required/>
            `;
		});
	});
});
