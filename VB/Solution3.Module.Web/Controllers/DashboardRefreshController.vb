Imports System
Imports System.Globalization
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.ExpressApp.Web.Templates
Imports DevExpress.ExpressApp.Web.Utils

Namespace Solution3.Module.Web.Controllers
	Public Class DashboardRefreshController
		Inherits ViewController(Of DashboardView)

		Public Const FilterSourceID As String = "FilterSource"
		Protected Overrides Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			If WebWindow.CurrentRequestWindow Is Nothing Then
				Return
			End If
			RemoveHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
			AddHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
		End Sub

		Private Sub CurrentRequestWindow_PagePreRender(ByVal sender As Object, ByVal e As EventArgs)
			If View Is Nothing Then
				Return
			End If
			Dim sourceItem As DashboardViewItem = CType(View.FindItem(FilterSourceID), DashboardViewItem)
			If sourceItem.InnerView Is Nothing Then
				Return
			End If
			Dim listView As ListView = CType(sourceItem.InnerView, ListView)
			Dim editor As ASPxGridListEditor = CType(listView.Editor, ASPxGridListEditor)
			If editor Is Nothing Then
				Return
			End If
			Dim holder As ICallbackManagerHolder = DirectCast(WebWindow.CurrentRequestPage, ICallbackManagerHolder)
			Dim script As String = holder.CallbackManager.GetScript()
			script = String.Format(CultureInfo.InvariantCulture, "" & ControlChars.CrLf & _
"                function(s, e) {{" & ControlChars.CrLf & _
"                    var xafCallback = function() {{" & ControlChars.CrLf & _
"                        s.EndCallback.RemoveHandler(xafCallback);" & ControlChars.CrLf & _
"                        {0}" & ControlChars.CrLf & _
"                    }};" & ControlChars.CrLf & _
"                    s.EndCallback.AddHandler(xafCallback);" & ControlChars.CrLf & _
"                }}" & ControlChars.CrLf & _
"                ", script)
			ClientSideEventsHelper.AssignClientHandlerSafe(editor.Grid, "SelectionChanged", script, "DashboardRefreshController")
		End Sub
	End Class
End Namespace
