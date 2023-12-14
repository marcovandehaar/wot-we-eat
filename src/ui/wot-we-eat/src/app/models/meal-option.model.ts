export interface MealOption {    
        id: string ,
        description: string ,
        mealBase: string,  
        amountOfWork: number,  
        healthy:string,
        suitableForChildren:boolean,
        vegetables: Vegetable[] | null,
        meatFishes: MeatFish[] |null,
        seasons: string[] |null,
        active: boolean
  }

export interface Vegetable {
      id: string ,
      name: string ,
}

export interface MeatFish {
      id: string ,
      name: string ,
      type: string,
}

export interface GroupedMeatFish {
      label: string;
      value: string;
      image: string;
      items: MeatFish[];
    }
  