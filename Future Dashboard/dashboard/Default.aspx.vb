Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports MySqlConnector
Imports Newtonsoft.Json.Linq

Partial Class dashboard_Default
    Inherits System.Web.UI.Page

    Protected Sub page_load(sender As Object, e As EventArgs) Handles Me.Load

        Dim DiscordIdtje As String = "394070278101270528"
        Dim DiscordName As String = "R."

        Dim connString As String = "server=162.19.161.111;user=root;password=qdk7Dr7FFsayDWZs;database=sql"

        Dim myConn = New MySqlConnection(connString)
        myConn.Open()

        Dim ctextcheck = "select firstname FROM users WHERE discord=@discord"
        Dim cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim name As String = Convert.ToString(cmdcheck.ExecuteScalar())


        ctextcheck = "select phone_number FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim nummer As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select job FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim baan As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select label FROM jobs WHERE name=@name"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@name", baan)
        Dim baanlabel As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select accounts FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim accounts As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select identifier FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim identifier As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select name, number FROM phone_contacts WHERE owner=@owner"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@owner", identifier)
        'Dim namen As String = Convert.ToString(cmdcheck.ExecuteScalar())

        Dim rdr As MySqlDataReader = cmdcheck.ExecuteReader()

        While rdr.Read()
            Dim namen As String = rdr(0)
            Dim nummers As String = rdr(1)

            Dim line As String = "                    <tr>
                      <td>
                        <div class=""d-flex px-2 py-1"">
                          <div>
                          </div>
                          <div class=""d-flex flex-column justify-content-center"">
                            <asp:Label CssClass=""mb-0 text-sm"" ID=""Label7"" runat=""server"">" + namen + "</asp:Label>
                          </div>
                        </div>
                      </td>
                      <td>
                        <asp:Label CssClass=""text-xs font-weight-bold mb-0"" ID=""Label6"" runat=""server"">" + nummers + "</asp:Label>
                      </td>
                    </tr>
"

            Label8.Text = Label8.Text + line

        End While
        rdr.Close()


        Dim ser As JObject = JObject.Parse(accounts)
        Dim data2 As List(Of JToken) = ser.Children().ToList


        Dim bankje As String = "Niet Gevonden"
        Dim geldke As String = "Niet Gevonden"

        For Each item As JProperty In data2
            item.CreateReader()
            Select Case item.Name
                Case "bank"
                    bankje = item.Value
                Case "money"
                    geldke = item.Value
            End Select
        Next

        Label1.Text = geldke
        Label2.Text = bankje
        Label3.Text = "Welkom " + name
        Label4.Text = nummer
        Label5.Text = baanlabel


        myConn.Close()



    End Sub

End Class