Public Class Form1
    Dim Web As New System.Net.WebClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InternetTestConecction()
        Update_Starten()
    End Sub

    Function InternetTestConecction()
        Dim Ping As New Net.NetworkInformation.Ping
        Try
            Ping.Send("google.de")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub Update_Starten()

        If InternetTestConecction() = True Then
            Try
                'Hier wird überprüft ob es eine neuere Version gibt!
                Dim Version As String = Web.DownloadString("https://github.com/DavHil/Einfache-Updatefunktion/blob/master/Einfaches-Update/AktuelleVersion.txt")
                Version = CInt(Version)
                If Version > CInt(lblversion.Text) Then
                    'Hier wird der Pfad der Neuen Exe angegeben
                    Dim Pfad As String = "https://github.com/DavHil/Einfache-Updatefunktion/blob/master/Einfaches-Update/Updatefunktion.exe"
                    'Hier wird der Pfad angeggeben wo alles abgespeichert wird
                    My.Computer.Network.DownloadFile(Pfad, Application.StartupPath & "/[Update" & Version & "]" & "Update.exe")
                    MsgBox("Ein Update wurde erkannt und Heruntergeladen")
                    Try

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If

            Catch ex As Exception
                'nichts
            End Try
        Else
            MsgBox("Sie benötigen für die Update überprüfung Internet")
        End If


    End Sub
End Class
