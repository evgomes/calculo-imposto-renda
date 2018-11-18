export interface Taxpayer {
    id: number,
    name: string,
    cpf: number,
    numberOfDependents: number,
    monthlyGrossIncome: number,
    incomeTaxRatePercentage: number,
    totalIncomeTax: number
}