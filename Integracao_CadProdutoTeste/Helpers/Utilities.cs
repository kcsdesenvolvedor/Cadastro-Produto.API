using CadastroDeProdutos.API.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integracao_CadProdutoTeste.Helpers
{
    public static class Utilities
    {
        //#region snippet1
        //public static void InitializeDbForTests(DataContext db)
        //{
        //    db.Messages.AddRange(GetSeedingMessages());
        //    db.SaveChanges();
        //}

        //public static void ReinitializeDbForTests(DataContext db)
        //{
        //    db.Messages.RemoveRange(db.Messages);
        //    InitializeDbForTests(db);
        //}

        //public static List<Message> GetSeedingMessages()
        //{
        //    return new List<Message>()
        //    {
        //        new Message(){ Text = "TEST RECORD: You're standing on my scarf." },
        //        new Message(){ Text = "TEST RECORD: Would you like a jelly baby?" },
        //        new Message(){ Text = "TEST RECORD: To the rational mind, " +
        //            "nothing is inexplicable; only unexplained." }
        //    };
        //}

    }
}
