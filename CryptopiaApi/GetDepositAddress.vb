Public Class GetDepositAddress
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters
        ''' <summary>The currency symbol of the address to return e.g. 'DOT' (not required if 'CurrencyId' supplied)</summary>
        Property Currency As String
        ''' <summary>The Cryptopia currency identifier of the address to return e.g. '2' (not required if 'Currency' supplied)</summary>
        Property CurrencyId As Integer?
    End Class


    Public Class Result
        Property Currency As String
        Property Address As String
        Property BaseAddress As String
    End Class


    Public Function [Call](params As Parameters) As Task(Of Result)
        Return CallFunction(Of Result, Parameters)("GetDepositAddress", params)
    End Function
End Class
