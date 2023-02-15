import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from 'src/model/contact';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ContactService {
  public contacts?: Contact[];
  public _http: HttpClient;

  constructor(private http: HttpClient) {
    this._http = http;
   }

  GetAllContacts(){  

    this._http.get<Contact[]>('/contacts').subscribe(result => {
      this.contacts = result;
    }, error => console.error(error));
    return this.contacts; 
  }  

  GetTest(){  
    
    return 'test'; 
  }  

  SaveContact(item: Contact){

    if (this._http != null) {
      var contact;
      const body = JSON.stringify(item);
      const headers = { 'content-type': 'application/json' }
      return this.http.post('/contact', body, { 'headers': headers });

    }
    return null;
  }
}
