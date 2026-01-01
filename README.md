# Web API Employees

## Visão Geral

Este projeto tem como objetivo demonstrar os **fundamentos de desenvolvimento de Web APIs com ASP.NET Core**, de forma simples, clara e didática.
---

## Objetivos Técnicos

* Criar uma Web API utilizando **ASP.NET Core**
* Implementar **CRUD completo** utilizando Controllers
* Trabalhar corretamente com **verbos HTTP**
* Retornar **status codes apropriados**
* Aplicar **validação de entrada** com DataAnnotations
* Documentar a API utilizando **Swagger**
* Utilizar **logging** básico

---

## Escopo do Projeto

### Incluído

* Controllers com rotas REST
* ViewModels e Requests separados
* Validação via `ModelState`
* Swagger com comentários XML
* Base de dados simulada em memória

---

## Estrutura do Projeto

```
WebApi
 ├── Controllers
 │   └── EmployeesController.cs
 ├── Extensions
 │   └── SwaggerConfigExtensions.cs
 ├── ViewModels
 │   ├── CreateEmployeeRequest.cs
 │   ├── EmployeeViewModel.cs
 │   └── UpdateEmployeeRequest
 └── Program.cs
```

---

## Endpoints Disponíveis

### GET /api/employees

Retorna a lista de colaboradores.

**Resposta:** `200 OK`

---

### GET /api/employees/{id}

Retorna um colaborador pelo Id.

* `200 OK`
* `404 Not Found`

---

### POST /api/employees

Cria um novo colaborador.

**Body:**

```json
{
  "name": "Ana"
}
```

* `201 Created`
* `400 Bad Request`

---

### PUT /api/employees/{id}

Atualiza um colaborador existente.

* `204 No Content`
* `404 Not Found`

---

### DELETE /api/employees/{id}

Remove um colaborador.

* `204 No Content`
* `404 Not Found`

---

## Validação

A validação de entrada é feita utilizando **DataAnnotations**, através do `ModelState`.

Exemplo:

```csharp
[Required]
public string Name { get; set; }
```

Essa abordagem é suficiente para este projeto e evita dependências externas.

---

## Swagger

O Swagger está configurado para:

* Expor todos os endpoints
* Exibir summaries via comentários XML

Isso facilita testes manuais e documentação da API.

---

## Logging

O projeto utiliza `ILogger<T>` para registrar ações importantes, como:

* Consulta de colaboradores
* Criação, atualização e remoção

Exemplo:

```csharp
_logger.LogInformation("Criando colaborador: {Name}", request.Name);
```
---




