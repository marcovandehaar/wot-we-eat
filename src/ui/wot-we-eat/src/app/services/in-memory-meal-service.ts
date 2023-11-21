import { InMemoryDbService } from 'angular-in-memory-web-api';
import { MealOption, Vegetable } from '../models/meal-option.model';

export class InMemoryMealApi implements InMemoryDbService {
  createDb() {
    let mealOptions: MealOption[] = [
      {
        id: '5CehW',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
       
      },
      {
        id: 'sfdg',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Healthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
       
      },
      {
        id: '5CejtyhW',
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Sverage',
        suitableForChildren:true,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        },{
          id: 'gujmy',
          name: 'Snijbonen',       
        }],
       
      },
    ];
    let vegetables: Vegetable[] = [
      {
        id: 'jmfgu',
        name: 'Witte bonen',       
      },
      {
        id: 'gujmy',
        name: 'Snijbonen',       
      },
      {
        id: 'ased',
        name: 'Brocoli',       
      }
    ]

    return { 'meal-option': mealOptions, 'vegetables': vegetables }; // The key here should match the endpoint
  }
}