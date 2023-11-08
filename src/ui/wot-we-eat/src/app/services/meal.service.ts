import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MealOption } from '../models/meal-option.model';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  //private apiUrl = 'https://localhost:7171';
  private apiUrl = 'api';

  constructor(private http: HttpClient) { }


  saveMealOption(mealOption: MealOption): Observable<any> {
    return this.http.post(`${this.apiUrl}/meal-option`, mealOption);
  }

  getMealOption(id: string): Observable<MealOption | undefined> {
    return this.http.get<MealOption>(`api/meal-option/${id}`);
  }

  getAllContacts(): Observable<MealOption[]> {
    return this.http.get<MealOption[]>('api/meal-option/all');
  }
}


