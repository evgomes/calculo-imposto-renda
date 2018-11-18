import { SaveTaxpayer } from './../models/save-taxpayer';
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

  getTaxpayers() : Observable<Taxpayer[]> {
    return this.http.get('/api/taxpayers').pipe(map(taxpayers => taxpayers.json()));
  }

  getTaxpayer(id: number) : Observable<Taxpayer> {
    return this.http.get(`/api/taxpayers/${id}`).pipe(map(taxpayer => taxpayer.json()));
  }

  create(taxpayer: SaveTaxpayer) : Observable<Taxpayer> {
    const taxpayerToSave = this.getTaxpayerWithfixedCpfFormat(taxpayer);
    return this.http.post(`/api/taxpayers`, taxpayerToSave).pipe(map(taxpayer => taxpayer.json()));
  }

  update(id: number, taxpayer: SaveTaxpayer) : Observable<Taxpayer> {
    const taxpayerToSave = this.getTaxpayerWithfixedCpfFormat(taxpayer);
    return this.http.put(`/api/taxpayers/${id}`, taxpayerToSave).pipe(map(taxpayer => taxpayer.json()));
  }

  delete(id: number) : Observable<Taxpayer> {
    return this.http.delete(`/api/taxpayers/${id}`).pipe(map(taxpayer => taxpayer.json()));
  }

  private getTaxpayerWithfixedCpfFormat(taxpayer: SaveTaxpayer) : SaveTaxpayer {
    let taxpayerToSave = Object.assign({}, taxpayer);
    taxpayerToSave.cpf = taxpayerToSave.cpf.replace(/\D/g, '');

    return taxpayerToSave;
  }
}
