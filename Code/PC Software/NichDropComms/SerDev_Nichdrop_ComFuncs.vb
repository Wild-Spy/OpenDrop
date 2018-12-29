Imports NichDropComms.SerComms

Public Class SerDev_Nichdrop_ComFuncs
    Inherits NichDropComms.SerDev_ComFuncs

    Public Const DevID As UInt16 = &H10
    Public Const DevBaud As Integer = 9600


    Enum CMD_ByteID As Integer
        Get_DevTypeID = &H0
        Get_DevID = &H1
        Set_DevID = &H2
        Get_RTCTime = &H3
        Set_RTCTime = &H4
        Get_AlarmTime = &H5
        Set_AlarmTime = &H6
        Get_NextWakeupTime = &H7
        Get_DropActPeriod = &H8
        Set_DropActPeriod = &H9
        Get_LowBatV = &HA
        Set_LowBatV = &HB
        Get_CritBatV = &HC
        Set_CritBatV = &HD
        Get_BatConvFact = &HE
        Set_BatConvFact = &HF
        Get_ChargePumpTop = &H10
        Set_ChargePumpTop = &H11
        Get_ChargePumpReset = &H12
        Set_ChargePumpReset = &H13
        Get_Armed = &H14
        Set_Armed = &H15
        Get_RFVersion = &H16
        Cmd_TestDropoff = &H17
        Get_BatVolt = &H18
        Get_LogEntries = &H19
        Cmd_ClearLogEntries = &H1A
        Get_Activations = &H1B
        Get_Version = &H1C
    End Enum

    Public Sub New(ByRef Parent As SerComms)
        InitCmdTable()
        Me.SerComParent = Parent
    End Sub

    Private Sub InitCmdTable()
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_DevTypeID, AddressOf Ser_CMD_Get_DevTypeID))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_DevID, AddressOf Ser_CMD_Get_DevID))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_DevID, AddressOf Ser_CMD_Set_DevID))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_RTCTime, AddressOf Ser_CMD_Get_RTCTime))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_RTCTime, AddressOf Ser_CMD_Set_RTCTime))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_AlarmTime, AddressOf Ser_CMD_Get_AlarmTime))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_AlarmTime, AddressOf Ser_CMD_Set_AlarmTime))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_NextWakeupTime, AddressOf Ser_CMD_Get_NextWakeupTime))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_DropActPeriod, AddressOf Ser_CMD_Get_DropActPeriod))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_DropActPeriod, AddressOf Ser_CMD_Set_DropActPeriod))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_LowBatV, AddressOf Ser_CMD_Get_LowBatV))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_LowBatV, AddressOf Ser_CMD_Set_LowBatV))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_CritBatV, AddressOf Ser_CMD_Get_CritBatV))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_CritBatV, AddressOf Ser_CMD_Set_CritBatV))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_BatConvFact, AddressOf Ser_CMD_Get_BatConvFact))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_BatConvFact, AddressOf Ser_CMD_Set_BatConvFact))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_ChargePumpTop, AddressOf Ser_CMD_Get_ChargePumpTop))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_ChargePumpTop, AddressOf Ser_CMD_Set_ChargePumpTop))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_ChargePumpReset, AddressOf Ser_CMD_Get_ChargePumpReset))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_ChargePumpReset, AddressOf Ser_CMD_Set_ChargePumpReset))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_Armed, AddressOf Ser_CMD_Get_Armed))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Set_Armed, AddressOf Ser_CMD_Set_Armed))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_RFVersion, AddressOf Ser_CMD_Get_RFVersion))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Cmd_TestDropoff, AddressOf Ser_CMD_Cmd_TestDropoff))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_BatVolt, AddressOf Ser_CMD_Get_BatVolt))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_LogEntries, AddressOf Ser_CMD_Get_LogEntries))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Cmd_ClearLogEntries, AddressOf Ser_CMD_Cmd_ClearLogEntries))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_Activations, AddressOf Ser_CMD_Get_Activations))
        CmdAry.Add(New Ser_CMD(CMD_ByteID.Get_Version, AddressOf Ser_CMD_Get_Version))
    End Sub

    Private Function bytes2Time(ByVal Bytes() As Byte) As DateTime
        Try
            Return New DateTime(Bytes(5) + 2000, Bytes(4), Bytes(3), Bytes(2), Bytes(1), Bytes(0))
        Catch ex As Exception
            Return New DateTime(1900, 1, 1)
        End Try

    End Function

    Private Function time2Bytes(ByVal Date_Time As DateTime) As Byte()
        Dim retBytes(5) As Byte
        retBytes(0) = Date_Time.Second
        retBytes(1) = Date_Time.Minute
        retBytes(2) = Date_Time.Hour
        retBytes(3) = Date_Time.Day
        retBytes(4) = Date_Time.Month
        retBytes(5) = Date_Time.Year - 2000

        Return retBytes
    End Function

    Private Function Ser_CMD_Get_DevTypeID(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToUInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Get_DevID(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(3) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 4)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToUInt32(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_DevID(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(3) As Byte

        tmpBuf = BitConverter.GetBytes(CType(ParamLst(0), UInt32))
        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 4)

    End Function

    Private Function Ser_CMD_Get_RTCTime(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = bytes2Time(tmpBuf)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_RTCTime(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum

        tmpBuf = time2Bytes(CType(ParamLst(0), DateTime))

        tmpErr = SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
        If tmpErr < 0 Then Return tmpErr

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Get_AlarmTime(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = bytes2Time(tmpBuf)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_AlarmTime(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum

        tmpBuf = time2Bytes(CType(ParamLst(0), DateTime))

        tmpErr = SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
        If tmpErr < 0 Then Return tmpErr

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Get_NextWakeupTime(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = bytes2Time(tmpBuf)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Get_DropActPeriod(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = tmpBuf(0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_DropActPeriod(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte

        tmpBuf(0) = CType(ParamLst(0), Byte)

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
    End Function

    Private Function Ser_CMD_Get_LowBatV(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToUInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_LowBatV(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte

        tmpBuf = BitConverter.GetBytes(CType(ParamLst(0), UInt16))

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)
    End Function

    Private Function Ser_CMD_Get_CritBatV(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToUInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_CritBatV(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte

        tmpBuf = BitConverter.GetBytes(CType(ParamLst(0), UInt16))

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)

    End Function

    Private Function Ser_CMD_Get_BatConvFact(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(3) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 4)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = System.Text.Encoding.Default.GetString(tmpBuf)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_BatConvFact(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(3) As Byte

        tmpBuf = System.Text.Encoding.Default.GetBytes(CType(ParamLst(0), String))

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 4)
    End Function

    Private Function Ser_CMD_Get_ChargePumpTop(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_ChargePumpTop(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte

        tmpBuf(0) = CType(ParamLst(0), Byte)

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
    End Function

    Private Function Ser_CMD_Get_ChargePumpReset(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Set_ChargePumpReset(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte

        tmpBuf(0) = CType(ParamLst(0), Byte)

        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
    End Function

    Private Function Ser_CMD_Get_Armed(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = tmpBuf(0)

        Return MyErr_Enum.MyErr_Success
    End Function

    Private Function Ser_CMD_Set_Armed(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte
        Dim tmpErr As MyErr_Enum

        '0xE6 is security byte
        tmpBuf(0) = &HE6
        tmpErr = SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        tmpBuf(0) = CType(ParamLst(0), Byte)
        Return SerComParent.Ser_RxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
    End Function

    Private Function Ser_CMD_Get_RFVersion(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = tmpBuf(0)

        Return MyErr_Enum.MyErr_Success
    End Function

    Private Function Ser_CMD_Cmd_TestDropoff(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        SerComParent.DoEventDelay(ParamLst(0))
    End Function

    Private Function Ser_CMD_Get_BatVolt(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(1) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 2)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = BitConverter.ToInt16(tmpBuf, 0)

        Return MyErr_Enum.MyErr_Success

    End Function

    Private Function Ser_CMD_Get_LogEntries(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(5) As Byte
        Dim tmpErr As MyErr_Enum
        Dim Entries As Byte = 0
        Dim timeAry() As DateTime
        Dim ValAry() As Byte
        Dim i As Integer

        'Read Number of entries
        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr
        Entries = tmpBuf(0)

        ReDim timeAry(Entries)
        ReDim ValAry(Entries)

        For i = 0 To Entries - 1
            tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
            If tmpErr < 0 Then Return tmpErr
            ValAry(i) = tmpBuf(0)

            tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 6)
            If tmpErr < 0 Then Return tmpErr
            timeAry(i) = bytes2Time(tmpBuf)
        Next

        ReDim RetVals(1)
        RetVals(0) = ValAry
        RetVals(1) = timeAry

        Return MyErr_Enum.MyErr_Success
    End Function

    Private Function Ser_CMD_Cmd_ClearLogEntries(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Return MyErr_Enum.MyErr_Success
    End Function

    Private Function Ser_CMD_Get_Activations(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(0) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 1)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = tmpBuf(0)

        Return MyErr_Enum.MyErr_Success
    End Function

    Private Function Ser_CMD_Get_Version(ByRef ParamLst() As Object, ByRef RetVals() As Object) As MyErr_Enum
        Dim tmpBuf(100) As Byte
        Dim tmpErr As MyErr_Enum

        tmpErr = SerComParent.Ser_TxSeg(SerComParent.Ser_Timeout, tmpBuf, 100)
        If tmpErr < 0 Then Return tmpErr

        RetVals(0) = System.Text.Encoding.Default.GetString(tmpBuf)

        Return MyErr_Enum.MyErr_Success

    End Function

End Class
