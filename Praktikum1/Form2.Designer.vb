<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.btn_abbrechen = New System.Windows.Forms.Button()
        Me.btn_anzeigen = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.rbtn_alle = New System.Windows.Forms.RadioButton()
        Me.rbtn_letztewoche = New System.Windows.Forms.RadioButton()
        Me.rbtn_letztermonat = New System.Windows.Forms.RadioButton()
        Me.lbl_header = New System.Windows.Forms.Label()
        Me.gbx_auswahl = New System.Windows.Forms.GroupBox()
        Me.dtp_ende = New System.Windows.Forms.DateTimePicker()
        Me.dtp_anfang = New System.Windows.Forms.DateTimePicker()
        Me.rbtn_intervall = New System.Windows.Forms.RadioButton()
        Me.lbl_bis = New System.Windows.Forms.Label()
        Me.btn_graphik = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbx_auswahl.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_abbrechen
        '
        Me.btn_abbrechen.Location = New System.Drawing.Point(548, 100)
        Me.btn_abbrechen.Name = "btn_abbrechen"
        Me.btn_abbrechen.Size = New System.Drawing.Size(108, 23)
        Me.btn_abbrechen.TabIndex = 0
        Me.btn_abbrechen.Text = "Abbrechen"
        Me.btn_abbrechen.UseVisualStyleBackColor = True
        '
        'btn_anzeigen
        '
        Me.btn_anzeigen.Location = New System.Drawing.Point(548, 29)
        Me.btn_anzeigen.Name = "btn_anzeigen"
        Me.btn_anzeigen.Size = New System.Drawing.Size(108, 23)
        Me.btn_anzeigen.TabIndex = 1
        Me.btn_anzeigen.Text = "Anzeigen"
        Me.btn_anzeigen.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(49, 155)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(556, 399)
        Me.DataGridView2.TabIndex = 2
        '
        'rbtn_alle
        '
        Me.rbtn_alle.AutoSize = True
        Me.rbtn_alle.Checked = True
        Me.rbtn_alle.Location = New System.Drawing.Point(6, 16)
        Me.rbtn_alle.Name = "rbtn_alle"
        Me.rbtn_alle.Size = New System.Drawing.Size(42, 17)
        Me.rbtn_alle.TabIndex = 3
        Me.rbtn_alle.TabStop = True
        Me.rbtn_alle.Text = "Alle"
        Me.rbtn_alle.UseVisualStyleBackColor = True
        '
        'rbtn_letztewoche
        '
        Me.rbtn_letztewoche.AutoSize = True
        Me.rbtn_letztewoche.Location = New System.Drawing.Point(6, 37)
        Me.rbtn_letztewoche.Name = "rbtn_letztewoche"
        Me.rbtn_letztewoche.Size = New System.Drawing.Size(92, 17)
        Me.rbtn_letztewoche.TabIndex = 4
        Me.rbtn_letztewoche.Text = "Letzte Woche"
        Me.rbtn_letztewoche.UseVisualStyleBackColor = True
        '
        'rbtn_letztermonat
        '
        Me.rbtn_letztermonat.AutoSize = True
        Me.rbtn_letztermonat.Location = New System.Drawing.Point(6, 58)
        Me.rbtn_letztermonat.Name = "rbtn_letztermonat"
        Me.rbtn_letztermonat.Size = New System.Drawing.Size(90, 17)
        Me.rbtn_letztermonat.TabIndex = 5
        Me.rbtn_letztermonat.Text = "Letzter Monat"
        Me.rbtn_letztermonat.UseVisualStyleBackColor = True
        '
        'lbl_header
        '
        Me.lbl_header.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lbl_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_header.Location = New System.Drawing.Point(49, 141)
        Me.lbl_header.Name = "lbl_header"
        Me.lbl_header.Size = New System.Drawing.Size(556, 13)
        Me.lbl_header.TabIndex = 8
        Me.lbl_header.Text = "Anrufe in der Zeit von    bis    "
        Me.lbl_header.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbx_auswahl
        '
        Me.gbx_auswahl.Controls.Add(Me.dtp_ende)
        Me.gbx_auswahl.Controls.Add(Me.dtp_anfang)
        Me.gbx_auswahl.Controls.Add(Me.rbtn_intervall)
        Me.gbx_auswahl.Controls.Add(Me.rbtn_letztermonat)
        Me.gbx_auswahl.Controls.Add(Me.rbtn_alle)
        Me.gbx_auswahl.Controls.Add(Me.rbtn_letztewoche)
        Me.gbx_auswahl.Controls.Add(Me.lbl_bis)
        Me.gbx_auswahl.Location = New System.Drawing.Point(29, 23)
        Me.gbx_auswahl.Name = "gbx_auswahl"
        Me.gbx_auswahl.Size = New System.Drawing.Size(513, 100)
        Me.gbx_auswahl.TabIndex = 9
        Me.gbx_auswahl.TabStop = False
        Me.gbx_auswahl.Text = "Auswahl"
        '
        'dtp_ende
        '
        Me.dtp_ende.Location = New System.Drawing.Point(303, 79)
        Me.dtp_ende.Name = "dtp_ende"
        Me.dtp_ende.Size = New System.Drawing.Size(200, 20)
        Me.dtp_ende.TabIndex = 8
        '
        'dtp_anfang
        '
        Me.dtp_anfang.Location = New System.Drawing.Point(88, 79)
        Me.dtp_anfang.Name = "dtp_anfang"
        Me.dtp_anfang.Size = New System.Drawing.Size(196, 20)
        Me.dtp_anfang.TabIndex = 7
        '
        'rbtn_intervall
        '
        Me.rbtn_intervall.AutoSize = True
        Me.rbtn_intervall.Location = New System.Drawing.Point(6, 79)
        Me.rbtn_intervall.Name = "rbtn_intervall"
        Me.rbtn_intervall.Size = New System.Drawing.Size(86, 17)
        Me.rbtn_intervall.TabIndex = 6
        Me.rbtn_intervall.TabStop = True
        Me.rbtn_intervall.Text = "Intervall von "
        Me.rbtn_intervall.UseVisualStyleBackColor = True
        '
        'lbl_bis
        '
        Me.lbl_bis.AutoSize = True
        Me.lbl_bis.Location = New System.Drawing.Point(285, 83)
        Me.lbl_bis.Name = "lbl_bis"
        Me.lbl_bis.Size = New System.Drawing.Size(20, 13)
        Me.lbl_bis.TabIndex = 9
        Me.lbl_bis.Text = "bis"
        '
        'btn_graphik
        '
        Me.btn_graphik.Location = New System.Drawing.Point(548, 65)
        Me.btn_graphik.Name = "btn_graphik"
        Me.btn_graphik.Size = New System.Drawing.Size(107, 23)
        Me.btn_graphik.TabIndex = 10
        Me.btn_graphik.Text = "Graphik"
        Me.btn_graphik.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 590)
        Me.Controls.Add(Me.btn_graphik)
        Me.Controls.Add(Me.gbx_auswahl)
        Me.Controls.Add(Me.lbl_header)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.btn_anzeigen)
        Me.Controls.Add(Me.btn_abbrechen)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbx_auswahl.ResumeLayout(False)
        Me.gbx_auswahl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_abbrechen As Button
    Friend WithEvents btn_anzeigen As Button
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents rbtn_alle As RadioButton
    Friend WithEvents rbtn_letztewoche As RadioButton
    Friend WithEvents rbtn_letztermonat As RadioButton
    Friend WithEvents lbl_header As Label
    Friend WithEvents gbx_auswahl As GroupBox
    Friend WithEvents lbl_bis As Label
    Friend WithEvents dtp_ende As DateTimePicker
    Friend WithEvents dtp_anfang As DateTimePicker
    Friend WithEvents rbtn_intervall As RadioButton
    Friend WithEvents btn_graphik As Button
End Class
