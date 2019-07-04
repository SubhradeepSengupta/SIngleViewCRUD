import { Component, OnInit } from '@angular/core';
import { PersonServiceService } from 'src/app/shared/person-service.service';
import { PersonModel } from 'src/app/shared/person-model.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styles: []
})
export class PersonListComponent implements OnInit {

  Name : String;
  constructor(private service : PersonServiceService) { }

  ngOnInit() {
    // getting all the details from the database through get request
    this.service.getDetails();
  }

  selectPerson(person : PersonModel) {
    // assinging an empty object as we have the target on the left
    // used to copy the data so two way binding won't change the list data while editing
    this.service.FormData = Object.assign({}, person);
  }

  deleteUser(person : PersonModel) {
    if(confirm("Are you sure?")) {
      this.service.deleteDetails(person.personId).subscribe(
        res => {
          this.service.getDetails();
        },
        err => {
          console.log(err);
        }
      )
    }
    }  
}
