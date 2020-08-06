import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import {AgGridModule} from 'ag-grid-angular';
import { AppComponent } from './app.component';
import { AgGridSampleComponent } from './ag-grid-sample/ag-grid-sample/ag-grid-sample.component';
import { SampleHeaderComponent } from './shared/sample-header/sample-header.component';
import { SampleFooterComponent } from './shared/sample-footer/sample-footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AddItemComponent } from './ag-grid-sample/add-item/add-item.component';

@NgModule({
  declarations: [
    AppComponent,
    AgGridSampleComponent,
    SampleHeaderComponent,
    SampleFooterComponent,
    AddItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,HttpClientModule,FormsModule, ReactiveFormsModule ,
    NgbModule,AgGridModule.withComponents([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
