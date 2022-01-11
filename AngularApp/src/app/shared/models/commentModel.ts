
export class CommentModel{
    public id: number;
    public name: string;

    constructor(init: Partial<CommentModel>) {
        Object.assign(this, init);
    }
}