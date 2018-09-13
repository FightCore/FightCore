# What is this?
Components to display material tabs with arbitrary components within them.
There are three main areas:
* TabsComponent: The main element consumers will use. Handles generating the actual tab bar
* TabContentsComponent: Defines a single tab's contents. Handles generating the actual tab contents
* Support files: Miscellaneous files necessary for the components to run

## Support Files
* tabs.interface.ts: Defines the overarching interface (TabsInterface) used to generate all tabs. Includes primarily data for TabsComponent, with TabItem for specific tabs
* tab-item.ts: Defines the data for a single component. Construct with intended Component and data to pass into component
* tab/tab-component.interface.ts: Simple interface used to define the data passed into a component. Content components are expected
* tab/tab.directive.ts: Defines the directive used on a ng-template tag to grab the associated here to place the tab contents
* tab-example/: Defines a simple example tab component. Useful for testing

## How to use? TabsComponent / All tabs
1. Include the TabsComponent in template ('app-tabs')
2. Set up tabs (array of TabsInterface) in your main component (let's call this "tabsInfo")
3. Pass in your tabs into the TabsComponent via the 'tabs' input property (eg, '<app-tabs [tabs]="tabsInfo"></app-tabs>')
4. Optionally, if you want to disable certain tabs, bind to the 'disableTabs' boolean property. In addition, define which tabs you wish to possibly disable via the 'canDisable' property in TabsInterface.

Note: Only supporting toggling all possible tabs together due to currently no foreseeable reason to individually toggle tabs in the future. Should be easy to add in the future, but rather not overcomplicate this unnecessarily

### Example
Template -
```<app-tabs [tabs]="tabsInfo" [disableTabs]="tabsDisabled"></app-tabs>```

Component ts -
```
import { Component, OnInit } from '@angular/core';
import { TabItem } from '../../components/tabs/tab/tab-item';
import { TabExampleComponent } from '../../components/tabs/tab-example/tab-example.component';
import { TabsInterface } from '../../components/tabs/tabs.interface';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html'
})
export class ExampleComponent implements OnInit {
  tabItems: TabsInterface[];    // Tabs to generate
  tabsDisabled: boolean = true; // Defines if tabs should be disabled
    
  constructor() { }

  ngOnInit() {
    // Initialize tabs
    this.tabItems = [
      {
        title: "First Tab",
        tabItem: new TabItem(TabExampleComponent, {testData: "First tab data"})
      },
      {
        title: "Second Tab",
        tabItem: new TabItem(TabExampleComponent, {testData: "Second tab data"})
      },
      {
        title: "Disabled Tab",
        tabItem: new TabItem(TabExampleComponent, {testData: "Third tab data"}),
        canDisable: true
      }
    ];
  }

}
```

## How to use? TabComponentInterface / Define a component as a tab content
This is for components that are meant to be in the content area of a tab.

1. Create any sort of component and implement TabComponentInterface
2. Make 'data' an input property
3. Use 'data' as necessary within your component

And that's it! Interface isn't completely necessary, but should be used for ease of maintainability in the future.

### Example
All in one:
```
import { TabComponentInterface } from './../tab/tab-component.interface';
import { Component, Input } from '@angular/core';

@Component({
  template: `
    <div>
      <h4>Tab Example: {{ data.testData }} </h4>
    </div>
  `
})
export class TabExampleComponent implements TabComponentInterface {
  @Input('data') data: any; // Likely should use interface to define expected data (eg, testData property)

}
```