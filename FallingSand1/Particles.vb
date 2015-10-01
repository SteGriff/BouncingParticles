Option Strict On

Imports System.Threading

Public Class Workspace

    'Moddable things
    Dim GroundLevel As Integer = 500
    Dim Bounce As Double = 0.8
    Dim Friction As Double = 0.8
    Dim Interval As Integer = 100

    'Fixed things
    Dim gr As Graphics
    Dim Atoms As New List(Of Atom)
    Dim Emitter As Emitter
    Dim Cycles As Integer = 0
    Dim AccelerationDueToGravity As Integer = 1
    Dim GroundPen As New Pen(Color.SaddleBrown, 4)
    Dim GroundEraser As New Pen(Me.BackColor, 4)
    Dim RightBound As Integer

    'Form fields
    Dim EmitCycle As Integer = 10

    Function SafeInt(ByVal aString As String, lowerLimit As Integer) As Integer

        Dim Result As Integer
        Dim Ok As Boolean = Int32.TryParse(aString, Result)

        Return CInt(IIf(Ok And Result >= lowerLimit, Result, lowerLimit))

    End Function
    Function SafeDouble(ByVal aString As String) As Double

        Dim Result As Double

        Dim Ok As Boolean = Double.TryParse(aString, Result)
        Return CDbl(IIf(Ok And Result > 0, Result, 1))

    End Function

    Private Sub Workspace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click

        Dim mouseEv = DirectCast(e, MouseEventArgs)

        If (mouseEv.Button = Windows.Forms.MouseButtons.Left) Then
            If mouseEv.Y > GroundLevel Then
                MoveGround(mouseEv.Y)
            Else
                Emitter.Move(mouseEv.X, mouseEv.Y)
            End If
        Else
            Atoms.Add(New Atom(mouseEv.X, mouseEv.Y, 10, AccelerationDueToGravity))
        End If

    End Sub

    Sub MoveGround(newLevel As Integer)
        SyncLock gr
            gr.DrawLine(GroundEraser, 0, GroundLevel + 4, RightBound, GroundLevel + 4)
        End SyncLock

        GroundLevel = newLevel
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load

        Randomize()

        Emitter = New Emitter(200, 200)

        Me.Width = 800
        Me.Height = 600

    End Sub

    Sub PaintEverything()

        SyncLock gr

            'Draw ground
            gr.DrawLine(GroundPen, 0, GroundLevel + 4, RightBound, GroundLevel + 4)

            'Draw the emitter
            Emitter.Draw(gr)

            Dim this As Integer = 0
            While this < Atoms.Count - 1

                Atoms(this).UnDrawLast(gr)
                Atoms(this).Draw(gr)

                'Remove if static on ground and process the new current atom
                If Atoms(this).RolledToHalt Then
                    Atoms(this).UnDraw(gr)
                    Atoms.Remove(Atoms(this))
                Else
                    this += 1
                End If

            End While

        End SyncLock
    End Sub

    Private Sub DoAllLogic()

        Cycles += 1

        If Cycles >= EmitCycle Then
            'Make an atom
            Emitter.Emit(Atoms, AccelerationDueToGravity)
            Cycles = 0
        End If

        Dim this As Integer = 0
        While this < Atoms.Count - 1

            'Cycle through all atoms and apply physical rules
            Atoms(this).BounceOff(GroundLevel, Bounce, Friction)
            Atoms(this).Accelerate()
            Atoms(this).Move(GroundLevel, RightBound)
            this += 1

        End While

    End Sub

    Private Sub IntervalBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervalBox.TextChanged
        Interval = SafeInt(IntervalBox.Text, 1)

    End Sub

    Private Sub BounceBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BounceBox.TextChanged
        Bounce = SafeDouble(BounceBox.Text)

    End Sub

    Private Sub FrictionBox_TextChanged(sender As Object, e As EventArgs) Handles FrictionBox.TextChanged
        Friction = SafeDouble(FrictionBox.Text)

    End Sub

    Private Sub EmitCycleBox_TextChanged(sender As Object, e As EventArgs) Handles EmitCycleBox.TextChanged
        EmitCycle = SafeInt(EmitCycleBox.Text, 5)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim GraphicsThread As Thread = Nothing
    Dim LogicThread As Thread = Nothing

    Private Sub SetupThreads()

        If GraphicsThread Is Nothing Then
            GraphicsThread = New Thread(New ThreadStart(AddressOf DoGraphics))
            GraphicsThread.Start()
        End If

        If LogicThread Is Nothing Then
            LogicThread = New Thread(New ThreadStart(AddressOf DoLogic))
            LogicThread.Start()
        End If

    End Sub

    Private Sub DoGraphics()

        Thread.Sleep(1000)

        Do
            Thread.Sleep(Interval)
            PaintEverything()
        Loop

    End Sub

    Private Sub DoLogic()

        Thread.Sleep(1000)

        Do
            Thread.Sleep(Interval)
            DoAllLogic()
        Loop

    End Sub

    Private Sub Workspace_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If gr Is Nothing Then
            gr = Me.CreateGraphics
        End If

        SetupThreads()

    End Sub

    Private Sub Workspace_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        RightBound = Me.Width

        SyncLock gr
            gr = Me.CreateGraphics
        End SyncLock

    End Sub
End Class
