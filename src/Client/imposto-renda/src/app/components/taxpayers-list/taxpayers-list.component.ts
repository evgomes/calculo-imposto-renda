import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Taxpayer } from 'src/app/models/taxpayer';
import { TaxpayersService } from 'src/app/services/taxpayers.service';

@Component({
  selector: 'app-taxpayers-list',
  templateUrl: './taxpayers-list.component.html',
  styleUrls: ['./taxpayers-list.component.css']
})
export class TaxpayersListComponent implements OnInit {
  taxpayers$: Observable<Taxpayer>;

  constructor(private taxpayersService: TaxpayersService) { }

  ngOnInit() {
    this.taxpayers$ = this.taxpayersService.getTaxpayers();
  }

}
