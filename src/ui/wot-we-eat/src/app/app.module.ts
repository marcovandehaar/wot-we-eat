import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { MealOptionFormComponent } from './meal-option-form/meal-option-form.component';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { HttpClientModule } from '@angular/common/http';
import { InMemoryMealApi } from './services/in-memory-meal-service';
import { ReactiveFormsModule } from '@angular/forms';
import { HealthySelectorComponent } from './components/healthy-selector/healthy-selector.component';
import { ChildrenToggleComponent } from './components/children-toggle/children-toggle.component';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { SeasonSelectorComponent } from './components/season-selector/season-selector.component';
import { environment } from 'src/environments/environment';
import { MealOptionOverviewComponent } from './meal-option-overview/meal-option-overview.component';
import { MealFormComponent } from './meal-form/meal-form.component';
import { MealOverviewComponent } from './meal-overview/meal-overview.component';


@NgModule({
  declarations: [
    AppComponent, 
    MainScreenComponent,
    MealOptionFormComponent,
    HealthySelectorComponent,
    ChildrenToggleComponent,
    SeasonSelectorComponent,
    MealOptionOverviewComponent,
    MealFormComponent,
    MealOverviewComponent,    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    environment.useInMemoryApi ? HttpClientInMemoryWebApiModule.forRoot(InMemoryMealApi, { delay: 1000 }) : [],
    MultiSelectModule,
    DropdownModule,
    CalendarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
 
}
