<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Workspace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BitrateLabel = New System.Windows.Forms.Label()
        Me.EmitterLabel = New System.Windows.Forms.Label()
        Me.EmitCycleBox = New System.Windows.Forms.TextBox()
        Me.IntervalBox = New System.Windows.Forms.TextBox()
        Me.BounceLabel = New System.Windows.Forms.Label()
        Me.BounceBox = New System.Windows.Forms.TextBox()
        Me.FrictionLabel = New System.Windows.Forms.Label()
        Me.FrictionBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BitrateLabel
        '
        Me.BitrateLabel.AutoSize = True
        Me.BitrateLabel.Location = New System.Drawing.Point(433, 35)
        Me.BitrateLabel.Name = "BitrateLabel"
        Me.BitrateLabel.Size = New System.Drawing.Size(73, 13)
        Me.BitrateLabel.TabIndex = 1
        Me.BitrateLabel.Text = "Timer interval:"
        '
        'EmitterLabel
        '
        Me.EmitterLabel.AutoSize = True
        Me.EmitterLabel.Location = New System.Drawing.Point(404, 9)
        Me.EmitterLabel.Name = "EmitterLabel"
        Me.EmitterLabel.Size = New System.Drawing.Size(102, 13)
        Me.EmitterLabel.TabIndex = 3
        Me.EmitterLabel.Text = "Cycles per emission:"
        '
        'EmitCycleBox
        '
        Me.EmitCycleBox.Location = New System.Drawing.Point(512, 6)
        Me.EmitCycleBox.Name = "EmitCycleBox"
        Me.EmitCycleBox.Size = New System.Drawing.Size(60, 20)
        Me.EmitCycleBox.TabIndex = 5
        Me.EmitCycleBox.Text = "10"
        '
        'IntervalBox
        '
        Me.IntervalBox.Location = New System.Drawing.Point(512, 32)
        Me.IntervalBox.Name = "IntervalBox"
        Me.IntervalBox.Size = New System.Drawing.Size(60, 20)
        Me.IntervalBox.TabIndex = 6
        Me.IntervalBox.Text = "10"
        '
        'BounceLabel
        '
        Me.BounceLabel.AutoSize = True
        Me.BounceLabel.Location = New System.Drawing.Point(578, 9)
        Me.BounceLabel.Name = "BounceLabel"
        Me.BounceLabel.Size = New System.Drawing.Size(47, 13)
        Me.BounceLabel.TabIndex = 7
        Me.BounceLabel.Text = "Bounce:"
        '
        'BounceBox
        '
        Me.BounceBox.Location = New System.Drawing.Point(631, 6)
        Me.BounceBox.Name = "BounceBox"
        Me.BounceBox.Size = New System.Drawing.Size(57, 20)
        Me.BounceBox.TabIndex = 8
        Me.BounceBox.Text = "0.8"
        '
        'FrictionLabel
        '
        Me.FrictionLabel.AutoSize = True
        Me.FrictionLabel.Location = New System.Drawing.Point(581, 35)
        Me.FrictionLabel.Name = "FrictionLabel"
        Me.FrictionLabel.Size = New System.Drawing.Size(44, 13)
        Me.FrictionLabel.TabIndex = 9
        Me.FrictionLabel.Text = "Friction:"
        '
        'FrictionBox
        '
        Me.FrictionBox.Location = New System.Drawing.Point(631, 32)
        Me.FrictionBox.Name = "FrictionBox"
        Me.FrictionBox.Size = New System.Drawing.Size(57, 20)
        Me.FrictionBox.TabIndex = 10
        Me.FrictionBox.Text = "0.8"
        '
        'Workspace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 369)
        Me.Controls.Add(Me.FrictionBox)
        Me.Controls.Add(Me.FrictionLabel)
        Me.Controls.Add(Me.BounceBox)
        Me.Controls.Add(Me.BounceLabel)
        Me.Controls.Add(Me.IntervalBox)
        Me.Controls.Add(Me.EmitCycleBox)
        Me.Controls.Add(Me.EmitterLabel)
        Me.Controls.Add(Me.BitrateLabel)
        Me.Name = "Workspace"
        Me.Text = "BouncingParticles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BitrateLabel As System.Windows.Forms.Label
    Friend WithEvents EmitterLabel As System.Windows.Forms.Label
    Friend WithEvents EmitCycleBox As System.Windows.Forms.TextBox
    Friend WithEvents IntervalBox As System.Windows.Forms.TextBox
    Friend WithEvents BounceLabel As System.Windows.Forms.Label
    Friend WithEvents BounceBox As System.Windows.Forms.TextBox
    Friend WithEvents FrictionLabel As System.Windows.Forms.Label
    Friend WithEvents FrictionBox As System.Windows.Forms.TextBox

End Class
