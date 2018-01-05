Public Class GetDepositAddress
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters
        Property Currency As String
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
