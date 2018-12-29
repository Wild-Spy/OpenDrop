Imports NichDropComms.SerComms
Imports NichDropComms.VarInterface

Public Class frmMain

    Private ignorenudCdChanges As Boolean = True
    Public SerComLib As New SerComms(Me)
    Public DevPorts As New List(Of String)
    Public DevIDs As New List(Of UInt32)
    Public DTDiff As TimeSpan
    Private NoUpdate As Boolean = True
    Private DevNameInEdit As String
    Public mretVals() As Object
    Public Vars As New List(Of VarInterface)
    Private disableCtrlLst As List(Of Control)
    Private skipDevNameUpdate As Boolean = False 'used for when the device name is changed on the device.  Stops the devName combo-box from updating all variables when the name devices name is updated in it's list

    Private Sub AddCtrlsToDisableList()
        disableCtrlLst = New List(Of Control)
        disableCtrlLst.Add(cbDevNames)
        disableCtrlLst.Add(btnBatCal)
        disableCtrlLst.Add(btnClearLog)
        disableCtrlLst.Add(btnCon)
        disableCtrlLst.Add(btnReadBatVals)
        disableCtrlLst.Add(btnReadLog)
        disableCtrlLst.Add(btnReadVals)
        disableCtrlLst.Add(btnTimeSync)
        disableCtrlLst.Add(btnWriteBatVals)
        disableCtrlLst.Add(btnWriteVals)
    End Sub

    Private Sub DisableButtons()
        Dim n As Control
        For Each n In disableCtrlLst
            n.Enabled = False
        Next
        Application.DoEvents()
    End Sub

    Private Sub EnableButtons()
        Dim n As Control
        For Each n In disableCtrlLst
            n.Enabled = True
        Next
        Application.DoEvents()
    End Sub

    Public Function FindNameInVarLst(ByVal name As String) As VarInterface
        Dim n As VarInterface

        For Each n In Vars
            If n.Name = name Then
                Return n
            End If
        Next

        Throw New Exception("No variable with name """ & name & """exists!")
        Return Nothing

    End Function

    Private Sub btnCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCon.Click
        Dim comPorts() As String = System.IO.Ports.SerialPort.GetPortNames()
        Dim PortStr As String
        Dim tmpErr As MyErr_Enum
        Dim devID As UInt16
        Dim tmpID As UInt32
        Dim RetVals(0) As Object

        NoUpdate = True
        btnCon.Enabled = False
        cbDevNames.Enabled = False
        DisableButtons()

        SerComLib.Ser_Timeout = 200 '00000
        SerComLib.Ser_Baud = SerDev_Nichdrop_ComFuncs.DevBaud

        'Clear lists
        DevPorts.Clear()
        DevIDs.Clear()
        cbDevNames.Items.Clear()

        For Each PortStr In comPorts

            SerComLib.Ser_PortName = PortStr

            tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DevTypeID, Nothing, RetVals)

            If tmpErr = MyErr_Enum.MyErr_Success Then
                devID = CType(RetVals(0), UInt16)
                If devID = SerDev_Nichdrop_ComFuncs.DevID Then
                    'Read Device Name
                    'SerComLib.DoEventDelay(500)
                    tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DevID, Nothing, RetVals)
                    If tmpErr = MyErr_Enum.MyErr_Success Then
                        tmpID = CType(RetVals(0), UInt32)
                        DevPorts.Add(PortStr)
                        DevIDs.Add(tmpID)
                        cbDevNames.Items.Add("[" & DevIDs.Count & "] " & tmpID.ToString("X8"))
                    End If
                End If
            End If
        Next

        If cbDevNames.Items.Count > 0 Then cbDevNames.Text = cbDevNames.Items(0)

        NoUpdate = False
        btnCon.Enabled = True
        cbDevNames.Enabled = True
        EnableButtons()

    End Sub

    Private Sub TimerRTC_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRTC.Tick
        Dim AlreadyTrue As Boolean = False

        If NoUpdate = True Then AlreadyTrue = True

        NoUpdate = True
        dtpDevDateTime.Value = Now() - DTDiff
        If AlreadyTrue = False Then NoUpdate = False
    End Sub

    Public Function FindSelectedPortNum() As String
        Return DevPorts(cbDevNames.SelectedIndex)
    End Function

    Private Sub cbDevNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDevNames.SelectedIndexChanged

        If skipDevNameUpdate = True Then Exit Sub

        setOverviewImagesToQuestion()
        setBatteryImagesToQuestion()

        lblStatus.Text = "Not Connected"

        SerComLib.Ser_PortName = FindSelectedPortNum()


        If cbDevNames.Text <> "" Then
            If FillOverviewInfo() = False Then Exit Sub
            If FillBatteryInfo(True) = False Then Exit Sub
            lblStatus.Text = "Connected (" & FindSelectedPortNum() & ")"
            tmrPing.Enabled = True
        End If

    End Sub

    Public Function FillOverviewInfo() As Boolean
        Dim tmpErr As MyErr_Enum
        Dim RetVals() As Object


        If SerComLib.Ser.IsOpen = False Then
            NoUpdate = True

            DisableButtons()
            SerComLib.Ser_Baud = 9600
            SerComLib.Ser.PortName = FindSelectedPortNum()

            'SerComLib.Ser.Open()

            'Version
            If PBDevVersion.BackColor <> Color.Green Then
                ReDim RetVals(0)
                SerComLib.Ser_Timeout = 500 '00000
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_Version, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                txtDevVersion.Text = CType(RetVals(0), String)
                PBDevVersion.BackColor = Color.Green
                PBDevVersion.BackgroundImage = imgLst.Images(0)
            End If

            'Device ID
            If PBDevID.BackColor <> Color.Green Then
                ReDim RetVals(0)
                'tmpErr = SerComLib.Ser_SendCmd_NoSerSetup(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DevID, Nothing, RetVals)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DevID, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                txtDevID.Text = CType(RetVals(0), UInt32).ToString("X8")
                PBDevID.BackColor = Color.Green
                PBDevID.BackgroundImage = imgLst.Images(0)
            End If

            'Date/Time
            If PBDevDateTime.BackColor <> Color.Green Then
                ReDim RetVals(0)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_RTCTime, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                dtpDevDateTime.Value = CType(RetVals(0), DateTime)
                DTDiff = Now() - CType(RetVals(0), DateTime)
                PBDevDateTime.BackColor = Color.Green
                PBDevDateTime.BackgroundImage = imgLst.Images(0)
            End If

            'Alarm Time
            If pbAlarmTime.BackColor <> Color.Green Then
                ReDim RetVals(0)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_AlarmTime, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                dtpAlarmTime.Value = CType(RetVals(0), DateTime)
                pbAlarmTime.BackColor = Color.Green
                pbAlarmTime.BackgroundImage = imgLst.Images(0)
            End If


            'Drop Period
            If pbDropActPer.BackColor <> Color.Green Then
                ReDim RetVals(0)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DropActPeriod, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                nudDropActPer.Value = CType(RetVals(0), Byte)
                pbDropActPer.BackColor = Color.Green
                pbDropActPer.BackgroundImage = imgLst.Images(0)
            End If

            'ARMED
            If pbArmed.BackColor <> Color.Green Then
                ReDim RetVals(0)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_Armed, Nothing, RetVals)
                If tmpErr < 0 Then GoTo abortSub
                If RetVals(0) > 3 Then
                    cbArmed.Text = "INVALID"
                Else
                    cbArmed.SelectedIndex = CType(RetVals(0), Byte)
                End If
                pbArmed.BackColor = Color.Green
                pbArmed.BackgroundImage = imgLst.Images(0)
            End If

            'SerComLib.Ser.Close()

            NoUpdate = False
        End If

        EnableButtons()
        Return True

abortSub:
        MsgBox("The connection to the device has been interrupted.")
        DeviceDisconnected()
        EnableButtons()
        Return False
    End Function

    Public Sub SetVarState(ByVal VarName As String, ByVal State As VarState)
        Select Case State
            Case VarState.VarState_Green
                FindNameInVarLst(VarName).PicB.BackColor = Color.Green
                FindNameInVarLst(VarName).PicB.BackgroundImage = imgLst.Images(0)

            Case VarState.VarState_Yellow
                FindNameInVarLst(VarName).PicB.BackColor = Color.Red
                FindNameInVarLst(VarName).PicB.BackgroundImage = imgLst.Images(1)

            Case VarState.VarState_White
                FindNameInVarLst(VarName).PicB.BackColor = Color.White
                FindNameInVarLst(VarName).PicB.BackgroundImage = imgLst.Images(2)

            Case VarState.VarState_Red
                FindNameInVarLst(VarName).PicB.BackColor = Color.Black
                FindNameInVarLst(VarName).PicB.BackgroundImage = imgLst.Images(3)

            Case Else
                FindNameInVarLst(VarName).PicB.BackColor = Color.White
                FindNameInVarLst(VarName).PicB.BackgroundImage = imgLst.Images(2)

        End Select
    End Sub

    Public Sub SetVarState(ByVal Var As VarInterface, ByVal State As VarState)
        Select Case State
            Case VarState.VarState_Green
                Var.PicB.BackColor = Color.Green
                Var.PicB.BackgroundImage = imgLst.Images(0)

            Case VarState.VarState_Yellow
                Var.PicB.BackColor = Color.Red
                Var.PicB.BackgroundImage = imgLst.Images(1)

            Case VarState.VarState_White
                Var.PicB.BackColor = Color.White
                Var.PicB.BackgroundImage = imgLst.Images(2)

            Case VarState.VarState_Red
                Var.PicB.BackColor = Color.Black
                Var.PicB.BackgroundImage = imgLst.Images(3)

            Case Else
                Var.PicB.BackColor = Color.White
                Var.PicB.BackgroundImage = imgLst.Images(2)

        End Select
    End Sub

    Public Function FillBatteryInfo(ByVal Force As Boolean) As Boolean
        Dim tmpErr As MyErr_Enum
        Dim RetVals() As Object
        Dim mVar As VarInterface

        If SerComLib.Ser.IsOpen = False Then

            DisableButtons()

            'Battery Conversion Factor
            mVar = FindNameInVarLst("BatConvFact")
            If mVar.PicB.BackColor <> Color.Green Or Force Then
                ReDim RetVals(0)
                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_BatConvFact, Nothing, RetVals)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    Try
                        mVar.Control.value = CType(RetVals(0), String)
                        SetVarState(mVar, VarState.VarState_Green)
                    Catch ex As Exception
                        mVar.Control.value = 0
                    End Try
                End If
            End If

            'Battery Voltage
            mVar = FindNameInVarLst("BatV")
            If mVar.PicB.BackColor <> Color.Green Or Force Then
                ReDim RetVals(0)
                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_BatVolt, Nothing, RetVals)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    Try
                        mVar.Control.Text = Math.Round((1024 / CType(RetVals(0), UInt16)) * nudBatConvFact.Value, 2).ToString
                        SetVarState(mVar, VarState.VarState_Green)
                    Catch ex As Exception
                        mVar.Control.Text = "0.00"
                    End Try
                End If
            End If

            'Low Battery Voltage
            mVar = FindNameInVarLst("LowBatV")
            If mVar.PicB.BackColor <> Color.Green Or Force Then
                ReDim RetVals(0)
                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_LowBatV, Nothing, RetVals)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    Try
                        mVar.Control.value = Math.Round((1024 / CType(RetVals(0), UInt16)) * nudBatConvFact.Value, 2)
                        SetVarState(mVar, VarState.VarState_Green)
                    Catch ex As Exception
                        mVar.Control.value = 0
                    End Try
                End If
            End If

            'Critical Battery Voltage
            mVar = FindNameInVarLst("CritBatV")
            If mVar.PicB.BackColor <> Color.Green Or Force Then
                ReDim RetVals(0)
                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_CritBatV, Nothing, RetVals)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    Try
                        mVar.Control.value = Math.Round((1024 / CType(RetVals(0), UInt16)) * nudBatConvFact.Value, 2)
                        SetVarState(mVar, VarState.VarState_Green)
                    Catch ex As Exception
                        mVar.Control.value = 0
                    End Try
                End If
            End If
            EnableButtons()
            Return True
        End If

        EnableButtons()
        Return False

abortSub:
        MsgBox("The connection to the device has been interrupted.")
        DeviceDisconnected()
        EnableButtons()
        Return False
    End Function

    Public Sub WriteBatteryInfo()
        Dim tmpErr As MyErr_Enum
        Dim Params() As Object
        Dim mVar As VarInterface


        If SerComLib.Ser.IsOpen = False Then

            DisableButtons()

            'Battery Conversion Factor
            mVar = FindNameInVarLst("BatConvFact")
            If (mVar.PicB.BackColor = Color.Red Or mVar.PicB.BackColor = Color.Black) Then 'And mVar.Control.BackColor = Color.White Then
                ReDim Params(0)

                Try
                    Params(0) = mVar.Control.text
                Catch ex As Exception
                    GoTo abortSub
                End Try

                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_BatConvFact, Params, Nothing)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    SetVarState(mVar, VarState.VarState_Green)
                End If
            End If

            'Low battery Voltage
            mVar = FindNameInVarLst("LowBatV")
            If (mVar.PicB.BackColor = Color.Red Or mVar.PicB.BackColor = Color.Black) Then 'And mVar.Control.backcolor = Color.White Then
                ReDim Params(0)

                Try
                    Params(0) = CType((1024 * nudBatConvFact.Value) / mVar.Control.value, UInt16)
                Catch ex As Exception
                    GoTo abortSub
                End Try

                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_LowBatV, Params, Nothing)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    SetVarState(mVar, VarState.VarState_Green)
                End If
            End If

            'Critical Battery Voltage
            mVar = FindNameInVarLst("CritBatV")
            If (mVar.PicB.BackColor = Color.Red Or mVar.PicB.BackColor = Color.Black) Then 'And mVar.Control.backcolor = Color.White Then
                ReDim Params(0)

                Try
                    Params(0) = CType((1024 * nudBatConvFact.Value) / mVar.Control.value, UInt16)
                Catch ex As Exception
                    GoTo abortSub
                End Try

                SerComLib.Ser_Timeout = 500
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_CritBatV, Params, Nothing)
                If tmpErr < 0 Then
                    SetVarState(mVar, VarState.VarState_Red)
                    GoTo abortSub
                Else
                    SetVarState(mVar, VarState.VarState_Green)
                End If
            End If
        End If

        EnableButtons()
        Exit Sub
abortSub:
        MsgBox("The connection to the device has been interrupted.")
        DeviceDisconnected()
        EnableButtons()
    End Sub

    Public Sub WriteOverviewInfo()

        If SerComLib.Ser.IsOpen = False Then

            DisableButtons()
            'Device ID
            If (PBDevID.BackColor = Color.Red Or PBDevID.BackColor = Color.Black) And txtDevID.BackColor = Color.White Then
                Dim tmpErr As MyErr_Enum
                Dim Params(0) As Object

                Params(0) = UInt32.Parse(txtDevID.Text, Globalization.NumberStyles.HexNumber)
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_DevID, Params, Nothing)
                If tmpErr < 0 Then
                    PBDevID.BackColor = Color.Black
                    PBDevID.BackgroundImage = imgLst.Images(3)
                    GoTo abortSub
                Else
                    PBDevID.BackColor = Color.Green
                    PBDevID.BackgroundImage = imgLst.Images(0)
                    'Update in combo box

                    Dim tmpIndex As Integer = cbDevNames.SelectedIndex

                    'skipDevNameUpdate = True
                    cbDevNames.Items(tmpIndex) = "[" & cbDevNames.SelectedIndex + 1 & "] " & CInt(Params(0)).ToString("X8")
                    cbDevNames.SelectedIndex = tmpIndex
                    'skipDevNameUpdate = False

                End If
            End If

            'RTC Time
            If (PBDevDateTime.BackColor = Color.Red Or PBDevDateTime.BackColor = Color.Black) And dtpDevDateTime.BackColor = Color.White Then
                Dim tmpErr As MyErr_Enum
                Dim Params(0) As Object

                Params(0) = dtpDevDateTime.Value
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_RTCTime, Params, Nothing)
                If tmpErr < 0 Then
                    PBDevDateTime.BackColor = Color.Black
                    PBDevDateTime.BackgroundImage = imgLst.Images(3)
                    GoTo abortSub
                Else
                    PBDevDateTime.BackColor = Color.Green
                    PBDevDateTime.BackgroundImage = imgLst.Images(0)
                End If
            End If

            'Alarm Time
            If (pbAlarmTime.BackColor = Color.Red Or pbAlarmTime.BackColor = Color.Black) And dtpAlarmTime.BackColor = Color.White Then
                Dim tmpErr As MyErr_Enum
                Dim Params(0) As Object

                Params(0) = dtpAlarmTime.Value
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_AlarmTime, Params, Nothing)
                If tmpErr < 0 Then
                    pbAlarmTime.BackColor = Color.Black
                    pbAlarmTime.BackgroundImage = imgLst.Images(3)
                    GoTo abortSub
                Else
                    pbAlarmTime.BackColor = Color.Green
                    pbAlarmTime.BackgroundImage = imgLst.Images(0)
                End If
            End If

            'Drop Time
            If (pbDropActPer.BackColor = Color.Red Or pbDropActPer.BackColor = Color.Black) Then
                Dim tmpErr As MyErr_Enum
                Dim Params(0) As Object

                Params(0) = nudDropActPer.Value
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_DropActPeriod, Params, Nothing)
                If tmpErr < 0 Then
                    pbDropActPer.BackColor = Color.Black
                    pbDropActPer.BackgroundImage = imgLst.Images(3)
                    GoTo abortSub
                Else
                    pbDropActPer.BackColor = Color.Green
                    pbDropActPer.BackgroundImage = imgLst.Images(0)
                End If
            End If

            'ARMED value
            If (pbArmed.BackColor = Color.Red Or pbArmed.BackColor = Color.Black) And cbArmed.BackColor = Color.White Then
                Dim tmpErr As MyErr_Enum
                Dim Params(0) As Object

                Params(0) = cbArmed.SelectedIndex
                tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_Armed, Params, Nothing)
                If tmpErr < 0 Then
                    pbArmed.BackColor = Color.Black
                    pbArmed.BackgroundImage = imgLst.Images(3)
                    GoTo abortSub
                Else
                    pbArmed.BackColor = Color.Green
                    pbArmed.BackgroundImage = imgLst.Images(0)
                End If
            End If
        End If

        EnableButtons()
        Exit Sub

abortSub:
        MsgBox("The connection to the device has been interrupted.")
        DeviceDisconnected()
        EnableButtons()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DTDiff = New TimeSpan()
        DTDiff = Now() - dtpDevDateTime.Value

        Vars.Add(New VarInterface("BatV", pbBatV, txtBatV, GetType(UInt16)))
        Vars.Add(New VarInterface("LowBatV", pbLowBatV, nudLowBatV, GetType(UInt16)))
        Vars.Add(New VarInterface("CritBatV", pbCritBatV, nudCritBatV, GetType(UInt16)))
        Vars.Add(New VarInterface("BatConvFact", pbBatConvFact, nudBatConvFact, GetType(String)))

        AddCtrlsToDisableList()

    End Sub

    Private Sub dtpDevDateTime_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            dtpDevDateTime_ValueChanged(sender, e)
        End If
    End Sub

    Private Sub dtpDevDateTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If NoUpdate = True Then Exit Sub


        If dtpDevDateTime.Value.Year > 2000 And dtpDevDateTime.Value.Year < 3000 Then
            Dim tmpErr As MyErr_Enum
            Dim Params() As Object

            DTDiff = Now() - dtpDevDateTime.Value

            ReDim Params(0)
            Params(0) = dtpDevDateTime.Value
            tmpErr = SerComLib.Ser_SendCmd(SerDev_LoggerV2_ComFuncs.CMD_ByteID.Set_DateTime, Params, Nothing)
            If tmpErr < 0 Then Exit Sub
        Else
            MsgBox("Invalid date.. must be on or after 1/1/2000")
        End If
    End Sub

    Private Sub txtDevName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DevNameInEdit = txtDevID.Text
    End Sub

    Private Sub txtDevName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    End Sub

    Private Sub txtDevName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtDevName_LostFocus(sender, e)
        End If
    End Sub

    Private Sub txtDevName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtDevID.Text <> DevNameInEdit Then
            Dim tmpErr As MyErr_Enum
            Dim Params(0) As Object

            Params(0) = txtDevID.Text
            tmpErr = SerComLib.Ser_SendCmd(SerDev_LoggerV2_ComFuncs.CMD_ByteID.Set_LoggerName, Params, Nothing)
            If tmpErr < 0 Then Exit Sub
            PBDevID.BackColor = Color.Green
        End If
    End Sub

    Private Sub txtDevName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PBDevID.BackColor = Color.Red
        If txtDevID.Text.Length > 19 Then
            txtDevID.Text = txtDevID.Text.Substring(0, 19)
        End If
    End Sub

    '    Private Sub btnReadLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadLog.Click
    '        Dim retVals() As Object = Nothing

    '        If btnReadLog.Text = "Cancel" Then
    '            btnReadLog.Text = "Canceling"
    '            SerComLib.CommFuncs.Tx_Cancel = True
    '            Exit Sub
    '        End If

    '        If lvLogs.Items.Count > 0 Then
    '            If MsgBox("Ready to read?" & vbNewLine & "Existing data will be overwitten!", MsgBoxStyle.OkCancel, "Warning!") = MsgBoxResult.Cancel Then
    '                Exit Sub
    '            End If
    '        End If

    '        pBTransfer.Value = 1
    '        SplitContainer3.Panel2MinSize = 65
    '        SplitContainer3.SplitterDistance = 1000
    '        btnReadLog.Text = "Cancel"

    '        bgwRxRecords.RunWorkerAsync()
    '        Do
    '            pBTransfer.Value = SerComLib.CommFuncs.Tx_PercDone
    '            lblRecCount.Text = SerComLib.CommFuncs.Tx_RecordsDone.ToString() & "/" & SerComLib.CommFuncs.Tx_RecordCount.ToString()
    '            lblTransfrRate.Text = SerComLib.CommFuncs.Tx_Rate & " kB/s"
    '            lblTimeRemain.Text = SerComLib.CommFuncs.Tx_TimeRemain & " s"
    '            Application.DoEvents()
    '        Loop While SerComLib.CommFuncs.Tx_InProgress = True

    '        'Put values into list view...
    '        Dim times As List(Of DateTime)
    '        Dim IDs As List(Of UInt32)
    '        Dim i As Integer
    '        Dim n As ListViewItem

    '        Try
    '            times = mretVals(0)
    '            IDs = mretVals(1)
    '        Catch ex As Exception
    '            GoTo FinishSub
    '        End Try


    '        'Erase all logs from list view control
    '        lvLogs.Items.Clear()

    '        For i = 0 To times.Count - 1
    '            n = New ListViewItem()
    '            n.Text = i
    '            n.SubItems.Add(times(i).ToString("dd/MM/yyyy"))
    '            n.SubItems.Add(times(i).ToString("HH:mm:ss"))
    '            n.SubItems.Add(IDs(i).ToString("X8"))
    '            lvLogs.Items.Add(n)
    '        Next

    'FinishSub:
    '        SplitContainer3.Panel2MinSize = 30
    '        SplitContainer3.SplitterDistance = 1000
    '        btnReadLog.Text = "Read Log"

    '    End Sub

    '    Private Sub bgwRxRecords_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwRxRecords.DoWork
    '        Dim tmpErr As MyErr_Enum

    '        SerComLib.CommFuncs.Tx_InProgress = True
    '        SerComLib.CommFuncs.Tx_PercDone = 1
    '        tmpErr = SerComLib.Ser_SendCmd(SerDev_LoggerV2_ComFuncs.CMD_ByteID.Get_AllRecordsFast, Nothing, mretVals)
    '        If tmpErr < 0 Then
    '            SerComLib.CommFuncs.Tx_InProgress = False
    '            Exit Sub
    '        End If
    '        SerComLib.CommFuncs.Tx_InProgress = False

    '    End Sub

    Private Sub btnSaveLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLog.Click
        Dim outFile As String = ""
        Dim tmpLine As String
        Dim i As Integer

        If lvLogs.Items.Count > 0 Then
            Dim n As ListViewItem

            If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each n In lvLogs.Items
                    tmpLine = ""
                    For i = 0 To 1
                        tmpLine &= n.SubItems(i).Text & ","
                    Next
                    tmpLine = tmpLine.Substring(0, tmpLine.Length - 1) & vbCrLf
                    outFile &= tmpLine
                Next

                My.Computer.FileSystem.WriteAllText(saveDialog.FileName, outFile, False)
            End If
        End If
    End Sub

    Private Sub tmrPing_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPing.Tick
        Dim tmpErr As MyErr_Enum
        Dim RetVals(0) As Object
        Dim devID As UInt16

        If SerComLib.Ser.IsOpen = False Then
            tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_DevTypeID, Nothing, RetVals)

            If tmpErr = MyErr_Enum.MyErr_Success Then
                devID = CType(RetVals(0), UInt16)
                If devID = SerDev_Nichdrop_ComFuncs.DevID Then
                    'Our device is still there!
                    Exit Sub
                End If
            End If

            'otherwise.. error!
            DeviceDisconnected()
        End If
    End Sub

    Private Sub DeviceDisconnected()
        tmrPing.Enabled = False
        lblStatus.Text = "Not Connected"
        setOverviewImagesToQuestion()
        setBatteryImagesToQuestion()
        cbDevNames.Text = ""
    End Sub

    Public Sub setOverviewImagesToQuestion()
        PBDevVersion.BackColor = Color.White
        PBDevVersion.BackgroundImage = imgLst.Images(2)
        PBDevID.BackColor = Color.White
        PBDevID.BackgroundImage = imgLst.Images(2)
        PBDevDateTime.BackColor = Color.White
        PBDevDateTime.BackgroundImage = imgLst.Images(2)
        pbAlarmTime.BackColor = Color.White
        pbAlarmTime.BackgroundImage = imgLst.Images(2)
        pbDropActPer.BackColor = Color.White
        pbDropActPer.BackgroundImage = imgLst.Images(2)
        pbArmed.BackColor = Color.White
        pbArmed.BackgroundImage = imgLst.Images(2)
    End Sub

    Public Sub setBatteryImagesToQuestion()
        pbBatConvFact.BackColor = Color.White
        pbBatConvFact.BackgroundImage = imgLst.Images(2)
        pbBatV.BackColor = Color.White
        pbBatV.BackgroundImage = imgLst.Images(2)
        pbLowBatV.BackColor = Color.White
        pbLowBatV.BackgroundImage = imgLst.Images(2)
        pbCritBatV.BackColor = Color.White
        pbCritBatV.BackgroundImage = imgLst.Images(2)
    End Sub

    Private Sub btnReadVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadVals.Click
        'lblStatus.Text = "Not Connected"

        If cbDevNames.Text <> "" Then
            SerComLib.DoEventDelay(600)
            FillOverviewInfo()
            lblStatus.Text = "Connected (" & FindSelectedPortNum() & ")"
            tmrPing.Enabled = True
        Else
            lblStatus.Text = "Not Connected"
        End If
    End Sub

    Private Sub txtDevID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDevID.Leave
        'If PBDevID.BackColor = Color.Red And txtDevID.BackColor = Color.White Then
        '    Dim tmpErr As MyErr_Enum
        '    Dim Params(0) As Object

        '    Params(0) = UInt32.Parse(txtDevID.Text, Globalization.NumberStyles.HexNumber)
        '    tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Set_DevID, Params, Nothing)
        '    If tmpErr < 0 Then Exit Sub
        '    PBDevID.BackColor = Color.Green
        'End If
    End Sub

    Private Sub txtDevID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDevID.TextChanged
        PBDevID.BackColor = Color.Red
        PBDevID.BackgroundImage = imgLst.Images(1)
        Try
            UInt32.Parse(txtDevID.Text, Globalization.NumberStyles.HexNumber)
        Catch ex As Exception
            txtDevID.BackColor = Color.Red
            Exit Sub
        End Try
        txtDevID.BackColor = Color.White
    End Sub

    Private Sub btnWriteVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteVals.Click
        SerComLib.DoEventDelay(600)
        WriteOverviewInfo()
    End Sub

    Private Sub dtpDevDateTime_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDevDateTime.GotFocus
        TimerRTC.Enabled = False
    End Sub

    Private Sub dtpDevDateTime_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDevDateTime.LostFocus
        TimerRTC.Enabled = True
    End Sub

    Private Sub dtpDevDateTime_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDevDateTime.ValueChanged
        If NoUpdate = True Then Exit Sub

        DTDiff = Now() - dtpDevDateTime.Value
        PBDevDateTime.BackColor = Color.Red
        PBDevDateTime.BackgroundImage = imgLst.Images(1)
        Try
            If dtpDevDateTime.Value.Year > 2255 Or dtpDevDateTime.Value.Year < 2000 Then
                Throw New Exception("Invalid Date")
            End If
        Catch ex As Exception
            dtpDevDateTime.BackColor = Color.Red
            Exit Sub
        End Try
        dtpDevDateTime.BackColor = Color.White
    End Sub

    Private Sub btnTimeSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeSync.Click
        dtpDevDateTime.Value = Now()
    End Sub

    Private Sub dtpAlarmTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAlarmTime.ValueChanged
        pbAlarmTime.BackColor = Color.Red
        pbAlarmTime.BackgroundImage = imgLst.Images(1)
        Try
            If dtpAlarmTime.Value.Year > 2255 Or dtpAlarmTime.Value.Year < 2000 Then
                Throw New Exception("Invalid Date")
            End If
        Catch ex As Exception
            dtpAlarmTime.BackColor = Color.Red
            Exit Sub
        End Try
        dtpAlarmTime.BackColor = Color.White
    End Sub

    Private Sub nudDropActPer_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDropActPer.ValueChanged
        pbDropActPer.BackColor = Color.Red
        pbDropActPer.BackgroundImage = imgLst.Images(1)
    End Sub

    Private Sub cbArmed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArmed.SelectedIndexChanged
        pbArmed.BackColor = Color.Red
        pbArmed.BackgroundImage = imgLst.Images(1)
        Try
            If cbArmed.SelectedIndex = -1 Then
                Throw New Exception("No Selection")
            End If
        Catch ex As Exception
            cbArmed.BackColor = Color.Red
            Exit Sub
        End Try
        cbArmed.BackColor = Color.White
    End Sub

    Private Sub cbArmed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbArmed.TextChanged
        cbArmed_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub btnReadBatVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadBatVals.Click
        'Static forceNext As DateTime = Now
        'Dim ForceThis As Boolean = False

        If cbDevNames.Text <> "" Then
            SerComLib.DoEventDelay(600)
            'If (forceNext - Now()).TotalSeconds < 2 Then
            '    ForceThis = True
            'End If

            FillBatteryInfo(True)
            lblStatus.Text = "Connected (" & FindSelectedPortNum() & ")"
            tmrPing.Enabled = True
            'forceNext = Now
        End If
    End Sub

    Private Sub btnWriteBatVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteBatVals.Click
        If cbDevNames.Text <> "" Then
            SerComLib.DoEventDelay(600)
            tmrPing.Enabled = False
            WriteBatteryInfo()
            tmrPing.Enabled = True
        End If
    End Sub

    Private Sub nudBatConvFact_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudBatConvFact.ValueChanged
        SetVarState("BatConvFact", VarState.VarState_Yellow)
    End Sub

    Private Sub nudLowBatV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLowBatV.ValueChanged
        SetVarState("LowBatV", VarState.VarState_Yellow)
    End Sub

    Private Sub nudCritBatV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudCritBatV.ValueChanged
        SetVarState("CritBatV", VarState.VarState_Yellow)
    End Sub

    Private Sub btnBatCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatCal.Click
        Dim tmpErr As MyErr_Enum
        Dim RetVals() As Object
        Dim mVar As VarInterface

        If SerComLib.Ser.IsOpen = False Then

            'Battery Conversion Factor
            mVar = FindNameInVarLst("BatConvFact")
            ReDim RetVals(0)
            SerComLib.Ser_Timeout = 500
            tmpErr = SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_BatVolt, Nothing, RetVals)
            If tmpErr = MyErr_Enum.MyErr_Success Then
                Dim tmpBatV As Decimal
                Try
                    tmpBatV = InputBox("Please enter the current battery voltage.", "Information Required", "0.00")
                Catch ex As Exception
                    MsgBox("Invalid value entered! Aborting")
                    Exit Sub
                End Try
                nudBatConvFact.Value = (CType(RetVals(0), UInt16) * tmpBatV) / 1024.0
            End If
        End If
    End Sub

    Private Sub btnReadLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadLog.Click
        Dim retVals(1) As Object
        Dim valAry() As Byte
        Dim timeAry() As DateTime
        Dim i As Integer
        Dim n As ListViewItem

        DisableButtons()

        If SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Get_LogEntries, Nothing, retVals) < 0 Then
            EnableButtons()
            Exit Sub
        End If


        valAry = retVals(0)
        timeAry = retVals(1)

        lvLogs.Items.Clear()

        For i = 0 To valAry.Count - 1
            n = New ListViewItem()
            n.Text = timeAry(i).ToString
            n.SubItems.Add(valAry(i).ToString)
            lvLogs.Items.Add(n)
        Next

        EnableButtons()

    End Sub

    Private Sub btnClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLog.Click
        If MsgBox("Would you like to clear all logs off the device too?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If MsgBox("Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                lvLogs.Items.Clear()
                If SerComLib.Ser_SendCmd(SerDev_Nichdrop_ComFuncs.CMD_ByteID.Cmd_ClearLogEntries, Nothing, Nothing) < 0 Then
                    MsgBox("Error clearing logs off device!")
                End If
            End If
        Else
            lvLogs.Items.Clear()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub cbStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStyle.SelectedIndexChanged
        If cbStyle.Text = "DATE/TIME MODE" Then
            TimerRTC.Start()
            tdpDropoffTime.Visible = True
            lblDevTime.Visible = True
            tlpDevTime.Visible = True
            lblAlarmTime.Visible = True
            tlpCountdown.Visible = False
            lblCountdown.Visible = False
            Label17.Visible = False
        Else
            TimerRTC.Stop()
            dtpDevDateTime.Value = New Date(2000, 1, 1, 0, 0, 0)
            tdpDropoffTime.Visible = False
            lblDevTime.Visible = False
            tlpDevTime.Visible = False
            lblAlarmTime.Visible = False
            tlpCountdown.Visible = True
            lblCountdown.Visible = True
            ignorenudCdChanges = True
            nudCdYears.Value = dtpAlarmTime.Value.Year - 2000
            nudCdMonths.Value = dtpAlarmTime.Value.Month - 1
            nudCdDays.Value = dtpAlarmTime.Value.Day - 1
            nudCdHours.Value = dtpAlarmTime.Value.Hour
            nudCdMinutes.Value = dtpAlarmTime.Value.Minute
            ignorenudCdChanges = False
            Label17.Visible = True
        End If
    End Sub

    Private Sub nudCdDays_ValueChanged(sender As Object, e As EventArgs) Handles nudCdDays.ValueChanged, nudCdMonths.ValueChanged, nudCdYears.ValueChanged, nudCdMinutes.ValueChanged, nudCdHours.ValueChanged
        If ignorenudCdChanges Then Return
        dtpAlarmTime.Value = New Date(2000 + nudCdYears.Value, 1 + nudCdMonths.Value, 1 + nudCdDays.Value, nudCdHours.Value, nudCdMinutes.Value, 0)
    End Sub
End Class

Public Class VarInterface
    Public PicB As PictureBox
    Public Control As Object
    Public Name As String
    Public VarType As Type
    Public VariableState As VarState

    Public Enum VarState As Integer
        VarState_Yellow = 0
        VarState_Green = 1
        VarState_White = 2
        VarState_Red = 3
    End Enum

    Public Sub New(ByVal mName As String, ByRef pb As PictureBox, ByRef ctrl As Control, ByVal mType As Type)
        PicB = pb
        Control = ctrl
        Name = mName
        VarType = mType
        VariableState = VarState.VarState_Yellow
    End Sub

    Public Sub SetState(ByVal State As VarState)
        Select Case State
            Case VarState.VarState_Green
                Me.PicB.BackColor = Color.Green
                Me.PicB.BackgroundImage = Control.parent.imgLst.Images(0)

            Case VarState.VarState_Yellow
                Me.PicB.BackColor = Color.Red
                Me.PicB.BackgroundImage = Control.parent.imgLst.Images(1)

            Case VarState.VarState_White
                Me.PicB.BackColor = Color.White
                Me.PicB.BackgroundImage = Control.parent.imgLst.Images(2)

            Case VarState.VarState_Red
                Me.PicB.BackColor = Color.Black
                Me.PicB.BackgroundImage = Control.parent.imgLst.Images(3)

            Case Else
                Me.PicB.BackColor = Color.White
                Me.PicB.BackgroundImage = Control.parent.imgLst.Images(2)

        End Select
        VariableState = State
    End Sub
End Class