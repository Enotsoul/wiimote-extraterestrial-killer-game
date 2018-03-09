'Wii Project Datacom
'Clinciu Andrei 2nmct6
Imports Wii.HID.Lib
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmWii
    Private device As HIDDevice
    Public A, B, Plus, Home, Minus, One, Two, Up, Down, LeftBtn, RightBtn As Boolean
    Public BTime = UnixTimeNow(), ATime = UnixTimeNow(), OneTime = UnixTimeNow(), TwoTime = UnixTimeNow()
    Public lastEnemy As Long = 0
    Public startTime As Long

    Private sheep As Bitmap = New Bitmap(Application.StartupPath & "/images/SuperSheep.png")
    Private flyingCow As Bitmap = New Bitmap(Application.StartupPath & "/images/flyingcow.png")
    Private ufo1 As Bitmap = New Bitmap(Application.StartupPath & "/images/UFO.png")
    Private ufo2 As Bitmap = New Bitmap(Application.StartupPath & "/images/pixel_ufo.thumbnail.png")

    Public totalItems As Integer = 0
    Public yourLifes As Integer = 10
    Public yourScore As Integer = 0
    Public bulletsInGun As Integer = 6

    Public cursorX, cursorY As Integer

    Public gamesList As New ArrayList()

    'with events..
    Private WithEvents WiiMote As frmWii
    'Event handling
    Public Event HandleWiiButton(ByVal button As String)


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  WII.HID.Lib.HIDDevice.
        '  WII.HID.Lib.HIDReport
        device = HIDDevice.GetHIDDevice(&H57E, &H306)
        ' WII.HID.Lib.HIDDevice.NativeMethods.
        initWii()

  
        'Add Images
        InitImages()


    End Sub

