Option Strict On

Public Class Workspace

    'Moddable things
    Dim GroundLevel As Integer = 500
    Dim Bounce As Double = 0.8
    Dim Friction As Double = 0.8

    'Fixed things
    Dim Atoms As New List(Of Atom)
    Dim Emitter As Emitter
    Dim Cycles As Integer = 0
    Dim AccelerationDueToGravity As Integer = 1

    Function SafeInt(ByVal aString As String) As Integer

        Dim Result As Integer
        Dim Ok As Boolean = Int32.TryParse(aString, Result)

        Return CInt(IIf(Ok And Result > 0, Result, 1))

    End Function
    Function SafeDouble(ByVal aString As String) As Double

        Dim Result As Double

        Dim Ok As Boolean = Double.TryParse(aString, Result)
        Return CDbl(IIf(Ok And Result > 0, Result, 1))

    End Function

    Private Sub Workspace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click

        Dim mouseEv = DirectCast(e, MouseEventArgs)

        If (mouseEv.Button = Windows.Forms.MouseButtons.Left) Then
            Emitter.Move(mouseEv.X, mouseEv.Y)
        Else
            Atoms.Add(New Atom(mouseEv.X, mouseEv.Y, 10, AccelerationDueToGravity))
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        Randomize()

        Emitter = New Emitter(200, 200)

        Me.Width = 800
        Me.Height = 600

    End Sub

    Dim gr As Graphics

    Private Sub Ticker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ticker.Tick
        PaintEverything(gr)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        gr = Me.CreateGraphics
        gr.Clear(Me.BackColor)

        'Draw ground
        Dim groundPen As New Pen(Color.SaddleBrown, 4)
        gr.DrawLine(groundPen, 0, GroundLevel + 4, Me.Width, GroundLevel + 4)

        PaintEverything(gr)

    End Sub

    Sub PaintEverything(ByVal gr As Graphics)

        Dim EmitCycle As Integer = SafeInt(EmitCycleBox.Text)

        Cycles += 1

        If Cycles >= EmitCycle Then
            'Make an atom
            Emitter.Emit(Atoms, AccelerationDueToGravity)
            AtomsLabel.Text = Atoms.Count.ToString
            Cycles = 0
        End If

        'Draw the emitter
        Emitter.Draw(gr)

        Dim this As Integer = 0

        While this < Atoms.Count - 1
            'Cycle through all atoms and apply physical rules

            Atoms(this).BounceOff(GroundLevel, Bounce, Friction)
            Atoms(this).Accelerate()
            Atoms(this).Move(GroundLevel)
            Atoms(this).Draw(gr)

            'Remove if static on ground and process the new current atom
            If Atoms(this).RolledToHalt Then
                Atoms(this).UnDraw(gr)
                Atoms.Remove(Atoms(this))
            Else
                this += 1
            End If

        End While

    End Sub


    Private Sub IntervalBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervalBox.TextChanged
        Ticker.Interval = SafeInt(IntervalBox.Text)

    End Sub

    Private Sub BounceBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BounceBox.TextChanged
        Bounce = SafeDouble(BounceBox.Text)

    End Sub

    Private Sub FrictionBox_TextChanged(sender As Object, e As EventArgs) Handles FrictionBox.TextChanged
        Friction = SafeDouble(FrictionBox.Text)

    End Sub
End Class
