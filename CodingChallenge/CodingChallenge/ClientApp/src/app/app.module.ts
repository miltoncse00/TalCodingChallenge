import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { calcMonthlyPremiumComponent } from "./MonthlyDeathPremium/calcMonthlyPremium.component";
import { DemoService } from "../shared/demoService";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    calcMonthlyPremiumComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: calcMonthlyPremiumComponent, pathMatch: 'full' },
      { path: 'calc-monthly-premium', component: calcMonthlyPremiumComponent }
    ])
  ],
  providers: [DemoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
