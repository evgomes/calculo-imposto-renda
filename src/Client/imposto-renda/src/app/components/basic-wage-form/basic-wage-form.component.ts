import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { BasicWageService } from 'src/app/services/basic-wage.service';

import { BasicWage } from './../../models/basic-wage';

@Component({
  selector: 'app-basic-wage-form',
  templateUrl: './basic-wage-form.component.html',
  styleUrls: ['./basic-wage-form.component.css']
})
export class BasicWageFormComponent implements OnInit, OnDestroy {

  basicWageSubscription: Subscription;
  basicWage: BasicWage = { value: 0 };

  constructor(
    private router: Router, 
    private basicWageService: BasicWageService, 
    private toastrService: ToastrService) { }

  ngOnInit() {
    this.basicWageSubscription = this.basicWageService.getBasicWageData().subscribe(basicWage => {
      this.basicWage = basicWage;
    });
  }

  ngOnDestroy() {
    if (this.basicWageSubscription) {
      this.basicWageSubscription.unsubscribe();
    }
  }

  submit(form: NgForm) {
    this.basicWageService.recordBasicWageData(this.basicWage).subscribe(result => {
      this.toastrService.success('Dados do salário mínimo atualizados com sucesso!');
      this.router.navigate(['/contribuintes/listar']);
    }, error => {
      this.toastrService.error('Não foi possível atualizar os dados do salário mínimo: ' + error);
    });
  }

  cancel() {
    this.router.navigate(['/contribuintes/listar']);
  }
}
