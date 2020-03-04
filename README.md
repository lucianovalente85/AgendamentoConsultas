# Cadastramento de Pacientes-Consultas-Anaminese

Aplicação de Gerenciamento de Pacientes-Consultas-Anaminese.


# Banco de dados
	O banco de dados é gerado diretamente pelo projeto, só substitua a string de conexão que está na classe DataBase:
		> Método de override void OnConfiguring(DbContextOptionsBuilder optionsBuilder):
			Substitua a string de conexão para o banco MySql.
		


# Inicializando projeto

Comandos necessários inicialização do projeto:

Abir o projeto 'AgendamentoConsultas.sln' no Visual Studio 2019 e inserir esses comandos:  
  
  > Caso ao excutar o projeto pela primeira vez e de o erro abaixo: 
	NETSDK1 - instale o SDK do .Net Core que está no link abaixo:
	https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x64-installer
	Se o erro persistir após a instalação, renicie a maquina e tente novamente.



# Arquitetura do projeto:

Backend (AgendamentoCosultas):
	
	> Controllers: fazem as funções CRUD no banco e comunicação com frontend utilizando Asp.net MVC
	
	


Frontend (Front):
	
	> Views: Está sendo utilizado as seguintes tecnologias Bootstrap e Razor.
		Observação: Algumas Views foram geradas através do scaffolding.	
	
	
