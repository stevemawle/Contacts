import { Address } from "./address";
import { Phone } from "./phone";

export class Contact {
    id!: string;
    firstName!: string;
    lastName!: string;
    address!: Address;
    phone!: Phone[];
}
