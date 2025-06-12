# Projeto de T�picos Avan�ados de Programa��o  

Este projeto foi desenvolvido como parte da disciplina de T�picos Avan�ados de Programa��o, sob a mentoria do professor Walter Coan.  

## Objetivo  

O objetivo principal do projeto foi criar servi�os que comp�em o funcionamento de uma faculdade. O bounded context deste projeto foi focado em **disciplinas**, abordando funcionalidades relacionadas � gest�o e opera��o de disciplinas acad�micas. Utilizei o banco de dados no SQL AzureCosmosDB  

## Arquitetura  

Os servi�os foram projetados para se comunicar de forma ass�ncrona atrav�s de mensagens utilizando o **Azure Service Bus**, garantindo escalabilidade e desacoplamento entre os componentes do sistema.  

## Tecnologias Utilizadas  

- **.NET 7**: Framework utilizado para o desenvolvimento dos servi�os.  
- **Azure Service Bus**: Ferramenta de mensageria para comunica��o entre os servi�os.  
- **SQL AzureCosmosDB**: Banco de dados utilizado para persist�ncia de dados.

## Estrutura do Projeto  

O projeto foi dividido em m�ltiplos servi�os, cada um respons�vel por uma parte espec�fica do dom�nio de disciplinas. Essa abordagem segue os princ�pios de arquitetura orientada a servi�os (SOA).  

## Professor Orientador  

Walter Coan
