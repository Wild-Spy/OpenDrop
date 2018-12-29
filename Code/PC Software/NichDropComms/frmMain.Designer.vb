<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbDevNames = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnCon = New System.Windows.Forms.Button()
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpCountdown = New System.Windows.Forms.TableLayoutPanel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.nudCdDays = New System.Windows.Forms.NumericUpDown()
        Me.nudCdMonths = New System.Windows.Forms.NumericUpDown()
        Me.nudCdYears = New System.Windows.Forms.NumericUpDown()
        Me.nudCdHours = New System.Windows.Forms.NumericUpDown()
        Me.nudCdMinutes = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbStyle = New System.Windows.Forms.PictureBox()
        Me.cbStyle = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tdpDropoffTime = New System.Windows.Forms.TableLayoutPanel()
        Me.pbAlarmTime = New System.Windows.Forms.PictureBox()
        Me.dtpAlarmTime = New System.Windows.Forms.DateTimePicker()
        Me.tlpDevTime = New System.Windows.Forms.TableLayoutPanel()
        Me.PBDevDateTime = New System.Windows.Forms.PictureBox()
        Me.dtpDevDateTime = New System.Windows.Forms.DateTimePicker()
        Me.btnTimeSync = New System.Windows.Forms.Button()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.PBDevID = New System.Windows.Forms.PictureBox()
        Me.txtDevID = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.PBDevVersion = New System.Windows.Forms.PictureBox()
        Me.txtDevVersion = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbDropActPer = New System.Windows.Forms.PictureBox()
        Me.nudDropActPer = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbArmed = New System.Windows.Forms.PictureBox()
        Me.cbArmed = New System.Windows.Forms.ComboBox()
        Me.lblAlarmTime = New System.Windows.Forms.Label()
        Me.lblDevTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnWriteVals = New System.Windows.Forms.Button()
        Me.btnReadVals = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbBatV = New System.Windows.Forms.PictureBox()
        Me.txtBatV = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbBatConvFact = New System.Windows.Forms.PictureBox()
        Me.nudBatConvFact = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbCritBatV = New System.Windows.Forms.PictureBox()
        Me.nudCritBatV = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.pbLowBatV = New System.Windows.Forms.PictureBox()
        Me.nudLowBatV = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBatCal = New System.Windows.Forms.Button()
        Me.btnWriteBatVals = New System.Windows.Forms.Button()
        Me.btnReadBatVals = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.lvLogs = New System.Windows.Forms.ListView()
        Me.columnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTimeRemain = New System.Windows.Forms.Label()
        Me.lblTransfrRate = New System.Windows.Forms.Label()
        Me.lblRecCount = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.pBTransfer = New System.Windows.Forms.ProgressBar()
        Me.btnSaveLog = New System.Windows.Forms.Button()
        Me.btnClearLog = New System.Windows.Forms.Button()
        Me.btnReadLog = New System.Windows.Forms.Button()
        Me.saveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.bgwRxRecords = New System.ComponentModel.BackgroundWorker()
        Me.tmrPing = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRTC = New System.Windows.Forms.Timer(Me.components)
        Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.tlpCountdown.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCdDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCdMonths, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCdYears, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCdHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCdMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.pbStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tdpDropoffTime.SuspendLayout()
        CType(Me.pbAlarmTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpDevTime.SuspendLayout()
        CType(Me.PBDevDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.PBDevID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PBDevVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.pbDropActPer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDropActPer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.pbArmed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        CType(Me.pbBatV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel14.SuspendLayout()
        CType(Me.pbBatConvFact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBatConvFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel15.SuspendLayout()
        CType(Me.pbCritBatV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCritBatV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel16.SuspendLayout()
        CType(Me.pbLowBatV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLowBatV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.cbDevNames)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblStatus)
        Me.splitContainer1.Panel1.Controls.Add(Me.label1)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnCon)
        Me.splitContainer1.Panel1MinSize = 46
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Size = New System.Drawing.Size(604, 540)
        Me.splitContainer1.SplitterDistance = 46
        Me.splitContainer1.TabIndex = 1
        '
        'cbDevNames
        '
        Me.cbDevNames.FormattingEnabled = True
        Me.cbDevNames.Location = New System.Drawing.Point(93, 12)
        Me.cbDevNames.Name = "cbDevNames"
        Me.cbDevNames.Size = New System.Drawing.Size(121, 21)
        Me.cbDevNames.TabIndex = 39
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Location = New System.Drawing.Point(259, 17)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(120, 15)
        Me.lblStatus.TabIndex = 38
        Me.lblStatus.Text = "Not Connected"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(220, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 13)
        Me.label1.TabIndex = 37
        Me.label1.Text = "Status:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCon
        '
        Me.btnCon.Location = New System.Drawing.Point(12, 12)
        Me.btnCon.Name = "btnCon"
        Me.btnCon.Size = New System.Drawing.Size(75, 23)
        Me.btnCon.TabIndex = 36
        Me.btnCon.Text = "Scan"
        Me.btnCon.UseVisualStyleBackColor = True
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Name = "splitContainer2"
        Me.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.TabControl1)
        Me.splitContainer2.Size = New System.Drawing.Size(604, 490)
        Me.splitContainer2.SplitterDistance = 414
        Me.splitContainer2.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(604, 414)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.SplitContainer4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(596, 388)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Values"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.TableLayoutPanel3)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnWriteVals)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnReadVals)
        Me.SplitContainer4.Size = New System.Drawing.Size(590, 382)
        Me.SplitContainer4.SplitterDistance = 304
        Me.SplitContainer4.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoScroll = True
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.tlpCountdown, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel10, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.tdpDropoffTime, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.tlpDevTime, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label21, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel8, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel9, 1, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.lblAlarmTime, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDevTime, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label23, 0, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.Label22, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCountdown, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 1, 9)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.TableLayoutPanel3.RowCount = 10
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(588, 302)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'tlpCountdown
        '
        Me.tlpCountdown.ColumnCount = 11
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCountdown.Controls.Add(Me.Label16, 9, 0)
        Me.tlpCountdown.Controls.Add(Me.Label15, 7, 0)
        Me.tlpCountdown.Controls.Add(Me.Label8, 5, 0)
        Me.tlpCountdown.Controls.Add(Me.Label6, 3, 0)
        Me.tlpCountdown.Controls.Add(Me.PictureBox1, 0, 0)
        Me.tlpCountdown.Controls.Add(Me.nudCdDays, 2, 0)
        Me.tlpCountdown.Controls.Add(Me.nudCdMonths, 4, 0)
        Me.tlpCountdown.Controls.Add(Me.nudCdYears, 6, 0)
        Me.tlpCountdown.Controls.Add(Me.nudCdHours, 8, 0)
        Me.tlpCountdown.Controls.Add(Me.nudCdMinutes, 10, 0)
        Me.tlpCountdown.Controls.Add(Me.Label5, 1, 0)
        Me.tlpCountdown.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCountdown.Location = New System.Drawing.Point(87, 167)
        Me.tlpCountdown.Name = "tlpCountdown"
        Me.tlpCountdown.RowCount = 1
        Me.tlpCountdown.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCountdown.Size = New System.Drawing.Size(491, 21)
        Me.tlpCountdown.TabIndex = 20
        Me.tlpCountdown.Visible = False
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(373, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Minutes"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(286, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Hours"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(200, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Years"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(106, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Months"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 21)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'nudCdDays
        '
        Me.nudCdDays.Location = New System.Drawing.Point(60, 3)
        Me.nudCdDays.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudCdDays.Name = "nudCdDays"
        Me.nudCdDays.Size = New System.Drawing.Size(40, 20)
        Me.nudCdDays.TabIndex = 20
        '
        'nudCdMonths
        '
        Me.nudCdMonths.Location = New System.Drawing.Point(154, 3)
        Me.nudCdMonths.Maximum = New Decimal(New Integer() {11, 0, 0, 0})
        Me.nudCdMonths.Name = "nudCdMonths"
        Me.nudCdMonths.Size = New System.Drawing.Size(40, 20)
        Me.nudCdMonths.TabIndex = 21
        Me.nudCdMonths.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudCdYears
        '
        Me.nudCdYears.Location = New System.Drawing.Point(240, 3)
        Me.nudCdYears.Name = "nudCdYears"
        Me.nudCdYears.Size = New System.Drawing.Size(40, 20)
        Me.nudCdYears.TabIndex = 22
        '
        'nudCdHours
        '
        Me.nudCdHours.Location = New System.Drawing.Point(327, 3)
        Me.nudCdHours.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.nudCdHours.Name = "nudCdHours"
        Me.nudCdHours.Size = New System.Drawing.Size(40, 20)
        Me.nudCdHours.TabIndex = 23
        '
        'nudCdMinutes
        '
        Me.nudCdMinutes.Location = New System.Drawing.Point(423, 3)
        Me.nudCdMinutes.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudCdMinutes.Name = "nudCdMinutes"
        Me.nudCdMinutes.Size = New System.Drawing.Size(40, 20)
        Me.nudCdMinutes.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Days"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.pbStyle, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.cbStyle, 1, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(87, 83)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(491, 20)
        Me.TableLayoutPanel10.TabIndex = 19
        '
        'pbStyle
        '
        Me.pbStyle.BackColor = System.Drawing.Color.White
        Me.pbStyle.BackgroundImage = CType(resources.GetObject("pbStyle.BackgroundImage"), System.Drawing.Image)
        Me.pbStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbStyle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbStyle.Location = New System.Drawing.Point(0, 0)
        Me.pbStyle.Margin = New System.Windows.Forms.Padding(0)
        Me.pbStyle.Name = "pbStyle"
        Me.pbStyle.Size = New System.Drawing.Size(20, 20)
        Me.pbStyle.TabIndex = 15
        Me.pbStyle.TabStop = False
        '
        'cbStyle
        '
        Me.cbStyle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbStyle.FormattingEnabled = True
        Me.cbStyle.Items.AddRange(New Object() {"DATE/TIME MODE", "COUNTDOWN MODE"})
        Me.cbStyle.Location = New System.Drawing.Point(23, 0)
        Me.cbStyle.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.cbStyle.Name = "cbStyle"
        Me.cbStyle.Size = New System.Drawing.Size(468, 21)
        Me.cbStyle.TabIndex = 0
        Me.cbStyle.Text = "DATE/TIME MODE"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Nichdrop ID"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Version"
        '
        'tdpDropoffTime
        '
        Me.tdpDropoffTime.ColumnCount = 2
        Me.tdpDropoffTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tdpDropoffTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tdpDropoffTime.Controls.Add(Me.pbAlarmTime, 0, 0)
        Me.tdpDropoffTime.Controls.Add(Me.dtpAlarmTime, 1, 0)
        Me.tdpDropoffTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tdpDropoffTime.Location = New System.Drawing.Point(87, 139)
        Me.tdpDropoffTime.Name = "tdpDropoffTime"
        Me.tdpDropoffTime.RowCount = 1
        Me.tdpDropoffTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tdpDropoffTime.Size = New System.Drawing.Size(491, 20)
        Me.tdpDropoffTime.TabIndex = 8
        '
        'pbAlarmTime
        '
        Me.pbAlarmTime.BackColor = System.Drawing.Color.White
        Me.pbAlarmTime.BackgroundImage = CType(resources.GetObject("pbAlarmTime.BackgroundImage"), System.Drawing.Image)
        Me.pbAlarmTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAlarmTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAlarmTime.Location = New System.Drawing.Point(0, 0)
        Me.pbAlarmTime.Margin = New System.Windows.Forms.Padding(0)
        Me.pbAlarmTime.Name = "pbAlarmTime"
        Me.pbAlarmTime.Size = New System.Drawing.Size(20, 20)
        Me.pbAlarmTime.TabIndex = 19
        Me.pbAlarmTime.TabStop = False
        '
        'dtpAlarmTime
        '
        Me.dtpAlarmTime.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.dtpAlarmTime.CalendarTitleForeColor = System.Drawing.SystemColors.HotTrack
        Me.dtpAlarmTime.CustomFormat = "dddd dd, MMMM, yyyy @ HH:mm:ss"
        Me.dtpAlarmTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpAlarmTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAlarmTime.Location = New System.Drawing.Point(23, 0)
        Me.dtpAlarmTime.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.dtpAlarmTime.Name = "dtpAlarmTime"
        Me.dtpAlarmTime.Size = New System.Drawing.Size(468, 20)
        Me.dtpAlarmTime.TabIndex = 0
        '
        'tlpDevTime
        '
        Me.tlpDevTime.ColumnCount = 3
        Me.tlpDevTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpDevTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDevTime.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpDevTime.Controls.Add(Me.PBDevDateTime, 0, 0)
        Me.tlpDevTime.Controls.Add(Me.dtpDevDateTime, 1, 0)
        Me.tlpDevTime.Controls.Add(Me.btnTimeSync, 2, 0)
        Me.tlpDevTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDevTime.Location = New System.Drawing.Point(87, 111)
        Me.tlpDevTime.Name = "tlpDevTime"
        Me.tlpDevTime.RowCount = 1
        Me.tlpDevTime.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDevTime.Size = New System.Drawing.Size(491, 20)
        Me.tlpDevTime.TabIndex = 6
        '
        'PBDevDateTime
        '
        Me.PBDevDateTime.BackColor = System.Drawing.Color.White
        Me.PBDevDateTime.BackgroundImage = CType(resources.GetObject("PBDevDateTime.BackgroundImage"), System.Drawing.Image)
        Me.PBDevDateTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBDevDateTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBDevDateTime.Location = New System.Drawing.Point(0, 0)
        Me.PBDevDateTime.Margin = New System.Windows.Forms.Padding(0)
        Me.PBDevDateTime.Name = "PBDevDateTime"
        Me.PBDevDateTime.Size = New System.Drawing.Size(20, 20)
        Me.PBDevDateTime.TabIndex = 19
        Me.PBDevDateTime.TabStop = False
        '
        'dtpDevDateTime
        '
        Me.dtpDevDateTime.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.dtpDevDateTime.CalendarTitleForeColor = System.Drawing.SystemColors.HotTrack
        Me.dtpDevDateTime.CustomFormat = "dddd dd, MMMM, yyyy @ HH:mm:ss"
        Me.dtpDevDateTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDevDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDevDateTime.Location = New System.Drawing.Point(23, 0)
        Me.dtpDevDateTime.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.dtpDevDateTime.Name = "dtpDevDateTime"
        Me.dtpDevDateTime.Size = New System.Drawing.Size(423, 20)
        Me.dtpDevDateTime.TabIndex = 0
        '
        'btnTimeSync
        '
        Me.btnTimeSync.Location = New System.Drawing.Point(449, 0)
        Me.btnTimeSync.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTimeSync.Name = "btnTimeSync"
        Me.btnTimeSync.Size = New System.Drawing.Size(42, 20)
        Me.btnTimeSync.TabIndex = 16
        Me.btnTimeSync.Text = "Sync"
        Me.btnTimeSync.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.PBDevID, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDevID, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(87, 55)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(491, 20)
        Me.TableLayoutPanel5.TabIndex = 4
        '
        'PBDevID
        '
        Me.PBDevID.BackColor = System.Drawing.Color.White
        Me.PBDevID.BackgroundImage = CType(resources.GetObject("PBDevID.BackgroundImage"), System.Drawing.Image)
        Me.PBDevID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBDevID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBDevID.Location = New System.Drawing.Point(0, 0)
        Me.PBDevID.Margin = New System.Windows.Forms.Padding(0)
        Me.PBDevID.Name = "PBDevID"
        Me.PBDevID.Size = New System.Drawing.Size(20, 20)
        Me.PBDevID.TabIndex = 15
        Me.PBDevID.TabStop = False
        '
        'txtDevID
        '
        Me.txtDevID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDevID.Location = New System.Drawing.Point(23, 0)
        Me.txtDevID.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtDevID.Name = "txtDevID"
        Me.txtDevID.Size = New System.Drawing.Size(468, 20)
        Me.txtDevID.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(308, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Value"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(17, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 16)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Name"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.PBDevVersion, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtDevVersion, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(87, 27)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(491, 20)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'PBDevVersion
        '
        Me.PBDevVersion.BackColor = System.Drawing.Color.White
        Me.PBDevVersion.BackgroundImage = CType(resources.GetObject("PBDevVersion.BackgroundImage"), System.Drawing.Image)
        Me.PBDevVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBDevVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PBDevVersion.Location = New System.Drawing.Point(0, 0)
        Me.PBDevVersion.Margin = New System.Windows.Forms.Padding(0)
        Me.PBDevVersion.Name = "PBDevVersion"
        Me.PBDevVersion.Size = New System.Drawing.Size(20, 20)
        Me.PBDevVersion.TabIndex = 15
        Me.PBDevVersion.TabStop = False
        '
        'txtDevVersion
        '
        Me.txtDevVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDevVersion.Location = New System.Drawing.Point(23, 0)
        Me.txtDevVersion.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtDevVersion.Name = "txtDevVersion"
        Me.txtDevVersion.ReadOnly = True
        Me.txtDevVersion.Size = New System.Drawing.Size(468, 20)
        Me.txtDevVersion.TabIndex = 0
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.pbDropActPer, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.nudDropActPer, 1, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(87, 196)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(491, 20)
        Me.TableLayoutPanel8.TabIndex = 16
        '
        'pbDropActPer
        '
        Me.pbDropActPer.BackColor = System.Drawing.Color.White
        Me.pbDropActPer.BackgroundImage = CType(resources.GetObject("pbDropActPer.BackgroundImage"), System.Drawing.Image)
        Me.pbDropActPer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDropActPer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbDropActPer.Location = New System.Drawing.Point(0, 0)
        Me.pbDropActPer.Margin = New System.Windows.Forms.Padding(0)
        Me.pbDropActPer.Name = "pbDropActPer"
        Me.pbDropActPer.Size = New System.Drawing.Size(20, 20)
        Me.pbDropActPer.TabIndex = 15
        Me.pbDropActPer.TabStop = False
        '
        'nudDropActPer
        '
        Me.nudDropActPer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudDropActPer.Location = New System.Drawing.Point(23, 0)
        Me.nudDropActPer.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.nudDropActPer.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudDropActPer.Name = "nudDropActPer"
        Me.nudDropActPer.Size = New System.Drawing.Size(468, 20)
        Me.nudDropActPer.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.nudDropActPer, "The period for which the dropoff element on " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the device will be activated in sec" & _
        "onds.")
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.pbArmed, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.cbArmed, 1, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(87, 224)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(491, 20)
        Me.TableLayoutPanel9.TabIndex = 17
        '
        'pbArmed
        '
        Me.pbArmed.BackColor = System.Drawing.Color.White
        Me.pbArmed.BackgroundImage = CType(resources.GetObject("pbArmed.BackgroundImage"), System.Drawing.Image)
        Me.pbArmed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbArmed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbArmed.Location = New System.Drawing.Point(0, 0)
        Me.pbArmed.Margin = New System.Windows.Forms.Padding(0)
        Me.pbArmed.Name = "pbArmed"
        Me.pbArmed.Size = New System.Drawing.Size(20, 20)
        Me.pbArmed.TabIndex = 15
        Me.pbArmed.TabStop = False
        '
        'cbArmed
        '
        Me.cbArmed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbArmed.FormattingEnabled = True
        Me.cbArmed.Items.AddRange(New Object() {"ARMED_OFF", "ARMED_ON", "ARMED_DEBUG", "ARMED_SHELF"})
        Me.cbArmed.Location = New System.Drawing.Point(23, 0)
        Me.cbArmed.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.cbArmed.Name = "cbArmed"
        Me.cbArmed.Size = New System.Drawing.Size(468, 21)
        Me.cbArmed.TabIndex = 0
        '
        'lblAlarmTime
        '
        Me.lblAlarmTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAlarmTime.AutoSize = True
        Me.lblAlarmTime.Location = New System.Drawing.Point(5, 142)
        Me.lblAlarmTime.Name = "lblAlarmTime"
        Me.lblAlarmTime.Size = New System.Drawing.Size(59, 13)
        Me.lblAlarmTime.TabIndex = 7
        Me.lblAlarmTime.Text = "Alarm Time"
        '
        'lblDevTime
        '
        Me.lblDevTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDevTime.AutoSize = True
        Me.lblDevTime.Location = New System.Drawing.Point(5, 114)
        Me.lblDevTime.Name = "lblDevTime"
        Me.lblDevTime.Size = New System.Drawing.Size(55, 13)
        Me.lblDevTime.TabIndex = 5
        Me.lblDevTime.Text = "RTC Time"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Dropoff Style"
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(5, 227)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "ARMED"
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(5, 199)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Drop Period"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip.SetToolTip(Me.Label22, "The period for which the dropoff element is on in seconds.")
        '
        'lblCountdown
        '
        Me.lblCountdown.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCountdown.AutoSize = True
        Me.lblCountdown.Location = New System.Drawing.Point(5, 171)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(61, 13)
        Me.lblCountdown.TabIndex = 21
        Me.lblCountdown.Text = "Countdown"
        Me.lblCountdown.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(134, 268)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(397, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Tip: Make sure to 'clear log' on 'Records' tab before deploying in countdown mode" & _
    "."
        '
        'btnWriteVals
        '
        Me.btnWriteVals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWriteVals.Location = New System.Drawing.Point(428, 3)
        Me.btnWriteVals.Name = "btnWriteVals"
        Me.btnWriteVals.Size = New System.Drawing.Size(75, 23)
        Me.btnWriteVals.TabIndex = 1
        Me.btnWriteVals.Text = "Write"
        Me.btnWriteVals.UseVisualStyleBackColor = True
        '
        'btnReadVals
        '
        Me.btnReadVals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadVals.Location = New System.Drawing.Point(509, 3)
        Me.btnReadVals.Name = "btnReadVals"
        Me.btnReadVals.Size = New System.Drawing.Size(75, 23)
        Me.btnReadVals.TabIndex = 0
        Me.btnReadVals.Text = "Read"
        Me.btnReadVals.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(596, 388)
        Me.TabPage3.TabIndex = 5
        Me.TabPage3.Text = "Battery"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer5
        '
        Me.SplitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.TableLayoutPanel12)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnBatCal)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnWriteBatVals)
        Me.SplitContainer5.Panel2.Controls.Add(Me.btnReadBatVals)
        Me.SplitContainer5.Size = New System.Drawing.Size(590, 382)
        Me.SplitContainer5.SplitterDistance = 304
        Me.SplitContainer5.TabIndex = 1
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.AutoScroll = True
        Me.TableLayoutPanel12.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel12.Controls.Add(Me.Label11, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.TableLayoutPanel17, 1, 1)
        Me.TableLayoutPanel12.Controls.Add(Me.Label14, 0, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.TableLayoutPanel14, 1, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.Label13, 0, 4)
        Me.TableLayoutPanel12.Controls.Add(Me.TableLayoutPanel15, 1, 4)
        Me.TableLayoutPanel12.Controls.Add(Me.TableLayoutPanel16, 1, 3)
        Me.TableLayoutPanel12.Controls.Add(Me.Label9, 0, 3)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel12.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.TableLayoutPanel12.RowCount = 10
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(588, 302)
        Me.TableLayoutPanel12.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Current Battery Voltage"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(336, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Value"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(45, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Name"
        '
        'TableLayoutPanel17
        '
        Me.TableLayoutPanel17.ColumnCount = 2
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel17.Controls.Add(Me.pbBatV, 0, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.txtBatV, 1, 0)
        Me.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel17.Location = New System.Drawing.Point(143, 27)
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        Me.TableLayoutPanel17.RowCount = 1
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel17.Size = New System.Drawing.Size(435, 20)
        Me.TableLayoutPanel17.TabIndex = 0
        '
        'pbBatV
        '
        Me.pbBatV.BackColor = System.Drawing.Color.White
        Me.pbBatV.BackgroundImage = CType(resources.GetObject("pbBatV.BackgroundImage"), System.Drawing.Image)
        Me.pbBatV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbBatV.Location = New System.Drawing.Point(0, 0)
        Me.pbBatV.Margin = New System.Windows.Forms.Padding(0)
        Me.pbBatV.Name = "pbBatV"
        Me.pbBatV.Size = New System.Drawing.Size(20, 20)
        Me.pbBatV.TabIndex = 15
        Me.pbBatV.TabStop = False
        '
        'txtBatV
        '
        Me.txtBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBatV.Location = New System.Drawing.Point(23, 0)
        Me.txtBatV.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtBatV.Name = "txtBatV"
        Me.txtBatV.ReadOnly = True
        Me.txtBatV.Size = New System.Drawing.Size(412, 20)
        Me.txtBatV.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Battery Conversion Factor"
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.ColumnCount = 2
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.pbBatConvFact, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.nudBatConvFact, 1, 0)
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(143, 55)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 1
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(435, 20)
        Me.TableLayoutPanel14.TabIndex = 1
        '
        'pbBatConvFact
        '
        Me.pbBatConvFact.BackColor = System.Drawing.Color.White
        Me.pbBatConvFact.BackgroundImage = CType(resources.GetObject("pbBatConvFact.BackgroundImage"), System.Drawing.Image)
        Me.pbBatConvFact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBatConvFact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbBatConvFact.Location = New System.Drawing.Point(0, 0)
        Me.pbBatConvFact.Margin = New System.Windows.Forms.Padding(0)
        Me.pbBatConvFact.Name = "pbBatConvFact"
        Me.pbBatConvFact.Size = New System.Drawing.Size(20, 20)
        Me.pbBatConvFact.TabIndex = 15
        Me.pbBatConvFact.TabStop = False
        '
        'nudBatConvFact
        '
        Me.nudBatConvFact.DecimalPlaces = 2
        Me.nudBatConvFact.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudBatConvFact.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudBatConvFact.Location = New System.Drawing.Point(23, 0)
        Me.nudBatConvFact.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.nudBatConvFact.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudBatConvFact.Name = "nudBatConvFact"
        Me.nudBatConvFact.Size = New System.Drawing.Size(412, 20)
        Me.nudBatConvFact.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Critical Battery Voltage"
        '
        'TableLayoutPanel15
        '
        Me.TableLayoutPanel15.ColumnCount = 2
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel15.Controls.Add(Me.pbCritBatV, 0, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.nudCritBatV, 1, 0)
        Me.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel15.Location = New System.Drawing.Point(143, 111)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        Me.TableLayoutPanel15.RowCount = 1
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel15.Size = New System.Drawing.Size(435, 20)
        Me.TableLayoutPanel15.TabIndex = 3
        '
        'pbCritBatV
        '
        Me.pbCritBatV.BackColor = System.Drawing.Color.White
        Me.pbCritBatV.BackgroundImage = CType(resources.GetObject("pbCritBatV.BackgroundImage"), System.Drawing.Image)
        Me.pbCritBatV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCritBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbCritBatV.Location = New System.Drawing.Point(0, 0)
        Me.pbCritBatV.Margin = New System.Windows.Forms.Padding(0)
        Me.pbCritBatV.Name = "pbCritBatV"
        Me.pbCritBatV.Size = New System.Drawing.Size(20, 20)
        Me.pbCritBatV.TabIndex = 13
        Me.pbCritBatV.TabStop = False
        '
        'nudCritBatV
        '
        Me.nudCritBatV.DecimalPlaces = 2
        Me.nudCritBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudCritBatV.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudCritBatV.Location = New System.Drawing.Point(23, 0)
        Me.nudCritBatV.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.nudCritBatV.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudCritBatV.Name = "nudCritBatV"
        Me.nudCritBatV.Size = New System.Drawing.Size(412, 20)
        Me.nudCritBatV.TabIndex = 0
        '
        'TableLayoutPanel16
        '
        Me.TableLayoutPanel16.ColumnCount = 2
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.Controls.Add(Me.pbLowBatV, 0, 0)
        Me.TableLayoutPanel16.Controls.Add(Me.nudLowBatV, 1, 0)
        Me.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel16.Location = New System.Drawing.Point(143, 83)
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        Me.TableLayoutPanel16.RowCount = 1
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.Size = New System.Drawing.Size(435, 20)
        Me.TableLayoutPanel16.TabIndex = 2
        '
        'pbLowBatV
        '
        Me.pbLowBatV.BackColor = System.Drawing.Color.White
        Me.pbLowBatV.BackgroundImage = CType(resources.GetObject("pbLowBatV.BackgroundImage"), System.Drawing.Image)
        Me.pbLowBatV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLowBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbLowBatV.Location = New System.Drawing.Point(0, 0)
        Me.pbLowBatV.Margin = New System.Windows.Forms.Padding(0)
        Me.pbLowBatV.Name = "pbLowBatV"
        Me.pbLowBatV.Size = New System.Drawing.Size(20, 20)
        Me.pbLowBatV.TabIndex = 15
        Me.pbLowBatV.TabStop = False
        '
        'nudLowBatV
        '
        Me.nudLowBatV.DecimalPlaces = 2
        Me.nudLowBatV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudLowBatV.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudLowBatV.Location = New System.Drawing.Point(23, 0)
        Me.nudLowBatV.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.nudLowBatV.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudLowBatV.Name = "nudLowBatV"
        Me.nudLowBatV.Size = New System.Drawing.Size(412, 20)
        Me.nudLowBatV.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Low Battery Voltage"
        '
        'btnBatCal
        '
        Me.btnBatCal.Location = New System.Drawing.Point(3, 3)
        Me.btnBatCal.Name = "btnBatCal"
        Me.btnBatCal.Size = New System.Drawing.Size(75, 23)
        Me.btnBatCal.TabIndex = 2
        Me.btnBatCal.Text = "Calibrate"
        Me.btnBatCal.UseVisualStyleBackColor = True
        '
        'btnWriteBatVals
        '
        Me.btnWriteBatVals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWriteBatVals.Location = New System.Drawing.Point(428, 3)
        Me.btnWriteBatVals.Name = "btnWriteBatVals"
        Me.btnWriteBatVals.Size = New System.Drawing.Size(75, 23)
        Me.btnWriteBatVals.TabIndex = 1
        Me.btnWriteBatVals.Text = "Write"
        Me.btnWriteBatVals.UseVisualStyleBackColor = True
        '
        'btnReadBatVals
        '
        Me.btnReadBatVals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadBatVals.Location = New System.Drawing.Point(509, 3)
        Me.btnReadBatVals.Name = "btnReadBatVals"
        Me.btnReadBatVals.Size = New System.Drawing.Size(75, 23)
        Me.btnReadBatVals.TabIndex = 1
        Me.btnReadBatVals.Text = "Read"
        Me.btnReadBatVals.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(596, 388)
        Me.TabPage4.TabIndex = 6
        Me.TabPage4.Text = "Records"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.lvLogs)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer3.Panel2MinSize = 30
        Me.SplitContainer3.Size = New System.Drawing.Size(590, 382)
        Me.SplitContainer3.SplitterDistance = 348
        Me.SplitContainer3.TabIndex = 4
        '
        'lvLogs
        '
        Me.lvLogs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader8, Me.ColumnHeader2})
        Me.lvLogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvLogs.FullRowSelect = True
        Me.lvLogs.Location = New System.Drawing.Point(0, 0)
        Me.lvLogs.Name = "lvLogs"
        Me.lvLogs.Size = New System.Drawing.Size(590, 348)
        Me.lvLogs.TabIndex = 1
        Me.lvLogs.UseCompatibleStateImageBehavior = False
        Me.lvLogs.View = System.Windows.Forms.View.Details
        '
        'columnHeader8
        '
        Me.columnHeader8.Text = "Date"
        Me.columnHeader8.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Data"
        Me.ColumnHeader2.Width = 147
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(590, 30)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTimeRemain)
        Me.Panel2.Controls.Add(Me.lblTransfrRate)
        Me.Panel2.Controls.Add(Me.lblRecCount)
        Me.Panel2.Controls.Add(Me.lbl1)
        Me.Panel2.Controls.Add(Me.lbl2)
        Me.Panel2.Controls.Add(Me.label2)
        Me.Panel2.Controls.Add(Me.pBTransfer)
        Me.Panel2.Controls.Add(Me.btnSaveLog)
        Me.Panel2.Controls.Add(Me.btnClearLog)
        Me.Panel2.Controls.Add(Me.btnReadLog)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(90, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(410, 24)
        Me.Panel2.TabIndex = 0
        '
        'lblTimeRemain
        '
        Me.lblTimeRemain.AutoSize = True
        Me.lblTimeRemain.Location = New System.Drawing.Point(367, 45)
        Me.lblTimeRemain.Name = "lblTimeRemain"
        Me.lblTimeRemain.Size = New System.Drawing.Size(13, 13)
        Me.lblTimeRemain.TabIndex = 59
        Me.lblTimeRemain.Text = "0"
        '
        'lblTransfrRate
        '
        Me.lblTransfrRate.AutoSize = True
        Me.lblTransfrRate.Location = New System.Drawing.Point(269, 45)
        Me.lblTransfrRate.Name = "lblTransfrRate"
        Me.lblTransfrRate.Size = New System.Drawing.Size(13, 13)
        Me.lblTransfrRate.TabIndex = 58
        Me.lblTransfrRate.Text = "0"
        '
        'lblRecCount
        '
        Me.lblRecCount.AutoSize = True
        Me.lblRecCount.Location = New System.Drawing.Point(88, 45)
        Me.lblRecCount.Name = "lblRecCount"
        Me.lblRecCount.Size = New System.Drawing.Size(13, 13)
        Me.lblRecCount.TabIndex = 57
        Me.lblRecCount.Text = "0"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(17, 45)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(76, 13)
        Me.lbl1.TabIndex = 54
        Me.lbl1.Text = "Record Count:"
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.lbl2.Location = New System.Drawing.Point(318, 45)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(57, 13)
        Me.lbl2.TabIndex = 56
        Me.lbl2.Text = "Time Left: "
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(199, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(75, 13)
        Me.label2.TabIndex = 55
        Me.label2.Text = "Transfer Rate:"
        '
        'pBTransfer
        '
        Me.pBTransfer.Location = New System.Drawing.Point(11, 26)
        Me.pBTransfer.Name = "pBTransfer"
        Me.pBTransfer.Size = New System.Drawing.Size(388, 16)
        Me.pBTransfer.TabIndex = 53
        '
        'btnSaveLog
        '
        Me.btnSaveLog.Location = New System.Drawing.Point(168, 3)
        Me.btnSaveLog.Name = "btnSaveLog"
        Me.btnSaveLog.Size = New System.Drawing.Size(75, 20)
        Me.btnSaveLog.TabIndex = 52
        Me.btnSaveLog.Text = "Save"
        Me.btnSaveLog.UseVisualStyleBackColor = True
        '
        'btnClearLog
        '
        Me.btnClearLog.Location = New System.Drawing.Point(310, 1)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(89, 21)
        Me.btnClearLog.TabIndex = 51
        Me.btnClearLog.Text = "Clear Log"
        Me.btnClearLog.UseVisualStyleBackColor = True
        '
        'btnReadLog
        '
        Me.btnReadLog.Location = New System.Drawing.Point(11, 2)
        Me.btnReadLog.Name = "btnReadLog"
        Me.btnReadLog.Size = New System.Drawing.Size(90, 21)
        Me.btnReadLog.TabIndex = 50
        Me.btnReadLog.Text = "Read Log"
        Me.btnReadLog.UseVisualStyleBackColor = True
        '
        'saveDialog
        '
        Me.saveDialog.DefaultExt = "csv"
        Me.saveDialog.Filter = "Comma Seperated List File (*.csv)|*.csv|All Files (*.*)|*.*"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tmrPing
        '
        Me.tmrPing.Interval = 60000
        '
        'TimerRTC
        '
        Me.TimerRTC.Enabled = True
        Me.TimerRTC.Interval = 1000
        '
        'imgLst
        '
        Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLst.Images.SetKeyName(0, "Green.bmp")
        Me.imgLst.Images.SetKeyName(1, "Yellow.bmp")
        Me.imgLst.Images.SetKeyName(2, "White.bmp")
        Me.imgLst.Images.SetKeyName(3, "Red.bmp")
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 540)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "frmMain"
        Me.Text = "WildSpy WID Logger Comms"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.tlpCountdown.ResumeLayout(False)
        Me.tlpCountdown.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCdDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCdMonths, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCdYears, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCdHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCdMinutes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel10.ResumeLayout(False)
        CType(Me.pbStyle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tdpDropoffTime.ResumeLayout(False)
        CType(Me.pbAlarmTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpDevTime.ResumeLayout(False)
        CType(Me.PBDevDateTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.PBDevID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.PBDevVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        CType(Me.pbDropActPer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDropActPer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel9.ResumeLayout(False)
        CType(Me.pbArmed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        Me.TableLayoutPanel17.ResumeLayout(False)
        Me.TableLayoutPanel17.PerformLayout()
        CType(Me.pbBatV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel14.ResumeLayout(False)
        CType(Me.pbBatConvFact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBatConvFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel15.ResumeLayout(False)
        CType(Me.pbCritBatV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCritBatV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel16.ResumeLayout(False)
        CType(Me.pbLowBatV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLowBatV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents cbDevNames As System.Windows.Forms.ComboBox
    Private WithEvents lblStatus As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnCon As System.Windows.Forms.Button
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Private WithEvents saveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bgwRxRecords As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrPing As System.Windows.Forms.Timer
    Private WithEvents TimerRTC As System.Windows.Forms.Timer
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tdpDropoffTime As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpDevTime As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PBDevID As System.Windows.Forms.PictureBox
    Friend WithEvents txtDevID As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PBDevVersion As System.Windows.Forms.PictureBox
    Friend WithEvents txtDevVersion As System.Windows.Forms.TextBox
    Friend WithEvents lblDevTime As System.Windows.Forms.Label
    Friend WithEvents lblAlarmTime As System.Windows.Forms.Label
    Friend WithEvents btnReadVals As System.Windows.Forms.Button
    Friend WithEvents imgLst As System.Windows.Forms.ImageList
    Friend WithEvents btnWriteVals As System.Windows.Forms.Button
    Friend WithEvents btnTimeSync As System.Windows.Forms.Button
    Friend WithEvents dtpDevDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAlarmTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbDropActPer As System.Windows.Forms.PictureBox
    Friend WithEvents nudDropActPer As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel14 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel15 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbCritBatV As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel17 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbBatV As System.Windows.Forms.PictureBox
    Friend WithEvents txtBatV As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnWriteBatVals As System.Windows.Forms.Button
    Friend WithEvents btnReadBatVals As System.Windows.Forms.Button
    Friend WithEvents nudCritBatV As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudBatConvFact As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel16 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbLowBatV As System.Windows.Forms.PictureBox
    Friend WithEvents nudLowBatV As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBatCal As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Private WithEvents lvLogs As System.Windows.Forms.ListView
    Private WithEvents columnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents lblTimeRemain As System.Windows.Forms.Label
    Private WithEvents lblTransfrRate As System.Windows.Forms.Label
    Private WithEvents lblRecCount As System.Windows.Forms.Label
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents lbl2 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents pBTransfer As System.Windows.Forms.ProgressBar
    Private WithEvents btnSaveLog As System.Windows.Forms.Button
    Private WithEvents btnClearLog As System.Windows.Forms.Button
    Private WithEvents btnReadLog As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbAlarmTime As System.Windows.Forms.PictureBox
    Friend WithEvents PBDevDateTime As System.Windows.Forms.PictureBox
    Friend WithEvents pbBatConvFact As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbArmed As System.Windows.Forms.PictureBox
    Friend WithEvents cbArmed As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbStyle As System.Windows.Forms.PictureBox
    Friend WithEvents cbStyle As System.Windows.Forms.ComboBox
    Friend WithEvents tlpCountdown As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudCdDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCdMonths As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCdYears As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCdHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCdMinutes As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCountdown As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
