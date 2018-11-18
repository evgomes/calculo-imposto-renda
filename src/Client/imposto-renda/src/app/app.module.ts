import { CommonModule } from '@angular/common';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CPFMask } from 'cpf-mask-ng2';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { BasicWageBadgeComponent } from './components/basic-wage-badge/basic-wage-badge.component';
import { BasicWageFormComponent } from './components/basic-wage-form/basic-wage-form.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { TaxpayerFormComponent } from './components/taxpayer-form/taxpayer-form.component';
import { TaxpayersListComponent } from './components/taxpayers-list/taxpayers-list.component';
import { TaxpayersViewComponent } from './components/taxpayers-view/taxpayers-view.component';
import { CpfPipe } from './pipes/cpf-pipe';
import { RealCurrencyPipe } from './pipes/real-currency-pipe';
import { AppErrorHandler } from './app-error-handler';

 
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    TaxpayersListComponent,
    RealCurrencyPipe,
    BasicWageBadgeComponent,
    TaxpayersViewComponent,
    TaxpayerFormComponent,
    BasicWageFormComponent,
    CPFMask,
    CpfPipe
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastrModule.forRoot(),
    NgbModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'contribuintes/novo', pathMatch: 'full' },
      { path: 'contribuintes/listar', component: TaxpayersViewComponent },
      { path: 'contribuintes/novo', component: TaxpayerFormComponent },
      { path: 'contribuintes/editar/:id', component: TaxpayerFormComponent },
      { path: 'salariominimo/editar', component: BasicWageFormComponent },
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
