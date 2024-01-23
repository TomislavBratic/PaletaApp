import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { FamilyfarmComponent } from './components/familyfarm/familyfarm.component';
import { AboutComponent } from './components/about/about.component';

export const routes: Routes = [
    { path: 'home', component: AppComponent },
    { path: 'familyfarms', component: FamilyfarmComponent },
    { path: 'about', component: AboutComponent },
];
