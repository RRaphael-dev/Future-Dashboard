
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports MySqlConnector
Imports Newtonsoft.Json.Linq

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub page_load(sender As Object, e As EventArgs) Handles Me.Load
        Dim client_id As String = "971473438369779774"
        Dim client_sceret As String = "AWvOe3JEDrtIhKj21g_zvGrYasgl6ogu"
        Dim redirect_url As String = "http://test.rocketscripts.nl/default2.aspx"
        Dim code As String = Request.QueryString("code")
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        Dim webRequest As HttpWebRequest = CType(webRequest.Create("https://discordapp.com/api/oauth2/token"), HttpWebRequest)
        webRequest.Method = "POST"
        Dim parameters As String = "client_id=" & client_id & "&client_secret=" & client_sceret & "&grant_type=authorization_code&code=" & code & "&redirect_uri=" & redirect_url & ""
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(parameters)
        webRequest.ContentType = "application/x-www-form-urlencoded"
        webRequest.ContentLength = byteArray.Length
        Dim postStream As Stream = webRequest.GetRequestStream()
        postStream.Write(byteArray, 0, byteArray.Length)
        postStream.Close()
        Dim response As WebResponse = webRequest.GetResponse()
        postStream = response.GetResponseStream()
        Dim reader As StreamReader = New StreamReader(postStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Dim tokenInfo As String = responseFromServer.Split(","c)(0).Split(":"c)(1)
        Dim access_token As String = tokenInfo.Trim().Substring(1, tokenInfo.Length - 3)

        Dim webRequest1 As HttpWebRequest = CType(webRequest.Create("https://discordapp.com/api/users/@me"), HttpWebRequest)
        webRequest1.Method = "Get"
        webRequest1.ContentLength = 0
        webRequest1.Headers.Add("Authorization", "Bearer " & access_token)
        webRequest1.ContentType = "application/x-www-form-urlencoded"
        Dim apiResponse1 As String = ""

        Using response1 As HttpWebResponse = TryCast(webRequest1.GetResponse(), HttpWebResponse)
            Dim reader1 As StreamReader = New StreamReader(response1.GetResponseStream())
            apiResponse1 = reader1.ReadToEnd()
        End Using

        Dim DiscordIdtje As String
        Dim DiscordName As String

        Try
            Dim rawresp As String = apiResponse1

            Dim jss As New JavaScriptSerializer()
            Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(rawresp)

            DiscordIdtje = dict("id")
            DiscordName = dict("username")
        Catch ex As Exception

        End Try

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Session("DiscordIdentifier") = DiscordIdtje
        Session("DiscordName") = DiscordName

        Redirect()


    End Sub

    Protected Sub Redirect()
        Response.Redirect("http://test.rocketscripts.nl/dashboard/default.aspx")
    End Sub

End Class
