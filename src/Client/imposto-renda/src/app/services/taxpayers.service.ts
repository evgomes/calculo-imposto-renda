import { map } from "rxjs/operators";

import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

import { Taxpayer } from '../models/taxpayer';

@Injectable({
  providedIn: 'root'
})
export class TaxpayersService {

  constructor(private http: Http) { }

  getTaxpayers() : Observable<Taxpayer> {
    return this.http.get('/api/taxpayers').pipe(map(taxpayers => taxpayers.json()));
  }
}
