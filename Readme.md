<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128591509/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4916)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DashboardFilterController.cs](./CS/EFCore/DependentDashboardEF/DependentDashboardEF.Module/Controllers/DashboardFilterController.cs) 
<!-- default file list end -->
# How to implement dependent views in a DashboardView (filter based on selection)

This example illustrates how to filter a ListView displayed in a DashboardView based on another ListView's selection.

###Scenario

When a [DashboardView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DashboardView) contains several list views, it is often required to make them dependent, e.g. display items of one ListView based on items or selection of another ListView.

Steps to implement
1. Add a new ViewController to your platform-agnostic module (DashboardFilterController).
2. In the OnActivated method retrieve the necessary DashboardViewItems via the FindItem method. After that subscribe to the ControlCreated event of the DashboardViewItem whose ListView will be used for filtering (hereinafter referred to as SourceView).
3. In the ControlCreated event handler retrieve the SourceView via the DashboardViewItem.InnerView property and subscribe to its SelectionChanged event.
4. In the SelectionChanged event handler retrieve the View that will be filtered (hereinafter referred to as TargetView) in the same manner as in the previous step.
5. To retrieve an object by which filtering will be performed, use the ListView.CurrentObject property. This object must be loaded from SourceView ObjectSpace to TargetView ObjectSpace via the GetObject method.
6. Now you can simply filter the TargetView by adding CriteriaOperator to the TargetView.CollectionSource.Criteria dictionary. In my example, I created a simple InOperator to filter the Position column via objects from SourceView.



