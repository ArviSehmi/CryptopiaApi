Public Class ApiKeys

    Private Const REG_KEY_ROOT As String = "HKEY_CURRENT_USER\Software\ArviSoft\CryptopiaApi"


    Private Const REG_KEY As String = "ApiKeys"

    <Newtonsoft.Json.JsonProperty("API_KEY")>
    Private _API_KEY As String
    <Newtonsoft.Json.JsonProperty("API_SECRET_BYTES")>
    Private _API_SECRET_BYTES As Byte()

    <Newtonsoft.Json.JsonIgnore()>
    Public ReadOnly Property API_KEY As String
        Get
            Return _API_KEY
        End Get
    End Property
    <Newtonsoft.Json.JsonIgnore()>
    Public ReadOnly Property API_SECRET_BYTES As Byte()
        Get
            Return _API_SECRET_BYTES
        End Get
    End Property

    Public Shared Sub DeleteDefaults()
        My.Computer.Registry.SetValue(REG_KEY_ROOT, REG_KEY, New Byte() {}, Microsoft.Win32.RegistryValueKind.Binary)
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(ApiKey As String, ApiSecret As String)
        MyClass.New(ApiKey, Convert.FromBase64String(ApiSecret))
    End Sub
    Public Sub New(ApiKey As String, ApiSecret() As Byte)
        Me._API_KEY = ApiKey
        Me._API_SECRET_BYTES = ApiSecret
    End Sub

    Public Sub StoreAsDefaults()
        Dim data = System.Text.UTF8Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(Me))
        Dim protectedData = System.Security.Cryptography.ProtectedData.Protect(data, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser)
        My.Computer.Registry.SetValue(REG_KEY_ROOT, REG_KEY, protectedData, Microsoft.Win32.RegistryValueKind.Binary)
    End Sub

    Public Shared Function LoadDefaults() As ApiKeys

        Dim protectedKeys = TryCast(My.Computer.Registry.GetValue(REG_KEY_ROOT, REG_KEY, Nothing), Byte())

        If protectedKeys Is Nothing Then Return Nothing
        If protectedKeys.Length = 0 Then Return Nothing


        Dim unprotectedKeys = System.Security.Cryptography.ProtectedData.Unprotect(protectedKeys, Nothing, Security.Cryptography.DataProtectionScope.CurrentUser)

        Dim data = System.Text.UTF8Encoding.UTF8.GetString(unprotectedKeys)

        Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of ApiKeys)(data)

    End Function

End Class
