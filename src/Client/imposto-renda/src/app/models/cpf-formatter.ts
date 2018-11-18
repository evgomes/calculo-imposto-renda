export class CpfFormatter {
    static formatCpf(cpf) {
        const cpfStr = cpf.toString();

        if (cpfStr.length !== 11) {
            return '';
        }

        return cpfStr.substr(0, 3) + '.' + cpfStr.substr(3, 3) + '.' + cpfStr.substr(6, 3) + '-' + cpfStr.substr(9, 2);
    }
}
