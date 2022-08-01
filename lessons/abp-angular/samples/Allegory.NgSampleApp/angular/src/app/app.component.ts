import { eLayoutType, RoutesService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent implements OnInit {

  constructor(private readonly routesService: RoutesService) { }

  ngOnInit(): void {
    this.routesService.add([
      {
        path: '/customers',
        name: 'Müşteriler',
        order: 3,
        layout: eLayoutType.application,
        iconClass: 'fa fa-users',
      }
    ]);
  }
}