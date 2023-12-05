import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { MealOptionFormComponent } from './meal-option-form/meal-option-form.component';
import { MealOptionOverviewComponent } from './meal-option-overview/meal-option-overview.component';


const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainScreenComponent },
  { path: 'meal-option/edit', component: MealOptionFormComponent },
  { path: 'meal-option-overview', component: MealOptionOverviewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
