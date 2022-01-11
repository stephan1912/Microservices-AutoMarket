
export class CountryModel{
    public id: number;
    public name: string;

    constructor(init: Partial<CountryModel>) {
        Object.assign(this, init);
    }
}