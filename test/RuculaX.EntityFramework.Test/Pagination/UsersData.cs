using System;

namespace RuculaX.EntityFramework.Test.Pagination;

public static class UsersData
{

    public static List<User> GetUsersToPagination() => new List<User>() {
        new ("001"){ Name = "Carlos", Addreass = new Addreass { Id = "001", CEP = "Cep Carlos" } },
        new ("002"){ Name = "Ana", Addreass = new Addreass { Id = "002", CEP = "Cep Ana" } },
        new ("003"){ Name = "João", Addreass = new Addreass { Id = "003", CEP = "Cep João" } },
        new ("004"){ Name = "Mariana",Addreass = new Addreass { Id = "004", CEP = "Cep Mariana" } },
        new ("005"){ Name = "Pedro", Addreass = new Addreass { Id = "005", CEP = "Cep Pedro" } },
        new ("006"){ Name = "Juliana", Addreass = new Addreass { Id = "006", CEP = "Cep Juliana" } },
        new ("007"){ Name = "Felipe", Addreass = new Addreass { Id = "007", CEP = "Cep Felipe" } },
        new ("008"){ Name = "Camila",  Addreass = new Addreass { Id = "008", CEP = "Cep Camila" } },
        new ("009"){ Name = "Lucas", Addreass = new Addreass { Id = "009", CEP = "Cep Lucas" } },
        new ("010"){ Name = "Bianca",  Addreass = new Addreass { Id = "010", CEP = "Cep Bianca" } },
        new ("011"){ Name = "Fernando", Addreass = new Addreass { Id = "011", CEP = "Cep Fernando" } },
        new ("012"){ Name = "Larissa",  Addreass = new Addreass { Id = "012", CEP = "Cep Larissa" } },
        new ("013"){ Name = "André",  Addreass = new Addreass { Id = "013", CEP = "Cep André" } },
        new ("014"){ Name = "Patrícia", Addreass = new Addreass { Id = "014", CEP = "Cep Patrícia" } },
        new ("015"){ Name = "Renato",  Addreass = new Addreass { Id = "015", CEP = "Cep Renato" } },
        new ("016"){ Name = "Daniela",  Addreass = new Addreass { Id = "016", CEP = "Cep Daniela" } },
        new ("017"){ Name = "Thiago",  Addreass = new Addreass { Id = "017", CEP = "Cep Thiago" } },
        new ("018"){ Name = "Sandra",  Addreass = new Addreass { Id = "018", CEP = "Cep Sandra" } },
        new ("019"){ Name = "Ricardo", Addreass = new Addreass { Id = "019", CEP = "Cep Ricardo" } },
        new ("020"){ Name = "Elaine",  Addreass = new Addreass { Id = "020", CEP = "Cep Elaine" } }
    };
}
