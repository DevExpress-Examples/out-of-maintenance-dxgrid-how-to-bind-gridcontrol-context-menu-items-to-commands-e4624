Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid


Namespace GridCommandToPopupMenuProject
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            persViewModel = New PersonViewModel(CreatePerson())
            DataContext = persViewModel
        End Sub

        Private persViewModel As PersonViewModel

        Private Function CreatePerson() As List(Of Person)
            Dim lPers As New List(Of Person)()
            For i As Integer = 0 To 14
                lPers.Add(New Person(i))
            Next i
            Return lPers
        End Function
    End Class
End Namespace
