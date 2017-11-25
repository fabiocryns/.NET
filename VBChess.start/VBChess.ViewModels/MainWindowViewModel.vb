Imports System.Windows.Input
Imports VBChess.Shared

Public Class MainWindowViewModel
    Public Sub New()
        Me.PlayAgain = New PlayAgainCommand(Me)
        Me.Game = New Cell(Of GameViewModel)(New GameViewModel())
    End Sub
    Public ReadOnly Property PlayAgain As ICommand
    Public ReadOnly Property Game As ICell(Of GameViewModel)

    Private Sub Restart()
        Me.Game.Value = New GameViewModel()
    End Sub

    Private Class PlayAgainCommand
        Implements ICommand

        Public Sub New(vm As MainWindowViewModel)
            _vm = vm
        End Sub

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            _vm.Restart()
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Private _vm As MainWindowViewModel
    End Class
End Class