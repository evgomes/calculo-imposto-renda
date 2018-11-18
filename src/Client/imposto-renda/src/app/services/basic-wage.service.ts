import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BasicWage } from '../models/basic-wage';

@Injectable({
  providedIn: 'root'
})
export class BasicWageService {

  constructor(private http: Http) { }

  getBasicWageData(): Observable<BasicWage> {
    return this.http.get('/api/basicwage').pipe(map(basicwage => basicwage.json()));
  }

  recordBasicWageData(basicWage: BasicWage) : Observable<BasicWage> {
    return this.http.post('/api/basicwage', basicWage).pipe(map(basicWage => basicWage.json()));
  }
}
