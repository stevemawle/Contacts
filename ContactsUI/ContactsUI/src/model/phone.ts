import { PhoneType } from "src/enum/phonetype";

export class Phone {
    id!: string;
    type!: PhoneType;
    prefix!: string;
    number!: string;
}
