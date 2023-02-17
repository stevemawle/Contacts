import { Address } from "./address";


export class Contact {
    id!: string;
    firstName!: string;
    lastName!: string;
    address!: Address;
    phone!: Array<Phone>;
}
