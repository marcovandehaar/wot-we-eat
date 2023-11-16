export class HealtyOption{
    id: number;
    value: string;
    title: string;

    constructor(i: number, v: string, t: string)
    {
        this.id = i;
        this.value  =v;
        this.title = t;
    }
}


export const healtyOptions: HealtyOption[] = [
    new HealtyOption(0,'Unhealthy','Ongezond!'),
    new HealtyOption(1,'Average','Gemiddled'),
    new HealtyOption(2,'Healthy','Gezond!'),   
]