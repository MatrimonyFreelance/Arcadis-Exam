import { Component, OnInit } from '@angular/core';
import {ColDef,GridApi,ColumnApi} from 'ag-grid-community';
import { Router } from '@angular/router';  
import { SampleModel } from '../sample-model';
import {AgServiceService} from '../ag-service.service';
import { ExcelServiceService } from 'src/app/shared/excel-service.service';

@Component({
  selector: 'app-ag-grid-sample',
  templateUrl: './ag-grid-sample.component.html',
  styleUrls: ['./ag-grid-sample.component.css']
})
export class AgGridSampleComponent implements OnInit {

  public sampleModels: any[];  
  public columnDefs: ColDef[];
  private api: GridApi;  
  isOpenGrid : boolean;
  private columnApi: ColumnApi;  
  itemModel: SampleModel;
  searchText : string;
  constructor(private agService: AgServiceService, private router: Router, private excelService:ExcelServiceService) {  
    this.columnDefs = this.createColumnDefs();  

  }
  onGridReady(params): void {  
    debugger;
    this.api = params.api;  
    this.columnApi = params.columnApi;  
    this.api.sizeColumnsToFit();  
}
private createColumnDefs() {  
        return [{  
            headerName: 'Title',  
            field: 'title',  
            filter: true,  
            enableSorting: true,  
            editable: true,  
            sortable: true  
        }, {  
            headerName: 'Cost',  
            field: 'costDesc',  
            filter: true,  
            editable: true,  
            sortable: true  
        }, {  
            headerName: 'Quantity',  
            field: 'quantity',  
            filter: true,  
            sortable: true,  
            editable: true 
        }, {  
            headerName: 'TotalCost',  
            field: 'totalCost',  
            filter: true,  
            editable: true,  
            sortable: true  
        }]  
    } 


  ngOnInit(): void {
    this.agService.getallItem().subscribe(data => {  
      debugger;
      this.sampleModels = data.data.map((p:any) => p); 
  })
  }
  openGrid(){
    this.isOpenGrid = !this.isOpenGrid;
  }

  status: any;  
    editWork() {  
        debugger;  
        if (this.api.getSelectedRows().length == 0) {  
          return;
        }  
        var row = this.api.getSelectedRows();  
        this.itemModel = new SampleModel();
        this.itemModel.cost =  parseFloat(row[0].cost);
        this.itemModel.costInd =  row[0].costInd;
        this.itemModel.quantity =  parseInt(row[0].quantity);
        this.itemModel.title =  row[0].title;
        this.itemModel.id = row[0].id;
        this.itemModel.costDesc = row[0].costDesc;
        this.sampleModels = [];
        this.agService.updateItem(this.itemModel).subscribe(data => {              
          this.sampleModels = data.data.map((p:any) => p);   
        });  
    }  
    deleteWork() {  
        debugger;  
        var selectedRows = this.api.getSelectedRows();  
        if (selectedRows.length == 0) {  
            return;  
        }  
        this.sampleModels = [];
        this.agService.deleteItem(selectedRows[0].id).subscribe(data => {              
          this.sampleModels = data.data.map((p:any) => p);   
        });  
    }  
    AddWork() {  
        this.router.navigate(['sample-project-srijit-insert']);  
    }
    Search(){
      debugger;
      if (this.searchText == undefined || this.searchText == null || this.searchText == "") {  
        this.sampleModels = [];
        this.agService.getallItem().subscribe(data => {  
          this.sampleModels = data.data.map((p:any) => p); 
        })  
      }
      else{

        this.sampleModels = [];
        this.agService.getallSearchItem(this.searchText).subscribe(data => {              
          this.sampleModels = data.data.map((p:any) => p);   
        });  
      }

    }
    
    exportToExcel(){
      debugger;
      this.excelService.exportAsExcel(this.sampleModels,"SampleFile");
    }
}
