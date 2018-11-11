import { TabItem } from './tab/tab-item';

export interface TabsInterface {
    title: string,                  // Title to display for the tab
    tabItem: TabItem, // Component to display
    canDisable?: boolean            // True if this tag should be disabled with the DisableTabs param
}
