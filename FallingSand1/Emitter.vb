Class Emitter
    Const EmitterSpan As Integer = 10

    Dim myMidX As Integer
    Dim myMidY As Integer

    Dim myLastMidX As Integer
    Dim myLastMidY As Integer

    Dim emitterPen As New Pen(Color.Red, 1)
    Dim eraserPen As New Pen(Workspace.BackColor, 1)

    Sub Emit(ByVal Atoms As List(Of Atom), ByVal gravity As Integer)

        Dim Diameter As Integer = CInt(Int(Rnd() * 8) + 10)
        Dim Acceleration As New VectorQuantity(0, 0)
        Dim Velocity As New VectorQuantity(CInt(Rnd() * 7) - 3, -15)

        Atoms.Add(New Atom(myMidX, myMidY, Diameter, Acceleration, Velocity, gravity))

    End Sub
    Sub New(ByVal X As Integer, ByVal Y As Integer)

        myMidX = X + CInt(EmitterSpan / 2)
        myMidY = Y + CInt(EmitterSpan / 2)

    End Sub
    Function Rectangle() As Drawing.Rectangle

        Dim X1 As Integer = myMidX - CInt(EmitterSpan / 2)
        Dim Y1 As Integer = myMidY - CInt(EmitterSpan / 2)

        Dim myShape As Drawing.Rectangle = New Drawing.Rectangle(X1, Y1, EmitterSpan, EmitterSpan)
        Return myShape

    End Function

    Function LastRectangle() As Drawing.Rectangle

        Dim X1 As Integer = myLastMidX - CInt(EmitterSpan / 2)
        Dim Y1 As Integer = myLastMidY - CInt(EmitterSpan / 2)

        Dim myShape As Drawing.Rectangle = New Drawing.Rectangle(X1, Y1, EmitterSpan, EmitterSpan)
        Return myShape

    End Function

    Sub Draw(gr As Graphics)

        If myLastMidX <> myMidX Or myLastMidY <> myMidY Then
            gr.DrawRectangle(eraserPen, LastRectangle)
        End If

        gr.DrawRectangle(emitterPen, Rectangle)

    End Sub

    Sub Move(X As Integer, Y As Integer)

        myLastMidX = myMidX
        myLastMidY = myMidY

        myMidX = X
        myMidY = Y

    End Sub

End Class
