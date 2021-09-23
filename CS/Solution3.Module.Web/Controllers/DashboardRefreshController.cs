using System;
using System.Globalization;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Utils;

namespace Solution3.Module.Web.Controllers {
    public class DashboardRefreshController : ViewController<DashboardView> {
        public const string FilterSourceID = "FilterSource";
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            if(WebWindow.CurrentRequestWindow == null) return;
            WebWindow.CurrentRequestWindow.PagePreRender -= CurrentRequestWindow_PagePreRender;
            WebWindow.CurrentRequestWindow.PagePreRender += CurrentRequestWindow_PagePreRender;
        }

        private void CurrentRequestWindow_PagePreRender(object sender, EventArgs e) {
			if(View == null) return;
            DashboardViewItem sourceItem = (DashboardViewItem)View.FindItem(FilterSourceID);
            if(sourceItem.InnerView == null) return;
            ListView listView = (ListView)sourceItem.InnerView;
            ASPxGridListEditor editor = (ASPxGridListEditor)listView.Editor;
            if(editor == null) return;
            ICallbackManagerHolder holder = (ICallbackManagerHolder)WebWindow.CurrentRequestPage;
            string script = holder.CallbackManager.GetScript();
            script = string.Format(CultureInfo.InvariantCulture, @"
function(s, e) {{
    if(e.isChangedOnServer){{
        {0}
    }}else{{
        var xafCallback = function() {{
            s.EndCallback.RemoveHandler(xafCallback);
            {0}
        }};
        s.EndCallback.AddHandler(xafCallback);
    }}
}}
                ", script);
            ClientSideEventsHelper.AssignClientHandlerSafe(editor.Grid, "SelectionChanged", script, "DashboardRefreshController");
        }
    }
}