#Region "Wii Controller stuff"
    Private Sub initWii()
        ' Report aanmaken
        Dim report As HIDReport = device.CreateReport()
        ' Report ID instellen op dat voor het aansturen van de player LED's
        report.ReportID = &H11
        ' Alle LED's en trilfunctie(F1) aanzetten F0 enkel leds.. niet zoemen
        report.Data(0) = &H10
        ' Het report versturen
        device.WriteReport(report)

        'Start read reporting..
        device.ReadReport(AddressOf OnReadReport)

        'Data Reporting Mode For buttons & Accellerometer:
        'WriteData(12, &H0 & &H33)
        report.ReportID = &H12
        report.Data(0) = &H0
        report.Data(1) = &H33 '&H33 of &H37
        device.WriteReport(report)

        tmrReport.Start()

        'Start Ir Camera
        StartIRCamera()


    End Sub
    Private Sub InitImages()
        'main Image
        pcbMain.Image = New Bitmap(pcbMain.Width, pcbMain.Height)
        addImage(pcbMain, My.Resources.Background, 0, 0)
        pcbAliens.Image = New Bitmap(pcbAliens.Width, pcbAliens.Height)
        'cursor
        ' pbCursor.Image = New Bitmap(pbCursor.Width, pbCursor.Height)
        '  addImage(pbCursor, New Bitmap(Application.StartupPath & "/images/cursor.png"), 0, 0)
        ' pbCursor.SizeMode = PictureBoxSizeMode.CenterImage
        ' pbCursor.BackColor = Color.Transparent

        pbCursor.Parent = pcbMain
        pcbAliens.Parent = pcbMain
        ' pbCursor.Parent = pcbMain



    End Sub
    'Callback functions
    Private Sub OnReadReport(ByVal report As HIDReport)

        If Me.InvokeRequired Then
            Me.Invoke(New ReadReportCallback(AddressOf OnReadReport), report)
        Else
            Select Case report.ReportID
                Case &H20
                    Dim reportData = report.Data()
                    '(a1) 20  | BB BB LF 00 00 VV
                    lblBattery.Text = IIf((reportData(2) And &H1) = &H1, "Bat Empty", "Battery")
                    ' An Extension Controller is connected 
                    chkExtension.Checked = IIf((reportData(2) And &H2) = &H2, True, False)

                    'Speaker enabled 
                    chkSpeaker.Checked = IIf((reportData(2) And &H4) = &H4, True, False)

                    ' IR camera enabled 
                    chkIRStatus.Checked = IIf((reportData(2) And &H8) = &H8, True, False)

                    ' LED 1  
                    chkLed1.Checked = IIf((reportData(2) And &H10) = &H10, True, False)

                    ' LED 2 
                    chkLed2.Checked = IIf((reportData(2) And &H20) = &H20, True, False)

                    ' LED 3  
                    chkLed3.Checked = IIf((reportData(2) And &H40) = &H40, True, False)

                    ' LED 4
                    chkLed4.Checked = IIf((reportData(2) And &H80) = &H80, True, False)

                    Dim theData As String = ""
                    For Each Str As String In reportData
                        theData += Str + " "
                    Next

                    Dim batteryLevel As Integer = reportData(5) 'And &HFF
                    pbBattery.Value = batteryLevel / 255 * 100
                    lblBatteryLevel.Text = batteryLevel / 255 * 100

                    'report.ReportID = &H15
                    'report.Data(0) = 0
                    'device.WriteReport(report)

                Case &H21
                    ' Memory en register read report
                    Console.WriteLine("Memory & register read report!")
                Case &H22
                    ' Acknowledge report
                    Console.WriteLine("Ok, acknowledge report!")
                    Dim reportData = report.Data()
                    Dim theData As String = ""
                    For Each Str As String In reportData
                        theData += Str + " "
                    Next
                    Console.WriteLine("Normal report! " + reportData.ToString + " or .. " + theData)
                Case &H30
                    ' Core buttons data report



                Case &H31
                    ' Core buttons en accelerometer data report
                    '(a1) RR BB BB XX YY ZZ [...]

                Case &H33
                    '0x33: Core Buttons and Accelerometer with 12 IR bytes  (6 extension bytes for 37)
                    '(a1) 33 BB BB AA AA AA II II II II II II II II II II II II 
                    Dim reportData = report.Data()
                    Dim buttonsData = reportData(0) * 256 + reportData(1)
                    Dim accX = reportData(2) / 64
                    Dim accY = reportData(3) / 64
                    Dim accZ = reportData(4) / 64
                    lblAccelerator.Text = "X = " & accX & vbNewLine & "  Y = " & accY & vbNewLine & " Z = " & accZ & vbNewLine

                    'Infrared camera!
                    Dim irX = reportData(5)
                    Dim irY = reportData(6)
                    Dim irInfo = reportData(7)

                    Dim irX2 = reportData(8)
                    Dim irY2 = reportData(9)
                    Dim irInfo2 = reportData(10)

                    Dim irX3 = reportData(11)
                    Dim irY3 = reportData(12)
                    Dim irInfo3 = reportData(13)

                    Dim irX4 = reportData(14)
                    Dim irY4 = reportData(15)
                    Dim irInfo4 = reportData(16)
                    Dim irMax = 256

                    lblIr1.Text = "IRLed1: X= " & irX & " Y= " & irY
                    lblIR2.Text = "IRLed2: X= " & irX2 & " Y= " & irY2
                    lblIr3.Text = "IRLed3: X= " & irX3 & " Y= " & irY3
                    lblIR4.Text = "IRLed4: X= " & irX4 & " Y= " & irY4

                    'TO have a full calculation but this won't work.. just use the normal data!!
                    Dim RawPositionX = reportData(6) Or ((reportData(8) >> 4) And &H3) << 8
                    Dim RawPositionY = reportData(7) Or ((reportData(8) >> 6) And &H3) << 8
                    Dim RawPositionX2 = reportData(9) Or ((reportData(11) >> 4) And &H3) << 8
                    Dim RawPositionY2 = reportData(10) Or ((reportData(11) >> 6) And &H3) << 8


                    Dim IRSensorsSize1 = reportData(8) And &HF
                    Dim IRSensorsSize2 = reportData(11) And &HF

                    'use normal irX data !! cause the extended stuff give you values over 2000!!!!!
                    ' Dim PositionX As Integer = 800 - CSng(RawPositionX * 800 / irMax)
                    Dim PositionX As Integer = 800 - CSng(irX * 800 / irMax)

                    '   800-  ( RawPositionX * 800 /irMax) 

                    Dim PositionX2 = CSng(RawPositionX2 * 800 / irMax)

                    '    Dim PositionY As Integer = CSng(RawPositionY * 600 / irMax)
                    Dim PositionY As Integer = CSng(irY * 600 / irMax)
                    Dim PositionY2 = CSng(RawPositionY2 * 600 / irMax)

                    'If PositionX < 1 Then
                    '    PositionX = 1
                    'End If
                    'If PositionY < 1 Then
                    '    PositionY = 1
                    'End If
                    'If PositionY > 600 Then
                    '    PositionY = 599
                    'End If
                    'If PositionX > 800 Then
                    '    PositionX = 799
                    'End If

                    'Fix the annoying bug when the locations remain the same!!!
                    If PositionX <> 3 And PositionY <> 598 Then

                        'Place the cursor at the right position
                        pbCursor.Location = New System.Drawing.Point(PositionX, PositionY)
                        ' Console.WriteLine("The current position is : " & PositionX & "," & PositionY)
                        pbCursor.Refresh()
                        '  tabGame.Refresh()
                        cursorX = PositionX
                        cursorY = PositionY

                        lblCursorLocation.Text = "Cursor location (X,Y) = " & PositionX & "," & PositionY
                    End If
                    'up 8 0
                    rblButtons.SetItemChecked(0, IIf((buttonsData And &H800) = &H800, True, False))
                    'down 4 0
                    rblButtons.SetItemChecked(1, IIf((buttonsData And &H400) = &H400, True, False))
                    'left 1 0
                    rblButtons.SetItemChecked(2, IIf((buttonsData And &H100) = &H100, True, False))
                    'right 2 0 
                    rblButtons.SetItemChecked(3, IIf((buttonsData And &H200) = &H200, True, False))
                    'minus 0 16  (00 10)
                    rblButtons.SetItemChecked(4, IIf((buttonsData And &HF10) = &H10, True, False))
                    'home 0 128 (00 80 )
                    rblButtons.SetItemChecked(5, IIf((buttonsData And &H80) = &H80, True, False))
                    'plus 16 0
                    rblButtons.SetItemChecked(6, IIf((buttonsData And &H1000) = &H1000, True, False))
                    '1 0 1
                    '   rblButtons.SetItemChecked(7, IIf((buttonsData And &H2) = &H2, True, False))
                    If (buttonsData And &H2) = &H2 Then
                        rblButtons.SetItemChecked(7, True)
                        'event here
                        WiiButtonClicked("1")
                    Else
                        rblButtons.SetItemChecked(7, False)
                    End If
                    '2 0 2
                    ' rblButtons.SetItemChecked(8, IIf((buttonsData And &H1) = &H1, True, False))
                    If (buttonsData And &H1) = &H1 Then
                        rblButtons.SetItemChecked(8, True)
                        'event here
                        WiiButtonClicked("2")
                    Else
                        rblButtons.SetItemChecked(8, False)
                    End If
                    'a 0 8
                    ' rblButtons.SetItemChecked(9, IIf((buttonsData And &H8) = &H8, True, False))
                    If (buttonsData And &H8) = &H8 Then
                        rblButtons.SetItemChecked(9, True)
                        'event here
                        WiiButtonClicked("A")
                    Else
                        rblButtons.SetItemChecked(9, False)
                    End If


                    'b 0 4 
                    '  rblButtons.SetItemChecked(10, IIf((buttonsData And &H4) = &H4, True, False))
                    If (buttonsData And &H4) = &H4 Then
                        rblButtons.SetItemChecked(10, True)
                        'event here
                        WiiButtonClicked("B")
                    Else
                        rblButtons.SetItemChecked(10, False)
                    End If

                    If (buttonsData And &H84) = &H84 Then
                        Console.WriteLine("Changing led..!")
                        report.ReportID = &H11
                        Dim theData = (IIf(chkLed1.Checked, &H10, 0) + IIf(chkLed2.Checked, &H20, 0) + IIf(chkLed3.Checked, &H40, 0) + IIf(chkLed4.Checked, &H80, 0)) << 1
                        If (theData > &H80) Then
                            theData = &H10
                        ElseIf theData < &H10 Then
                            theData = &H10
                        End If

                        report.Data(0) = theData
                        device.WriteReport(report)
                    End If
            End Select
        device.ReadReport(AddressOf OnReadReport)
        End If

    End Sub

    Private Sub WriteData(ByVal address As Integer, ByVal data() As Byte)
        If Not device Is Nothing Then
            Dim index As Integer = 0

            While index < data.Length

                ' Bepaal hoeveel bytes er nog moeten verzonden worden
                Dim leftOver As Integer = data.Length - index

                ' We kunnen maximaal 16 bytes per keer verzenden dus moeten we het aantal te verzenden bytes daarop limiteren
                Dim count As Integer = IIf(leftOver > 16, 16, leftOver)

                Dim tempAddress As Integer = address + index

                Dim report As HIDReport = device.CreateReport()
                report.ReportID = &H16
                report.Data(0) = ((tempAddress And &H4000000) >> &H18)
                report.Data(1) = ((tempAddress And &HFF0000) >> &H10)
                report.Data(2) = ((tempAddress And &HFF00) >> &H8)
                report.Data(3) = ((tempAddress And &HFF))
                report.Data(4) = count
                Buffer.BlockCopy(data, index, report.Data, 5, count)
                device.WriteReport(report)
                index += 16
            End While
        End If
    End Sub



    Private Sub chkLed1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLed1.CheckedChanged, chkLed2.CheckedChanged, chkLed3.CheckedChanged, chkLed4.CheckStateChanged

        'Dim theData As Byte
        'theData = IIf(chkLed1.Checked, &H10, 0) Or IIf(chkLed2.Checked, &H20, 0) Or IIf(chkLed3.Checked, &H40, 0) Or IIf(chkLed4.Checked, &H80, 0)
        'Dim changed As Boolean = False
        'If sender.name = "chkLed1" Then
        '    theData = theData Xor &H10
        '    changed = True
        'ElseIf sender.name = "chkLed2" Then
        '    theData = theData Xor &H20
        '    changed = True
        'ElseIf sender.name = "chkLed3" Then
        '    theData = theData Xor &H40
        '    changed = True
        'ElseIf sender.name = "chkLed4" Then
        '    theData = theData Xor &H80
        '    changed = True
        'End If

        'Console.WriteLine(sender.name & " is now " & sender.checked)
        'If changed Then
        '    Dim report As HIDReport = device.CreateReport
        '    report.ReportID = &H11
        '    report.Data(0) = theData
        '    device.WriteReport(report)
        'End If


    End Sub


    'Send a report status every 1 second:)
    Private Sub tmrReport_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReport.Tick
        'status Request report
        Dim report As HIDReport = device.CreateReport
        report.ReportID = &H15
        'Send rumble if it'ts checked
        report.Data(0) = IIf(chkRumble.Checked, 1, 0)
        Try
            device.WriteReport(report)
        Catch ex As Exception
            Console.WriteLine("Sending report failed! " & ex.Message)
        End Try

    End Sub

    Private Sub StartIRCamera()
        '     Wanneer we naar het geheugen schrijven moeten we nu het address van het geheugen hexadecimaal doorgeven in het formaat 0xXXXXXX. 
        'Willen we echter naar het register schrijven dan moeten we nog een extra waarde toevoegen aan het adres zodat het 
        'er als volgt uit ziet 0x4XXXXXX. De 4 in het address maakt duidelijk dat het om een register gaat.
        'Voor het aanzet van de camera volgen we nu de volgende procedure
        Dim report As HIDReport = device.CreateReport
        Dim data(100) As Byte
        '1.	Stuur een report met ID 0x13 waar bij bit 2 van de eerst data byte op 1 staat
        report.ReportID = &H13
        report.Data(0) = 4
        device.WriteReport(report)

        Threading.Thread.Sleep(70)

        '2.	Stuur een report met ID 0x1A waar bij bit 2 van de eerst data byte op 1 staat
        report.ReportID = &H1A
        report.Data(0) = 4
        device.WriteReport(report)

        Threading.Thread.Sleep(70)

        '3.	Stuur een byte array met 1 byte met waarde 0x08 naar het registeradres 0xB00030
        WriteData(&HB00030, {&H8})
        Threading.Thread.Sleep(70)

        '4.	Stuur een byte array met de acht bytes voor het eerste sensitivity block naar registeradres 0xB00000 bvb 
        '    [0x02, 0x00, 0x00, 0x71, 0x01, 0x00, 0x90, 0x00, 0x41] voor maximale gevoeligheid
        WriteData(&HB00000, {&H2, &H0, &H0, &H71, &H1, &H0, &H90, &H0, &H41})
        Threading.Thread.Sleep(70)

        '5.	Stuur een byte array met de twee bytes voor het tweede sensitivity block naar registeradres 0xB0001A bvb
        '       [0x40, 0x00] voor maximale gevoeligheid
        WriteData(&HB0001A, {&H40, &H0})
        Threading.Thread.Sleep(70)

        '6.	Stuur een byte array met 1 byte naar het registeradres 0xB00033 met de mode voor de camera.
        ' De waarde voor de mode hangt af van de reporting mode die we willen. Voor reporting mode 0x36 en 0x37
        '        kiezen we als waarde 0x01 (Basic), voor reporting mode 0x22 kiezen we 0x03 (Extended) en voor 0x3E/0x3F kiezen we 0x05 (Full)
        WriteData(&HB00033, {&H3})
        Threading.Thread.Sleep(70)


        '7.	Stuur een byte array met 1 byte met waarde 0x08 naar het registeradres 0xB00030
        WriteData(&HB00030, {&H8})
        Threading.Thread.Sleep(70)

        'Wanneer we deze procedure correct is uit gevoerd kunnen we via de data reports de punten van de camera in lezen.
        Console.WriteLine("IR cameras should be working..")
    End Sub


