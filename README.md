# PortfolioManagementSystem

Para que seja possível executar esta aplicação, basta alterar o AppSetting configurando um banco de dados sql server local e um banco de dados NoSql MongoDb. Após isso, executar o comando: dotnet ef database update -s ./PortfolioManagementSystem  -p ./Infraestructure. Com a execução deste comando as tabelas do banco de dados devem ser criadas.

# Arquitetura
Para os processos assincronos esta aplicação está utilizando o HangFire, o que significa que na primeira execução as primeiras tabelas devem ser criadas. Caso queira forçar a execução de um job, ou ver os logs recentes, basta adicionar "/hangfire" na sua porta localhost.

A aplicação está utilziando .net 8, EntityFramework, FluentValidation, Bando de dados relacional SQL server e não relacional MongoDb.



# Como Utilizar

Para a utilização, basta utilziar as APIs de criação de usuário para inserir os usuários no bando de dados, e posteriormente utilizar as outras APIs para cadastro de produto, compra e venda de produtos. Os usuários criados com perfil de "Customer", automaticamente possuem carteiras criadas e associadas a eles.
