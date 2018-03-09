<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWii
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
        Me.components = New System.ComponentModel.Container()
        Me.tab = New System.Windows.Forms.TabControl()
        Me.tabGame = New System.Windows.Forms.TabPage()
        Me.lblBulletsLeft = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLifes = New System.Windows.Forms.Label()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbCursor = New System.Windows.Forms.PictureBox()
        Me.pcbAliens = New System.Windows.Forms.PictureBox()
        Me.pcbMain = New System.Windows.Forms.PictureBox()
        Me.tabDebug = New System.Windows.Forms.TabPage()
        Me.lblIR4 = New System.Windows.Forms.Label()
        Me.lblIR2 = New System.Windows.Forms.Label()
        Me.lblIr3 = New System.Windows.Forms.Label()
        Me.lblIr1 = New System.Windows.Forms.Label()
        Me.chkRumble = New System.Windows.Forms.CheckBox()
        Me.AccAndIr = New System.Windows.Forms.GroupBox()
        Me.lblAccelerator = New System.Windows.Forms.Label()
        Me.rblButtons = New System.Windows.Forms.CheckedListBox()
        Me.pbBattery = New System.Windows.Forms.ProgressBar()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.chkExtension = New System.Windows.Forms.CheckBox()
        Me.chkSpeaker = New System.Windows.Forms.CheckBox()
        Me.chkIRStatus = New System.Windows.Forms.CheckBox()
        Me.chkLed4 = New System.Windows.Forms.CheckBox()
        Me.chkLed3 = New System.Windows.Forms.CheckBox()
        Me.chkLed2 = New System.Windows.Forms.CheckBox()
        Me.chkLed1 = New System.Windows.Forms.CheckBox()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.lblBatteryLevel = New System.Windows.Forms.Label()
        Me.lblBattery = New System.Windows.Forms.Label()
        Me.tmrReport = New System.Windows.Forms.Timer(Me.components)
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.miStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrGame = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GameToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.smiStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.smiStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.smiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCursorLocation = New System.Windows.Forms.Label()
        Me.tab.SuspendLayout()
        Me.tabGame.SuspendLayout()
        CType(Me.pbCursor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbAliens, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDebug.SuspendLayout()
        Me.AccAndIr.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Controls.Add(Me.tabGame)
        Me.tab.Controls.Add(Me.tabDebug)
        Me.tab.Location = New System.Drawing.Point(0, 27)
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(808, 626)
        Me.tab.TabIndex = 4
        '
        'tabGame
        '
        Me.tabGame.Controls.Add(Me.lblBulletsLeft)
        Me.tabGame.Controls.Add(Me.Label3)
        Me.tabGame.Controls.Add(Me.lblLifes)
        Me.tabGame.Controls.Add(Me.lblScore)
        Me.tabGame.Controls.Add(Me.Label2)
        Me.tabGame.Controls.Add(Me.Label1)
        Me.tabGame.Controls.Add(Me.pbCursor)
        Me.tabGame.Controls.Add(Me.pcbAliens)
        Me.tabGame.Controls.Add(Me.pcbMain)
        Me.tabGame.Location = New System.Drawing.Point(4, 22)
        Me.tabGame.Name = "tabGame"
        Me.tabGame.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGame.Size = New System.Drawing.Size(800, 600)
        Me.tabGame.TabIndex = 0
        Me.tabGame.Text = "Ufo Shoot'em All"
        Me.tabGame.UseVisualStyleBackColor = True
        '
        'lblBulletsLeft
        '
        Me.lblBulletsLeft.AutoSize = True
        Me.lblBulletsLeft.Location = New System.Drawing.Point(72, 56)
        Me.lblBulletsLeft.Name = "lblBulletsLeft"
        Me.lblBulletsLeft.Size = New System.Drawing.Size(13, 13)
        Me.lblBulletsLeft.TabIndex = 10
        Me.lblBulletsLeft.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Bullets:"
        '
        'lblLifes
        '
        Me.lblLifes.AutoSize = True
        Me.lblLifes.Location = New System.Drawing.Point(72, 9)
        Me.lblLifes.Name = "lblLifes"
        Me.lblLifes.Size = New System.Drawing.Size(13, 13)
        Me.lblLifes.TabIndex = 8
        Me.lblLifes.Text = "0"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Location = New System.Drawing.Point(72, 34)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(13, 13)
        Me.lblScore.TabIndex = 7
        Me.lblScore.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Score:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Lifes Left:"
        '
        'pbCursor
        '
        Me.pbCursor.BackColor = System.Drawing.Color.Transparent
        Me.pbCursor.Image = Global._2nmct6_andrei.clinciu_WiiProject.My.Resources.Resources.cursor
        Me.pbCursor.Location = New System.Drawing.Point(375, 275)
        Me.pbCursor.Name = "pbCursor"
        Me.pbCursor.Size = New System.Drawing.Size(50, 50)
        Me.pbCursor.TabIndex = 4
        Me.pbCursor.TabStop = False
        '
        'pcbAliens
        '
        Me.pcbAliens.BackColor = System.Drawing.Color.Transparent
        Me.pcbAliens.Location = New System.Drawing.Point(-3, 0)
        Me.pcbAliens.Name = "pcbAliens"
        Me.pcbAliens.Size = New System.Drawing.Size(800, 594)
        Me.pcbAliens.TabIndex = 3
        Me.pcbAliens.TabStop = False
        '
        'pcbMain
        '
        Me.pcbMain.Location = New System.Drawing.Point(0, 0)
        Me.pcbMain.Name = "pcbMain"
        Me.pcbMain.Size = New System.Drawing.Size(800, 594)
        Me.pcbMain.TabIndex = 1
        Me.pcbMain.TabStop = False
        '
        'tabDebug
        '
        Me.tabDebug.Controls.Add(Me.lblCursorLocation)
        Me.tabDebug.Controls.Add(Me.lblIR4)
        Me.tabDebug.Controls.Add(Me.lblIR2)
        Me.tabDebug.Controls.Add(Me.lblIr3)
        Me.tabDebug.Controls.Add(Me.lblIr1)
        Me.tabDebug.Controls.Add(Me.chkRumble)
        Me.tabDebug.Controls.Add(Me.AccAndIr)
        Me.tabDebug.Controls.Add(Me.rblButtons)
        Me.tabDebug.Controls.Add(Me.pbBattery)
        Me.tabDebug.Controls.Add(Me.gbStatus)
        Me.tabDebug.Controls.Add(Me.btnStatus)
        Me.tabDebug.Controls.Add(Me.lblBatteryLevel)
        Me.tabDebug.Controls.Add(Me.lblBattery)
        Me.tabDebug.Location = New System.Drawing.Point(4, 22)
        Me.tabDebug.Name = "tabDebug"
        Me.tabDebug.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDebug.Size = New System.Drawing.Size(800, 600)
        Me.tabDebug.TabIndex = 1
        Me.tabDebug.Text = "WiiMote Info"
        Me.tabDebug.UseVisualStyleBackColor = True
        '
        'lblIR4
        '
        Me.lblIR4.AutoSize = True
        Me.lblIR4.Location = New System.Drawing.Point(10, 289)
        Me.lblIR4.Name = "lblIR4"
        Me.lblIR4.Size = New System.Drawing.Size(17, 13)
        Me.lblIR4.TabIndex = 13
        Me.lblIR4.Text = "lvl"
        '
        'lblIR2
        '
        Me.lblIR2.AutoSize = True
        Me.lblIR2.Location = New System.Drawing.Point(10, 230)
        Me.lblIR2.Name = "lblIR2"
        Me.lblIR2.Size = New System.Drawing.Size(17, 13)
        Me.lblIR2.TabIndex = 13
        Me.lblIR2.Text = "lvl"
        '
        'lblIr3
        '
        Me.lblIr3.AutoSize = True
        Me.lblIr3.Location = New System.Drawing.Point(10, 262)
        Me.lblIr3.Name = "lblIr3"
        Me.lblIr3.Size = New System.Drawing.Size(17, 13)
        Me.lblIr3.TabIndex = 12
        Me.lblIr3.Text = "lvl"
        '
        'lblIr1
        '
        Me.lblIr1.AutoSize = True
        Me.lblIr1.Location = New System.Drawing.Point(10, 203)
        Me.lblIr1.Name = "lblIr1"
        Me.lblIr1.Size = New System.Drawing.Size(17, 13)
        Me.lblIr1.TabIndex = 12
        Me.lblIr1.Text = "lvl"
        '
        'chkRumble
        '
        Me.chkRumble.AutoSize = True
        Me.chkRumble.Location = New System.Drawing.Point(230, 139)
        Me.chkRumble.Name = "chkRumble"
        Me.chkRumble.Size = New System.Drawing.Size(62, 17)
        Me.chkRumble.TabIndex = 11
        Me.chkRumble.Text = "Rumble"
        Me.chkRumble.UseVisualStyleBackColor = True
        '
        'AccAndIr
        '
        Me.AccAndIr.Controls.Add(Me.lblAccelerator)
        Me.AccAndIr.Location = New System.Drawing.Point(72, 6)
        Me.AccAndIr.Name = "AccAndIr"
        Me.AccAndIr.Size = New System.Drawing.Size(128, 123)
        Me.AccAndIr.TabIndex = 10
        Me.AccAndIr.TabStop = False
        Me.AccAndIr.Text = "Accelerator "
        '
        'lblAccelerator
        '
        Me.lblAccelerator.AutoSize = True
        Me.lblAccelerator.Location = New System.Drawing.Point(6, 35)
        Me.lblAccelerator.Name = "lblAccelerator"
        Me.lblAccelerator.Size = New System.Drawing.Size(61, 13)
        Me.lblAccelerator.TabIndex = 0
        Me.lblAccelerator.Text = "Accelerator"
        '
        'rblButtons
        '
        Me.rblButtons.FormattingEnabled = True
        Me.rblButtons.Items.AddRange(New Object() {"Up", "Down", "Left", "Right", "-", "Home", "+", "1", "2", "A", "B"})
        Me.rblButtons.Location = New System.Drawing.Point(10, 6)
        Me.rblButtons.Name = "rblButtons"
        Me.rblButtons.Size = New System.Drawing.Size(56, 184)
        Me.rblButtons.TabIndex = 9
        '
        'pbBattery
        '
        Me.pbBattery.Location = New System.Drawing.Point(230, 107)
        Me.pbBattery.Name = "pbBattery"
        Me.pbBattery.Size = New System.Drawing.Size(212, 22)
        Me.pbBattery.TabIndex = 8
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.chkExtension)
        Me.gbStatus.Controls.Add(Me.chkSpeaker)
        Me.gbStatus.Controls.Add(Me.chkIRStatus)
        Me.gbStatus.Controls.Add(Me.chkLed4)
        Me.gbStatus.Controls.Add(Me.chkLed3)
        Me.gbStatus.Controls.Add(Me.chkLed2)
        Me.gbStatus.Controls.Add(Me.chkLed1)
        Me.gbStatus.Location = New System.Drawing.Point(206, 6)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(241, 64)
        Me.gbStatus.TabIndex = 7
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Leds"
        '
        'chkExtension
        '
        Me.chkExtension.AutoSize = True
        Me.chkExtension.Location = New System.Drawing.Point(166, 35)
        Me.chkExtension.Name = "chkExtension"
        Me.chkExtension.Size = New System.Drawing.Size(72, 17)
        Me.chkExtension.TabIndex = 4
        Me.chkExtension.Text = "Extension"
        Me.chkExtension.UseVisualStyleBackColor = True
        '
        'chkSpeaker
        '
        Me.chkSpeaker.AutoSize = True
        Me.chkSpeaker.Location = New System.Drawing.Point(82, 35)
        Me.chkSpeaker.Name = "chkSpeaker"
        Me.chkSpeaker.Size = New System.Drawing.Size(66, 17)
        Me.chkSpeaker.TabIndex = 4
        Me.chkSpeaker.Text = "Speaker"
        Me.chkSpeaker.UseVisualStyleBackColor = True
        '
        'chkIRStatus
        '
        Me.chkIRStatus.AutoSize = True
        Me.chkIRStatus.Location = New System.Drawing.Point(6, 35)
        Me.chkIRStatus.Name = "chkIRStatus"
        Me.chkIRStatus.Size = New System.Drawing.Size(70, 17)
        Me.chkIRStatus.TabIndex = 4
        Me.chkIRStatus.Text = "IR Status"
        Me.chkIRStatus.UseVisualStyleBackColor = True
        '
        'chkLed4
        '
        Me.chkLed4.AutoSize = True
        Me.chkLed4.Location = New System.Drawing.Point(183, 12)
        Me.chkLed4.Name = "chkLed4"
        Me.chkLed4.Size = New System.Drawing.Size(53, 17)
        Me.chkLed4.TabIndex = 0
        Me.chkLed4.Text = "LED4"
        Me.chkLed4.UseVisualStyleBackColor = True
        '
        'chkLed3
        '
        Me.chkLed3.AutoSize = True
        Me.chkLed3.Location = New System.Drawing.Point(124, 12)
        Me.chkLed3.Name = "chkLed3"
        Me.chkLed3.Size = New System.Drawing.Size(53, 17)
        Me.chkLed3.TabIndex = 0
        Me.chkLed3.Text = "LED3"
        Me.chkLed3.UseVisualStyleBackColor = True
        '
        'chkLed2
        '
        Me.chkLed2.AutoSize = True
        Me.chkLed2.Location = New System.Drawing.Point(65, 12)
        Me.chkLed2.Name = "chkLed2"
        Me.chkLed2.Size = New System.Drawing.Size(53, 17)
        Me.chkLed2.TabIndex = 0
        Me.chkLed2.Text = "LED2"
        Me.chkLed2.UseVisualStyleBackColor = True
        '
        'chkLed1
        '
        Me.chkLed1.AutoSize = True
        Me.chkLed1.Location = New System.Drawing.Point(6, 12)
        Me.chkLed1.Name = "chkLed1"
        Me.chkLed1.Size = New System.Drawing.Size(53, 17)
        Me.chkLed1.TabIndex = 0
        Me.chkLed1.Text = "LED1"
        Me.chkLed1.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.Location = New System.Drawing.Point(367, 135)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(75, 23)
        Me.btnStatus.TabIndex = 6
        Me.btnStatus.Text = "Status"
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'lblBatteryLevel
        '
        Me.lblBatteryLevel.AutoSize = True
        Me.lblBatteryLevel.Location = New System.Drawing.Point(319, 73)
        Me.lblBatteryLevel.Name = "lblBatteryLevel"
        Me.lblBatteryLevel.Size = New System.Drawing.Size(17, 13)
        Me.lblBatteryLevel.TabIndex = 4
        Me.lblBatteryLevel.Text = "lvl"
        '
        'lblBattery
        '
        Me.lblBattery.AutoSize = True
        Me.lblBattery.Location = New System.Drawing.Point(227, 73)
        Me.lblBattery.Name = "lblBattery"
        Me.lblBattery.Size = New System.Drawing.Size(40, 13)
        Me.lblBattery.TabIndex = 4
        Me.lblBattery.Text = "Battery"
        '
        'tmrReport
        '
        Me.tmrReport.Interval = 1000
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miStart, Me.miStop, Me.miExit})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'miStart
        '
        Me.miStart.Name = "miStart"
        Me.miStart.Size = New System.Drawing.Size(98, 22)
        Me.miStart.Text = "&Start"
        '
        'miStop
        '
        Me.miStop.Name = "miStop"
        Me.miStop.Size = New System.Drawing.Size(98, 22)
        Me.miStop.Text = "S&top"
        '
        'miExit
        '
        Me.miExit.Name = "miExit"
        Me.miExit.Size = New System.Drawing.Size(98, 22)
        Me.miExit.Text = "&Exit"
        '
        'tmrGame
        '
        Me.tmrGame.Interval = 300
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(806, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem1
        '
        Me.GameToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smiStart, Me.smiStop, Me.smiExit})
        Me.GameToolStripMenuItem1.Name = "GameToolStripMenuItem1"
        Me.GameToolStripMenuItem1.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem1.Text = "Game"
        '
        'smiStart
        '
        Me.smiStart.Name = "smiStart"
        Me.smiStart.Size = New System.Drawing.Size(98, 22)
        Me.smiStart.Text = "&Start"
        '
        'smiStop
        '
        Me.smiStop.Name = "smiStop"
        Me.smiStop.Size = New System.Drawing.Size(98, 22)
        Me.smiStop.Text = "Sto&p"
        '
        'smiExit
        '
        Me.smiExit.Name = "smiExit"
        Me.smiExit.Size = New System.Drawing.Size(98, 22)
        Me.smiExit.Text = "Exit"
        '
        'lblCursorLocation
        '
        Me.lblCursorLocation.AutoSize = True
        Me.lblCursorLocation.Location = New System.Drawing.Point(227, 193)
        Me.lblCursorLocation.Name = "lblCursorLocation"
        Me.lblCursorLocation.Size = New System.Drawing.Size(17, 13)
        Me.lblCursorLocation.TabIndex = 14
        Me.lblCursorLocation.Text = "lvl"
        '
        'frmWii
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 632)
        Me.Controls.Add(Me.tab)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.ImeMode = System.Windows.Forms.ImeMode.AlphaFull
        Me.Name = "frmWii"
        Me.Text = "Wii Project"
        Me.tab.ResumeLayout(False)
        Me.tabGame.ResumeLayout(False)
        Me.tabGame.PerformLayout()
        CType(Me.pbCursor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbAliens, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDebug.ResumeLayout(False)
        Me.tabDebug.PerformLayout()
        Me.AccAndIr.ResumeLayout(False)
        Me.AccAndIr.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents tabGame As System.Windows.Forms.TabPage
    Friend WithEvents tabDebug As System.Windows.Forms.TabPage
    Friend WithEvents pbBattery As System.Windows.Forms.ProgressBar
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents chkExtension As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpeaker As System.Windows.Forms.CheckBox
    Friend WithEvents chkIRStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkLed4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLed3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLed2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLed1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnStatus As System.Windows.Forms.Button
    Friend WithEvents lblBattery As System.Windows.Forms.Label
    Friend WithEvents lblBatteryLevel As System.Windows.Forms.Label
    Public WithEvents rblButtons As System.Windows.Forms.CheckedListBox
    Friend WithEvents AccAndIr As System.Windows.Forms.GroupBox
    Friend WithEvents lblAccelerator As System.Windows.Forms.Label
    Friend WithEvents chkRumble As System.Windows.Forms.CheckBox
    Friend WithEvents tmrReport As System.Windows.Forms.Timer
    Friend WithEvents lblIr1 As System.Windows.Forms.Label
    Friend WithEvents lblIR4 As System.Windows.Forms.Label
    Friend WithEvents lblIR2 As System.Windows.Forms.Label
    Friend WithEvents lblIr3 As System.Windows.Forms.Label
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrGame As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pcbMain As System.Windows.Forms.PictureBox
    Friend WithEvents pbCursor As System.Windows.Forms.PictureBox
    Friend WithEvents pcbAliens As System.Windows.Forms.PictureBox
    Friend WithEvents lblLifes As System.Windows.Forms.Label
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBulletsLeft As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCursorLocation As System.Windows.Forms.Label

End Class
