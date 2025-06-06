using System;

namespace RuculaX.EntityFramework.Test.Pagination;

public static class UsersData
{

    public static List<User> GetUsersToPagination() => new List<User>() {
        new (){ Name = "Carlos", Id = "001", Addreass = new Addreass { Id = "001", CEP = "Cep Carlos" } },
        new (){ Name = "Ana", Id = "002", Addreass = new Addreass { Id = "002", CEP = "Cep Ana" } },
        new (){ Name = "João", Id = "003", Addreass = new Addreass { Id = "003", CEP = "Cep João" } },
        new (){ Name = "Mariana", Id = "004", Addreass = new Addreass { Id = "004", CEP = "Cep Mariana" } },
        new (){ Name = "Pedro", Id = "005", Addreass = new Addreass { Id = "005", CEP = "Cep Pedro" } },
        new (){ Name = "Juliana", Id = "006", Addreass = new Addreass { Id = "006", CEP = "Cep Juliana" } },
        new (){ Name = "Felipe", Id = "007", Addreass = new Addreass { Id = "007", CEP = "Cep Felipe" } },
        new (){ Name = "Camila", Id = "008", Addreass = new Addreass { Id = "008", CEP = "Cep Camila" } },
        new (){ Name = "Lucas", Id = "009", Addreass = new Addreass { Id = "009", CEP = "Cep Lucas" } },
        new (){ Name = "Bianca", Id = "010", Addreass = new Addreass { Id = "010", CEP = "Cep Bianca" } },
        new (){ Name = "Fernando", Id = "011", Addreass = new Addreass { Id = "011", CEP = "Cep Fernando" } },
        new (){ Name = "Larissa", Id = "012", Addreass = new Addreass { Id = "012", CEP = "Cep Larissa" } },
        new (){ Name = "André", Id = "013", Addreass = new Addreass { Id = "013", CEP = "Cep André" } },
        new (){ Name = "Patrícia", Id = "014", Addreass = new Addreass { Id = "014", CEP = "Cep Patrícia" } },
        new (){ Name = "Renato", Id = "015", Addreass = new Addreass { Id = "015", CEP = "Cep Renato" } },
        new (){ Name = "Daniela", Id = "016", Addreass = new Addreass { Id = "016", CEP = "Cep Daniela" } },
        new (){ Name = "Thiago", Id = "017", Addreass = new Addreass { Id = "017", CEP = "Cep Thiago" } },
        new (){ Name = "Sandra", Id = "018", Addreass = new Addreass { Id = "018", CEP = "Cep Sandra" } },
        new (){ Name = "Ricardo", Id = "019", Addreass = new Addreass { Id = "019", CEP = "Cep Ricardo" } },
        new (){ Name = "Elaine", Id = "020", Addreass = new Addreass { Id = "020", CEP = "Cep Elaine" } }
    };
}
