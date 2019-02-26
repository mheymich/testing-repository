Imports System
Imports System.Data.SqlClient
Public Class Form2
    
    Private Sub btn_anzeigen_Click(sender As Object, e As EventArgs) Handles btn_anzeigen.Click
        Form1.sqlTable = New DataTable
        Dim StrSQL_Query As String = "Select Firma, count(Firma) As Anzahl, Cast(sum(Dauer)/60.0 As Decimal(10,2)) As [Gesamtzeit (std)] From Test_Praktikum.dbo.csv_Inhalt_Firma Where (Firma <> '' And Firma <> 'Unbekannt' And Firma <> 'Unbenannt') "
        Dim heute As Date = DateTime.Today
        Dim Wochentag As Integer
        Dim dbl_interval As Double
        'Dim zeitzusatz As Double                                               ' dient dazu die Standard-Uhrzeit von 12:00 AM auf 00:00 AM zu setzen
        Dim StartDate As New Date
        Dim EndDate As New Date

        Wochentag = Weekday(heute, FirstDayOfWeek.Monday)

        If rbtn_letztewoche.Checked Then
            dbl_interval = -(Wochentag)
            EndDate = DateAdd(DateInterval.Day, dbl_interval, heute)
            'EndDate.Add(-zeitzusatz)
            dbl_interval = -6
            StartDate = DateAdd(DateInterval.Day, dbl_interval, EndDate)
            StrSQL_Query &= " And (Datum Between '" & StartDate & "' And '" & EndDate & "') "

        ElseIf rbtn_letztermonat.Checked Then
            StartDate = DateSerial(Year(heute), Month(heute) - 1, 1)
            EndDate = DateSerial(Year(heute), Month(heute), 0)
            StrSQL_Query &= "And (Datum Between '" & StartDate & "' And '" & EndDate & "') "

        ElseIf rbtn_intervall.Checked Then
            StartDate = dtp_anfang.Value        ' Soll bei 00:00:00 anfangen
            EndDate = dtp_ende.Value            ' Soll bei 23:59:59 aufhören
            StrSQL_Query &= "And (Datum Between '" & StartDate & "' And '" & EndDate & "') "
        Else
            StartDate = "01.01.2017"
            EndDate = heute
        End If
        'StrSQL_Query &= "And (Datum Between '" & StartDate & "' And '" & EndDate & "') Group by Firma Order by sum(Dauer) Desc"
        StrSQL_Query &= "Group by Firma Order by sum(Dauer) Desc"
        lbl_header.Text = "Anrufe In der Zeit von " & StartDate & "  bis " & EndDate

        Using Connection As SqlConnection = New SqlConnection("integrated security=SSPI;persist security info=False;data source=WIN2008-R2\WIN2008R2;initial catalog=Test_Praktikum")
            Try
                Connection.Open()                                                   ' Verbindung herstellen
                Dim cmd_Query As New SqlCommand(StrSQL_Query, Connection)
                Dim dr As SqlDataReader = cmd_Query.ExecuteReader()                 ' SQL-Kommando durchführen mit Initialiesierung des DataRaeders
                Form1.sqlTable.Load(dr)
                dr.Close()
            Catch ex As Exception
                MsgBox("Fehler:" & ex.Message)
            End Try
        End Using

        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.DataSource = Form1.sqlTable                                     ' DataTable mit DataGridView anzeigen

    End Sub

    Private Sub btn_graphik_Click(sender As Object, e As EventArgs) Handles btn_graphik.Click
        If Form1.sqlTable Is Nothing Then
            MsgBox("Keine Auswahl getroffen! Bitte treffen Sie links Ihre Auswahl und klicken Sie erst auf die Schaltfläche 'Anzeigen'!")
        Else
            Form3.Show()
        End If
    End Sub

    Private Sub btn_abbrechen_Click(sender As Object, e As EventArgs) Handles btn_abbrechen.Click
        Me.Close()
    End Sub
End Class