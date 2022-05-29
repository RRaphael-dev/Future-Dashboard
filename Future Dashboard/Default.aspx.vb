
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("https://discord.com/api/oauth2/authorize?client_id=971473438369779774&redirect_uri=http%3A%2F%2Ftest.rocketscripts.nl%2Fdefault2.aspx&response_type=code&scope=identify%20email")
    End Sub

End Class
