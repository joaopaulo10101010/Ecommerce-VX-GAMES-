const input = document.getElementById('inputimage');
const imagemdeeditar = document.getElementById('imagemdeeditar');


input.addEventListener('change', () => { enviarImagem() })

async function enviarImagem() {
    const arquivo = input.files[0];

    const formData = new FormData();
    formData.append('imagemform', arquivo);

    if (arquivo) {

        const response = await fetch('/conta/imagem', {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            console.log("A controler recebeu a imagem para colocar no banco.");
            const mensagem = await response.text();
            imagemdeeditar.src = mensagem;
        } else {
            alert("A Controler não conseguiu proceguir");
        }
    }
}