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
