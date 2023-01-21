import { Component } from '@angular/core';
import { ContentComponent } from '../../shared/ui/content/content.component';
import { Tab } from '../../models/tab';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [ContentComponent],
  template: `
  <div class="row">
    <div class="col-sm-12 col-md-6 col-lg-6">
      <form (submit)="$event.preventDefault()">
        <div class="mb-3">
          <label for="exampleInputEmail1" class="form-label">Email address</label>
          <input
            type="email"
            class="form-control"
            id="exampleInputEmail1"
            aria-describedby="emailHelp"
          />
        </div>
        <div class="mb-3">
          <label for="exampleInputPassword1" class="form-label">Password</label>
          <input
            type="password"
            class="form-control"
            id="exampleInputPassword1"
          />
        </div>
        <button type="submit" class="btn btn-primary mb-2">Submit</button>
      </form>
    </div>

    <div class="col-sm-12 col-md-6 col-lg-6">
      <h4>Customer Informations</h4>
      <app-content [tabs]="customerTabs"></app-content>
    </div>
  </div>
  `
})
export class CustomersComponent {
  customerTabs = [{ name: 'General' }, { name: 'Details' }] as Tab[];
}