$(document).ready(inicializar);

const pesquisarButton = $("#pesquisarButton");

function inicializar() {
    pesquisarButton.click(obterProdutoPorCategoria);
    $(document).on("click", "#closePopover", fecharPopover)
}

function obterProdutoPorCategoria() {
    alternarIconePesquisar();

    $.ajax({
        url: "/Produtos/Categoria",
        method: "get", // method ou type - get é o default
        data: { categoriaId: $("#CategoriaId").val() }
    })
        .done(function (response) { exibirPopover(response) }) // success
        .fail(function (response) { }) // error
        .always(function (response) { }); // complete
}

function exibirPopover(response) {
    pesquisarButton
        .popover("destroy")
        .popover({
            content: obterGridProdutos(response),
            html: true,
            animation: true,
            title: "Produtos desta categoria <span id='closePopover' class='close'>&times;</span>"
        })
        .popover("show");

    alternarIconePesquisar();
}

function obterGridProdutos(produtos) {
    var html = "<table class='table table-striped'>";

    html += "<tr><th>Produto</th><th>Preço</th><th>Estoque</th></tr>";

    $(produtos).each(
        function (i) {
            html += "<tr>";
            html += "<td>" + produtos[i].Nome + "</td>";
            html += "<td>" + produtos[i].Preco.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }) + "</td>";
            html += "<td>" + produtos[i].Estoque + "</td>";
            html += "</tr>";
        }
    );

    return html + "</table>";
}

function fecharPopover() {
    pesquisarButton.popover("destroy");
}

function alternarIconePesquisar() {
    pesquisarButton.find('span').toggleClass('glyphicon-search glyphicon-refresh glyphicon-spin');
}