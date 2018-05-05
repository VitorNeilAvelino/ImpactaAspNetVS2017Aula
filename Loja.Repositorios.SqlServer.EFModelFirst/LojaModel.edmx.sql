
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2018 13:50:21
-- Generated from EDMX file: C:\Users\vavelino\source\repos\ImpactaAspNetVS2017\Loja.Repositorios.SqlServer.EFModelFirst\LojaModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LojaModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL,
    [Preco] decimal(9,2)  NOT NULL,
    [Categoria_Id] int  NOT NULL
);
GO

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ProdutoImagem'
CREATE TABLE [dbo].[ProdutoImagem] (
    [Produto_Id] int  NOT NULL,
    [Imagem] varbinary(max)  NOT NULL
);
GO

-- Creating table 'FornecedoresCategorias'
CREATE TABLE [dbo].[FornecedoresCategorias] (
    [Fornecedores_Id] int  NOT NULL,
    [Categorias_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [PK_Produto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categoria'
ALTER TABLE [dbo].[Categoria]
ADD CONSTRAINT [PK_Categoria]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Produto_Id] in table 'ProdutoImagem'
ALTER TABLE [dbo].[ProdutoImagem]
ADD CONSTRAINT [PK_ProdutoImagem]
    PRIMARY KEY CLUSTERED ([Produto_Id] ASC);
GO

-- Creating primary key on [Fornecedores_Id], [Categorias_Id] in table 'FornecedoresCategorias'
ALTER TABLE [dbo].[FornecedoresCategorias]
ADD CONSTRAINT [PK_FornecedoresCategorias]
    PRIMARY KEY CLUSTERED ([Fornecedores_Id], [Categorias_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_CategoriasProdutos]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriasProdutos'
CREATE INDEX [IX_FK_CategoriasProdutos]
ON [dbo].[Produto]
    ([Categoria_Id]);
GO

-- Creating foreign key on [Fornecedores_Id] in table 'FornecedoresCategorias'
ALTER TABLE [dbo].[FornecedoresCategorias]
ADD CONSTRAINT [FK_FornecedoresCategorias_Fornecedores]
    FOREIGN KEY ([Fornecedores_Id])
    REFERENCES [dbo].[Fornecedor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categorias_Id] in table 'FornecedoresCategorias'
ALTER TABLE [dbo].[FornecedoresCategorias]
ADD CONSTRAINT [FK_FornecedoresCategorias_Categorias]
    FOREIGN KEY ([Categorias_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornecedoresCategorias_Categorias'
CREATE INDEX [IX_FK_FornecedoresCategorias_Categorias]
ON [dbo].[FornecedoresCategorias]
    ([Categorias_Id]);
GO

-- Creating foreign key on [Produto_Id] in table 'ProdutoImagem'
ALTER TABLE [dbo].[ProdutoImagem]
ADD CONSTRAINT [FK_ProdutosProdutoImagem]
    FOREIGN KEY ([Produto_Id])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------