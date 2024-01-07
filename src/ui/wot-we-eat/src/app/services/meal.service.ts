import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,map } from 'rxjs';
import { GroupedMeatFish, MealOption, MeatFish, Vegetable } from '../models/meal-option.model';
import { environment } from 'src/environments/environment';
import { Meal } from '../models/meal';

@Injectable({
  providedIn: 'root'
})
export class MealService {

  private apiUrl =  environment.apiUrl;
  //private apiUrl = 'api';

  constructor(private http: HttpClient) { }


  saveMealOption(mealOption: MealOption): Observable<any> {
    return this.http.post(`${this.apiUrl}/meal-option`, mealOption);
  }

  getMealOption(id: string): Observable<MealOption | undefined> {
    return this.http.get<MealOption>(`${this.apiUrl}/meal-option/${id}`);
  }

  getAllMealOptions(active?: boolean): Observable<MealOption[]> {
    let params = new HttpParams();
    if (active !== undefined) {
      // Assuming your API expects the active parameter as a query string
      params = params.set('active', active.toString());
    }
    return this.http.get<MealOption[]>(`${this.apiUrl}/meal-option`, { params });
  }
  

  getAllVegetables(): Observable<Vegetable[]> {
    return this.http.get<Vegetable[]>(`${this.apiUrl}/vegetable`);
  }

  getAllMeatFishes(): Observable<MeatFish[]> {
    return this.http.get<MeatFish[]>(`${this.apiUrl}/meat-fish`);
  }

  getGroupedMeatFishes(): Observable<GroupedMeatFish[]> {
    return this.getAllMeatFishes().pipe(
      map(meatFishes => this.groupMeatFishesByType(meatFishes))
    );
  }

  updateMealOptionActiveStatus(mealOptionId: string, active: boolean): Observable<any> {
    return this.http.put(`${this.apiUrl}/meal-option/${mealOptionId}`, { isActive: active });
  }

  saveMeal(meal: Meal): Observable<Meal> {
    return this.http.post<Meal>(`${this.apiUrl}/meals`, meal);
  }
  

  groupMeatFishesByType(meatFishes: MeatFish[]): GroupedMeatFish[] {
    const grouped = meatFishes.reduce((acc, meatFish) => {
      if (!acc[meatFish.type]) {
        acc[meatFish.type] = [];
      }
      acc[meatFish.type].push(meatFish);
      return acc;
    }, {} as Record<string, MeatFish[]>);
  
    return Object.keys(grouped).map(key => ({
      label: key === 'Meat' ? 'Vlees' : 'Vis',
      value: key,
      items: grouped[key],
      image: key === 'Meat' ? 'meat.png' : 'fish.png' // Assign the image based on the meatFishType
    }));
  }
  
}


