import { InMemoryDbService } from 'angular-in-memory-web-api';
import { MealOption, MeatFish, Vegetable } from '../models/meal-option.model';

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
        meatFishes: [{
          id: 'trg',
          name: 'Braadworst',
          meatFishType: 'Meat',       
        }],
       seasons: ['Winter','Spring','Summer','Autumn'],
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
        meatFishes: [{
          id: 'rth',
          name: 'SPeklap',
          meatFishType: 'Meat',       
        }],
        seasons: ['Winter','Spring','Summer','Autumn'],
       
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
        meatFishes: [{
          id: 'bgf',
          name: 'Zalmfilet',
          meatFishType: 'Fish',       
        }],
        seasons: ['Spring','Summer'],
       
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
    ];
    let meatFishes: MeatFish[] = [
      {
        id: 'trg',
        name: 'Braadworst',
        meatFishType: 'Meat',       
      },
      {
        id: 'rth',
        name: 'Slavink',
        meatFishType: 'Meat',       
      },
      {
        id: 'tjjjg',
        name: 'Kip Cordon Bleu',
        meatFishType: 'Meat',       
      },
      {
        id: 'bbb',
        name: 'Speklap',
        meatFishType: 'Meat',       
      },
      {
        id: 'bgf',
        name: 'Zalmfilet',
        meatFishType: 'Fish',       
      },
      
      {
        id: 'ere',
        name: 'Pangafilet',
        meatFishType: 'Fish',       
      },
      {
        id: 'www',
        name: 'Fish sticks',
        meatFishType: 'Fish',       
      },
      
      {
        id: 'uuu',
        name: 'Fish cuisine - mediteraan',
        meatFishType: 'Fish',       
      }
    ];
    

    return { 'meal-option': mealOptions, 'vegetable': vegetables, 'meat-fish':meatFishes }; // The key here should match the endpoint
  }
}