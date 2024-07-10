# Todo's

- Documentação da arquitetura Clear com .Net Core
- Verificar uso de Docker ou Serviços Linux
- Desenvolver o Welcome Kit do Projeto
- Organização dos Repositórios

## Done
  - Template de Projeto para Asp.Net Core Web Api para o projeto com dependências
---

[Documentação da Arquitetura Clean](/docs/Clean.md)

## <a name="Testing"></a> Testing
[xUnit Test with code coverage](https://medium.com/bluekiri/code-coverage-in-vsts-with-xunit-coverlet-and-reportgenerator-be2a64cd9c2f)
[Organizing xUnit Read from Write](http://www.brendanconnolly.net/organizing-tests-with-xunit-traits/)
[Using Theory](https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/)

```
$env:TEST_ENV = "memory" # memory or postgres
```

## Testando o Endpoint

# <a name="Postgree"></a> Postgree
http://www.postgresqltutorial.com/psql-commands/
https://medium.com/coding-blocks/creating-user-database-and-adding-access-on-postgresql-8bfcd2f4a91e

## <a name="Migration"></a> Migration
### Powershell
Criando a variavel de ambiente para habilitar a migração
e Adicionando uma migração
```
$env:SAP_INT_CONN = "Host=localhost;Database=postgres;Username=postgres;Password=postgres"
Add-Migration Initial -OutputDir PostgresDataAccess/Entities/Migrations -Context Context
```


## Enviroment Variables of Container

JSDN_URL:

| Env | Hosts |
| --- |:----- |
| Pre-Dev| |
| Dev | https://admin.jccloudplatform.com/api/v2.0  https://admin.jccloudplatform.com/api/1.0 |
| UAT | |
| Staging | |
| Production | |


## Hosts

| Env | Hosts |
| --- |:----- |
| Pre-Dev| 200.229.197.132 predev-admtelefonica.gcsb.com.br predev-portalvivocloud.com.br predev-enterprisevivo01.com.br |
| Dev | 18.233.91.209 superadmin.jamcracker.com admin.jccloudplatform.com store.sourcestore.com store1.jccloudplatform.com jcp.jccloudplatform.com store2.jccloudplatform.com store3.jccloudplatform.com www.jccloudplatform.com jcpapp.jccloudplatform.com
| UAT | 186.200.35.192 adminuat.nasnuvens.rnp.br telephonicaqareseller.nasnuvens.rnp.br www.telesourcetesttest.com www.telefojctest.com telefostore.telefojctest.com store.sourcestore.com superadmin.jamcracker.com admtelefonica.gcsb.com.br 186.200.35.192 uat-portalvivocloud.com.br uat-enterprisevivo01.com.br |
| Staging | |
| Production | |



# <a name="nginx"></a> Nginx Config on Startup:
O nginx injeta no proxy as configurações do host base as configurações a seguir são utilizadas para reescrita das urls do swagger para execuçao.

No Método Configure:
```
  app.UseSwagger(config => config.PostProcess = (document, request) =>
  {
      // Change document server settings to public
      document.Host = ExtractHost(request);
      document.BasePath = ExtractPath(request);
      document.Schemes.Clear();
  });

  app.UseSwaggerUi3(config =>
  config.TransformToExternalPath =
      (route, request) => ExtractPath(request) + route);
```
Métodos de Apoio:
```
  private string ExtractHost(HttpRequest request) =>
      request.Headers.ContainsKey("Host") ?
          new Uri($"{ExtractProto(request)}://{request.Headers["Host"].First()}").Host :
              request.Host.Value;

  private string ExtractProto(HttpRequest request) =>
      request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

  private string ExtractPath(HttpRequest request) =>
      request.Headers.ContainsKey("Origin") ?
          new Uri($"{request.Headers["Origin"].First()}").AbsolutePath :
          string.Empty;
```
