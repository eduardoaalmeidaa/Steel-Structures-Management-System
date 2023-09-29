# Sistema de Gestão de Estruturas Metálicas
Este é um sistema de gerenciamento desenvolvido em C# e SQL Server que permite a uma empresa de estruturas metálicas gerenciar informações sobre clientes, serviços e ferramentas. Ele segue a arquitetura MVC (Model-View-Controller) para facilitar o desenvolvimento e a manutenção.

## Pré-requisitos
Antes de executar o aplicativo, certifique-se de que você tenha os seguintes pré-requisitos instalados:

- Visual Studio
- SQL Server
- .NET Framework 

## Configuração do Banco de Dados
### Abra o SQL Server Management Studio.
Execute o script SQL database.sql fornecido neste projeto para criar o banco de dados e as tabelas necessárias.
Atualize a string de conexão no arquivo Web.config do projeto para refletir as configurações do seu servidor SQL:
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/63679bfe-fd0f-4d9a-aae9-a77d0bb42162)
Substitua SEU_SERVIDOR pelo nome do seu servidor SQL e SEU_BANCO_DE_DADOS pelo nome do banco de dados que você criou.

## Executando o Aplicativo
 - Abra a solução no Visual Studio.
 - Certifique-se de definir o projeto da web como projeto de inicialização.
 - Pressione F5 para compilar e executar o aplicativo.
 - O aplicativo estará disponível em http://localhost:7129, onde 7129 é a porta padrão do servidor da web.

## Recursos
O aplicativo possui as seguintes funcionalidades:

- Cadastro de Clientes: Registre informações de clientes, como nome, endereço, telefone, etc.
- Cadastro de Serviços: Registre informações sobre os serviços prestados, incluindo descrição, custo, cliente associado, etc.
- Página de Ferramentas: Gerencie as ferramentas disponíveis para uso como calculadoras, etc.

![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/53f6e1c4-5ca9-4436-924d-b73dc1eaad03)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/436b3107-2cfb-4c2d-9620-058572b33ff2)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/d08883b1-bb58-43d1-a92e-041aeac974e4)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/710da8dc-9943-4abc-982c-def230061512)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/e20b0b21-a121-4b3e-95e9-eb19cdf4f35e)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/f9129561-712c-47e2-bbce-e0429d244d1a)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/08f67c84-01c7-4a86-997d-61b30ead6def)
![image](https://github.com/eduardoaalmeidaa/AdmFagil/assets/89856553/2ee367fb-1fc3-4e0c-af75-a8e9749f4882)







