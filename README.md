# Projeto de API com GraphQL em .NET 6

Este é um projeto de API desenvolvido em .NET 6 que simula um banco, permitindo o cadastro de usuários e contas bancárias, além de realizar operações como saque, depósito, edição da conta e verificação do saldo. O banco de dados utilizado é o MySQL.

## Pré-requisitos

- .NET 6 SDK instalado na máquina
- MySQL instalado na máquina
- Conexão com o banco de dados configurada no arquivo `appSettings.Development.json`

## Como executar o projeto

1. Clone o repositório para sua máquina local.
2. Abra o arquivo `appSettings.Development.json` e atualize a `connectionString` com os detalhes de conexão corretos para o seu banco de dados MySQL.
3. Abra o Visual Studio 2022.
4. No Visual Studio 2022, abra o projeto e aguarde a restauração das dependências.
5. Defina o projeto da API como o projeto de inicialização.
6. Execute o projeto pressionando o botão "Executar" (ou pressione F5) para iniciar o projeto.

Após executar o projeto, uma página do Banana Cake Pop será aberta no navegador. O Banana Cake Pop é uma ferramenta para executar consultas e mutações GraphQL.

**Observação**: Caso o banco de dados não exista em sua máquina, ele será criado automaticamente ao executar o projeto, juntamente com as tabelas necessárias. Algumas informações de exemplo serão inseridas no banco para fins de demonstração.

## Informações de exemplo

Ao executar o projeto pela primeira vez, algumas informações de exemplo serão inseridas no banco de dados para facilitar os testes. Essas informações são:

### Usuário

- ID: 11111111-1111-1111-1111-111111111111
- Nome: User
- Email: user@user.com

### Conta

- ID: 11111111-1111-1111-0000-000000000001
- ID do usuário: 11111111-1111-1111-1111-111111111111
- Número da conta: 54321
- Saldo: 1000.00
- Ativa: Sim

Você pode usar essas informações para testar as funcionalidades do projeto sem precisar cadastrar novos usuários ou contas.

## Executando os Testes

O projeto também inclui testes automatizados implementados com xUnit. Para executar os testes, siga as etapas abaixo:

- Abra o Visual Studio 2022.
- No Visual Studio 2022, abra a janela "Gerenciador de Testes" clicando em "Teste" no menu e selecionando "Gerenciador de Testes".
- No "Gerenciador de Testes", clique no botão "Executar" (ou pressione "Ctrl+R, T") para executar todos os testes.
Os resultados dos testes serão exibidos na janela "Gerenciador de Testes".

## Consultas e Mutações GraphQL

### Usuário

- Mutation para adicionar ou editar um usuário. Para adicionar, não passe o ID e informe apenas o nome e o email. Para editar, passe o ID juntamente com as demais informações:

```graphql
mutation upsertUser {
  upsertUser(request: {
    id: "11111111-1111-1111-1111-111111111111",
    name: "Nome do usuário",
    email: "email@example.com"
  }) {
    id
    name
    email
    errors {
      errorCode
      errorMessage
      propertyName
      severity
    }
  }
}
```

- Query para obter um usuário por ID:

```graphql
query getUser {
  user(request: {
    id: "11111111-1111-1111-1111-111111111111"
  }) {
    id
    name
    email
  }
}
```

- Query para obter todos os usuários:

```graphql
query getUsers {
  users {
    users {
      id
      name
      email
    }
  }
}
```

### Conta

- Mutation para adicionar ou editar uma conta. Para adicionar, não passe o ID e informe apenas o número da conta, o valor e o ID do usuário vinculado. Para editar, passe o ID da conta juntamente com as demais informações:

```graphql
mutation upsertAccount {
  upsertAccount(request: {
    id: "11111111-1111-1111-1111-111111111111",
    number: "54324",
    value: 95.00,
    userId: "11111111-1111-1111-1111-111111111111"
  }) {
    id
    number
    value
    userId
    errors {
      errorCode
      errorMessage
      propertyName
      severity
    }
  }
}
```

- Mutation para realizar um saque em uma conta:

```graphql
mutation withdraw {
  withdraw(number: "54321", value: 50) {
    number
    value
    errors {
      errorCode
      errorMessage
      propertyName
      severity
    }
  }  
}
```

- Mutation para realizar um depósito em uma conta:

```graphql
mutation deposit {
  deposit(number: "54321", value: 10) {
    number
    value
    errors {
      errorCode
      errorMessage
      propertyName
      severity
    }
  }
}
```

- Query para obter o saldo de uma conta:

```graphql
query getBalance {
  balance(number: "54321") {
    value
    errors {
      errorCode
      errorMessage
      propertyName
      severity
    }
  }
}
```

- Query para obter uma conta por ID:

```graphql
query getAccount {
  account(request: {
    id: "11111111-1111-1111-0000-000000000001"
  }) {
    id
    number
    value
    userName
    active
  }
}
```

- Query para obter todas as contas:

```graphql
query getAccounts {
  accounts {
    accounts {
      id
      number
      value
      userName
    }
  }
}
```

Certifique-se de substituir os valores dos campos de entrada (request) pelos dados relevantes ao executar as mutações e consultas.
