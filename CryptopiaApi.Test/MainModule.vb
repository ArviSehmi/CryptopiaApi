Module MainModule

    Sub Main()

        CryptopiaApi.Client.DefaultApiKey = "API KEY"
        CryptopiaApi.Client.DefaultApiSecret = "API SECRET"

        Test_GetBalance()

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub



    Public Sub Test_GetBalance()

        Dim parameters = New GetBalance.Parameters() With {.Currency = ""} 'blank = all

        Dim balances = GetBalance.Execute(parameters).Result

        For Each r In balances
            Console.WriteLine(r.Symbol & " = " & r.Available)
        Next

    End Sub

End Module
