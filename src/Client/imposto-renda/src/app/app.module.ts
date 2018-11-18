import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { TaxpayersListComponent } from './components/taxpayers-list/taxpayers-list.component';

import { RealCurrencyPipe } from './pipes/real-currency-pipe';
import { BasicWageBadgeComponent } from './components/basic-wage-badge/basic-wage-badge.component';
import { TaxpayersViewComponent } from './components/taxpayers-view/taxpayers-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TaxpayersListComponent,
    RealCurrencyPipe,
    BasicWageBadgeComponent,
    TaxpayersViewComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: TaxpayersViewComponent, pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
