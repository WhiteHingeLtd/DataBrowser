Public Class Form1
    Private Sub FileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileDialog.FileOk
        Filetext.Text = FileDialog.FileName
    End Sub

    Dim loader As New WHLClasses.GenericDataController

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Filetext.TextLength > 0 Then
            Try
                'Open the thing.
                Dim Values As KeyValuePair(Of Type, Object) = loader.LoadAnything(Filetext.Text)
                'Load the explorer
                Dim NewExplorer As New WHLClasses.ItemBrowser
                NewExplorer.XMLTreeItem(Values.Value)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FileDialog.ShowDialog()
    End Sub
End Class
