Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    Private Sub FileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileDialog.FileOk
        Filetext.Text = FileDialog.FileName
    End Sub

    Dim loader As New WHLClasses.GenericDataController

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Filetext.TextLength > 0 Then
            Try
                Dim NewExplorer As New WHLClasses.ItemBrowser
                'Open the thing
                Dim Values As KeyValuePair(Of Type, Object) = loader.LoadAnything(Of Object)(Filetext.Text)
                Using reader = new StreamReader(FileText.text)
                    Dim reader2 = new JsonTextReader(reader)
                    dim token = JToken.Load(reader2)
                    NewExplorer.JsonTreeItem(token)
                End Using
                'Load the explorer
                
                
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FileDialog.ShowDialog()
    End Sub

    Public Sub SearchAFile(Search As String)
        Filetext.Text = Search
        Button2.PerformClick()
    End Sub
End Class
