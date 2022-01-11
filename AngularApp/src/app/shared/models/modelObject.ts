export class ModelObject {
    public id: number;
    public name: string;
    public generation: string;
    public launchYear: string;
    public finalYear: string;
    public brandName: string;

    constructor(init: Partial<ModelObject>) {
        Object.assign(this, init);
    }
}