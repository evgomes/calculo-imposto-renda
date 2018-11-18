import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { BasicWage } from '../models/basic-wage';

import { map } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class BasicWageService {

  constructor(private http: Http) { }

  getBasicWageData(): Observable<BasicWage> {
    return this.http.get('/api/basicwage').pipe(map(basicwage => basicwage.json()));
  }
}
