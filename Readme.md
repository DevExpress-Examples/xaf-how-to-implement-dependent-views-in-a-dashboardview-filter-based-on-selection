<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128591509/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4916)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# XAF - How to implement dependent views in a DashboardView (filter based on selection)

This example illustrates how to filter a ListView displayed in a DashboardView based on another ListView's selection.

## Scenario

When a [DashboardView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DashboardView) contains several list views, it is often required to make them dependent, e.g. display items of one ListView based on items or selection of another ListView.

![chrome_WHVRxufQHv](https://user-images.githubusercontent.com/14300209/226880445-1db093ce-416a-40e9-874a-13b931005242.gif)


## Implementation Details
1. Add a new [ViewController](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController) to your platform-agnostic module ([DashboardFilterController.cs](./CS/EFCore/DependentDashboardEF/DependentDashboardEF.Module/Controllers/DashboardFilterController.cs) ).
2. Access the target and source views.
3. Handle the source view's list view selection changed event.
4. In the event handler, filter the target view.

## Files to Review

- [DashboardFilterController.cs](./CS/EFCore/DependentDashboardEF/DependentDashboardEF.Module/Controllers/DashboardFilterController.cs) 

## Documentation

- [Display Multiple Views Side-by-Side (Dashboard View)](https://docs.devexpress.com/eXpressAppFramework/113296/ui-construction/views/layout/display-several-views-side-by-side)
- [DashboardView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DashboardView)

