import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BlogComponent } from './components/blog/blog.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { RegistrationComponent } from './components/registration/registration.component';


export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'familyfarms', component: BlogComponent },
    { path: 'about', component: AboutComponent },
    {path: 'registration', component:RegistrationComponent}
];
