Namespace Solution3.Win
	Partial Public Class Solution3WindowsFormsApplication
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
			Me.module3 = New Solution3.Module.Solution3Module()
			Me.module4 = New Solution3.Module.Win.Solution3WindowsFormsModule()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' Solution3WindowsFormsApplication
			' 
			Me.ApplicationName = "Solution3"
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.Solution3WindowsFormsApplication_DatabaseVersionMismatch)
'			Me.CustomizeLanguagesList += New System.EventHandler(Of DevExpress.ExpressApp.CustomizeLanguagesListEventArgs)(Me.Solution3WindowsFormsApplication_CustomizeLanguagesList)
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
		Private module3 As Solution3.Module.Solution3Module
		Private module4 As Solution3.Module.Win.Solution3WindowsFormsModule
	End Class
End Namespace
