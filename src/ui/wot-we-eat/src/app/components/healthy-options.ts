export class HealthyOption{
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


export const healtyOptions: HealthyOption[] = [
    new HealthyOption(0,'Unhealthy','Ongezond!'),
    new HealthyOption(1,'Average','Gemiddled'),
    new HealthyOption(2,'Healthy','Gezond!'),   
]