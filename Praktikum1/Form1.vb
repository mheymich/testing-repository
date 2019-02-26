Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Object
Imports System.MarshalByRefObject
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1

    Public sqlTable As DataTable = Nothing                               ' zugreifbar für alle Methoden (Form1.sqlTable)
    Dim csvTable As DataTable = Nothing                                  ' zugreifbar für alle Methoden (Form1.csvTable)
    Dim StrSQL_Insert As String = ""                                     ' zugreifbar für alle Methoden (Form1.StrSQL_Insert)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_durchsuchen_Click(sender As Object, e As EventArgs) Handles btn_durchsuchen.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        tbx_durchsuchen.Text = OpenFileDialog1.FileName
    End Sub
    Private Sub tbx_durchsuchen_KeyDown(sender As Object, e As KeyEventArgs) Handles tbx_durchsuchen.KeyDown
        If (e.KeyValue = 13) Then                                         ' 13 ASCII Dezimahl für Enter-Taste
            btn_einlesen_fph.Focus()
        End If
    End Sub

    Private Sub btn_einlesen_fph_Click(sender As Object, e As EventArgs) Handles btn_einlesen_fph.Click
        csvTable = Nothing
        If tbx_durchsuchen.Text Like "*\*.*.*list*.csv" Then                                   'checkt, ob tbx_durchsuchen einen vollständigen Datei-Pfad zum öffnen hat nach dem Prinzip Fritz!Phone.
            ' Liste zum Füllen des Stringarrays zur Einstellung der Namen der Spalten
            Dim ary_columnName As String()
            Dim myList As New List(Of String)()
            myList.Add("Typ")                                                                   ' ary_columnName(0)
            myList.Add("Datum")                                                                 ' ary_columnName(1)  
            myList.Add("Firma")
            myList.Add("Name")
            myList.Add("Rufnummer")                                                             ' ary_columnName(4) 
            myList.Add("Nebenstelle")
            myList.Add("Eigene Rufnummer")
            myList.Add("Dauer")                                                                 ' ary_columnName(7) 
            ary_columnName = myList.ToArray()

            Dim rowCount As Integer = 0                                                         ' Der rowCount zählt die als Datensätze erkannten Zeilen der Datei.
            Using TxtReader As New FileIO.TextFieldParser(tbx_durchsuchen.Text)                 ' TextFieldParser zum Einlesen einer csv-Datei (statisch festgelegt)
                TxtReader.TextFieldType = FileIO.FieldType.Delimited
                TxtReader.SetDelimiters(";")

                lbx_status.Items.Add(tbx_durchsuchen.Text & " geöffnet...")

                ' Deklaration der Komponenten zum Lesen und Speichern in DataTable
                Dim Row As DataRow
                Dim Upperbound As Integer
                Dim CurrentRow As String()
                Dim FieldNameSplit As String()

                ' Einlese-Schleife, die in DataTable speichert
                Dim zeilenCount As Integer = 0                                                  ' ähnliche Funktion wie rowCount (siehe oben), aber zählt jede einzelne Zeile in der Datei
                While Not TxtReader.EndOfData
                    CurrentRow = TxtReader.ReadFields()
                    Upperbound = ary_columnName.GetUpperBound(0)
                    If zeilenCount > 1 Then                                                     ' Die Zeile 0 und die Zeile 1 mit den Feldüberschriften sollen damit übersprungen werden.
                        If csvTable Is Nothing Then
                            csvTable = New DataTable("csvTable")
                            Build_csvTable(Upperbound, ary_columnName)                          ' Funktion zum erstellen der Spalten
                        End If
                        FieldNameSplit = Split(CurrentRow(2), ", ")                             ' splittet das Feld "Name" zu "Firma" und "Name"
                        Row = csvTable.NewRow
                        For ColumnCount = 0 To Upperbound
                            If ColumnCount < 2 Then                                             ' füllt die ersten beiden Datensätze eins-zu-eins
                                Row(ary_columnName(ColumnCount)) = CurrentRow(ColumnCount)
                            ElseIf ary_columnName(ColumnCount) = "Firma" Then
                                Row(ary_columnName(ColumnCount)) = FieldNameSplit(0)
                            ElseIf ary_columnName(ColumnCount) = "Name" Then
                                If FieldNameSplit.Length >= 2 Then                              ' Der Split gibt ein Array in der Länge der Objekte im Split.
                                    Row(ary_columnName(ColumnCount)) = FieldNameSplit(1)
                                Else
                                    Row(ary_columnName(ColumnCount)) = ""                       ' bei nur einem Objekt im Split, bleibt Name LEER
                                End If
                            Else
                                Row(ary_columnName(ColumnCount)) = CurrentRow(ColumnCount - 1)   ' füllt den Rest
                            End If
                        Next
                        csvTable.Rows.Add(Row)
                        rowCount += 1
                    End If
                    zeilenCount += 1
                End While
            End Using

            ' Anzeige
            DataGridView1.DataSource = csvTable
            lbx_status.Items.Add(rowCount.ToString & " Datensätze gelesen.")

            'Dauer in Minuten umrechnen
            For i = 0 To csvTable.Rows.Count - 1
                csvTable.Rows.Item(i).Item("Dauer") = ConvertToInt(csvTable.Rows.Item(i).Item("Dauer"))
            Next

            'Setze String zum Speichern
            StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Name, Rufnummer, Nebenstelle, [Eigene Rufnummer], Dauer) "
        Else
            MsgBox("Keine gültige Datei ausgewählt! Bitte wählen sie eine Datei mit Format '\dd.mm.yyyylist.csv' aus!")
        End If

    End Sub
    Private Sub btn_einlesen_tvw_Click(sender As Object, e As EventArgs) Handles btn_einlesen_tvw.Click
        csvTable = Nothing
        If tbx_durchsuchen.Text Like "*\connectionreport (*).csv" Then                     ' checkt, ob tbx_durchsuchen einen vollständigen Datei-Pfad zum öffnen hat nach dem Prinzip Teamviewer.
            ' Liste zum Füllen des Stringarrays zur Einstellung der Namen der Spalten
            Dim ary_columnName As String()
            Dim myList As New List(Of String)()
            myList.Add("Nebenstelle")                                                       ' ary_columnName(0)
            myList.Add("Firma")
            myList.Add("Rufnummer")                                                         ' ary_columnName(2)
            myList.Add("Typ")
            myList.Add("Datum")                                                             ' ary_columnName(4)
            myList.Add("Dauer")                                                             ' ary_columnName(5)
            ary_columnName = myList.ToArray()

            Dim rowCount As Integer = 0                                                     ' Der rowCount zählt die als Datensätze erkannten Zeilen der Datei.
            Using TxtReader As New FileIO.TextFieldParser(tbx_durchsuchen.Text)             ' TextFieldParser zum Einlesen einer csv-Datei (statisch festgelegt)
                TxtReader.TextFieldType = FileIO.FieldType.Delimited
                TxtReader.SetDelimiters(";")

                lbx_status.Items.Add(tbx_durchsuchen.Text & " geöffnet...")

                ' Deklaration der Komponenten zum Lesen und Speichern in DataTable
                Dim Row As DataRow
                Dim Upperbound As Integer
                Dim CurrentRow As String()
                Dim FieldComputerSplit As String()

                ' Einlese-Schleife, die in DataTable speichert
                Dim zeilenCount As Integer = 0                                              ' ähnliche Funktion wie rowCount (siehe oben), aber zählt jede einzelne Zeile in der Datei
                While Not TxtReader.EndOfData
                    CurrentRow = TxtReader.ReadFields()
                    Upperbound = ary_columnName.GetUpperBound(0)
                    If zeilenCount > 0 Then                                                 ' Die Zeile 0 und die Zeile 1 mit den Feldüberschriften sollen damit übersprungen werden.
                        If csvTable Is Nothing Then
                            csvTable = New DataTable("csvTable")
                            Build_csvTable(Upperbound, ary_columnName)                      ' Funktion zum erstellen der Spalten
                        End If
                        FieldComputerSplit = Split(CurrentRow(1), ", ")                     ' splittet das Feld "Computer" zu "Firma" und "Name"
                        Row = csvTable.NewRow
                        Dim ColumnCount As Integer = 0
                        While ColumnCount < 5
                            If ary_columnName(ColumnCount) = "Firma" Then
                                Row(ary_columnName(ColumnCount)) = FieldComputerSplit(0)
                            ElseIf ary_columnName(ColumnCount) = "Typ" Then
                                Row(ary_columnName(ColumnCount)) = ""
                            Else
                                Row(ary_columnName(ColumnCount)) = CurrentRow(ColumnCount)
                            End If
                            ColumnCount += 1
                        End While
                        Row(ary_columnName(ColumnCount)) = CurrentRow(ColumnCount + 1) ' füllt Dauer
                        csvTable.Rows.Add(Row)
                        rowCount += 1
                    End If
                    zeilenCount += 1
                End While
            End Using

            ' Anzeige
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.DataSource = csvTable
            lbx_status.Items.Add(rowCount.ToString & " Datensätze gelesen.")

            'Setze String zum Speichern
            StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Rufnummer, Nebenstelle, Dauer) "
        Else
            MsgBox("Keine gültige Datei ausgewählt! Bitte wählen Sie eine Datei mit Format '\connectionreport (n).csv' aus!")
        End If

    End Sub

    Private Sub btn_speichern_Click(sender As Object, e As EventArgs) Handles btn_speichern.Click

        'Check, ob es Daten zum Speichern gibt
        If csvTable_Check() Then

            ' Initialiesierung der Verbindungs- und Kopierobjekte
            Dim eingefugtCount As Integer = 0
            Dim fehlerCount As Integer = 0
            Using Connection As SqlConnection = New SqlConnection("integrated security=SSPI;persist security info=false;data source=WIN2008-R2\WIN2008R2;initial catalog=Test_Praktikum")
                Dim StrSQL_Read As String = "Select * From csv_Inhalt_Firma"
                'StrSQL_Insert &= "Values (@Typ, @Datum, @Name, @Rufnummer, @Nebenstelle, @[Eigene Rufnummer], @Dauer)"
                Dim currentrow As DataRow

                Try
                    Connection.Open()                                                          ' Verbindung herstellen

                    'Erst überprüfen welcher Button geklickt wurde (über den String)
                    If StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Rufnummer, Nebenstelle, Dauer) " Then
                        'Überprüfen und speichern Version mit Insert-Befehl (einzelne Datensätze)
                        For i = 0 To csvTable.Rows.Count - 1
                            currentrow = csvTable.Rows.Item(i)
                            If Überprüfung(Connection, currentrow) Then                        ' Wenn Datensatz neu, dann speichern
                                StrSQL_Insert &= "Values ('" & currentrow.Field(Of String)("Typ") & "', '" & currentrow.Field(Of DateTime)("Datum") & "', '"
                                StrSQL_Insert &= currentrow.Field(Of String)("Firma") & "', '" & currentrow.Field(Of String)("Rufnummer") & "', '"
                                StrSQL_Insert &= currentrow.Field(Of String)("Nebenstelle") & "','" & currentrow.Field(Of String)("Dauer") & "')"
                                Dim cmd_Insert As New SqlCommand(StrSQL_Insert, Connection)
                                cmd_Insert.ExecuteNonQuery()
                                ' String Reset, gegen doppelte Tabellenfüllung in einer SQL-Anweisung
                                StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Rufnummer, Nebenstelle, Dauer) "
                                eingefugtCount += 1
                            Else
                                fehlerCount += 1
                            End If
                        Next
                    ElseIf StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Name, Rufnummer, Nebenstelle, [Eigene Rufnummer], Dauer) " Then
                        'Überprüfen und speichern Version mit Insert-Befehl (einzelne Datensätze speichern)
                        For i = 0 To csvTable.Rows.Count - 1
                            currentrow = csvTable.Rows.Item(i)
                            If Überprüfung(Connection, currentrow) Then                        ' Wenn Datensatz neu, dann speichern
                                StrSQL_Insert &= "Values ('" & currentrow.Field(Of String)("Typ") & "', '" & currentrow.Field(Of DateTime)("Datum") & "', '"
                                StrSQL_Insert &= currentrow.Field(Of String)("Firma") & "', '" & currentrow.Field(Of String)("Name") & "', '"
                                StrSQL_Insert &= currentrow.Field(Of String)("Rufnummer") & "', '" & currentrow.Field(Of String)("Nebenstelle") & "','"
                                StrSQL_Insert &= currentrow.Field(Of String)("Eigene Rufnummer") & "', '" & currentrow.Field(Of String)("Dauer") & "')"
                                Dim cmd_Insert As New SqlCommand(StrSQL_Insert, Connection)
                                cmd_Insert.ExecuteNonQuery()
                                StrSQL_Insert = "Insert csv_Inhalt_Firma (Typ, Datum, Firma, Name, Rufnummer, Nebenstelle, [Eigene Rufnummer], Dauer) "     ' String Reset, gegen doppelte Tabellenfüllung in einer SQL-Anweisung
                                eingefugtCount += 1
                            Else
                                fehlerCount += 1
                            End If
                        Next
                    End If

                    ' Auslesen aus der Tabelle der Datenbank zum Zählen der gesamten Datensätze
                    Dim cmd_Read As SqlCommand = New SqlCommand(StrSQL_Read, Connection)       ' SQL-Kommando initiieren (Auslesen)
                    Dim dr As SqlDataReader = cmd_Read.ExecuteReader()                         ' SQL-Kommando durchführen mit Initialiesierung des DataRaeders
                    sqlTable = New DataTable
                    sqlTable.Load(dr)
                    dr.Close()

                Catch exc As Exception
                    MsgBox("Fehlermeldung: " & exc.Message)
                End Try
            End Using

            lbx_status.Items.Add(eingefugtCount.ToString & " neu eingefügte Datensätze.")
            lbx_status.Items.Add(fehlerCount.ToString & " fehlerhafte/doppelte Datensätze.")
            lbx_status.Items.Add(sqlTable.Rows.Count & " Datensätze in Datenbank vorhanden.")
            csvTable = Nothing

        End If

    End Sub

    Private Sub btn_auswertung_Click(sender As Object, e As EventArgs) Handles btn_auswertung.Click
        Form2.Text = "Auswertung Telefonate"
        Form2.Show()
    End Sub
    Private Function Build_csvTable(Upperbound As Integer, ary_columnname As String())
        Dim Column As DataColumn
        For ColumnCount = 0 To Upperbound
            Column = New DataColumn()
            If ary_columnname(ColumnCount) = "Datum" Then
                Column.DataType = Type.GetType("System.DateTime")
            Else
                Column.DataType = Type.GetType("System.String")
            End If
            Column.ColumnName = ary_columnname(ColumnCount)
            Column.Caption = ary_columnname(ColumnCount)            ' Feldüberschrift oberhalb der DataTable setzen
            Column.ReadOnly = False
            Column.Unique = False
            csvTable.Columns.Add(Column)
        Next
        Return csvTable.Columns
    End Function
    Private Function csvTable_Check() As Boolean
        Dim blnCheck As Boolean = True
        If csvTable Is Nothing Then
            MsgBox("Keine Datei eingelesen oder eingelesene Datei bereits gespeichert. Bitte wählen Sie eine noch nicht gespeicherte Datei aus...")
            blnCheck = False
        End If
        Return blnCheck
    End Function
    Private Function Überprüfung(Connection As SqlConnection, currentrow As DataRow) As Boolean

        Dim Test As Boolean = True                                            ' Der Datensatz ist grundsätzlich immer erstmal neu.
        Dim ary_Datenbank(0 To 2) As String
        Dim ary_CSV(0 To 2) As String

        'Stringarray der CSV-Tabelle füllen (begrenzt auf Primärschlüssel in der Datenbank)
        ary_CSV(0) = currentrow.Item("Datum").ToString
        ary_CSV(1) = currentrow.Item("Rufnummer").ToString
        ary_CSV(2) = currentrow.Item("Dauer").ToString

        ' Auslesen aus der Tabelle der Datenbank
        Dim StrSQL_Read As String = "Select * From csv_Inhalt_Firma"
        Dim cmd_Read As SqlCommand = New SqlCommand(StrSQL_Read, Connection)  ' SQL-Kommando initiieren (Auslesen)
        Dim dr As SqlDataReader = cmd_Read.ExecuteReader()                    ' SQL-Kommando durchführen mit Initialiesierung des DataRaeders
        sqlTable = New DataTable
        sqlTable.Load(dr)
        dr.Close()

        'Vergleichen der Primärschlüssel
        For i = 0 To sqlTable.Rows.Count - 1
            ary_Datenbank(0) = sqlTable.Rows.Item(i).Item("Datum").ToString
            ary_Datenbank(1) = sqlTable.Rows.Item(i).Item("Rufnummer").ToString
            ary_Datenbank(2) = sqlTable.Rows.Item(i).Item("Dauer").ToString
            If (ary_Datenbank(0) = ary_CSV(0)) Then
                If (ary_Datenbank(1) = ary_CSV(1)) Then
                    If (ary_Datenbank(2) = ary_CSV(2)) Then
                        Test = False
                        Exit For
                    End If
                End If
            End If
        Next

        Return Test

    End Function
    Private Function ConvertToInt(str As String) As Integer
        Dim Int1 As Integer
        Dim ary_String As String()
        ary_String = Split(str, ":")
        Int1 = CInt(ary_String(0)) * 60 + CInt(ary_String(1))
        Return Int1
    End Function
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

End Class
