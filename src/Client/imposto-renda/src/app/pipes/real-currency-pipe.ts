import {Pipe, PipeTransform} from "@angular/core";
import {CurrencyPipe} from "@angular/common";

@Pipe({name: 'realcurrency'})
export class RealCurrencyPipe extends CurrencyPipe implements PipeTransform {
  transform(value: any, currencyCode: string, symbolDisplay: boolean, digits: string): string {
    const formatoMoeda = super.transform(value, currencyCode, symbolDisplay, digits);
    const primeiroDigito = formatoMoeda.search(/\d/);
    return formatoMoeda.substring(0, primeiroDigito) + ' ' + formatoMoeda.substr(primeiroDigito);
  }
}