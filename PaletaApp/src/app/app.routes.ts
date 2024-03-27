import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BlogComponent } from './components/blog/blog.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { authGuard } from './guards/auth.guard';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';


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
    { path: 'testerrors', component: TestErrorComponent },
    { path: 'not-found', component: NotFoundComponent },
    { path: 'server-error', component: ServerErrorComponent },
    {path:'**', component:NotFoundComponent, pathMatch:'full'}
];
