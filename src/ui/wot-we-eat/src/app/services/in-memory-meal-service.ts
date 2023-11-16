import { InMemoryDbService } from 'angular-in-memory-web-api';
import { MealOption } from '../models/meal-option.model';

export class InMemoryMealApi implements InMemoryDbService {
  createDb() {
    let mealOptions: MealOption[] = [
      {
        id: '5CehW',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
       
      },
      {
        id: '5CehW',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Healthy',
       
      },
      {
        id: '5CehW',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Sverage',
       
      },
    ]

    return { 'meal-option': mealOptions }; // The key here should match the endpoint
  }
}