#End Region


#Region "Game Functions"
   

    Private Sub StartGame()
        Console.WriteLine("Starting the game!")
        MessageBox.Show("Shoot all the ufo's and special animals to get a high score!     Don't let them get away or you will lose life points! Reload by pressing the A button:)! Have fun!")
        'Start Ir Camera
        ' StartIRCamera()
        StartIRCamera()
        tmrGame.Start()

        'clear the games List
        gamesList.Clear()

        'New Image for the aliens:)

        'all the new settings..:D
        totalItems = 0
        yourLifes = 10
        yourScore = 0
        bulletsInGun = 6
        UpdateLabels()

        'set the start time.. (for the speed of the things that follow... each second => 1px faster for newer items)
        startTime = UnixTimeNow()
    End Sub

    Private Sub StopGame()
        Console.WriteLine("Stopping the game!")
        tmrGame.Stop()
        gamesList.Clear()
    End Sub

    Private Sub AddNewRandomItem()
        'Aliens
        Dim Score = 1, moveSpeed, rndX, rndY As Integer
        Dim monster As Bitmap = New Bitmap(1, 1)
        Dim name As String
        Dim extraSpeed As Integer = 0
        Dim rnd As Integer = RandomNumber(1, 5)
        '  Console.WriteLine(rnd)
        Dim rndStartPos As Integer = RandomNumber(1, 3)

        'calculate the extra speed
        extraSpeed = (UnixTimeNow() - startTime) / 1300

        If rnd = 1 Then
            monster = sheep
            moveSpeed = 13 + extraSpeed
            name = "sheep"
            Score = 4
        ElseIf rnd = 2 Then
            monster = flyingCow
            moveSpeed = 9 + extraSpeed
            name = "cow"
            Score = 3
        ElseIf rnd = 3 Then
            monster = ufo1
            moveSpeed = 15 + extraSpeed
            name = "ufo1"
            Score = 5
        ElseIf rnd = 4 Then
            monster = ufo2
            moveSpeed = 17 + extraSpeed
            Score = 7
            name = "ufo2"
        End If


        'only add an item if there's no more than 10..
        Dim timeNow = UnixTimeNow()

        If totalItems <= 100 And (timeNow - lastEnemy) > 3000 - ((timeNow - startTime) / 100) Then
            If rndStartPos = 1 Then
                rndX = monster.Width / 2
                rndY = RandomNumber(0, 500)
            ElseIf rndStartPos = 2 Then
                rndX = 800 - monster.Width / 2
                rndY = RandomNumber(0, 500)
                'The other way around:D
                moveSpeed *= -1
            End If
            Console.WriteLine("New one created at " & rndX & "," & rndY)

            Dim theEnemy As New Enemy(name, rndX, rndY, Score, moveSpeed)
            gamesList.Add(theEnemy)

            addImage(pcbAliens, monster, rndX, rndY)
            totalItems += 1
            lastEnemy = UnixTimeNow()
        End If

        If totalItems >= 100 Then
            StopGame()
            MessageBox.Show("Wow you have successfully passed all 100 flying things! Your score is: " & yourScore)
        End If
        'sheep.Dispose()
        ' flyingCow.Dispose()
        'ufo1.Dispose()
        'ufo2.Dispose()
    End Sub

    'Move the existing images...
    Private Sub MoveExistingImages()
        pcbAliens.Image = New Bitmap(pcbAliens.Width, pcbAliens.Height)
        Dim toAdd As Boolean = True
        Dim monster As Bitmap = New Bitmap(1, 1)

        For Each enm As Enemy In gamesList

            'Dim rnd As Integer = RandomNumber(1, 5)

            'If rnd = 1 Then
            '    enm.X += enm.MoveSpeed
            'ElseIf rnd = 2 Then
            '    enm.X -= enm.MoveSpeed
            'ElseIf rnd = 3 Then
            '    enm.Y -= enm.MoveSpeed
            'ElseIf rnd = 4 Then
            '    enm.Y += enm.MoveSpeed
            'End If

            'the direction is already in the moving speed.. 
            If enm.Y < 1 Or enm.X < 1 Or enm.Y > 600 Or enm.Y > 800 Then
                'just continue the for and remove the enemy if it can be done
                'Console.WriteLine("Not moving this one anymore..")
                ' gamesList.Remove(enm)
                Continue For

            Else
                enm.X += enm.MoveSpeed
            End If


            If enm.Name = "sheep" Then
                monster = sheep
            ElseIf enm.Name = "cow" Then
                monster = flyingCow
            ElseIf enm.Name = "ufo1" Then
                monster = ufo1
            ElseIf enm.Name = "ufo2" Then
                monster = ufo2
            End If


            'REmove the monster & you failed to destroy it..
            If enm.Y < 1 Then
                toAdd = False
            End If
            If enm.X < 1 Then
                toAdd = False
            End If
            If enm.Y > 600 Then
                toAdd = False
            End If
            If enm.X > 800 Then
                toAdd = False
            End If

            If toAdd Then
                addImage(pcbAliens, monster, enm.X, enm.Y)
            Else
                '  gamesList.Remove(enm)
                Console.WriteLine("You didn't kill the enemy.. you lost 1 life!")
                yourLifes -= 1

                If yourLifes <= 0 Then
                    Exit For
                End If
            End If


            '  sheep.Dispose()
            '  flyingCow.Dispose()
            ' ufo1.Dispose()
            ' ufo2.Dispose()
        Next

        'don't do it in the for or you'll get an error:)
        If yourLifes <= 0 Then
            StopGame()
            MessageBox.Show("The game ended ! You lost all your lifes... Your score is: " & yourScore)
        End If
    End Sub
    'min & max random
    Private Function RandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
        Randomize()
        Dim random As New Random()
        Randomize()
        Return random.Next(min, max)
    End Function

    Private Sub tmrGame_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGame.Tick

        AddNewRandomItem()
        MoveExistingImages()
        Me.Invalidate()
        UpdateLabels()
    End Sub


    Private Sub addImage(ByRef pcb As PictureBox, ByVal img As Image, ByVal X As Integer, ByVal Y As Integer)
        Dim g As Graphics
        ' Console.WriteLine("graphics ok!")

        '  pcb.Image = New Bitmap(pcb.Width, pcb.Height)

        g = Graphics.FromImage(pcb.Image) 'neem de graphics uit de picturebox
        'g.Clear(Color.Transparent)

        g.DrawImage(img, X, Y)
        '  g.DrawImage(img, X + 80, Y + 80)
        pcb.Refresh()
        g.Dispose()

        '   Console.WriteLine("Adding image " & img.ToString)

    End Sub
    'unixtime
    Public Function UnixTimeNow() As Long
        Dim _TimeSpan As TimeSpan = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0))
        Return CLng(_TimeSpan.TotalMilliseconds)
    End Function
    'Update labels!
    Private Sub UpdateLabels()
        lblLifes.Text = yourLifes
        lblScore.Text = yourScore
        lblBulletsLeft.Text = bulletsInGun
    End Sub
