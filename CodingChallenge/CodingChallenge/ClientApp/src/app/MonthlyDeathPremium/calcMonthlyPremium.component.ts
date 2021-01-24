import { Component, OnInit } from '@angular/core'
import { FormGroup, FormBuilder, FormControl, Validators} from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

import { DemoService } from "../../shared/demoService";
import { DeathPremium } from "../../shared/insured.model";

@Component({
  selector: 'calc-monthly-premium',
  templateUrl: './calcMonthlyPremium.component.html',
  styleUrls: ['./calcMonthlyPremium.component.css']
})
export class calcMonthlyPremiumComponent implements OnInit {
  constructor(private fb: FormBuilder, private demoService: DemoService) { }
  myForm: FormGroup;
  successfulSave: boolean;
  errors: string[];
  occupations: string[];
  deathPremium: DeathPremium;
  ngOnInit(): void {
    this.errors = [];
    this.demoService.getOccupation().subscribe((data:string[]) => {
        this.occupations = data;
    });

    this.myForm = this.fb.group({
      name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      age: new FormControl('', [Validators.required,Validators.min(0), Validators.max(150)]),
      dateOfBirth: new FormControl(this.currentDate(), Validators.maxLength(10)),
      deathSumInsured: new FormControl('', [Validators.required, Validators.min(1), Validators.max(9999999999.99)]),
      occupation: new FormControl('', [Validators.required])
    });
    
  }

  currentDate() {
    const currentDate = new Date();
    return currentDate.toISOString().substring(0, 10);
  }

  onOccupationChange = () => {
    if (this.myForm.valid) {
      this.demoService.calcMonthlyPremium(this.myForm.value).subscribe(
        (data: DeathPremium) => {
          alert(data);
          this.deathPremium = data;
          alert(this.deathPremium.monthlyDeathPremium);

        },
        (err: HttpErrorResponse) => {

          if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            this.errors.push(err.error.message);
          } else {
            if (err.status == 400) {
              var json = JSON.stringify(err.error);
              let validationErrorDictionary = JSON.parse(json);
              for (var fieldName in err.error) {
                if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                  this.errors.push(validationErrorDictionary[fieldName]);
                }
              }
            } else {
              this.errors.push("something went wrong!");
            }
          }
        });
    }


  }
}
