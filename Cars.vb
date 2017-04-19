Imports Oracle.DataAccess.Client

Public Class Cars

    Private Sub Cars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CarTable As New DataTable

        CarTable = Form1.ds.Tables("DT_CARS")

        DataGridView1.DataSource = CarTable

    End Sub

    Private Sub addRec_Click(sender As Object, e As EventArgs) Handles addRec.Click
        Dim cmd As New OracleCommand("hardware.Add_Car_Record", Form1.Connect())
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Car_Reg", txtCarReg.Text)
        cmd.Parameters.Add("@Car_Name", txtCarMake.Text)
        cmd.Parameters.Add("@Car_Price", Val(txtCarPrice.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Record Added Successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cars_Load()
    End Sub

    Private Sub editRecord_Click(sender As Object, e As EventArgs) Handles editRecord.Click
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("hardware.Edit_Car_Record", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Car_Reg", txtCarReg.Text)
        cmd.Parameters.Add("@Car_Name", txtCarMake.Text)
        cmd.Parameters.Add("@Car_Price", Val(txtCarPrice.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Record Updated")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cars_Load()
        con.Close()
    End Sub

    Private Sub deleteRecord_Click(sender As Object, e As EventArgs) Handles deleteRecord.Click
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("hardware.Delete_Car_Record", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Car_Reg", txtCarReg.Text)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Record Deleted")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cars_Load()
        con.Close()
    End Sub

    Private Sub refreshGrid_Click(sender As Object, e As EventArgs) Handles refreshGrid.Click
        Dim ds As New DataSet
        ds = Form1.populateDS
        DataGridView1.DataSource = ds.Tables("DT_CARS")
    End Sub

    Private Sub clearText_Click(sender As Object, e As EventArgs) Handles clearText.Click
        txtCarReg.Clear()
        txtCarMake.Clear()
        txtCarPrice.Clear()
    End Sub

    Private Sub Cars_Load()
        Cars.refreshGrid_Click()
    End Sub

    Private Shared Sub refreshGrid_Click()
        Dim ds As New DataSet
        ds = Form1.populateDS
        Cars.DataGridView1.DataSource = ds.Tables("DT_CARS")
    End Sub

End Class