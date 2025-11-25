### Estrutura Database

``` SQL
CREATE DATABASE dataschool;
USE dataschool;

-- Table structure for table `professor`

CREATE TABLE IF NOT EXISTS `professor` (
  `codprofessor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) NOT NULL,
  `cpf` varchar(16) NOT NULL,
  `sexo` char(1) NOT NULL,
  `titulacao` varchar(50) NOT NULL,
  `area` varchar(50) NOT NULL,
  PRIMARY KEY (`codprofessor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Table structure for table `Aluno`

CREATE TABLE Aluno (
    CodAluno INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Cpf VARCHAR(16) UNIQUE,
    Sexo CHAR(1),
    Idade INT
);

```

### Estrutura do Projeto

Essas estruturas representam as camadas lógicas de uma aplicação, ajudando a separar responsabilidades e a organizar o código.

# Resumo das Camadas e Estruturas

`1. DAL (Data Access Layer) - Camada de Acesso a Dados`
O que é: É a camada responsável pela comunicação direta com o banco de dados ou qualquer outra fonte de dados (arquivos, serviços externos, etc.).

Responsabilidade: Realizar as operações CRUD (Create, Read, Update, Delete) dos dados.

Exemplo: Contém métodos que executam consultas SQL, chamam Stored Procedures ou usam um ORM (como Entity Framework) para buscar, inserir ou atualizar informações no DB.

Foco: Persistência de Dados.

`2. POJO (Plain Old Java Object) / DTO (Data Transfer Object) / Model`
O que é: No C#, o termo mais comum é DTO (Data Transfer Object) ou simplesmente Model (dependendo da arquitetura), mas o conceito é similar ao POJO. São classes simples que representam a estrutura dos dados.

Responsabilidade: Apenas transportar dados entre as diferentes camadas. Elas contêm apenas propriedades (com getters e setters) e não devem conter lógica de negócios.

Exemplo: Uma classe Produto com propriedades como Id, Nome e Preco.

Foco: Estrutura e Transporte de Dados.

`3. BLL (Business Logic Layer) - Camada de Lógica de Negócios`
O que é: É o coração da aplicação, onde reside toda a lógica de negócios e as regras específicas do sistema.

Responsabilidade: Processar os dados, aplicar regras de validação, realizar cálculos e garantir que as operações estejam de acordo com as necessidades da empresa. Esta camada usa a DAL para obter ou salvar dados.

Exemplo: Um método que calcula o preço final de um produto, aplicando impostos e descontos, antes de pedir à DAL para salvar a transação.

Foco: Regras e Validações de Negócios.

`4. View (Apresentação / Interface do Usuário)`
O que é: É a camada de apresentação ou interface do usuário (UI - User Interface).

Responsabilidade: Exibir as informações para o usuário e capturar suas interações (cliques, preenchimento de formulários). Esta camada usa a BLL para solicitar dados ou operações.

Exemplo: Em C#, pode ser uma página ASP.NET Core Razor, uma tela Windows Forms/WPF, ou um componente Blazor.

Foco: Interação e Experiência do Usuário.
