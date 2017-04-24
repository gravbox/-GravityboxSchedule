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

Imports Gravitybox.Objects

Namespace Gravitybox.Forms

	Friend Class ScheduleAppearanceForm
		Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			cboStyle.Items.Add("Choose Theme")
			cboStyle.Items.Add(Gravitybox.Controls.Schedule.ThemeConstants.Office2003)
			cboStyle.Items.Add(Gravitybox.Controls.Schedule.ThemeConstants.Office2007)
			cboStyle.Items.Add(Gravitybox.Controls.Schedule.ThemeConstants.Energy)
			cboStyle.Items.Add(Gravitybox.Controls.Schedule.ThemeConstants.Sunny)
			cboStyle.Items.Add(Gravitybox.Controls.Schedule.ThemeConstants.Olive)
			cboStyle.SelectedIndex = 0

		End Sub

		'Form overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend WithEvents cmdCancel As System.Windows.Forms.Button
		Friend WithEvents cmdOK As System.Windows.Forms.Button
		Friend WithEvents lblHeader As System.Windows.Forms.Label
		Friend WithEvents cmdReset As System.Windows.Forms.Button
		Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
		Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
		Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
		Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
		Friend WithEvents cboStyle As System.Windows.Forms.ComboBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.cmdCancel = New System.Windows.Forms.Button
			Me.cmdOK = New System.Windows.Forms.Button
			Me.lblHeader = New System.Windows.Forms.Label
			Me.cmdReset = New System.Windows.Forms.Button
			Me.TabControl1 = New System.Windows.Forms.TabControl
			Me.TabPage1 = New System.Windows.Forms.TabPage
			Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
			Me.TabPage2 = New System.Windows.Forms.TabPage
			Me.TabPage3 = New System.Windows.Forms.TabPage
			Me.cboStyle = New System.Windows.Forms.ComboBox
			Me.Label1 = New System.Windows.Forms.Label
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.SuspendLayout()
			'
			'cmdCancel
			'
			Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdCancel.Location = New System.Drawing.Point(618, 426)
			Me.cmdCancel.Name = "cmdCancel"
			Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
			Me.cmdCancel.TabIndex = 5
			Me.cmdCancel.Text = "Cancel"
			'
			'cmdOK
			'
			Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdOK.Location = New System.Drawing.Point(530, 426)
			Me.cmdOK.Name = "cmdOK"
			Me.cmdOK.Size = New System.Drawing.Size(80, 24)
			Me.cmdOK.TabIndex = 4
			Me.cmdOK.Text = "OK"
			'
			'lblHeader
			'
			Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.lblHeader.Location = New System.Drawing.Point(8, 8)
			Me.lblHeader.Name = "lblHeader"
			Me.lblHeader.Size = New System.Drawing.Size(448, 56)
			Me.lblHeader.TabIndex = 3
			Me.lblHeader.Text = "This configuration screen allows you to setup the default look-and-feel of a sche" & _
					"dule."
			'
			'cmdReset
			'
			Me.cmdReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.cmdReset.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdReset.Location = New System.Drawing.Point(8, 424)
			Me.cmdReset.Name = "cmdReset"
			Me.cmdReset.Size = New System.Drawing.Size(80, 24)
			Me.cmdReset.TabIndex = 2
			Me.cmdReset.Text = "Reset"
			'
			'TabControl1
			'
			Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Controls.Add(Me.TabPage2)
			Me.TabControl1.Controls.Add(Me.TabPage3)
			Me.TabControl1.Location = New System.Drawing.Point(456, 40)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New System.Drawing.Size(248, 376)
			Me.TabControl1.TabIndex = 0
			'
			'TabPage1
			'
			Me.TabPage1.Controls.Add(Me.PropertyGrid1)
			Me.TabPage1.Location = New System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Size = New System.Drawing.Size(240, 350)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Schedule"
			'
			'PropertyGrid1
			'
			Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
			Me.PropertyGrid1.Name = "PropertyGrid1"
			Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.PropertyGrid1.Size = New System.Drawing.Size(240, 350)
			Me.PropertyGrid1.TabIndex = 1
			'
			'TabPage2
			'
			Me.TabPage2.Location = New System.Drawing.Point(4, 22)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Size = New System.Drawing.Size(240, 382)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "Row Header"
			'
			'TabPage3
			'
			Me.TabPage3.Location = New System.Drawing.Point(4, 22)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Size = New System.Drawing.Size(240, 382)
			Me.TabPage3.TabIndex = 2
			Me.TabPage3.Text = "Column Header"
			'
			'cboStyle
			'
			Me.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      'Me.cboStyle.FormattingEnabled = True
			Me.cboStyle.Location = New System.Drawing.Point(512, 8)
			Me.cboStyle.Name = "cboStyle"
			Me.cboStyle.Size = New System.Drawing.Size(184, 21)
			Me.cboStyle.TabIndex = 6
			'
			'Label1
			'
			Me.Label1.AutoSize = True
			Me.Label1.Location = New System.Drawing.Point(464, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(35, 13)
			Me.Label1.TabIndex = 7
			Me.Label1.Text = "Styles"
			'
			'ScheduleAppearanceForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(706, 455)
			Me.Controls.Add(Me.Label1)
			Me.Controls.Add(Me.cboStyle)
			Me.Controls.Add(Me.TabControl1)
			Me.Controls.Add(Me.cmdReset)
			Me.Controls.Add(Me.lblHeader)
			Me.Controls.Add(Me.cmdCancel)
			Me.Controls.Add(Me.cmdOK)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "ScheduleAppearanceForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Appointment Appearance"
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

#End Region

#Region "Class Members"

		Private m_MainObject As Gravitybox.Controls.Schedule
		Private Schedule1 As New Gravitybox.Controls.Schedule(False)

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

		Public Property MainObject() As Gravitybox.Controls.Schedule
			Get
				Return m_MainObject
			End Get
			Set(ByVal Value As Gravitybox.Controls.Schedule)
				m_MainObject = Value

				Try

					'Reset Appearanace object
					Schedule1.TabIndex = 4

					'Setup the schedule
					Me.Controls.Add(Schedule1)
					Schedule1.SetBounds(8, lblHeader.Top + lblHeader.Height + 8, TabControl1.Left - 16, TabControl1.Height - (lblHeader.Top + lblHeader.Height + 8))
					Schedule1.AllowAdd = False
					Schedule1.AllowCopy = False
					Schedule1.AllowDrop = False
					Schedule1.EventHeader.AllowHeader = False
					Schedule1.AllowForeignDrops = False
					Schedule1.AllowInPlaceEdit = False
					Schedule1.AllowMove = False
					Schedule1.AllowRemove = False
					Schedule1.AllowSelector = True
					Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.None
					Schedule1.AutoRedraw = True

					Schedule1.SetMinMaxDate(#1/1/2004#, #1/2/2004#)
					Schedule1.StartTime = #8:00:00 AM#
					Schedule1.DayLength = 6
					Schedule1.ColumnHeader.AutoFit = True
					Schedule1.RowHeader.AutoFit = True
					Schedule1.ScrollBars = ScrollBars.None
					Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger

					PropertyGrid1.HelpVisible = True
					PropertyGrid1.ToolbarVisible = False
					PropertyGrid1.PropertySort = PropertySort.Alphabetical

					'Setup the master appearance object
					Call SetupMaster()
					Schedule1.Refresh()

					'Setup the PropertyGrid
					PropertyGrid1.SelectedObject = Me.Schedule1.Appearance

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Set
		End Property

#End Region

#Region "Methods"

		Private Sub SetupMaster()

			Try
				'Setup the master appearance object
				Schedule1.Appearance.FromXML(MainObject.Appearance.ToXML())
				Schedule1.RowHeader.Appearance.FromXML(MainObject.RowHeader.Appearance.ToXML)
				Schedule1.ColumnHeader.Appearance.FromXML(MainObject.ColumnHeader.Appearance.ToXML)

				PropertyGrid1.Refresh()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs)

			Try
				Schedule1.Refresh()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

			Try
				'Reset Appearanace object
				MainObject.Appearance.FromXML(Schedule1.Appearance.ToXML)
				MainObject.RowHeader.Appearance.FromXML(Schedule1.RowHeader.Appearance.ToXML)
				MainObject.ColumnHeader.Appearance.FromXML(Schedule1.ColumnHeader.Appearance.ToXML)
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Me.Close()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

			Try
				Me.Close()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
			Call UpdateGrid()
		End Sub

		Private Sub OnBeforeAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
			e.Cancel = True
		End Sub

		Private Sub OnBeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs)
			'Cancel the property dialog if the user double clicks an appointment
			e.Cancel = True
		End Sub

		Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click

			Try
				Schedule1.AutoRedraw = False
				Schedule1.SetDefaultAppearance()
				Schedule1.SetDefaultRowColAppearance()
				Call UpdateGrid()
				Schedule1.AutoRedraw = True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub UpdateGrid()

			Try
				TabControl1.SelectedTab.Controls.Add(PropertyGrid1)
				If TabControl1.SelectedIndex = 0 Then
					PropertyGrid1.SelectedObject = Me.Schedule1.Appearance
				ElseIf TabControl1.SelectedIndex = 1 Then
					PropertyGrid1.SelectedObject = Me.Schedule1.RowHeader.Appearance
				ElseIf TabControl1.SelectedIndex = 2 Then
					PropertyGrid1.SelectedObject = Me.Schedule1.ColumnHeader.Appearance
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Event Handlers"

		Private Sub cboStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStyle.SelectedIndexChanged

			If Not (cboStyle.SelectedItem.GetType Is GetType(Gravitybox.Controls.Schedule.ThemeConstants)) Then
				Return
			End If

			Dim style As Gravitybox.Controls.Schedule.ThemeConstants = CType(cboStyle.SelectedItem, Gravitybox.Controls.Schedule.ThemeConstants)
			ThemeHelper.SetupStyleTheme(Schedule1, style)
			Me.UpdateGrid()

		End Sub

#End Region

	End Class

End Namespace