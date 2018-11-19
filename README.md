# Cálculo de Imposto de Renda

Aplicação de teste desenvolvida para calcular o imposto de renda de pessoas físicas com base em regras pré-estabelecidas para quantidade de dependentes e faixa salarial de contribuintes.

## Tecnologias Utilizadas
### API
- ASP.NET Core 2.1;
- Entity Framework Core 2.1 (framework ORM para acesso a dados);
- AutoMapper (mapeamento de recursos da API para modelos de domínio);
- Swagger (documentação da API);
- Moq (mocks para testes unitários).

### Aplicação Cliente
- Angular 6;
- Bootstrap 4 (estilização das páginas);
- Ng-Bootstrap (compatibilidade do Bootstrap com Angular);
- Ngx-Toastr (notificações toast);
- cpf-mask-ng2 (validação de CPFs);
- Rxjs (utilização de observables);

### Como Testar

Primeiramente, faça o clone do repositório em uma pasta do computador:

```git clone https://github.com/evgomes/calculo-imposto-renda.git```

Será necessário abrir duas instâncias do terminal (caso esteja executando em Linux), ou prompt de comando do Windows (no caso do Windows), na pasta baixada para executar a aplicação. Com o primeiro terminal ou prompt aberto, execute os seguintes comandos:

```
cd src/API/IncomeTax.API.Client/
dotnet run
```

Esse primeiro comando irá rodar a API. No segundo terminal, execute os seguintes comandos:

```
cd src/Client/imposto-renda/
npm install
npm run start
```

O segundo comando iniciará a aplicação front-end feita em Angular. Acesse o endereço ```localhost:4200``` para iniciar a aplicação.

### Documentação da API

A API possui documentação gerada automaticamente pelo Swagger. Para acessar, com a API rodando, acesse o endereço ```https://localhost:5001/swagger```. Caso dê erro de certificado digital, adicione uma exceção ao navegador para visualizar o conteúdo.

### Melhorias Futuras
- Testes unitários de rotas da API e injeção de dependência;
- Testes do front-end;
- Utilização de cache na API para melhorar performance, principalmente na parte de cálculos;
- Paginação de dados de contribuintes.