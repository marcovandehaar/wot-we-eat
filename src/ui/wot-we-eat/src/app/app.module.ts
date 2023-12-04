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
import { SeasonSelectorComponent } from './components/season-selector/season-selector.component';
import { environment } from 'src/environments/environment';


@NgModule({
  declarations: [
    AppComponent, 
    MainScreenComponent,
    MealOptionFormComponent,
    HealthySelectorComponent,
    ChildrenToggleComponent,
    SeasonSelectorComponent,    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    environment.useInMemoryApi ? HttpClientInMemoryWebApiModule.forRoot(InMemoryMealApi, { delay: 200 }) : [],
    MultiSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
 
}
