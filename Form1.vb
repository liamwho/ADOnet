Imports Oracle.DataAccess.Client

Public Class Form1

    Public con As New OracleConnection
    Public ds As New DataSet

    Public Function Connect() As OracleConnection
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim connectString As String = "Data Source=XE; user id=" & username & ";" & "Password=" & password & ";"
        Dim con As New OracleConnection(connectString)
        con.Open()
        MsgBox("Oracle Schema Hardware is now Open")
        Return con
    End Function

    Public Function populateDS() As DataSet
        ds = New DataSet
        Dim sql As String
        Dim da As OracleDataAdapter
        sql = "SELECT * from HARDWARE.CARS"
        da = New OracleDataAdapter(sql, Connect())
        da.Fill(ds, "DT_CARS")
        txtCarMake.Text = ds.Tables("DT_CARS").Rows(0).Item(1)
        txtCarPrice.Text = ds.Tables("DT_CARS").Rows(0).Item(2)
        con.Close()
        Return ds
    End Function

    Public Function CloseDB() As OracleConnection
        con.Close()
    End Function

    Private Sub OpenDB_Click(sender As Object, e As EventArgs) Handles OpenDB.Click
        populateDS()
        Cars.Show()
        CloseDB()
    End Sub

End Class
