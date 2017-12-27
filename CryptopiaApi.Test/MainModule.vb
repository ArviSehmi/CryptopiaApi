Module MainModule

    Sub Main()

        CryptopiaApi.Client.DefaultApiKey = ""
        CryptopiaApi.Client.DefaultApiSecret = ""

        'Test_GetBalance()
        Test_GetCurrencies()

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub



    Public Sub Test_GetBalance()

        Dim parameters = New GetBalance.Parameters() With {.Currency = ""} 'blank = all

        Dim balances = GetBalance.Call(parameters).Result

        For Each r In balances
            Console.WriteLine(r.Symbol & " = " & r.Available)
        Next

    End Sub


    Public Sub Test_GetCurrencies()

        Dim currs = GetCurrencies.Call().Result

        For Each r In currs
            Console.WriteLine(r.Symbol & " = " & r.Status)
        Next

    End Sub
End Module
