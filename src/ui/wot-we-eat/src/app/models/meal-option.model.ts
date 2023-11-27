export interface MealOption {    
        id: string ,
        description: string ,
        mealBase: string,  
        amountOfWork: string,  
        healthy:string,
        suitableForChildren:boolean,
        vegetables: Vegetable[] | null,
        meatFishes: MeatFish[] |null,
        seasons: string[] |null
  }

export interface Vegetable {
      id: string ,
      name: string ,
}

export interface MeatFish {
      id: string ,
      name: string ,
      meatFishType: string,
}

export interface GroupedMeatFish {
      label: string;
      value: string;
      image: string;
      items: MeatFish[];
    }
  