import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AgGridSampleComponent } from './ag-grid-sample/ag-grid-sample/ag-grid-sample.component';
import { AppComponent } from './app.component';
import { AddItemComponent } from './ag-grid-sample/add-item/add-item.component';


const routes: Routes = [
  {path: '', component:AgGridSampleComponent},
  {path: 'sample-project-srijit', component:AgGridSampleComponent},
  {path: 'sample-project-srijit-insert', component:AddItemComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
