import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: '/registration.component.html',
  styles: ['p {font-family: Lato;} ']
})
export class RegistrationComponent {
  userForm: any;

  constructor(private formBuilder: FormBuilder) {
    this.CreateForm();

  }
  CreateForm() {
    this.userForm = this.formBuilder.group({
      'name': ['', Validators.required],
      'email': ['', [Validators.required]],
      'password': ['', [Validators.required]],
      'confirmPassword': ['', [Validators.required]]

      // console.log(this.userForm);  
    })
 
    //saveUser(): void {
    //  if(this.userForm.dirty && this.userForm.valid) {
    //  // alert(`name' : ${this.userForm.value.name}  'email' : ${this.userForm.value.email}`);              
    //}
  }
}
