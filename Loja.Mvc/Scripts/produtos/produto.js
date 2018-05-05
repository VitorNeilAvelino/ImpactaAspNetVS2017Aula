$(document).ready(inicializar);

var pesquisarButton = {};

function inicializar() {
    //var pesquisarButton = document.getElementById("pesquisarButton");
    //pesquisarButton.addEventListener("click", obterProdutoPorCategoria);

    pesquisarButton = $("#pesquisarButton");
    pesquisarButton.click(obterProdutoPorCategoria);

    //var lupas = $(".glyphicon glyphicon-search");
    //var botoes = $("button[type=button]")

    //var fecharPopoverButton = $("#fecharPopover");
    //fecharPopoverButton.click(fecharPopover);

    $(document).on("click", "#fecharPopover",
        function () { pesquisarButton.popover("destroy"); });
}

function obterProdutoPorCategoria() {
    const categoriaId = $("#CategoriaId").val();

    $.ajax({
        url: "/Produtos/Categoria",
        method: "GET",
        data: { categoriaId }
    }
    )
        .done(function (response) { exibirPopover(response); })
        .fail()
        .always();
}

function exibirPopover(response) {
    pesquisarButton
        .popover("destroy")
        .popover({
            content: montarGridProdutos(response),
            html: true,
            animation: true,
            title: "Produtos desta categoria <span class='close' id='fecharPopover'>&times;</span>"
        })
        .popover("show");
}

function montarGridProdutos(produtos) {
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