Imports System.Web
Imports System.Text
Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Net
Public MustInherit Class ApiEndpoint

    Private Shared ReadOnly BASE_URL As String = "https://www.cryptopia.co.nz/Api/"

    Private ReadOnly _Keys As ApiKeys

    Public Sub New(Keys As ApiKeys)
        Me._Keys = Keys
    End Sub


    Public Function CallFunction(Of ResultType)(functionName As String, Optional needsAuthorisation As Boolean = True) As Task(Of ResultType)
        Return CallFunction(Of ResultType, Object)(functionName, Nothing, needsAuthorisation)
    End Function

    Public Async Function CallFunction(Of ResultType, ParameterType)(functionName As String, parameters As ParameterType, Optional needsAuthorisation As Boolean = True) As Task(Of ResultType)

        Dim URL As String = $"{BASE_URL}{functionName}"

        Dim http_req = HttpWebRequest.Create(URL)
        http_req.Method = "GET"

        If needsAuthorisation Then

            http_req.Method = "POST"
            Dim post_json = JsonConvert.SerializeObject(parameters)
            Dim post_data = UTF8Encoding.UTF8.GetBytes(post_json)
            http_req.ContentType = "application/json"
            http_req.ContentLength = post_data.Length
            http_req.Headers.Add("Authorization", getAuthorisation(URL, post_data))

            Using http_req_stream = Await http_req.GetRequestStreamAsync()
                Await http_req_stream.WriteAsync(post_data, 0, post_data.Length)
            End Using

        End If

        Using http_resp = Await http_req.GetResponseAsync()

            Using respS = New System.IO.StreamReader(http_resp.GetResponseStream())
                Dim result_json = Await respS.ReadToEndAsync()
                Dim result = JsonConvert.DeserializeObject(Of CallResult(Of ResultType))(result_json)
                If result.Success Then Return result.Data
                Throw New Exception(result.Error)
            End Using

        End Using


    End Function

    Private Function getAuthorisation(URL As String, post_data As Byte()) As String
        'AMX scheme authorisation header
        Using md = MD5.Create(), hm = New HMACSHA256(Me._Keys.API_SECRET_BYTES)
            Dim nonce = Convert.ToUInt64(Now.Ticks)
            Dim md5Hash = Convert.ToBase64String(md.ComputeHash(post_data))
            Dim signature = $"{Me._Keys.API_KEY}POST{HttpUtility.UrlEncode(URL).ToLower()}{nonce}{md5Hash}"
            Dim hmac = Convert.ToBase64String(hm.ComputeHash(UTF8Encoding.UTF8.GetBytes(signature)))
            Return $"amx {Me._Keys.API_KEY}:{hmac}:{nonce}"
        End Using
    End Function


    Private Class CallResult(Of ResultType)

        Property Success As Boolean
        Property [Error] As String
        Property Data As ResultType

    End Class

End Class
