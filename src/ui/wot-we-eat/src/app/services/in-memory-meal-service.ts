import { InMemoryDbService, RequestInfo, ResponseOptions, STATUS } from 'angular-in-memory-web-api';
import { MealOption, MeatFish, Vegetable } from '../models/meal-option.model';
import { of } from 'rxjs';

export class InMemoryMealApi implements InMemoryDbService {
  createDb() {
    let mealOptions: MealOption[] = [
      {
        id: '5CehW',
        active:true,
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        meatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
       seasons: ['Winter','Spring','Summer','Autumn'],
      },
      {
        id: 'sfdg',
        active:true,
        description: 'Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Healthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        meatFishes: [{
          id: 'rth',
          name: 'SPeklap',
          type: 'Meat',       
        }],
        seasons: ['Winter','Spring','Summer','Autumn'],
       
      },
      {
        id: '5CejtyhW',
        active:true,
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
        meatFishes: [{
          id: 'bgf',
          name: 'Zalmfilet',
          type: 'Fish',       
        }],
        seasons: ['Spring','Summer'],
       
      },
      {
        id: '5CehWfg',
        active:true,
        description: '3Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        meatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
       seasons: ['Winter','Spring','Summer','Autumn'],
      },
      {
        id: '5CehWsder',
        active:true,
        description: '4Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        meatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
       seasons: ['Winter','Spring','Summer','Autumn'],
      },
      {
        id: '5CehsrtehW',
        active:true,
        description: '5Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 'Average',
        healthy:'Uhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        meatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
       seasons: ['Winter','Spring','Summer','Autumn'],
      }
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
    ];
    let meatFishes: MeatFish[] = [
      {
        id: 'trg',
        name: 'Braadworst',
        type: 'Meat',       
      },
      {
        id: 'rth',
        name: 'Slavink',
        type: 'Meat',       
      },
      {
        id: 'tjjjg',
        name: 'Kip Cordon Bleu',
        type: 'Meat',       
      },
      {
        id: 'bbb',
        name: 'Speklap',
        type: 'Meat',       
      },
      {
        id: 'bgf',
        name: 'Zalmfilet',
        type: 'Fish',       
      },
      
      {
        id: 'ere',
        name: 'Pangafilet',
        type: 'Fish',       
      },
      {
        id: 'www',
        name: 'Fish sticks',
        type: 'Fish',       
      },
      
      {
        id: 'uuu',
        name: 'Fish cuisine - mediteraan',
        type: 'Fish',       
      }
    ];
    

    return { 'meal-option': mealOptions, 'vegetable': vegetables, 'meat-fish':meatFishes }; // The key here should match the endpoint
  }

  put(reqInfo: RequestInfo) {
    // You can add your logic here to handle the PUT request
    // For example, update the meal option if it exists
     const collectionName = reqInfo.collectionName;
    if (collectionName === 'meal-option') {
      return this.updateMealOption(reqInfo);
    }
    // Default behavior for other collections
    return undefined; // let the default PUT handler work
  }

  private updateMealOption(reqInfo: RequestInfo) {
    const collection = reqInfo.collection as MealOption[];
    const id = reqInfo.id;
    const updatedMealOptionData = reqInfo.utils.getJsonBody(reqInfo.req);
    // Find the meal option by ID
    const mealOptionIndex = collection.findIndex(m => m.id === id);
    if (mealOptionIndex === -1) {
      return {
        body: { error: 'Meal Option not found' },
        status: STATUS.NOT_FOUND
      };
    }

    const mealOptionToUpdate = collection[mealOptionIndex];
    mealOptionToUpdate.active = updatedMealOptionData.active;
    
    return of({
      body: mealOptionToUpdate,
      status: STATUS.OK
    });
  }
}