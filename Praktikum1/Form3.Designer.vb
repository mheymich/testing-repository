<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.cht_graphik = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.cht_graphik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cht_graphik
        '
        Me.cht_graphik.BackColor = System.Drawing.Color.Gray
        Me.cht_graphik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX2.Interval = 1.0R
        ChartArea1.AxisY.Interval = 1.0R
        ChartArea1.AxisY.Title = "Gesamtzeit in std"
        ChartArea1.Name = "ChartArea1"
        Me.cht_graphik.ChartAreas.Add(ChartArea1)
        Me.cht_graphik.Location = New System.Drawing.Point(4, 28)
        Me.cht_graphik.Name = "cht_graphik"
        Me.cht_graphik.Padding = New System.Windows.Forms.Padding(10)
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series1.IsValueShownAsLabel = True
        Series1.IsVisibleInLegend = False
        Series1.Name = "Series1"
        Series1.XValueMember = "DataBindings"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series1.YValuesPerPoint = 5
        Me.cht_graphik.Series.Add(Series1)
        Me.cht_graphik.Size = New System.Drawing.Size(748, 435)
        Me.cht_graphik.TabIndex = 0
        Me.cht_graphik.Text = "Anrufe der ausgewählten Zeitspanne"
        Title1.BackColor = System.Drawing.Color.White
        Title1.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.Name = "Title1"
        Title1.Text = "Gesamtgesprächszeit der verschiedenen Anrufer"
        Me.cht_graphik.Titles.Add(Title1)
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 590)
        Me.Controls.Add(Me.cht_graphik)
        Me.Name = "Form3"
        Me.Text = "Auswertung Graphik"
        CType(Me.cht_graphik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cht_graphik As DataVisualization.Charting.Chart
End Class
