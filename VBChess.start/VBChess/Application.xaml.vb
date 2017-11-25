Imports VBChess.ViewModels

Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Protected Overrides Sub OnStartup(e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim window As New MainWindow()
        window.DataContext = New MainWindowViewModel()
        window.Show()
    End Sub
End Class
