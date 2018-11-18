import { BasicWage } from './../../models/basic-wage';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { BasicWageService } from 'src/app/services/basic-wage.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-basic-wage-badge',
  templateUrl: './basic-wage-badge.component.html',
  styleUrls: ['./basic-wage-badge.component.css']
})
export class BasicWageBadgeComponent implements OnInit, OnDestroy {
  
  basicWageSubscription: Subscription;
  basicWage: BasicWage = { value: 0 };

  constructor(private baiscWageService: BasicWageService) { }

  ngOnInit() {
    this.basicWageSubscription = this.baiscWageService.getBasicWageData().subscribe(res => this.basicWage = res);
  }

  ngOnDestroy() {
    this.basicWageSubscription.unsubscribe();
  }

}
