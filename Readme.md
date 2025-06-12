# Projeto de Tópicos Avançados de Programação  

Este projeto foi desenvolvido como parte da disciplina de Tópicos Avançados de Programação, sob a mentoria do professor Walter Coan.  

## Objetivo  

O objetivo principal do projeto foi criar serviços que compõem o funcionamento de uma faculdade. O bounded context deste projeto foi focado em **disciplinas**, abordando funcionalidades relacionadas à gestão e operação de disciplinas acadêmicas. Utilizei o banco de dados no SQL AzureCosmosDB  

## Arquitetura  

Os serviços foram projetados para se comunicar de forma assíncrona através de mensagens utilizando o **Azure Service Bus**, garantindo escalabilidade e desacoplamento entre os componentes do sistema.  

## Tecnologias Utilizadas  

- **.NET 7**: Framework utilizado para o desenvolvimento dos serviços.  
- **Azure Service Bus**: Ferramenta de mensageria para comunicação entre os serviços.  
- **SQL AzureCosmosDB**: Banco de dados utilizado para persistência de dados.

## Estrutura do Projeto  

O projeto foi dividido em múltiplos serviços, cada um responsável por uma parte específica do domínio de disciplinas. Essa abordagem segue os princípios de arquitetura orientada a serviços (SOA).  

## Professor Orientador  

Walter Coan
