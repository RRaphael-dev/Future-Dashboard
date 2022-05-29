Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports MySqlConnector
Imports Newtonsoft.Json.Linq

Partial Class dashboard_billing
    Inherits System.Web.UI.Page

    Protected Sub page_load(sender As Object, e As EventArgs) Handles Me.Load

        Dim DiscordIdtje As String = "394070278101270528"
        Dim DiscordName As String = "R."

        Dim connString As String = "server=162.19.161.111;user=root;password=qdk7Dr7FFsayDWZs;database=sql"

        Dim myConn = New MySqlConnection(connString)
        myConn.Open()

        Dim ctextcheck = "select iban FROM users WHERE discord=@discord"
        Dim cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim iban As String = Convert.ToString(cmdcheck.ExecuteScalar())


        ctextcheck = "select firstname FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim voornaam As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select lastname FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim achternaam As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select job FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim job As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select job_grade FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim grade As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select salary FROM job_grades WHERE grade=@grade AND job_name=@jobname"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@grade", grade)
        cmdcheck.Parameters.AddWithValue("@jobname", job)
        Dim salaris As String = Convert.ToString(cmdcheck.ExecuteScalar())

        ctextcheck = "select accounts FROM users WHERE discord=@discord"
        cmdcheck = New MySqlCommand(ctextcheck, myConn)
        cmdcheck.Parameters.AddWithValue("@discord", DiscordIdtje)
        Dim accounts As String = Convert.ToString(cmdcheck.ExecuteScalar())

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

        Dim card As String = " <div class=""card bg-transparent shadow-xl"">
                <div class=""overflow-hidden position-relative border-radius-xl"" style=""background-image: url('./assets/img/curved-images/curved14.jpg');"">
                  <span class=""mask bg-gradient-dark""></span>
                  <div class=""card-body position-relative z-index-1 p-3"">
                    <i class=""fas fa-wifi text-white p-2""></i>
                      <h5 class=""text-white mt-4 mb-5 pb-2"">" + iban + "</h5>
                    <div class=""d-flex"">
                      <div class=""d-flex"">
                        <div class=""me-4"">
                          <p class=""text-white text-sm opacity-8 mb-0"">Card Holder</p>
                          <h6 class=""text-white mb-0"">" + voornaam + " " + achternaam + "</h6>
                        </div>
                        <div>
                          <p class=""text-white text-sm opacity-8 mb-0"">Expires</p>
                          <h6 class=""text-white mb-0"">11/2024</h6>
                        </div>
                      </div>
                      <div class=""ms-auto w-20 d-flex align-items-end justify-content-end"">
                        <img class=""w-60 mt-2"" src=""./assets/img/logos/mastercard.png"" alt=""logo"">
                      </div>
                    </div>
                  </div>
                </div>
              </div>"

        Dim salary As String = " <h5 Class=""mb-0"">+" + String.Format("{0:n0}", Convert.ToInt32(salaris)) + "</h5>"
        Dim bank As String = "<h5 class=""mb-0"">" + String.Format("{0:n0}", Convert.ToInt64(bankje)) + "</h5>"

        Label1.Text = card
        Label2.Text = salary
        Label3.Text = bank

        myConn.Close()



    End Sub
    'Protected Sub (sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
    '    Response.Redirect("https://discord.com/api/oauth2/authorize?client_id=971473438369779774&redirect_uri=http%3A%2F%2Ftest.rocketscripts.nl%2Fdefault2.aspx&response_type=code&scope=identify%20email")
    'End Sub


End Class
