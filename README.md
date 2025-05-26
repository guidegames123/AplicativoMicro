Carlos Eduardo Dias

# Aplicativo Micro-ondas Digital

Este projeto simula um micro-ondas digital desenvolvido em **ASP.NET Web Forms**, uma **API em .NET**, e utilizando **SQL Server** como banco de dados.
Foi feito até a etapa 3 completa e algumas partes da etapa 4.

## Tecnologias Utilizadas

- .NET Framework 4.0 ou superior
- ASP.NET Web Forms
- API REST em C#
- SQL Server (LocalDB ou SQL Server Express)
- Entity Framework
- Bootstrap (para interface básica)

---

## Estrutura do Projeto

- `/WebForms` → Interface Web (ASP.NET Web Forms)
- `/API` → API em .NET
- `/BancoDeDados` → Scripts para criação do banco SQL Server

---

## Como Configurar o Banco de Dados

1. Abra o **SQL Server Management Studio (SSMS)**.
2. Clique com o botão direito em **Bancos de Dados → Restaurar Banco de Dados**.
3. Selecione **Dispositivo → Adicionar**.
4. Navegue até a pasta do projeto e selecione o arquivo `DB_BackUp.bak`.
5. Clique em **OK**.
6. O nome do banco deve ser: **MSSQLSERVER01**.

String de Conexão: @"Server=localhost\MSSQLSERVER01;Database=MicroOndasDB;Trusted_Connection=True;";

