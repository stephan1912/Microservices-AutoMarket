
export class BodyStyleModel{
    public id: number;
    public name: string;
    public description: string;

    constructor(init: Partial<BodyStyleModel>) {
        Object.assign(this, init);
    }
}
