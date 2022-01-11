import { ModelObject } from "./modelObject";

export class BrandModel{
    public id: number;
    public name: string;
    public code: string;
    public models: ModelObject[] = [];

    constructor(init: Partial<BrandModel>) {
        Object.assign(this, init);
    }
}