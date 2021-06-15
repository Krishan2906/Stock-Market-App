import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { LoginService } from '../../services/login.service'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(public loginservices:LoginService) {
  }

  onSubmit(form:NgForm){
    this.loginservices.userSignUp().subscribe(
      res=>{
        this.resetForm(form);
        alert("hello success");
      },
      err=>{console.log(err)}
    )  
  }

  resetForm(form:NgForm){
    form.form.reset();
  }

  ngOnInit(): void {
  }

}
