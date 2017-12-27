Imports System.Web
Imports System.Text
Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Net
Public Class Client

    Private Shared ReadOnly BASE_URL As String = "https://www.cryptopia.co.nz/Api/"
    Private Shared _DefaultApiKey As String
    Private Shared _DefaultApiKeySecret As String
    Private Shared _DefaultClient As Client

    Public Shared WriteOnly Property DefaultApiKey As String
        Set(value As String)
            _DefaultApiKey = value
            _DefaultClient = Nothing
        End Set
    End Property
    Public Shared WriteOnly Property DefaultApiSecret As String
        Set(value As String)
            _DefaultApiKeySecret = value
            _DefaultClient = Nothing
        End Set
    End Property

    Public Shared ReadOnly Property [Default] As Client
        Get
            If _DefaultClient Is Nothing Then
                _DefaultClient = New Client
            End If
            Return _DefaultClient
        End Get
    End Property


    Private ReadOnly API_KEY As String
    Private ReadOnly API_SECRET As String
    Private ReadOnly API_SECRET_BYTES As Byte()

    Public Sub New()
        MyClass.New(_DefaultApiKey, _DefaultApiKeySecret)
    End Sub

    Public Sub New(APIKey As String, APISecret As String)
        Me.API_KEY = APIKey
        Me.API_SECRET = APISecret
        Me.API_SECRET_BYTES = Convert.FromBase64String(Me.API_SECRET)
    End Sub



    Public Async Function CallFunction(Of ResultType, ParameterType)(functionName As String, parameters As ParameterType) As Task(Of ResultType)

        Dim URL As String = $"{BASE_URL}{functionName}"

        Dim post_json = JsonConvert.SerializeObject(parameters)
        Dim post_data = UTF8Encoding.UTF8.GetBytes(post_json)

        Dim nonce = Convert.ToUInt64(Now.Ticks)

        Dim http_req = HttpWebRequest.Create(URL)
        http_req.Method = "POST"
        http_req.ContentType = "application/json"
        http_req.ContentLength = post_data.Length

        Using md = MD5.Create(), hm = New HMACSHA256(API_SECRET_BYTES)
            Dim md5Hash = Convert.ToBase64String(md.ComputeHash(post_data))
            Dim signature = $"{API_KEY}POST{HttpUtility.UrlEncode(URL).ToLower()}{nonce}{md5Hash}"
            Dim hmac = Convert.ToBase64String(hm.ComputeHash(UTF8Encoding.UTF8.GetBytes(signature)))
            Dim auth = $"amx {API_KEY}:{hmac}:{nonce}"
            http_req.Headers.Add("Authorization", auth)
        End Using


        Using http_req_stream = Await http_req.GetRequestStreamAsync()
            Await http_req_stream.WriteAsync(post_data, 0, post_data.Length)
        End Using

        Using http_resp = Await http_req.GetResponseAsync()

            Using respS = New System.IO.StreamReader(http_resp.GetResponseStream())
                Dim result_json = Await respS.ReadToEndAsync()
                Dim result = JsonConvert.DeserializeObject(Of CallResult(Of ResultType))(result_json)
                If result.Success Then Return result.Data
                Throw New Exception(result.Error)
            End Using

        End Using


    End Function


    Private Class CallResult(Of ResultType)

        Property Success As Boolean
        Property [Error] As String
        Property Data As ResultType

    End Class

End Class
