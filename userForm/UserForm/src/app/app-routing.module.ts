import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './UserLogin/login/login.component';
import { SignupComponent } from './UserLogin/signup/signup.component';

const routes: Routes = [
    { path:'login', component: LoginComponent},
    { path:'signup', component: SignupComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const routingComponents =[LoginComponent, SignupComponent];