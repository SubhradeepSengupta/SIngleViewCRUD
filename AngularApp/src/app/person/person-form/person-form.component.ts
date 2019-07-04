import { Component, OnInit } from '@angular/core';
import { PersonServiceService } from 'src/app/shared/person-service.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styles: []
})
export class PersonFormComponent implements OnInit {

  constructor(private service : PersonServiceService) { }

  ngOnInit() {
    // form resets on page load
    this.resetForm();
  }

  resetForm(form? : NgForm) {
    if(!form == null)
      form.resetForm();
    this.service.FormData = {
      personId : 0,
      personName : '',
      personDesignation : '',
      personAge : null
    }
  }

  onSubmit(form : NgForm) {
    if(this.service.FormData.personId == 0) {
      // catching hte observable from the post and the put function through subscribe
    this.service.postDetails().subscribe(
      // success and error function
      res => {
        this.resetForm(form);
        this.service.getDetails();
      },
      err => {
        console.log(err);
      }
    )
  } else {
    this.service.updateDetails().subscribe(
      res => {
        this.resetForm(form);
        this.service.getDetails();
      },
      err => {
        console.log(err);
      }
    )
  }
}

}
