Class Atom

    Dim myLastX As Integer
    Dim myLastY As Integer

    Dim myX As Integer
    Dim myY As Integer

    Dim myDiameter As Integer
    Dim myVelocity As VectorQuantity
    Dim myAcceleration As VectorQuantity

    Dim particlePen As New Pen(Brushes.Black, 2)
    Dim eraserPen As New Pen(Workspace.BackColor, 2)

    Property X() As Integer
        Get
            Return myX
        End Get
        Set(ByVal value As Integer)
            myX = value
        End Set
    End Property
    Property Y() As Integer
        Get
            Return myY
        End Get
        Set(ByVal value As Integer)
            myY = value
        End Set
    End Property
    Property Diameter() As Integer
        Get
            Return myDiameter
        End Get
        Set(ByVal value As Integer)
            myDiameter = value
        End Set
    End Property

    Sub New(ByVal x As Integer, ByVal y As Integer, ByVal diameter As Integer, ByVal gravity As Integer)

        'New still particle
        myVelocity = New VectorQuantity(0, 0)
        myAcceleration = New VectorQuantity(0, 0)
        GeneralInitialise(x, y, diameter, gravity)

    End Sub
    Sub New(ByVal x As Integer, ByVal y As Integer, ByVal diameter As Integer, ByVal acceleration As VectorQuantity, ByVal velocity As VectorQuantity, ByVal gravity As Integer)

        'New moving particle
        myVelocity = velocity
        myAcceleration = acceleration
        GeneralInitialise(x, y, diameter, gravity)

    End Sub
    Sub GeneralInitialise(ByVal x As Integer, ByVal y As Integer, ByVal diameter As Integer, ByVal gravity As Integer)

        'Intialisations common to constructors
        Me.X = x
        Me.Y = y
        Me.Diameter = diameter
        Me.SubjectToGravity(gravity)

    End Sub

    Function IsOnOrBelow(ByVal level As Integer) As Boolean

        If Me.Y + Me.Diameter >= level Then
            Return True
        End If

    End Function
    Sub SubjectToGravity(ByVal gravity As Integer)
        myAcceleration.Y += gravity

    End Sub
    Sub Accelerate()
        myVelocity.X += myAcceleration.X
        myVelocity.Y += myAcceleration.Y

    End Sub
    Sub Move(ByVal Ground As Integer)

        myLastX = myX
        myLastY = myY

        myX += myVelocity.X
        myY += myVelocity.Y

        'Stay above ground
        If Me.IsOnOrBelow(Ground) Then
            myY = Ground - myDiameter
        End If

        'Stay on-screen in x-direction
        If myX < 0 Then
            myX = Workspace.Width
        ElseIf myX > Workspace.Width Then
            myX = 0
        End If

    End Sub

    Sub Draw(ByVal gr As Graphics)

        'Erase old
        Me.UnDrawLast(gr)

        'Draw new
        gr.DrawEllipse(particlePen, Me.X, Me.Y, Me.Diameter, CInt(Me.Diameter))

    End Sub
    Sub UnDrawLast(ByVal gr As Graphics)

        gr.DrawEllipse(eraserPen, myLastX, myLastY, Me.Diameter, CInt(Me.Diameter))

    End Sub
    Sub UnDraw(ByVal gr As Graphics)
        Dim eraserPen As New Pen(Workspace.BackColor, 2)
        gr.DrawEllipse(eraserPen, myX, myY, Me.Diameter, Me.Diameter)

    End Sub

    Function RolledToHalt() As Boolean
        Return Me.Still And myAcceleration.X = 0 And myAcceleration.Y = 0

    End Function
    Function Still() As Boolean
        Return myVelocity.X = 0 And myVelocity.Y = 0

    End Function

    Sub FrictionX(ByVal frictionFactor As Double)

        Dim NewXVelocity As Integer = CInt(myVelocity.X * frictionFactor)
        If NewXVelocity = myVelocity.X Then
            myVelocity.X = 0
        Else
            myVelocity.X = NewXVelocity
        End If

    End Sub

    Sub BounceOff(ByVal level As Integer, Optional ByVal bounceFactor As Double = 0.8, Optional ByVal frictionFactor As Double = 0.8)

        If Me.IsOnOrBelow(level) Then

            If myY > level Then
                myY = level
            End If

            myVelocity.Y = CInt((-myVelocity.Y) * bounceFactor)

            If Math.Abs(myVelocity.Y) = myVelocity.Y Then
                'Stop on surface
                myAcceleration.Y = 0
                myVelocity.Y = 0
                Me.FrictionX(frictionFactor)
            Else
                'Bouncyball spin effect
                myVelocity.X += CInt(Int(Rnd() * 3) - 1)
            End If

        End If

    End Sub
End Class