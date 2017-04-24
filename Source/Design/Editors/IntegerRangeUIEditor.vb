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
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

Namespace Gravitybox.Design.Editors

  Friend Class IntegerRangeUIEditor
    Inherits System.Drawing.Design.UITypeEditor

    Dim ui As Gravitybox.Design.UIControls.IntegerRangeControl

#Region "Edit Style"

    Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
      Return System.Drawing.Design.UITypeEditorEditStyle.DropDown
    End Function

    Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object

      'Get the editor service.
      Dim edSvc As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
      If (edSvc Is Nothing) Then Return value

      'Create our UI
      If ui Is Nothing Then ui = New Gravitybox.Design.UIControls.IntegerRangeControl

      'Initialize the UI
      ui.Minimum = 0
      ui.Maximum = 100
      ui.SmallChange = 1
      ui.LargeChange = 10
      ui.TickFrequency = 5
      ui.Value = GetIntlInteger(CType(value, String))

      'Instruct the editor service to display the control as a dropdown.
      edSvc.DropDownControl(ui)
      Return ui.Value

    End Function

#End Region

  End Class

End Namespace
