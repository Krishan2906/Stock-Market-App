import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LogIn } from 'src/app/services/login.module';

import { LoginService } from '../../services/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login=new LogIn();
  correct:boolean=true;

  constructor(private loginService:LoginService) {
   }


   onFormSubmit(form:NgForm){
    //  console.log(this.loginService.login(this.login));
    this.loginService.login(this.login).subscribe(
      res => {
        this.correct=true;
        this.resetForm(form);
      },
      err => {
        this.correct=false;
        console.log(err);
      }
    );
   }

   resetForm(form:NgForm)
  {
    form.form.reset();
    this.login=new LogIn();
  }

  ngOnInit(): void {
  }

}
