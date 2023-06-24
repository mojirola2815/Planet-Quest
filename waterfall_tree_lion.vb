Public Class PlanetQuest
 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
 
        ' Set the title of the form.
        Me.Text = "Planet Quest"
 
        ' Set the background color of the form.
        Me.BackColor = Color.Teal
 
        ' Set the size of the form.
        Me.ClientSize = New Size(480, 520)
 
        ' Display a MessageBox.
        MessageBox.Show("Welcome to Planet Quest!")
 
    End Sub
 
    ' Declare the boolean for the game state.
    Dim gameOn As Boolean = False
 
    ' Declare the variable for the user's score.
    Dim score As Integer = 0
 
    Private Sub startGameButton_Click(sender As Object, e As EventArgs) Handles startGameButton.Click
 
        ' Change the boolean to begin the game.
        gameOn = True
 
        ' Set the startGameButton to invisible.
        startGameButton.Visible = False
 
        ' Set the initial position of the planet.
        planetPictureBox.Top = 66
        planetPictureBox.Left = 128
 
        ' Set the initial position of the UFO.
        ufoPictureBox.Top = 50
        ufoPictureBox.Left = -120
 
        ' Set the left arrow key to visible.
        leftArrowPictureBox.Visible = True
 
        ' Set the right arrow key to visible.
        rightArrowPictureBox.Visible = True
 
        ' Create a Timer object.
        Dim timer As Timer = New Timer()
 
        ' Set the Interval property of the Timer.
        timer.Interval = 10
 
        ' Connect the Timer to the Tick event.
        AddHandler timer.Tick, AddressOf timer_Tick
 
        ' Start the Timer.
        timer.Start()
 
    End Sub
 
    Private Sub timer_Tick(sender As Object, e As EventArgs)
 
        ' Move the UFO to the right if the game is running.
        If gameOn Then
            ufoPictureBox.Left += 5
        End If
 
        ' If the UFO gets to the edge of the screen, start moving it left.
        If ufoPictureBox.Left >= Me.ClientSize.Width - ufoPictureBox.Width Then
            ufoPictureBox.Left -= 5
        End If
 
    End Sub
 
    Private Sub leftArrowPictureBox_Click(sender As Object, e As EventArgs) Handles leftArrowPictureBox.Click
 
        ' Move the planet left.
        planetPictureBox.Left -= 20
 
        ' If the planet is off the screen, move it to the far right.
        If planetPictureBox.Left <= 0 Then
            planetPictureBox.Left = Me.ClientSize.Width
        End If
 
    End Sub
 
    Private Sub rightArrowPictureBox_Click(sender As Object, e As EventArgs) Handles rightArrowPictureBox.Click
 
        ' Move the planet right.
        planetPictureBox.Left += 20
 
        ' If the planet is off the screen, move it to the far left.
        If planetPictureBox.Left >= Me.ClientSize.Width Then
            planetPictureBox.Left = 0
        End If
 
    End Sub
 
    Private Sub ufoPictureBox_Click(sender As Object, e As EventArgs) Handles ufoPictureBox.Click
 
        ' If the game is over, display a message and exit.
        If Not gameOn Then
            MessageBox.Show("Game Over!")
            Exit Sub
        End If
 
        ' Increase the user's score.
        score += 1
 
        ' Display the user's score.
        scoreLabel.Text = "Score: " & score
 
    End Sub
 
End Class