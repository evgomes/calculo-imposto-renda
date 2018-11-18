import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, Subscription } from 'rxjs';
import { Taxpayer } from 'src/app/models/taxpayer';

import { CpfFormatter } from './../../models/cpf-formatter';
import { SaveTaxpayer } from './../../models/save-taxpayer';
import { TaxpayersService } from './../../services/taxpayers.service';

@Component({
  selector: 'app-taxpayer-form',
  templateUrl: './taxpayer-form.component.html',
  styleUrls: ['./taxpayer-form.component.css']
})
export class TaxpayerFormComponent implements OnInit, OnDestroy {
  taxpayer: SaveTaxpayer = new SaveTaxpayer();
  taxpayerId: number = 0;
  taxpayerSubscription: Subscription = null;
  action: string = 'save-then-redirect';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private taxpayerService: TaxpayersService,
    private toastrService: ToastrService) {
    route.params.subscribe(p => {
      this.taxpayerId = +p['id'];
    });
  }

  ngOnInit() {
    if (this.taxpayerId > 0) {
      this.taxpayerSubscription = this.taxpayerService.getTaxpayer(this.taxpayerId)
        .subscribe(tax => {
          this.taxpayer.name = tax.name;
          this.taxpayer.cpf = CpfFormatter.formatCpf(tax.cpf);
          this.taxpayer.numberOfDependents = tax.numberOfDependents;
          this.taxpayer.monthlyGrossIncome = tax.monthlyGrossIncome;
        }, error => {
          if (error.status == 404) {
            this.toastrService.info('Contribuinte não encontrado.');
            this.router.navigate(['/']);
          }
        });
    }
  }

  ngOnDestroy() {
    if (this.taxpayerSubscription) {
      this.taxpayerSubscription.unsubscribe();
    }
  }

  submit(form: NgForm) {
    this.save().subscribe(result => {
      this.toastrService.success('Dados do contribuinte gravados com sucesso!');

      switch (this.action) {
        case 'save-after-edit':
          this.router.navigate(['/contribuintes/listar']);
          break;
        case 'save-then-redirect':
          this.router.navigate(['/salariominimo/editar']);
          break;
        case 'save-then-new':
          this.taxpayer.name = '';
          this.taxpayer.cpf = '';
          this.taxpayer.monthlyGrossIncome = 0;
          this.taxpayer.numberOfDependents = 0;
          this.taxpayerId = 0;
          form.reset();
          this.router.navigate(['/contribuintes/novo']);
          break;
      }
    }, error => {
      this.toastrService.error('Não foi possível gravar o contribuinte: ' + error);
    })
  }

  delete() {
    if (!confirm(`Tem certeza que deseja excluir o contribuinte "${this.taxpayer.name}"?`)) {
      return;
    }

    this.taxpayerService.delete(this.taxpayerId).subscribe(taxpayer => {
      this.toastrService.success('Contribuinte excluído com sucesso!');
      this.router.navigate(['/contribuintes/listar']);
    }, error => {
      this.toastrService.success('Não foi possível excluir o contribuinte: ' + error);
    })
  }

  private save(): Observable<Taxpayer> {
    if (this.taxpayerId) {
      return this.taxpayerService.update(this.taxpayerId, this.taxpayer);
    } else {
      return this.taxpayerService.create(this.taxpayer);
    }
  }
}
