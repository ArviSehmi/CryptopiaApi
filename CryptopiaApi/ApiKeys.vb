Public Class ApiKeys

    Property API_KEY As String
    Property API_SECRET As String
    Property API_SECRET_BYTES As Byte()


    Public Sub New(ApiKey As String, ApiSecret As String)
        API_KEY = API_KEY
        API_SECRET = ApiSecret
        API_SECRET_BYTES = Convert.FromBase64String(ApiSecret)
    End Sub


    Public Sub StoreAsDefaults()
        Dim data = System.Text.UTF8Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(Me))
        Dim protectedData = System.Security.Cryptography.ProtectedData.Protect(data, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser)
        My.Settings.Item("ApiKeys") = protectedData
    End Sub

    Public Shared Function LoadDefaults() As ApiKeys
        Dim existingKeys = TryCast(My.Settings.Item("ApiKeys"), Byte())

        If existingKeys Is Nothing Then Return Nothing
        If existingKeys.Length = 0 Then Return Nothing

        Dim data = System.Text.UTF8Encoding.UTF8.GetString(existingKeys)

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of ApiKeys)(data)

    End Function

End Class
