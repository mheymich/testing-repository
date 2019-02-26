Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form3
    Private Sub cht_graphik_Layout(sender As Object, e As LayoutEventArgs) Handles cht_graphik.Layout
        ' Aus irgendeinem Grund durchläuft das Programm diese Methode genau zweimal
        ' Bei Fehler: "Ein Diagrammelement mit dem Namen '<Name>' ist bereits in 'SeriesCollection' vorhanden." die folgende Zeile dekomentieren, um die Balken zu reseten und neu initiieren zu können.
        cht_graphik.Series.Clear()

        cht_graphik.Series.Add("MySeries")
        cht_graphik.Series("MySeries").ChartType = SeriesChartType.Bar
        Dim i As Integer = 0
        For Each row As DataRow In Form1.sqlTable.Rows
            cht_graphik.Series("MySeries").Points.AddXY(Form1.sqlTable.Rows.Item(i).Item(0), Form1.sqlTable.Rows.Item(i).Item(2))
            i += 1
            If i > 14 Then Exit For
        Next
        cht_graphik.Series("MySeries").ChartArea = "ChartArea1"
        cht_graphik.DataBind()
    End Sub
End Class