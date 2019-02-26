<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_einlesen_fph = New System.Windows.Forms.Button()
        Me.btn_speichern = New System.Windows.Forms.Button()
        Me.lbl_inhalt = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_durchsuchen = New System.Windows.Forms.Button()
        Me.tbx_durchsuchen = New System.Windows.Forms.TextBox()
        Me.lbx_status = New System.Windows.Forms.ListBox()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.btn_auswertung = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_einlesen_tvw = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_einlesen_fph
        '
        Me.btn_einlesen_fph.Location = New System.Drawing.Point(4, 416)
        Me.btn_einlesen_fph.Name = "btn_einlesen_fph"
        Me.btn_einlesen_fph.Size = New System.Drawing.Size(134, 30)
        Me.btn_einlesen_fph.TabIndex = 2
        Me.btn_einlesen_fph.Text = "Einlesen Fritz!Phone"
        Me.btn_einlesen_fph.UseVisualStyleBackColor = True
        '
        'btn_speichern
        '
        Me.btn_speichern.Location = New System.Drawing.Point(593, 437)
        Me.btn_speichern.Name = "btn_speichern"
        Me.btn_speichern.Size = New System.Drawing.Size(75, 23)
        Me.btn_speichern.TabIndex = 4
        Me.btn_speichern.Text = "Speichern"
        Me.btn_speichern.UseVisualStyleBackColor = True
        '
        'lbl_inhalt
        '
        Me.lbl_inhalt.AutoSize = True
        Me.lbl_inhalt.Location = New System.Drawing.Point(29, 80)
        Me.lbl_inhalt.Name = "lbl_inhalt"
        Me.lbl_inhalt.Size = New System.Drawing.Size(0, 13)
        Me.lbl_inhalt.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(670, 399)
        Me.DataGridView1.TabIndex = 9
        '
        'btn_durchsuchen
        '
        Me.btn_durchsuchen.Location = New System.Drawing.Point(465, 436)
        Me.btn_durchsuchen.Name = "btn_durchsuchen"
        Me.btn_durchsuchen.Size = New System.Drawing.Size(97, 23)
        Me.btn_durchsuchen.TabIndex = 1
        Me.btn_durchsuchen.Text = "Durchsuchen"
        Me.btn_durchsuchen.UseVisualStyleBackColor = True
        '
        'tbx_durchsuchen
        '
        Me.tbx_durchsuchen.Location = New System.Drawing.Point(197, 437)
        Me.tbx_durchsuchen.Name = "tbx_durchsuchen"
        Me.tbx_durchsuchen.Size = New System.Drawing.Size(262, 20)
        Me.tbx_durchsuchen.TabIndex = 0
        Me.tbx_durchsuchen.Text = "D:\Praktikum\csv\"
        '
        'lbx_status
        '
        Me.lbx_status.AllowDrop = True
        Me.lbx_status.BackColor = System.Drawing.SystemColors.Menu
        Me.lbx_status.FormattingEnabled = True
        Me.lbx_status.Location = New System.Drawing.Point(146, 485)
        Me.lbx_status.Name = "lbx_status"
        Me.lbx_status.Size = New System.Drawing.Size(416, 95)
        Me.lbx_status.TabIndex = 8
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Location = New System.Drawing.Point(54, 487)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(86, 13)
        Me.lbl_status.TabIndex = 7
        Me.lbl_status.Text = "Statusprotokoll : "
        '
        'btn_auswertung
        '
        Me.btn_auswertung.Location = New System.Drawing.Point(593, 495)
        Me.btn_auswertung.Name = "btn_auswertung"
        Me.btn_auswertung.Size = New System.Drawing.Size(75, 23)
        Me.btn_auswertung.TabIndex = 5
        Me.btn_auswertung.Text = "Auswertung"
        Me.btn_auswertung.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(593, 557)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 6
        Me.btn_close.Text = "Schließen"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_einlesen_tvw
        '
        Me.btn_einlesen_tvw.Location = New System.Drawing.Point(4, 450)
        Me.btn_einlesen_tvw.Name = "btn_einlesen_tvw"
        Me.btn_einlesen_tvw.Size = New System.Drawing.Size(134, 30)
        Me.btn_einlesen_tvw.TabIndex = 3
        Me.btn_einlesen_tvw.Text = "Einlesen Teamviewer"
        Me.btn_einlesen_tvw.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 590)
        Me.Controls.Add(Me.btn_einlesen_tvw)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.btn_auswertung)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.lbx_status)
        Me.Controls.Add(Me.tbx_durchsuchen)
        Me.Controls.Add(Me.btn_durchsuchen)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lbl_inhalt)
        Me.Controls.Add(Me.btn_speichern)
        Me.Controls.Add(Me.btn_einlesen_fph)
        Me.Name = "Form1"
        Me.Text = "Praktikum1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_einlesen_fph As Button
    Friend WithEvents btn_speichern As Button
    Friend WithEvents lbl_inhalt As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btn_durchsuchen As Button
    Friend WithEvents tbx_durchsuchen As TextBox
    Friend WithEvents lbx_status As ListBox
    Friend WithEvents lbl_status As Label
    Friend WithEvents btn_auswertung As Button
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_einlesen_tvw As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
