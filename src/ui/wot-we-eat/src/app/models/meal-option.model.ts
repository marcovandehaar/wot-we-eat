export interface MealOption {    
        mealOptionId: string ,
        description: string ,
        mealBase: string,  
        amountOfWork: number,  
        healthy:string,
        suitableForChildren:boolean,
        vegetables: Vegetable[] | null,
        possibleMeatFishes: MeatFish[] |null,
        inSeasons: string[] |null,
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
  