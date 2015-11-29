var ViewModel = function () {
    var self = this;
    self.produtos = ko.observableArray();
    self.produtoDetail = ko.observable();
    self.newProduto = {
        Nome: ko.observable(),
        Marca: ko.observable(),
        Estoque: ko.observable(),
        Preco: ko.observable(),
        Fornecedor: ko.observable()
    }
    self.fornecedors = ko.observableArray();
    self.fornecedorDetail = ko.observable();
    self.newFornecedor = {
        Nome: ko.observable(),
        CNPJ: ko.observable()
    }
    self.error = ko.observable();

    var produtosUri = '/api/produtos/';
    var fornecedorsUri = '/api/fornecedors/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllProdutos() {
        ajaxHelper(produtosUri, 'GET').done(function (data) {
            self.produtos(data);
        });
    }
    function getAllFornecedors() {
        ajaxHelper(fornecedorsUri, 'GET').done(function (data) {
            self.fornecedors(data);
        });
    }

    self.getProdutoDetail = function (item) {
        ajaxHelper(produtosUri + item.Id, 'GET').done(function (data) {
            self.produtoDetail(data);
        });
    }
    self.getFornecedorDetail = function (item) {
        ajaxHelper(fornecedorsUri + item.Id, 'GET').done(function (data) {
            self.fornecedorDetail(data);
        });
    }
    self.addProduto = function (formElement) {
        var produto = {
            Nome: self.newProduto.Nome(),
            Marca: self.newProduto.Marca(),
            Estoque: self.newProduto.Estoque(),
            Preco: self.newProduto.Preco(),
            FornecedorId: self.newProduto.Fornecedor().Id
        };

        ajaxHelper(produtosUri, 'POST', produto).done(function (item) {
            self.produtos.push(item);
        });
    }
    self.addFornecedor = function (formElement) {
        var fornecedor = {
            Nome: self.newFornecedor.Nome(),
            CNPJ: self.newFornecedor.CNPJ()
        };

        ajaxHelper(fornecedorsUri, 'POST', fornecedor).done(function (item) {
            self.fornecedors.push(item);
        });
    }

    // Fetch the initial data.
    getAllProdutos();
    getAllFornecedors();
};

ko.applyBindings(new ViewModel());