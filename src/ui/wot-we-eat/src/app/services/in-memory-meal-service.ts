import { InMemoryDbService, RequestInfo, ResponseOptions, STATUS } from 'angular-in-memory-web-api';
import { MealOption, MeatFish, Vegetable } from '../models/meal-option.model';
import { of } from 'rxjs';

export class InMemoryMealApi implements InMemoryDbService {
  createDb() {
    let mealOptions: MealOption[] = [
      {
        id: '1406ace7-58f7-4d31-af0d-3b95ff69b8bf',
        active:true,
        description: 'Testmaaltijd 1',
        mealBase:'Potato',
        amountOfWork: 3,
        healthy:'Average',
        suitableForChildren:false,
        vegetables: [
          {
            "id": "1406ace7-58f7-4d31-af0d-3b95ff69b8bf",
            "name": "Sla"
          }
        ],
        possibleMeatFishes:[
          {
            "id": "cb66e275-68fd-4b19-9f75-23a8789dcc19",
            "name": "Rundervink",
            "type": "Meat"
          }
        ],
        inSeasons: [
          "Spring",
          "Summer"
        ],
        possibleVariations: [],
      },
      {
        id: '5CehW',
        active:true,
        description: 'Gekookte aardappelen, witte bonen met worst',
        mealBase:'Potato',
        amountOfWork: 3,
        healthy:'Unhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        possibleMeatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
        inSeasons: ['Winter','Spring','Summer','Autumn'],
        possibleVariations: [],
      },
      {
        id: 'sfdg',
        active:true,
        description: 'Snijbonen, aardappelbolletjes en rundervink',
        mealBase:'Potato',
        amountOfWork: 3,
        healthy:'Healthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'gujmy',
          name: 'Snijbonen',       
        }],
        possibleMeatFishes: [{
          id: 'gtgt',
          name: 'Rundervink',
          type: 'Meat',       
        }],
        inSeasons: ['Winter','Spring','Summer','Autumn'],
        possibleVariations: [],
       
      },
      {
        id: '5CejtyhW',
        active:true,
        description: 'Snijbonen, witte bonen, aardappeltjes en kabeljouwburger',
        mealBase:'Potato',
        amountOfWork: 5,
        healthy:'Healthy',
        suitableForChildren:true,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        },{
          id: 'gujmy',
          name: 'Snijbonen',       
        }],
        possibleMeatFishes: [{
          id: 'hdhd',
          name: 'Kabeljouwburger',
          type: 'Fish',       
        }],
        inSeasons: ['Spring','Summer'],
        possibleVariations: [],
       
      },
      {
        id: '5CehWfg',
        active:true,
        description: 'Rijst, broccoli, fish cuisine mediteraan en fish sticks',
        mealBase:'Rice',
        amountOfWork: 3,
        healthy:'Healthy',
        suitableForChildren:true,
        vegetables: [{
          id: 'ased',
          name: 'Broccoli',       
        }],
        possibleMeatFishes: [{
          id: 'uuu',
          name: 'Fish cuisine - mediteraan',
          type: 'Fish',       
        },
        {
          id: 'www',
          name: 'Fish sticks',
          type: 'Fish',       
        }
      ],
      inSeasons: ['Winter','Spring','Summer','Autumn'],
      possibleVariations: [],
      },
      {
        id: '5CehWsder',
        active:true,
        description: '4Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 3,
        healthy:'Unhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        possibleMeatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
        inSeasons: ['Winter','Spring','Summer','Autumn'],
        possibleVariations: [],
      },
      {
        id: '5CehsrtehW',
        active:true,
        description: '5Dit is een fijne maaltijd',
        mealBase:'Potato',
        amountOfWork: 3,
        healthy:'Unhealthy',
        suitableForChildren:false,
        vegetables: [{
          id: 'jmfgu',
          name: 'Witte bonen',       
        }],
        possibleMeatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          type: 'Meat',       
        }],
        inSeasons: ['Winter','Spring','Summer','Autumn'],
        possibleVariations: [],
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
        id: 'gtgt',
        name: 'Rundervink',
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
      },
      {
        id: 'hdhd',
        name: 'Kabeljouwburger',
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

  get(reqInfo: RequestInfo) {
    if (reqInfo.collectionName === 'meal-option' && reqInfo.id) {
      return this.getMealOptionById(reqInfo);
    }
    return undefined; // Fallback to default behavior
  }
  
  private getMealOptionById(reqInfo: RequestInfo) {
    const collection = reqInfo.collection as MealOption[];
    const mealOption = collection.find(m => m.id === reqInfo.id);
    if (!mealOption) {
      return reqInfo.utils.createResponse$(() => ({
        body: { error: 'Meal Option not found' },
        status: STATUS.NOT_FOUND
      }));
    }
    return reqInfo.utils.createResponse$(() => ({
      body: mealOption,
      status: STATUS.OK
    }));
  }
}