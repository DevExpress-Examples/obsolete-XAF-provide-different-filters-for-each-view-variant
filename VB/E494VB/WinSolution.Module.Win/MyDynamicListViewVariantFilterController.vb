Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.ViewVariantsModule
Imports DevExpress.Data.Filtering

Namespace WinSolution.Module.Win
	Partial Public Class MyDynamicListViewVariantFilterController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
		End Sub
		Protected Overrides Overloads Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			AddHandler Frame.GetController(Of ChangeVariantController)().ChangeVariantAction.Executed, AddressOf ChangeVariantAction_Executed
		End Sub
		Private criteria As CriteriaOperator = Nothing
		Private Sub ChangeVariantAction_Executed(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.ActionBaseEventArgs)
			If Frame.View.Id = "DomainObject1_ListView" Then
				criteria = CriteriaOperator.Parse("FirstName LIKE 'A%'")
			Else
				If Frame.View.Id = "DomainObject1_ListView_Variant1" Then
					criteria = CriteriaOperator.Parse("FirstName LIKE 'B%'")
				End If
			End If
			CType(Frame.View, ListView).CollectionSource.Criteria("MyFilter") = criteria
		End Sub
	End Class
End Namespace
