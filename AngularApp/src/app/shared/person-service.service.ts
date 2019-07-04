import { Injectable } from '@angular/core';
import { PersonModel } from './person-model.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PersonServiceService {
  FormData : PersonModel
  URL = 'https://localhost:44394/api/';
  list : PersonModel[];

  constructor(private http : HttpClient) { }

  postDetails() {
    // returning the observable so it can be accessed from other component
    return this.http.post(this.URL + 'HomeModels',this.FormData);
  }

  getDetails() {
    // converting observable to promise and returning the list of data as Model array
    this.http.get(this.URL + 'HomeModels').toPromise()
    .then(res => this.list = res as PersonModel[]);
  }

  updateDetails() {
    return this.http.put(this.URL + 'HomeModels/' + this.FormData.personId, this.FormData)
  }

  deleteDetails(id) {
    return this.http.delete(this.URL + 'HomeModels/' + id);
  }
}
