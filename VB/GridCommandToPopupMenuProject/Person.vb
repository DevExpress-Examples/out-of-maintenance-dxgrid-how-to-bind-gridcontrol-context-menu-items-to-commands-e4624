Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace GridCommandToPopupMenuProject
    Public Class Person
        Public Sub New(ByVal i As Integer)
            FirstName = String.Format("FirstName - {0}", i)
            LastName = String.Format("LastName - {0}", i)
        End Sub
        Public Property FirstName() As String
        Public Property LastName() As String
    End Class
End Namespace
