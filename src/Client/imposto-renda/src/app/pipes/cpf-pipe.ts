import { CpfFormatter } from './../models/cpf-formatter';
import {Pipe, PipeTransform} from "@angular/core";

@Pipe({name: 'cpf'})
export class CpfPipe implements PipeTransform {
    transform(value: any, ...args: any[]) {
        return CpfFormatter.formatCpf(value);
    }
}