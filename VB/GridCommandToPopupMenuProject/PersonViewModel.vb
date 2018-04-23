Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Input
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports DevExpress.Xpf.Mvvm

Namespace GridCommandToPopupMenuProject
    Friend Class PersonViewModel
        Implements INotifyPropertyChanged

        Public Sub New(ByVal lPerson As List(Of Person))
            ListPerson = New ObservableCollection(Of Person)()
            For Each p As Person In lPerson
                ListPerson.Add(p)
            Next p
        End Sub

        Public Property ListPerson() As ObservableCollection(Of Person)
        Public Property SelectedPerson() As Person
            Get
                Return _selectedPerson
            End Get
            Set(ByVal value As Person)
                _selectedPerson = value
                NotifyPropertyChanged()
            End Set
        End Property
        Public Property SelectedPersonNum() As Integer
            Get
                Return _selectedPersonNum
            End Get
            Set(ByVal value As Integer)
                _selectedPersonNum = value
                SelectedPerson = ListPerson(value)
                NotifyPropertyChanged()
            End Set
        End Property

        Private _selectedPerson As Person
        Private _selectedPersonNum As Integer

        Public ReadOnly Property CreateNewPerson() As ICommand
            Get
                If createNewPerson_Renamed Is Nothing Then
                    createNewPerson_Renamed = New DelegateCommand(Of Person)(Sub(p) CreatePerson())
                End If
                Return createNewPerson_Renamed
            End Get
        End Property
        Public ReadOnly Property DeletePerson() As ICommand
            Get
                If deletePerson_Renamed Is Nothing Then
                    deletePerson_Renamed = New DelegateCommand(Of Person)(Sub(p) DelPerson(), Function(o) CanDeletePerson())
                End If
                Return deletePerson_Renamed
            End Get
        End Property
        Public ReadOnly Property GoToFivePersonNext() As ICommand
            Get
                If goToFivePersonNext_Renamed Is Nothing Then
                    goToFivePersonNext_Renamed = New DelegateCommand(Of Person)(Sub(p) GoTo5PersonNext(), Function(o) CanGoToFivePersonNext())
                End If
                Return goToFivePersonNext_Renamed
            End Get
        End Property


        Private createNewPerson_Renamed As DelegateCommand(Of Person)

        Private deletePerson_Renamed As DelegateCommand(Of Person)

        Private goToFivePersonNext_Renamed As DelegateCommand(Of Person)

        Private Sub CreatePerson()
            Dim p As New Person(1)
            p.FirstName = "test"
            p.LastName = "test"
            ListPerson.Add(p)
        End Sub

        Private Sub DelPerson()
            ListPerson.Remove(SelectedPerson)
        End Sub
        Private Function CanDeletePerson() As Boolean
            Return SelectedPerson IsNot Nothing
        End Function

        Private Sub GoTo5PersonNext()
            SelectedPersonNum += 5
        End Sub
        Private Function CanGoToFivePersonNext() As Boolean
            Return SelectedPersonNum + 5 < ListPerson.Count
        End Function

#Region "INotifyPropertyChanged Members"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Private Sub NotifyPropertyChanged(Optional ByVal propertyName As String = "")
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
#End Region
    End Class
End Namespace
