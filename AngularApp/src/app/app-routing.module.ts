import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdvertComponent } from './advert/advert.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: "/home",
    pathMatch: 'full'
  },
  {
    path: 'home', 
    component: HomeComponent,
  },
  {
    path: 'advert', 
    component: AdvertComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
