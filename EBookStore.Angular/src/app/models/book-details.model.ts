import { Book } from '.';

export interface BookDetails extends Book{
    description: string;
    WrittenIn: string;
}