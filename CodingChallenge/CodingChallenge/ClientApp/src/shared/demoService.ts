import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InsuredInput } from './insured.model';
import { Observable } from 'rxjs';


@Injectable()
export class DemoService {
  myAppUrl: string = "";

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }


  calcMonthlyPremium(insuredInput: InsuredInput) {

    return this.httpClient.post(this.myAppUrl + "api/DeathSumPremium/MonthlyDeathPremium", insuredInput);
  }

  getOccupation(): Observable<string[]> {

    return this.httpClient.get<string[]>(this.myAppUrl + "api/DeathSumPremium/Occupations");

  }
}
