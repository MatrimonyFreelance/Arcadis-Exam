import { Component, OnInit } from '@angular/core';
import {AgServiceService} from '../ag-service.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';  
import { SampleModel } from '../sample-model';
@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {
  submitted: boolean= false;  
  itemForm: any;
  itemModel : SampleModel;
  constructor(private AgServiceService : AgServiceService,
    private formBuilder: FormBuilder,private router:Router) { }

  ngOnInit(): void {
    debugger;
    this.itemForm = this.formBuilder.group({  
      title: ["", Validators.required],  
      cost: ["", Validators.required],  
      quantity: ["", Validators.required],  
      costId: ["", Validators.required]
    });  
  }

  onSubmit() {  
    debugger;
    this.submitted = true;  
    if (this.itemForm.invalid) {  
      return;  
    } 
    this.itemModel = new SampleModel();

    this.itemModel.cost =  parseFloat(this.itemForm.controls.cost.value);
    this.itemModel.costInd =  this.itemForm.controls.costId.value;
    this.itemModel.quantity =  parseInt(this.itemForm.controls.quantity.value);
    this.itemModel.title =  this.itemForm.controls.title.value;

    this.AgServiceService.addNewItem(this.itemModel)  
      .subscribe( data => {  
        this.router.navigate(['sample-project-srijit']);  
      });  
  }  
  Cancel()  
  {  
    this.router.navigate(['sample-project-srijit']);  
  }  

}
