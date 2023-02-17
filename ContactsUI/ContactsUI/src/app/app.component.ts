import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { PhoneType } from 'src/enum/phonetype';
import { Address } from 'src/model/address';
import { Contact } from 'src/model/contact';
import { Phone } from 'src/model/phone';
import { ContactService } from 'src/services/contact.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],

})

export class AppComponent {
  public contact?: Contact;
  public contacts?: Contact[];
  public _http?: HttpClient;

  ePhoneType = PhoneType;
  
  constructor(http: HttpClient, private contactServ : ContactService) {
    
    this._http = http;

    //TODO Work out why this call to the service doesn't display the data on the page
    //although the rest api is returning data and direct http get works
    //this.contacts = this.contactServ.GetAllContacts();
    
    this._http.get<Contact[]>('/contacts').subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));
    
  }
  title = 'Contacts';

  public save(event: any, item: Contact) {
    
      this.contactServ.SaveContact(item).subscribe({
        error: (err: any) => { console.error(err) }
      });
      window.location.reload();
   
  }

  public delete(event: any, item: string) {
    if (this._http != null) {
      const body = JSON.stringify(item);
      const headers = { 'content-type': 'application/json' }
      this._http.post<Contact>('/contactDelete?id=' + item, { 'headers': headers }).subscribe(result => {
        this.contact = result;
      }, error => alert(error));
      window.location.reload();
    }
  }
  

  public addNew(event: any, item: Contact) {
 
      //TODO  Initialise a new object so we don't have a dependency on an existing contact in the system.
      const clonedContact = JSON.parse(JSON.stringify(item));
     
      clonedContact.id = '0';
      clonedContact.firstName = '';
      clonedContact.lastName = '';
      clonedContact.address.id = '0';
      clonedContact.address.line1 = '';
      clonedContact.address.line2 = '';
      clonedContact.phone.forEach(item => {
        item.id = '0';
        item.number = ''
        item.prefix = ''
      });
      
      this.contactServ.SaveContact(clonedContact).subscribe({
        error: (err: any) => { console.error(err) }
      });
      window.location.reload();
  }

}

