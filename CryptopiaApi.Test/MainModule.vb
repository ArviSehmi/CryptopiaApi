Module MainModule


    Private _Client As Client

    Sub Main()


        'CryptopiaApi.ApiKeys.DeleteDefaults()

        LoadOrRequestApiKeys()

        'Test_GetBalance()
        Test_GetCurrencies()

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub

    Public Sub LoadOrRequestApiKeys()

        Dim defaultKeys = CryptopiaApi.ApiKeys.LoadDefaults()

        If defaultKeys IsNot Nothing Then
            Console.WriteLine($"Continue with key {defaultKeys.API_KEY}...?")
            Console.WriteLine("Y=Yes    N=Change    D=Delete stored keys")

            Select Case Char.ToUpper(Console.ReadKey().KeyChar)
                Case "Y"
                Case "N"
                    defaultKeys = Nothing
                Case "D"
                    defaultKeys = Nothing
                    CryptopiaApi.ApiKeys.DeleteDefaults()
                    Console.WriteLine("Stored keys deleted.")
                Case Else
                    End
            End Select
        End If


        If defaultKeys Is Nothing Then
            Console.WriteLine("Please enter your API Key...")
            Dim apiKey = Console.ReadLine().Trim()

            Console.WriteLine("Please enter your API SECRET Key...")
            Dim apiSecret = Console.ReadLine().Trim()

            defaultKeys = New ApiKeys(apiKey, apiSecret)

            Console.WriteLine("Store these keys...?")
            Console.WriteLine("Y=Yes    N=No    Any other key to exit.")

            Select Case Char.ToUpper(Console.ReadKey().KeyChar)
                Case "Y"
                    defaultKeys.StoreAsDefaults()
                Case "N"
                Case Else
                    End
            End Select

        End If

        _Client = New Client(defaultKeys)

    End Sub



    Public Sub Test_GetBalance()

        Dim parameters = New GetBalance.Parameters() With {.Currency = ""} 'blank = all



        Dim balances = _Client.GetBalance(parameters).Result

        For Each r In balances
            Console.WriteLine(r.Symbol & " = " & r.Available)
        Next

    End Sub


    Public Sub Test_GetCurrencies()

        Dim currs = _Client.GetCurrencies().Result

        For Each r In currs
            Console.WriteLine(r.Symbol & " = " & r.Status)
        Next

    End Sub
End Module
