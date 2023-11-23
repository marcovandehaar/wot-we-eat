import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,map } from 'rxjs';
import { GroupedMeatFish, MealOption, MeatFish, Vegetable } from '../models/meal-option.model';

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
    return this.http.get<MealOption>(`${this.apiUrl}/meal-option/${id}`);
  }

  getAllMealOptions(): Observable<MealOption[]> {
    return this.http.get<MealOption[]>(`${this.apiUrl}/meal-option`);
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

  private groupMeatFishesByType(meatFishes: MeatFish[]): GroupedMeatFish[] {
    const grouped = meatFishes.reduce((acc, meatFish) => {
      if (!acc[meatFish.meatFishType]) {
        acc[meatFish.meatFishType] = [];
      }
      acc[meatFish.meatFishType].push(meatFish);
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


