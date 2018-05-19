using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ViewVariantsModule;
using DevExpress.Data.Filtering;

namespace WinSolution.Module.Win {
    public partial class MyDynamicListViewVariantFilterController : ViewController {
        public MyDynamicListViewVariantFilterController() {
            InitializeComponent();
            RegisterActions(components);
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            Frame.GetController<ChangeVariantController>().ChangeVariantAction.Executed += new System.EventHandler<DevExpress.ExpressApp.Actions.ActionBaseEventArgs>(ChangeVariantAction_Executed);
        }
        CriteriaOperator criteria = null;
        void ChangeVariantAction_Executed(object sender, DevExpress.ExpressApp.Actions.ActionBaseEventArgs e) {
            if (Frame.View.Id == "DomainObject1_ListView") {
                criteria = CriteriaOperator.Parse("FirstName LIKE 'A%'");
            }
            else
                if (Frame.View.Id == "DomainObject1_ListView_Variant1") {
                    criteria = CriteriaOperator.Parse("FirstName LIKE 'B%'");
                }
            ((ListView)Frame.View).CollectionSource.Criteria["MyFilter"] = criteria;
        }
    }
}
