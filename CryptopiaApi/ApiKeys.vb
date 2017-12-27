Public Class ApiKeys

    Property API_KEY As String
    Property API_SECRET_BYTES As Byte()


    Public Sub New(ApiKey As String, ApiSecret As String)
        API_KEY = ApiKey
        API_SECRET_BYTES = Convert.FromBase64String(ApiSecret)
    End Sub
    Public Sub New(ApiKey As String, ApiSecret() As Byte)
        API_KEY = ApiKey
        API_SECRET_BYTES = ApiSecret
    End Sub

    Public Sub StoreAsDefaults()
        Dim data = System.Text.UTF8Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(Me))
        Dim protectedData = System.Security.Cryptography.ProtectedData.Protect(data, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser)
        My.Computer.Registry.CurrentUser.SetValue($"CryptopiaApi\ApiKeys", protectedData, Microsoft.Win32.RegistryValueKind.Binary)
    End Sub

    Public Shared Function LoadDefaults() As ApiKeys

        Dim protectedKeys = TryCast(My.Computer.Registry.CurrentUser.GetValue($"CryptopiaApi\ApiKeys"), Byte())

        If protectedKeys Is Nothing Then Return Nothing
        If protectedKeys.Length = 0 Then Return Nothing


        Dim unprotectedKeys = System.Security.Cryptography.ProtectedData.Unprotect(protectedKeys, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser)

        Dim data = System.Text.UTF8Encoding.UTF8.GetString(unprotectedKeys)

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of ApiKeys)(data)

    End Function

End Class
