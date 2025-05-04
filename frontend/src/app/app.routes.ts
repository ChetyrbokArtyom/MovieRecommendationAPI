import { Routes } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
export const routes: Routes = [
    { 
      path: '',
      component: HomeComponent
    },
    { 
      path: 'register', 
      component: RegistrationComponent 
    },
    {
      path: 'login',
      component: LoginComponent
    }

  ]