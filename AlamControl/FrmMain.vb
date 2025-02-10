Imports System.ComponentModel.Design
Imports System.IO

Public Class FrmMain
    Dim bellSound As String = "bell.wav"
    Dim bellSound1 As String = "bell_01.wav"
    Dim StrAlarmFor As String = String.Empty
    Enum AlarmFor
        General = 100
        Summer = 200
        Examination = 300
    End Enum
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        StrAlarmFor = ReadCounterLocation(Me)
        AutoSelectAlarmFor(StrAlarmFor)
    End Sub
    Private Sub AutoSelectAlarmFor(str As String)
        Dim alarmValue As Integer
        If Integer.TryParse(str, alarmValue) Then
            If alarmValue = AlarmFor.General Then
                rdoGeneral.Checked = True
            ElseIf alarmValue = AlarmFor.Summer Then
                rdoSummer.Checked = True
            Else
                rdoGeneral.Checked = True
            End If
        Else
            ' Handle the case where the string is not a valid number
            MessageBox.Show("Invalid alarm value.")
            rdoGeneral.Checked = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtCurrrent.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
    Private Sub txtCurrrent_TextChanged(sender As Object, e As EventArgs) Handles txtCurrrent.TextChanged
        Try
            If (TimeOfDay = dt_7_in.Text) Then
                If cb_7_in.Checked = True Then
                    PlaySound(bellSound)
                End If

            ElseIf TimeOfDay = dt_7_out.Text Then
                If cb_7_out.Checked = True Then
                    PlaySound(bellSound)
                End If

            ElseIf TimeOfDay = dt_8_in.Text Then
                If cb_8_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_8_out.Text Then
                If cb_8_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_9_in.Text Then
                If cb_9_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_9_out.Text Then
                If cb_9_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_10_in.Text Then
                If cb_10_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_11_out.Text Then
                If cb_11_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_12_in.Text Then
                If cb_12_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_12_out.Text Then
                If cb_12_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_13_in.Text Then
                If cb_13_in.Checked = True Then
                    PlaySound(bellSound)
                End If

            End If



            'Event
            If (TimeOfDay = dt_1_in.Text) Then
                If cb_1_in.Checked = True Then
                    PlaySound(bellSound)
                End If

            ElseIf TimeOfDay = dt_1_out.Text Then
                If cb_1_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_2_in.Text Then
                If cb_2_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_2_out.Text Then
                If cb_2_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_3_in.Text Then
                If cb_3_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_3_out.Text Then
                If cb_3_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_13_out.Text Then
                If cb_13_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_14_in.Text Then
                If cb_14_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_14_out.Text Then
                If cb_14_out.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf TimeOfDay = dt_15_in.Text Then
                If cb_15_in.Checked = True Then
                    PlaySound(bellSound)
                End If
            End If

            'Special Alart

            If Now.DayOfWeek = DayOfWeek.Monday And (TimeOfDay = dt_FlagMon.Text) Then
                If cb_FlagMon.Checked = True Then
                    PlaySound(bellSound)
                End If

            ElseIf Now.DayOfWeek = DayOfWeek.Friday And (TimeOfDay = dt_FlagFri.Text) Then
                If cb_FlagFri.Checked = True Then
                    PlaySound(bellSound)
                End If
            ElseIf Now.DayOfWeek = DayOfWeek.Friday And (TimeOfDay = dt_15_out.Text) Then
                If cb_15_out.Checked = True Then
                    PlaySound(bellSound1)
                End If
            End If

            'Special Alart 5 mins before Time-in: 8:40,14:00 (General only): Requested by: Daren, Kolyan
            '            If (rdoGeneral.Checked) Then
            '            If (TimeOfDay.ToString("HH:mm:ss") = "08:35:00") Then
            '            PlaySound(bellSound)
            '            End If
            '            If (TimeOfDay.ToString("HH:mm:ss") = "13:55:00") Then
            '           PlaySound(bellSound)
            '            End If
            '            If Now.DayOfWeek = DayOfWeek.Friday Then
            'Friday Before Natonal Anthem 15mn
            '            If TimeOfDay.ToString("HH:mm:ss") = "15:45:00" Then
            '           PlaySound(bellSound)
            '           End If
            '            End If
            '            End If

            ' Nation Anthem
            '           If Now.DayOfWeek = DayOfWeek.Monday Then
            '           'Monday




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub SOUND(ByVal Sounds As String)
        Try
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "media/" + Sounds
            Sound.Load()
            Sound.Play()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub StopSound(ByVal Sounds As String)
        Try
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "media/" + Sounds
            Sound.Load()
            Sound.Stop()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PlaySound(ByVal sounds As String)
        SOUND(sounds)
    End Sub

    Private Sub picMuteSound_Click(sender As Object, e As EventArgs) Handles picMuteSound.Click
        StopSound(bellSound)
    End Sub

    Private Sub cbMorningAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbMorningAll.CheckedChanged
        If cbMorningAll.Checked = True Then
            cb_7_in.Checked = True
            cb_7_out.Checked = True
            cb_8_in.Checked = True
            cb_8_out.Checked = True
            cb_9_in.Checked = True
            cb_9_out.Checked = True
            cb_10_in.Checked = True
            cb_11_out.Checked = True
            cb_12_in.Checked = True
            cb_12_out.Checked = True
            cb_13_in.Checked = True
        Else
            cb_7_in.Checked = False
            cb_7_out.Checked = False
            cb_8_in.Checked = False
            cb_8_out.Checked = False
            cb_9_in.Checked = False
            cb_9_out.Checked = False
            cb_10_in.Checked = False
            cb_11_out.Checked = False
            cb_12_in.Checked = False
            cb_12_out.Checked = False
            cb_13_in.Checked = False
        End If
    End Sub

    Private Sub cbEveningAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbEveningAll.CheckedChanged
        If cbEveningAll.Checked Then
            cb_1_in.Checked = True
            cb_1_out.Checked = True
            cb_2_in.Checked = True
            cb_2_out.Checked = True
            cb_3_in.Checked = True
            cb_3_out.Checked = True
            cb_13_out.Checked = True
            cb_14_in.Checked = True
            cb_14_out.Checked = True
            cb_15_in.Checked = True
        Else
            cb_1_in.Checked = False
            cb_1_out.Checked = False
            cb_2_in.Checked = False
            cb_2_out.Checked = False
            cb_3_in.Checked = False
            cb_3_out.Checked = False
            cb_13_out.Checked = False
            cb_14_in.Checked = False
            cb_14_out.Checked = False
            cb_15_in.Checked = False
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon.Visible = True
            Me.Hide()
            NotifyIcon.BalloonTipText = "PSIS Alarm Control is hide in the system tray"
            NotifyIcon.ShowBalloonTip(500)
        End If
    End Sub

    Private Sub NotifyIcon_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False
    End Sub
    Public Shared Sub WriteCounterLocation(ByVal frm As Form, ByVal Loc As String)
        Dim filePath As String = Path.Combine(GetUserHome(frm), "AlarmControl.txt")

        Using sw As StreamWriter = New StreamWriter(filePath)
            sw.Write(Loc)
        End Using
    End Sub
    Public Shared Function ReadCounterLocation(ByVal frm As Form) As String
        Dim counterLoc As String = String.Empty

        Try
            Dim filePath As String = Path.Combine(GetUserHome(frm), "AlarmControl.txt")
            counterLoc = File.ReadAllText(filePath)
        Catch ex As Exception
            counterLoc = String.Empty
            Return counterLoc
        End Try

        Return counterLoc
    End Function
    Public Shared Function GetUserHome(ByVal form As Form) As String
        Dim homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE")

        If Not String.IsNullOrEmpty(homeDrive) Then
            Dim homePath = Environment.GetEnvironmentVariable("HOMEPATH")

            If Not String.IsNullOrEmpty(homePath) Then
                Dim fullHomePath = homeDrive + System.IO.Path.DirectorySeparatorChar + homePath
                Return System.IO.Path.Combine(fullHomePath, "")
            Else
                Throw New Exception("Environment variable error, there is no 'HOMEPATH'")
            End If
        Else
            Throw New Exception("Environment variable error, there is no 'HOMEDRIVE'")
        End If
    End Function
    Private Sub rdoGeneral_CheckedChanged(sender As Object, e As EventArgs) Handles rdoGeneral.CheckedChanged
        If Me.rdoGeneral.Checked Then
            AlarmForGeneralProgram()
            WriteCounterLocation(Me, AlarmFor.General)
        End If
    End Sub
    Private Sub AlarmForGeneralProgram()
        Dim dtStr As String
        dtStr = DateTime.Now.ToString("yyyy-MM-dd")

        'Morning:
        dt_7_in.Value = DateTime.Parse(dtStr + " 07:30")
        dt_7_out.Value = DateTime.Parse(dtStr + " 08:20")

        dt_8_in.Value = DateTime.Parse(dtStr + " 08:40")
        dt_8_out.Value = DateTime.Parse(dtStr + " 09:30")

        dt_9_in.Value = DateTime.Parse(dtStr + " 09:40")
        dt_9_out.Value = DateTime.Parse(dtStr + " 10:30")

        'Will disabled this
        cb_12_out.Checked = False
        cb_13_in.Checked = False
        cb_14_in.Checked = False
        cb_14_out.Checked = False
        cb_15_in.Checked = False

        dt_12_out.Enabled = cb_12_out.Checked
        dt_13_in.Enabled = cb_13_in.Checked
        dt_14_in.Enabled = cb_14_in.Checked
        dt_14_out.Enabled = cb_14_out.Checked
        dt_15_in.Enabled = cb_15_in.Checked

        'Will enabled this
        cb_10_in.Checked = True
        cb_11_out.Checked = True

        dt_10_in.Enabled = cb_10_in.Checked
        dt_11_out.Enabled = cb_11_out.Checked

        dt_10_in.Value = DateTime.Parse(dtStr + " 10:40")
        dt_11_out.Value = DateTime.Parse(dtStr + " 11:30")

        'Afternoon:
        dt_1_in.Value = DateTime.Parse(dtStr + " 13:00")
        dt_1_out.Value = DateTime.Parse(dtStr + " 13:50")

        dt_2_in.Value = DateTime.Parse(dtStr + " 14:00")
        dt_2_out.Value = DateTime.Parse(dtStr + " 14:50")

        dt_3_in.Value = DateTime.Parse(dtStr + " 15:10")
        dt_3_out.Value = DateTime.Parse(dtStr + " 16:00")

        'National Anthems
        dt_FlagMon.Value = DateTime.Parse(dtStr + " 07:15")
        dt_FlagFri.Value = DateTime.Parse(dtStr + " 16:00")
        dt_15_out.Value = DateTime.Parse(dtStr + " 15:45")
    End Sub
    Private Sub AlarmForSummerCourseProgram()
        Dim dtStr As String
        dtStr = DateTime.Now.ToString("yyyy-MM-dd")

        'Morning:
        dt_7_in.Value = DateTime.Parse(dtStr + " 08:00")
        dt_7_out.Value = DateTime.Parse(dtStr + " 08:50")

        dt_8_in.Value = DateTime.Parse(dtStr + " 09:10")
        dt_8_out.Value = DateTime.Parse(dtStr + " 10:00")

        dt_9_in.Value = DateTime.Parse(dtStr + " 10:10")
        dt_9_out.Value = DateTime.Parse(dtStr + " 11:00")

        'Will disabled this
        cb_10_in.Checked = False
        cb_11_out.Checked = False

        dt_10_in.Enabled = cb_10_in.Checked
        dt_11_out.Enabled = cb_11_out.Checked

        'Will disabled this
        cb_12_out.Checked = False
        cb_13_in.Checked = False
        cb_14_in.Checked = False
        cb_14_out.Checked = False
        cb_15_in.Checked = False

        dt_12_out.Enabled = cb_12_out.Checked
        dt_13_in.Enabled = cb_13_in.Checked
        dt_14_in.Enabled = cb_14_in.Checked
        dt_14_out.Enabled = cb_14_out.Checked
        dt_15_in.Enabled = cb_15_in.Checked



        'Afternoon:
        dt_1_in.Value = DateTime.Parse(dtStr + " 13:00")
        dt_1_out.Value = DateTime.Parse(dtStr + " 13:50")

        dt_2_in.Value = DateTime.Parse(dtStr + " 14:00")
        dt_2_out.Value = DateTime.Parse(dtStr + " 14:50")

        dt_3_in.Value = DateTime.Parse(dtStr + " 15:10")
        dt_3_out.Value = DateTime.Parse(dtStr + " 16:00")

        'National Anthems
        dt_FlagMon.Value = DateTime.Parse(dtStr + " 07:45")
        dt_FlagFri.Value = DateTime.Parse(dtStr + " 16:00")
        dt_15_out.Value = DateTime.Parse(dtStr + " 15:45")
    End Sub

    Private Sub rdoSummer_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSummer.CheckedChanged
        If Me.rdoSummer.Checked Then
            AlarmForSummerCourseProgram()
            WriteCounterLocation(Me, AlarmFor.Summer)
        End If
    End Sub
    Private Sub AlarmForExamanition()
        Dim dtStr As String
        dtStr = DateTime.Now.ToString("yyyy-MM-dd")


        'Will disabled this
        cb_10_in.Checked = True
        cb_11_out.Checked = True

        dt_10_in.Enabled = cb_10_in.Checked
        dt_11_out.Enabled = cb_11_out.Checked

        'Will disabled this
        cb_12_out.Checked = True
        cb_13_in.Checked = True
        cb_14_in.Checked = True
        cb_14_out.Checked = True
        cb_15_in.Checked = True

        dt_12_out.Enabled = cb_12_out.Checked
        dt_13_in.Enabled = cb_13_in.Checked
        dt_14_in.Enabled = cb_14_in.Checked
        dt_14_out.Enabled = cb_14_out.Checked
        dt_15_in.Enabled = cb_15_in.Checked




    End Sub

    Private Sub rdoExamination_CheckedChanged(sender As Object, e As EventArgs) Handles rdoExamination.CheckedChanged
        If Me.rdoExamination.Checked Then
            AlarmForExamanition()
            WriteCounterLocation(Me, AlarmFor.Examination)
        End If
    End Sub
End Class