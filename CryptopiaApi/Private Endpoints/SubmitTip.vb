Public Class SubmitTip
    Inherits ApiEndpoint

    Public Sub New(apiKeys As ApiKeys)
        MyBase.New(apiKeys)
    End Sub


    Public Class Parameters

        ''' <summary>The currency symbol Of the coins To tip e.g. 'DOT' (not required if 'CurrencyId' supplied)</summary>
        Public Property Currency As String

        ''' <summary>The Cryptopia currency identifier Of the coins To tip e.g. '2' (not required if 'Currency' supplied)</summary>
        Public Property CurrencyId As Integer?

        ''' <summary>The amount Of last active users To tip (Min: 2 Max: 100)</summary>
        Public Property ActiveUsers As String

        ''' <summary>the amount Of coins To buy e.g. 123.00000000 (Amount will be divided equally amongst the active users)</summary>
        Public Property Amount As Decimal

    End Class


    Public Function [Call](params As Parameters) As Task(Of String)
        Return CallFunction(Of String, Parameters)("SubmitTip", params)
    End Function
End Class