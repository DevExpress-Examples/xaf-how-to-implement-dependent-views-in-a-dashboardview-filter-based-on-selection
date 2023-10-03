<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4916)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# XAF - How to implement dependent views in a DashboardView (filter based on selection)

This example illustrates how to filter a ListView displayed in a DashboardView based on another ListView's selection.

## Scenario

When a [DashboardView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DashboardView) contains several list views, it is often required to make them dependent, e.g. display items of one ListView based on items or selection of another ListView.

![chrome_WHVRxufQHv](https://user-images.githubusercontent.com/14300209/226880445-1db093ce-416a-40e9-874a-13b931005242.gif)


## Implementation Details
1. Add a new [ViewController](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController) to the **YourSolutionName.Module** project. For more information, refer to the following file: [DashboardFilterController.cs](./CS/EFCore/DependentDashboardEF/DependentDashboardEF.Module/Controllers/DashboardFilterController.cs).
2. In the `OnActivated` method, retrieve `DashboardViewItems` via the `FindItem` method. Also, subscribe to the `ControlCreated` event of a `DashboardViewItem` whose `ListView` is used to filter data (hereinafter referred to as `SourceView`).
4. In the `ControlCreated` event handler retrieve the `SourceView` via the [DashboardViewItem.InnerView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.DashboardViewItem.InnerView?p=netframework) property and subscribe to its [SelectionChanged](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.View.SelectionChanged?p=netframework) event.
5. In the `SelectionChanged` event handler, retrieve the View to be filtered (hereinafter referred to as `TargetView`) in the same manner as in the previous step.
6. To get an object to filter on, use the [ListView.CurrentObject](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ListView.CurrentObject?p=netframework) property. This object must be loaded from `SourceView` Object Space to `TargetView` Object Space via the `GetObject` method.
7. Now you can add `CriteriaOperator` to the [TargetView.CollectionSource.Criteria](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.CollectionSourceBase.Criteria?p=netframework) dictionary to filter the `TargetView`. In this example, we created a `InOperator` to filter the **Position** column via objects from `SourceView`.

## Files to Review

- [DashboardFilterController.cs](./CS/EFCore/DependentDashboardEF/DependentDashboardEF.Module/Controllers/DashboardFilterController.cs) 

## Documentation

- [Display Multiple Views Side-by-Side (Dashboard View)](https://docs.devexpress.com/eXpressAppFramework/113296/ui-construction/views/layout/display-several-views-side-by-side)
- [DashboardView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DashboardView)

