import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlanetListComponent } from './components/planets/planet-list/planet-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component: PlanetListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