#End Region



#Region "Events "
    Private Sub smiStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiStart.Click
        StartGame()
    End Sub

    Private Sub smiStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiStop.Click
        StopGame()
    End Sub

    Private Sub smiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smiExit.Click
        Close()
    End Sub


    Private Sub tabGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabGame.Click

    End Sub

    Private Sub frmWii_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabGame.MouseMove
        ' tabGame.Refresh()
        pbCursor.Top = e.Y
        pbCursor.Left = e.X
        Me.Invalidate()
        '   Dim drawimage As Graphics
        '   drawimage.di()
    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click

        Console.WriteLine("Sending status..")
        'status Request report
        Dim report As HIDReport = device.CreateReport
        report.ReportID = &H15
        report.Data(0) = 0
        device.WriteReport(report)

        'Start read reporting..
        ' device.ReadReport(AddressOf StatusReport)

    End Sub

    Private Sub chkRumble_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRumble.CheckedChanged
        Dim theData As Byte
        If chkRumble.Checked Then
            theData = 1
        Else
            theData = 0
        End If
        Console.WriteLine("Rumble activated")
        theData += IIf(chkLed1.Checked, &H10, 0) + IIf(chkLed2.Checked, &H20, 0) + IIf(chkLed3.Checked, &H40, 0) + IIf(chkLed4.Checked, &H80, 0)

        Dim report As HIDReport = device.CreateReport
        report.ReportID = &H11
        report.Data(0) = theData
        device.WriteReport(report)

    End Sub


    Public Sub FoundButton(ByVal button As String) Handles WiiMote.HandleWiiButton
        Console.WriteLine("You have clicked the " & button & " button!")
    End Sub
    Public Sub WiiButtonClicked(ByVal button As String)
        Dim oldTime As Long

        Select Case button
            Case "A"
                oldTime = ATime
                ATime = UnixTimeNow()
                If ((ATime - oldTime) > 50) Then
                    Console.WriteLine("You have clicked the " & button & " button! " & UnixTimeNow())
                    'do reload stuff here add time penalty to reload..
                    bulletsInGun = 6
                    ATime = UnixTimeNow() + 1500
                    BTime = UnixTimeNow() + 1500
                End If
            Case "B"
                oldTime = BTime
                BTime = UnixTimeNow()
                If ((BTime - oldTime) > 50) Then

                    'handle shooting here!
                    Dim monster As Bitmap = New Bitmap(1, 1)
                    If bulletsInGun >= 1 Then

                        For Each enm As Enemy In gamesList


                            If enm.Name = "sheep" Then
                                monster = sheep
                            ElseIf enm.Name = "cow" Then
                                monster = flyingCow
                            ElseIf enm.Name = "ufo1" Then
                                monster = ufo1
                            ElseIf enm.Name = "ufo2" Then
                                monster = ufo2
                            End If

                            Console.WriteLine("You have clicked the " & button & " button! " & enm.X & "<" & cursorX & " And " & enm.X + monster.Width & " > " & cursorX & " aaand the Y: " & enm.Y & "<" & cursorY & " And " & enm.Y + monster.Height & " > " & cursorY)
                            If enm.X < cursorX And (enm.X + monster.Width) > cursorX Then
                                If enm.Y < cursorY And (enm.Y + monster.Height) > cursorY Then
                                    Console.WriteLine("You shot a " & enm.Name & "  at " & cursorX & "," & cursorY)
                                    yourScore += enm.Score
                                    gamesList.Remove(enm)

                                    'exit for so we only shoot ONE item!
                                    Exit For
                                End If
                            End If
                        Next
                        bulletsInGun -= 1
                    End If

                End If
            Case "1"
                oldTime = OneTime
                OneTime = UnixTimeNow()
                If ((OneTime - oldTime) > 50) Then
                    Console.WriteLine("You have clicked the " & button & " button! " & UnixTimeNow())

                End If
            Case "2"
                oldTime = TwoTime
                TwoTime = UnixTimeNow()
                If ((TwoTime - oldTime) > 50) Then
                    Console.WriteLine("You have clicked the " & button & " button! " & UnixTimeNow())

                End If

        End Select

    End Sub
#End Region





End Class
