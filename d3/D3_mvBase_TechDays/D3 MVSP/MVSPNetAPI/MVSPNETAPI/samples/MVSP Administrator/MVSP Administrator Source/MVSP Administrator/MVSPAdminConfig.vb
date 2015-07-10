Imports System.Xml
Imports System.IO
Public Class MVSPAdminConfig

    Private xmldoc As New Xml.XmlDocument
    

    'Private appdir As String = Environ("APPDATA")
    'Private xmlfiledir As String = appdir & "\TigerLogic\MVSP Administrator\"
    'Private xmlconfigdir As String = appdir & "connection\"
    'Private xmlconfigfile As String = xmlfiledir & "config.xml"
    Dim xmlconfigfile As String
    Private xmle As Xml.XmlElement
    


    Public Function load(ByVal xmlconfigfile As String) As Boolean

        Try
            xmldoc.Load(xmlconfigdir & xmlconfigfile)

        Catch ex As Exception
            Try
                If System.IO.Directory.Exists(xmlconfigdir) Then
                Else
                    System.IO.Directory.CreateDirectory(appdir & "\TigerLogic")
                    System.IO.Directory.CreateDirectory(appdir & "\TigerLogic\MVSP Administrator")
                    System.IO.Directory.CreateDirectory(appdir & "\TigerLogic\MVSP Administrator\connection")
                End If
                createxml(xmlconfigfile)
                xmldoc.Load(xmlconfigdir & xmlconfigfile)
            Catch ex1 As Exception
            End Try

        End Try
        
        Return True
    End Function
    Public Function getconfigxml(ByVal parameter As String) As String
        Dim value As String = ""

        Try
            xmle = xmldoc.DocumentElement.Item(parameter)
            value = xmle.InnerText
        Catch ex As Exception
            value = "*Not Exist*"
        End Try
        Return value
    End Function
    Public Function setconfigxml(ByVal parameter As String, ByVal value As String) As Boolean
        Try
            Dim tmpvalue As String
            tmpvalue = getconfigxml(parameter)
            If tmpvalue = "*Not Exist*" Then
                xmle = xmldoc.CreateNode(XmlNodeType.Element, "", parameter, "")
                xmle.InnerText = value
                xmldoc.DocumentElement.AppendChild(xmle)
            Else
                xmle.InnerText = value
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Function saveconfig(ByVal xmlconfigfile As String) As Boolean
        Try
            xmldoc.Save(xmlconfigdir & xmlconfigfile)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function createxml(ByVal xmlconfigfile As String) As Boolean
        Try
            Dim sr As StreamWriter = File.CreateText(xmlconfigdir & xmlconfigfile)
            sr.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            sr.WriteLine("<Configuration>")
            sr.WriteLine("</Configuration>")
            sr.Close()
            sr = Nothing
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class

