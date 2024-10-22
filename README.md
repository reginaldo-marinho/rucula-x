# RuculaX
RuculaX é projeto que tem como principal objetivo, entender situações repetidadas que encontramos durante o desenvolvimento de um software e resolver de uma forma mais simples.

Por Exemplo, em modelo de dominio é comum trabalharmos com entidades que herdam de Entity, onde essa entidade contém propriedades que garantem que ela seja única. Assim sendo o RuculaX contém uma classe `Entity<T>` que garante na sua herança a criação de uma identidade única.

<p align="center">
<img src="Ruculax.png" style="width:200px">
</p>

## Soluções Disponíveis
- [Identidade Única com Entity](./src/RuculaX.Domain/README.md)
- [Repositório Base](./src/RuculaX.EntityFramework/README.md)
- [Unidade Lógica de Trabalho](./src/RuculaX.EntityFramework/README.md)
- [Fabrica de Query - Recurso para suporte a paginação](./src/RuculaX.Database/README.md)