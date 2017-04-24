#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  <Serializable(), _
  DefaultProperty("Text"), _
  DefaultEvent("Refresh"), _
  TypeConverter(GetType(Gravitybox.Design.Converters.RoomConverter))> _
  Public Class Room
    Inherits BaseObject

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "room"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Private Const m_def_Visible As Boolean = True

    'Private Member Constants
    Private m_Notes As String = ""
		Private m_Visible As Boolean = m_def_Visible
		Protected m_Appearance As New Gravitybox.Objects.Appearance

#End Region

#Region "Constructors"

    Public Sub New()
      Me.New(Guid.NewGuid.ToString, "", "")
    End Sub

    Public Sub New(ByVal key As String)
      Me.New(key, "", "")
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String)
      Me.New(key, text, "")
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String, ByVal notes As String)
      MyBase.New(key, text)
      m_Notes = notes
			m_Visible = m_def_Visible
			Me.SetupDefaultAppearance()
      AddHandler Me.TextChanged, AddressOf TextChangedHandler
    End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.Room
				element.FromXML(Me.ToXML)
				element.SetKey(Guid.NewGuid.ToString)
				Return element
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing
    End Function

#End Region

#Region "Property Implementaions"

		''' <summary>
		''' This object contains all the format information for this object.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.AppearanceConverter)), _
		Description("This object contains all the format information for this object.")> _
		Public Property Appearance() As Gravitybox.Objects.Appearance
			Get
				Return m_Appearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.Appearance)
				If Value Is Nothing Then
					Me.SetupDefaultAppearance()
				Else
					RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
					m_Appearance = Value
					AddHandler m_Appearance.Refresh, AddressOf OnRefresh
				End If
				OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
			End Set
		End Property

		''' <summary>
		''' Determines note text associated with this object.
		''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("notes"), _
    Category("Data"), _
    DefaultValue(""), _
    Description("Determines note text associated with this object.")> _
    Public Property Notes() As String
      Get
        Return m_Notes
      End Get
      Set(ByVal Value As String)
        If m_Notes <> Value Then
          m_Notes = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if this object is visible.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    DefaultValue(m_def_Visible), _
    Description("Determines if this object is visible.")> _
    Public Property Visible() As Boolean
      Get
        Return m_Visible
      End Get
      Set(ByVal Value As Boolean)
        If m_Visible <> Value Then
          m_Visible = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

#End Region

#Region "Handlers"

		Private Sub TextChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub

#End Region

#Region "SetupDefaultAppearance"

		Private Sub SetupDefaultAppearance()

			Try
				'Create and default the appearance
				m_Appearance.FromXML((New Gravitybox.Objects.Appearance).ToXML())
				Me.Appearance.BackColor = System.Drawing.Color.LightBlue
				Me.Appearance.ForeColor = System.Drawing.Color.Black
				Me.Appearance.HatchStyle = Drawing2D.HatchStyle.Min
				Me.Appearance.HatchColor = System.Drawing.Color.LightGray
				Me.Appearance.BorderColor = System.Drawing.Color.FromArgb(&H5A, &H8E, &HCE)
				Me.Appearance.StringFormatFlags = StringFormatFlags.FitBlackBox
				Me.Appearance.Alignment = StringAlignment.Center
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "XML"

		Public Overloads Overrides Function ToXML() As String

			Dim xmlHelper As New Gravitybox.Objects.XMLHelper
			Dim XMLDoc As New Xml.XmlDocument
			Dim parentNode As Xml.XmlElement
			Dim elemNew As Xml.XmlNode

			Try
				'Setup the Node Name
				parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

				'Add the appropriate properties
				Call xmlHelper.addElement(parentNode, "key", Me.Key)
				Call xmlHelper.addElement(parentNode, "text", Me.Text)
				Call xmlHelper.addElement(parentNode, "notes", m_Notes)
				Call xmlHelper.addElement(parentNode, "visible", m_Visible.ToString)

				'TODO
				'Appearanace is not Serialized

				'PropertyItemCollection
        elemNew = xmlHelper.addElement(parentNode, PropertyItemCollection.MyXMLNodeName, "")
				elemNew.InnerXml = PropertyItemCollection.XmlNode.InnerXml

				'Return the XML string
				Return parentNode.OuterXml

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

		Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean

			Dim XMLDoc As New xml.XmlDocument

			Try

				'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				Me.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
				Me.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))
				m_Notes = GetNodeValue(XMLDoc, startXPath & "notes", m_Notes)
				m_Visible = CBool(GetNodeValue(XMLDoc, startXPath & "visible", m_Visible.ToString))

				'TODO
				'Appearanace is not Serialized

				If Not shallow Then
					'Objects
					PropertyItemCollection.Clear()
					PropertyItemCollection.FromXML(GetNodeXML(XMLDoc, startXPath & PropertyItemCollection.MyXMLNodeName, "", True))
				End If

				If Not cancelEvents Then
					OnReload(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
					OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
				End If

				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean
      Return FromXML(xml, False, False)
    End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overloads Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

	End Class

End Namespace
