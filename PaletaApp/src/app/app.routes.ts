import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BlogComponent } from './components/blog/blog.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { authGuard } from './guards/auth.guard';


export const routes: Routes = [
    {path:'',
        runGuardsAndResolvers:'always',
        canActivate:[authGuard],
        children:[ 
            { path: 'home', component: HomeComponent },
            { path: 'familyfarms', component: BlogComponent },
            { path: 'about', component: AboutComponent },
        ]
        },
    {path: 'registration', component:RegistrationComponent},
    {path:'**', component:HomeComponent, pathMatch:'full'}
];
