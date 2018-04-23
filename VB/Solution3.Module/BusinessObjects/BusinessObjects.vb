Imports System
Imports System.Linq
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.Persistent.BaseImpl

' With XPO, the data model is declared by classes (so-called Persistent Objects) that will define the database structure, and consequently, the user interface (http://documentation.devexpress.com/#Xaf/CustomDocument2600).
Namespace Solution4.Module.BusinessObjects
	Public Enum TitleOfCourtesy
		Dr
		Miss
		Mr
		Mrs
		Ms
	End Enum

	<DefaultClassOptions>
	Public Class Contact
		Inherits Person

        Private fTitleOfCourtesy As TitleOfCourtesy
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Property TitleOfCourtesy() As TitleOfCourtesy
			Get
                Return fTitleOfCourtesy
			End Get
			Set(ByVal value As TitleOfCourtesy)
                SetPropertyValue("TitleOfCourtesy", fTitleOfCourtesy, value)
			End Set
		End Property
        Private fPosition As Position
		<ImmediatePostDataAttribute>
		Public Property Position() As Position
			Get
                Return fPosition
			End Get
			Set(ByVal value As Position)
                SetPropertyValue("Position", fPosition, value)
			End Set
		End Property
	End Class

	<DefaultClassOptions, DefaultProperty("Title")>
	Public Class Position
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
        Private fTitle As String
		Public Property Title() As String
			Get
                Return fTitle
			End Get
			Set(ByVal value As String)
                SetPropertyValue("Title", fTitle, value)
			End Set
		End Property
	End Class
End Namespace
