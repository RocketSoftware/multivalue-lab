Public Class MVSPLogin

    Dim intuser As String = My.User.Name
    Dim intpassword As String = ""
    Dim inthostname As String = "localhost"
    Dim inttcpipsocket As Integer = 9000
    Dim intconfigname As String = ""
    Public Property username() As String
        Get
            username = intuser
        End Get
        Set(ByVal value As String)
            intuser = value
        End Set
    End Property
    Public Property password() As String
        Get
            password = intpassword
        End Get
        Set(ByVal value As String)
            intpassword = value
        End Set
    End Property
    Public Property hostname() As String
        Get
            hostname = inthostname
        End Get
        Set(ByVal value As String)
            inthostname = value
        End Set
    End Property
    Public Property socket() As Integer
        Get
            socket = inttcpipsocket
        End Get
        Set(ByVal value As Integer)
            inttcpipsocket = value
        End Set
    End Property
    Public Property configname() As String
        Get
            configname = intconfigname
        End Get
        Set(ByVal value As String)
            intconfigname = value
        End Set
    End Property
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        intuser = UsernameTextBox.Text
        intpassword = PasswordTextBox.Text
        inthostname = HostnameTextBox.Text
        inttcpipsocket = TCPIPSocketTextBox.Text
        intconfigname = confignameTextbox.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub MVSPLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UsernameTextBox.Text = intuser
        PasswordTextBox.Text = intpassword
        HostnameTextBox.Text = inthostname
        TCPIPSocketTextBox.Text = inttcpipsocket
        confignameTextbox.Text = intconfigname
    End Sub
End Class
