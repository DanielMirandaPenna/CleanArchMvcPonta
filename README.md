# CleanArchMvcPonta
1. **Instalar o Git:**
   - Se o Git ainda não estiver instalado, você pode baixá-lo e instalá-lo a partir do site oficial: [Git - Downloads](https://git-scm.com/downloads).

2. **Instalar o .NET 8 SDK:**
   - Baixe e instale o .NET 8 SDK a partir do site oficial da Microsoft: [.NET Downloads](https://dotnet.microsoft.com/download).

3. **Instalar o PostgreSQL:**
   - Baixe e instale o PostgreSQL a partir do site oficial: [PostgreSQL Downloads](https://www.postgresql.org/download).
   - Durante a instalação, certifique-se de lembrar a senha que você definiu para o cusuário 'postgres'.

4. **Criar o Usuário PostgreSQL:**
   - Abra o pgAdmin ou o Prompt de Comando do PostgreSQL.
   - Conecte-se ao seu servidor PostgreSQL usando as credenciais de administrador.
   - No pgAdmin, navegue até "Login/Grupos de Papéis" ou uma seção similar.
   - Crie um novo usuário com o nome `postgres` e atribua a senha 'postgres'.
   - Certifique-se de que esse usuário tenha permissões adequadas para acessar e modificar o banco de dados usado pela aplicação.
   - Caso não queria criar um novo usuário apenas informe o usuário existente no passo 6

5. **Clonar o Repositório do Projeto:**
   - Abra o terminal ou Prompt de Comando.
   - Navegue até o diretório onde deseja clonar o repositório.
   - Execute o seguinte comando para clonar o repositório do projeto:
   - git clone https://github.com/DanielMirandaPenna/CleanArchMvcPonta.git

6. **Configurar a Conexão com o Banco de Dados:**
   - Abra o projeto em seu editor de código.
   - Encontre o arquivo de configuração de conexão com o banco de dados 'appsettings.json'.
   - Atualize a ConnectionStrings incluindo o nome do banco de dados, o nome de usuário e a senha corretos.

7. **Documentação Swagger:**
   - Após configurar a string de conexão com o banco de dados, execute o projeto para visualizar a documentação Swagger.
   - A aplicação utiliza segurança JWT, o que significa que você precisará criar um usuário no endpoint `CreateUser` e, em seguida, fazer login no endpoint `LoginUser`.
   - A força de segurança da senha do usuário foi reduzida temporariamente para facilitar os testes.
   - Após fazer login, obtenha o token de autenticação. Em seguida, clique em "Authorize" na documentação Swagger e insira "Bearer" seguido pelo token (Bearer xxxxxxxx) para autenticar suas solicitações.

8. **Segurança:**
   - O sistema possui medidas de prevenção contra ataques de força bruta.
   - Também conta com prevenção contra ataques de injeção SQL devido ao uso de querys e LINQ ao acessar o banco de dados, tornando os ataques mais difíceis de serem realizados.
