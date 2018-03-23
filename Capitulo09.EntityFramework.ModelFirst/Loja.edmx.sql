
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2018 18:36:00
-- Generated from EDMX file: C:\Users\Vitor Avelino\Source\Repos\ImpactaAspNetVS2017Aula\Capitulo09.EntityFramework.ModelFirst\Loja.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LojaModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoriaProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_CategoriaProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoFotoProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoFotoSet] DROP CONSTRAINT [FK_ProdutoFotoProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_FornecedorCategoria_Fornecedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FornecedorCategoria] DROP CONSTRAINT [FK_FornecedorCategoria_Fornecedor];
GO
IF OBJECT_ID(N'[dbo].[FK_FornecedorCategoria_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FornecedorCategoria] DROP CONSTRAINT [FK_FornecedorCategoria_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoFotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoFotoSet];
GO
IF OBJECT_ID(N'[dbo].[FornecedorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FornecedorSet];
GO
IF OBJECT_ID(N'[dbo].[FornecedorCategoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FornecedorCategoria];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Produto'
CREATE TABLE [dbo].[Produto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL,
    [Preco] decimal(18,0)  NOT NULL,
    [Categoria_Id] int  NOT NULL
);
GO

-- Creating table 'Categoria'
CREATE TABLE [dbo].[Categoria] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'ProdutoFoto'
CREATE TABLE [dbo].[ProdutoFoto] (
    [ProdutoId] int  NOT NULL,
    [Foto] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Fornecedor'
CREATE TABLE [dbo].[Fornecedor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'FornecedorCategoria'
CREATE TABLE [dbo].[FornecedorCategoria] (
    [Fornecedor_Id] int  NOT NULL,
    [Categoria_Id] int  NOT NULL
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

-- Creating primary key on [ProdutoId] in table 'ProdutoFoto'
ALTER TABLE [dbo].[ProdutoFoto]
ADD CONSTRAINT [PK_ProdutoFoto]
    PRIMARY KEY CLUSTERED ([ProdutoId] ASC);
GO

-- Creating primary key on [Id] in table 'Fornecedor'
ALTER TABLE [dbo].[Fornecedor]
ADD CONSTRAINT [PK_Fornecedor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Fornecedor_Id], [Categoria_Id] in table 'FornecedorCategoria'
ALTER TABLE [dbo].[FornecedorCategoria]
ADD CONSTRAINT [PK_FornecedorCategoria]
    PRIMARY KEY CLUSTERED ([Fornecedor_Id], [Categoria_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_Id] in table 'Produto'
ALTER TABLE [dbo].[Produto]
ADD CONSTRAINT [FK_CategoriaProduto]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaProduto'
CREATE INDEX [IX_FK_CategoriaProduto]
ON [dbo].[Produto]
    ([Categoria_Id]);
GO

-- Creating foreign key on [ProdutoId] in table 'ProdutoFoto'
ALTER TABLE [dbo].[ProdutoFoto]
ADD CONSTRAINT [FK_ProdutoFotoProduto]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[Produto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Fornecedor_Id] in table 'FornecedorCategoria'
ALTER TABLE [dbo].[FornecedorCategoria]
ADD CONSTRAINT [FK_FornecedorCategoria_Fornecedor]
    FOREIGN KEY ([Fornecedor_Id])
    REFERENCES [dbo].[Fornecedor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categoria_Id] in table 'FornecedorCategoria'
ALTER TABLE [dbo].[FornecedorCategoria]
ADD CONSTRAINT [FK_FornecedorCategoria_Categoria]
    FOREIGN KEY ([Categoria_Id])
    REFERENCES [dbo].[Categoria]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FornecedorCategoria_Categoria'
CREATE INDEX [IX_FK_FornecedorCategoria_Categoria]
ON [dbo].[FornecedorCategoria]
    ([Categoria_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------