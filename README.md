# 🍔 Lanchonete Sabida

> Sistema desktop de registro de pedidos para lanchonete, feito em C# com Windows Forms.

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![License](https://img.shields.io/github/license/SEU-USUARIO/lanchonete-sabida)

![Demonstração](docs/screenshots/demo.gif)

## 📌 Sobre
Duas ou três frases: o problema que resolve (agilizar o registro de pedidos),
para quem é, e o contexto (projeto acadêmico / estudo / portfólio).

## ✨ Funcionalidades
- [x] Abertura de novo pedido com número e data/hora
- [x] Cadastro de lanches e bebidas com quantidade e cálculo de total
- [x] Complementos opcionais por lanche
- [x] Gravação de conteúdo em arquivo XML

## 🖼️ Telas
| Dados do pedido | Itens | Resumo |
|---|---|---|
| ![](docs/screenshots/dados.png) | ![](docs/screenshots/itens.png) | ![](docs/screenshots/resumo.png) |

## 🛠️ Tecnologias
- C# · Windows Forms · .NET Framework 4.8
- LINQ to XML / `XmlWriter` para persistência

## ▶️ Como executar
**Pré-requisitos:** Windows, Visual Studio 2022 (carga de trabalho
*Desenvolvimento para desktop com .NET*) e .NET Framework 4.8.

```bash
git clone https://github.com/SEU-USUARIO/lanchonete-sabida.git
```
1. Abra `LanchoneteSabida.sln` no Visual Studio.
2. Pressione `F5`.

Ou baixe o executável na aba **Releases**.

## 🗂️ Estrutura do projeto
```
LanchoneteSabida/
├── Form1.cs            # lógica da tela
├── Form1.Designer.cs   # layout gerado pelo Designer
├── Program.cs          # ponto de entrada
└── Properties/
```

## 📋 Regras de negócio
- Cada pedido recebe um número sequencial.
- Complementos só são habilitados para lanches.
- (descreva as regras que o sistema aplica)

## 🗺️ Roadmap
- [ ] Gravação de pedidos em XML estável
- [ ] Tela de resumo dos pedidos
- [ ] Exportação em TXT/JSON
- [ ] Testes automatizados
- [ ] Migração para .NET moderno

## 📚 Aprendizados
Em poucas linhas: o que você praticou (eventos, DataGridView, XML, regras
de negócio). Isso conta ponto em entrevista.

## 👤 Autor
**Matheus Ferenci Miranda Leitão** 
· [LinkedIn](https://www.linkedin.com/in/matheus-ferenci-miranda-leit%C3%A3o-a611b9374/) 
· [Portfólio](https://github.com/mths09/lanchonete-do-saber) 
· matheusferenci0@gmail.com

## 📄 Licença
Distribuído sob a licença MIT. Veja [LICENSE](LICENSE).
